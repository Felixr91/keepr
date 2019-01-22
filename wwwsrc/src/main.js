import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

// Vue.config.productionTip = false

new Vue({
  router,
  store,
  mounted() {
    //checks for valid session
    this.$store.dispatch("authenticate");
  },
  render: h => h(App)
}).$mount('#app')
