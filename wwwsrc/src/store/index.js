import axios from 'axios'
import vue from 'vue'
import vuex from 'vuex'
import router from 'router'

let base = window.location.host.indexOf('localhost') > -1 ? '//localhost:5000/' : '/'

let api = axios.create({
  baseURL: base + 'api/',
  timeout: 2000,
  withCredentials: true
})

let auth = axios.create({
  baseURL: base,
  timeout: 2000,
  withCredentials: true
})

vue.use(vuex)

var store = new vuex.Store({
  state: {
      error: {},
      user: {}
  },
  mutations: {
      handleError(state, err) {
          state.error = err
      },
      setUser(state, user) {
          state.user = user
      }
  },
  actions: {
      login({ commit, dispatch }, payload){
        auth.post('accounts/login', payload)
            .then(res => {
                console.log(res)
                commit('setUser', res.data)
            })
            .catch( err => {
                commit('handleError', err.message)
            })
      },
      register({ commit, dispatch }, payload){
        auth.post('accounts/register', payload)
            .then(res => {
                console.log(res)
                commit('setUser', res.data)
            })
      },
      authenticate({ commit, dispatch}){
          auth('accounts/authenticate')
            .then(res => {
                commit('setUser', res.data)
            })
            .catch(err => {
                commit('handleError', err)
            })
      },
      logout({ commit, dispatch }){
          auth.delete('accounts/logout')
            .then(res => {
                console.log(res)
                commit('setUser', {})
            })
      }
  }
})


export default store