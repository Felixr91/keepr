import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: [],
    activeUsersVaults: [],
    activeVaultKeeps: [],
    ActiveVault: {},
    activeUsersKeeps: [],
    ActiveKeep: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps;
    },
    setUsersVaults(state, activeUsersVaults) {
      state.activeUsersVaults = activeUsersVaults;
    },
    setActiveVaultKeeps(state, ActiveVaultKeep) {
      state.activeVaultKeeps = ActiveVaultKeep
    },
    setActiveKeep(state, ActiveKeep) {
      state.ActiveKeep = ActiveKeep
    },
    setAllActiveUsersKeeps(state, activekeeps) {
      state.activeUsersKeeps = activekeeps;
    },
    setActiveVault(state, activeVault) {
      state.ActiveVault = activeVault
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          // console.log("You're logged in!")
          // debugger
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          router.push({ name: 'home' })
          commit('setUser', {})
        })
    },
    //Get Public Keeps
    getPublicKeeps({ commit, dispatch }) {
      api.get('/keeps/')
        .then(res => {
          commit("setPublicKeeps", res.data)
        })
        .catch(err => console.log('Cannot get public decks'));
    },
    goToMyVaults({ commit, dispatch }) {
      router.push({ name: 'vaults' })
    },
    goHome() {
      router.push({ name: 'home' })
    },
    getUsersVaults({ commit, dispatch }) {
      api.get('/vaults/')
        .then(res => {
          commit("setUsersVaults", res.data)
        })
        .catch(err => console.log('Cannot get your vaults!'));
    },
    //move inside of vault // VaultKeeps view >> set active vault
    goToVaultKeeps({ commit, dispatch }, vaultid) {
      api.get('/vaultkeeps/' + vaultid)
        .then(res => {
          commit("setActiveVaultKeeps", res.data)
        })
      router.push({ name: 'vaultkeeps', params: { vaultid: vaultid } })
    },
    myKeeps({ commit }) {
      api.get('/keeps/user')
        .then(res => {
          commit("setAllActiveUsersKeeps", res.data)
        })
      router.push({ name: 'keeps' })
    },
    addVault({ commit, dispatch }, payload) {
      api.post('/vaults/', payload)
        .then(res => {
          dispatch('getUsersVaults')
        })
    },
    addKeep({ commit, dispatch }, payload) {
      api.post('/keeps/', payload)
        .then(res => {
          dispatch('getUsersKeeps')
        })
    },
    deleteVault({ commit, dispatch }, vaultid) {
      api.delete('/vaults/' + vaultid)
        .then(res => {
          console.log("Vault Deleted!")
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('/keeps/' + keepId)
        .then(res => {
          console.log("Keep Deleted!")
          dispatch('myKeeps')
          // window.location.reload()
        })
    },
    deleteVaultKeep({ commit, dispatch }, vaultkeep) {
      api.put('/vaultkeeps/', vaultkeep)
        .then(res => {
          console.log("vaultkeep deleted!")
          dispatch('goToVaultKeeps', vaultkeep.vaultId)
        })
    },
    getUsersKeeps({ commit, dispatch }) {
      api.get('/keeps/user')
        .then(res => {
          commit("setAllActiveUsersKeeps", res.data)
        })
    },
    loginScreen() {
      router.push({ name: 'login' })
    },
    postVaultKeep({ commit, dispatch }, payload) {
      api.post('/vaultkeeps', payload)
        .then(res => {
          console.log("vaultkeep added!")
          dispatch('goToVaultKeeps', payload.vaultId)
        })
    },
    getSelectedVault({ commit, dispatch }, payload) {
      commit("setActiveVault", payload)
    },
    editKeep({ commit, dispatch }, payload) {
      api.put('/keeps/', payload)
        .then(res => {
          console.log("keep edited")
        })
    }
  }
})