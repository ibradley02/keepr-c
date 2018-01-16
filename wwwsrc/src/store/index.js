import axios from 'axios'
import vue from 'vue'
import vuex from 'vuex'
import vuerouter from '../router/'

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
vue.use(vuerouter)

var store = new vuex.Store({
    state: {
        error: {},
        user: {},
        vaults: [],
        keeps: []
    },
    mutations: {
        handleError(state, err) {
            state.error = err
        },
        setUser(state, user) {
            state.user = user
        },
        setKeeps(state, keeps){
            state.keeps = keeps
        },
        setVaults(state, vaults){
            state.vaults = vaults
        }
    },
    actions: {
        //USER AUTH
        login({ commit, dispatch }, payload) {
            auth.post('accounts/login', payload)
                .then(res => {
                    console.log(res)
                    commit('setUser', res.data)
                })
                .catch(err => {
                    commit('handleError', err.message)
                })
        },
        register({ commit, dispatch }, payload) {
            auth.post('accounts/register', payload)
                .then(res => {
                    console.log(res)
                    commit('setUser', res.data)
                })
        },
        authenticate({ commit, dispatch }) {
            auth('accounts/authenticate')
                .then(res => {
                    commit('setUser', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        logout({ commit, dispatch }) {
            auth.delete('accounts/logout')
                .then(res => {
                    console.log(res)
                    commit('setUser', {})
                    router.push({ name: "Home" })
                })
        },
        //VAULTS
        createVault({ commit, dispatch }, payload) {
            debugger
            api.post('vaults', payload)
                .then(res => {
                    console.log(res)
                    commit('setVaults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        updateVault({ commit, dispatch }) {

        },
        deleteVault({ commit, dispatch }) {

        },
        getVaults({ commit, dispatch }) {

        },
        getVaultsById({ commit, dispatch }, payload ){
            api('vaults', payload)
                .then(res => {
                    console.log(res)
                    commit('setVaults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        //KEEPS
        createKeep({ commit, dispatch }) {

        },
        updateKeep({ commit, dispatch }) {

        },
        deleteKeep({ commit, dispatch }) {

        },
        getKeeps({ commit, dispatch }) {
            
        },
        getKeepsByVault({ commit, dispatch }) {
            
        }
    }
})


export default store