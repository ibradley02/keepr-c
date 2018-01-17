import axios from 'axios'
import vue from 'vue'
import vuex from 'vuex'
import router from '../router/'

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
        setKeeps(state, keeps) {
            state.keeps = keeps
        },
        setVaults(state, vaults) {
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
                    console.log(err)
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
                    dispatch('getVaultsById', res.data.id)
                })
                .catch(err => {
                    router.push({ name: "Home" })
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
            api.put('vaults/' + payload)
                .then(res => {
                    console.log(res)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        deleteVault({ commit, dispatch }, payload) {
            api.delete('vaults/' + payload)
                .then(res => {
                    console.log(res)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getVaults({ commit, dispatch }) {
            api('vaults/')
                .then(res => {
                    console.log(res)
                    commit('setVaults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getVaultsById({ commit, dispatch }, payload) {
            api('vaults/' + payload)
                .then(res => {
                    // debugger
                    console.log(res)
                    commit('setVaults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        //KEEPS
        createKeep({ commit, dispatch }, payload) {
            api.post('keeps', payload)
                .then(res => {
                    console.log(res)
                    dispatch('getKeeps')
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        updateKeep({ commit, dispatch }) {

        },
        deleteKeep({ commit, dispatch }, payload) {
            api.delete('keeps/' + payload)
                .then(res => {
                    console.log(res)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getKeeps({ commit, dispatch }) {
            api('keeps')
                .then(res => {
                    console.log(res)
                    commit('setKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getKeepsByVault({ commit, dispatch }) {

        }
    }
})


export default store