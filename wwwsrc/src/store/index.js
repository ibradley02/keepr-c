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
        activeKeep: {},
        activeVault: {},
        vaultKeeps: {},
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
            if (vaults.id) {
                state.vaults.push(vaults)
            } else {
                state.vaults = vaults
            }
        },
        setActiveKeep(state, payload) {
            state.activeKeep = payload
        },
        setVaultKeeps(state, payload) {
            state.vaultKeeps = payload
        },
        setActiveVault(state, payload) {
            vue.set(state, "activeVault", payload)
        }
    },
    actions: {
        //USER AUTH
        login({ commit, dispatch }, payload) {
            auth.post('accounts/login', payload)
                .then(res => {
                    commit('setUser', res.data)
                    dispatch('getKeeps')
                })
                .catch(err => {
                    commit('handleError', err.message)
                })
        },
        register({ commit, dispatch }, payload) {
            auth.post('accounts/register', payload)
                .then(res => {
                    commit('setUser', res.data)
                })
        },
        authenticate({ commit, dispatch }) {
            auth('accounts/authenticate')
                .then(res => {
                    commit('setUser', res.data)
                    dispatch('getVaultsById', res.data.id)
                    router.push({ name: "Dashboard" })
                })
                .catch(err => {
                    router.push({ name: "Home" })
                })
        },
        logout({ commit, dispatch }) {
            auth.delete('accounts/logout')
                .then(res => {
                    commit('setUser', {})
                    router.push({ name: "Home" })
                })
        },
        //VAULTS
        createVault({ commit, dispatch }, payload) {
            api.post('vaults', payload)
                .then(res => {
                    dispatch('getVaultsById', payload.userId)
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
            api.delete('vaults/' + payload.id)
                .then(res => {
                    dispatch('getVaultsById', payload.userId)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getVaults({ commit, dispatch }) {
            api('vaults/')
                .then(res => {
                    commit('setVaults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getVaultsById({ commit, dispatch }, payload) {
            api('vaults/users/' + payload)
                .then(res => {
                    commit('setVaults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getActiveVault({ commit, dispatch }, id) {
            api('vaults/' + id)
                .then(res => {
                    console.log(res)
                    commit('setActiveVault', res.data)
                    dispatch('getKeepsByVault', id)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        //KEEPS
        createKeep({ commit, dispatch }, payload) {
            api.post('keeps', payload)
                .then(res => {
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
                    dispatch('getKeeps')
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getKeeps({ commit, dispatch }) {
            api('keeps')
                .then(res => {
                    commit('setKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getActiveKeep({ commit, dispatch }, payload) {
            api('keeps/' + payload)
                .then(res => {
                    commit('setActiveKeep', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        //VaultKeeps
        getKeepsByVault({ commit, dispatch }, id) {
            api('vaultkeeps/vaults/' + id + '/keeps')
                .then(res => {
                    commit('setVaultKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        addKeepToVault({ commit, dispatch }, payload) {
            api.post('/vaultkeeps/vaults/' + payload.VaultId + '/keeps', payload)
                .then(res => {
                    console.log(res)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        incrementKeepCount({ commit, dispatch }, payload) {
            api.put('/keeps/' + payload.id, payload)
                .then(res => {
                    console.log(res)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        }
    }
})


export default store