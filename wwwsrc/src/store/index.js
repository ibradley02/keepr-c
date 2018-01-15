import axios from 'axios'
import vue from 'vue'
import vuex from 'vuex'
import router from 'router'

let base = window.location.host.indexOf('localhost') > -1 ? '//localhost:3000/' : '/'

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
        auth.post('login', payload)
            .then(res => {
                console.log(res)
                commit('setUser', res.data)
            })
            .catch( err => {
                commit('handleError', err.response.data)
            })
      },
      register({ commit, dispatch }, payload){
        auth.post('register', payload)
            .then(res => {
                console.log(res)
                commit('setUser', res.data.data)
            })
      }
  }
})


export default store