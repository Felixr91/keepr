import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
//@ts-ignore
import Vaultkeeps from './views/VaultKeeps.vue'
//@ts-ignore
import Vaults from './views/Vaults.vue'
//@ts-ignore
import Keeps from './views/Keeps.vue'
//@ts-ignore
import Keep from './views/Keep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/Vaults/:vaultid',
      name: 'vaultkeeps',
      component: Vaultkeeps
    },
    {
      path: '/Vaults',
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/Keeps',
      name: 'keeps',
      component: Keeps
    },
    {
      path: '/Keeps/:keepid',
      name: 'keep',
      component: Keep,
      props: true
    }
  ]
})
