import Vue from 'vue'
import Vuex from 'vuex'
import App from './App.vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

// Import Bootstrap an BootstrapVue CSS files (order is important)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

Vue.config.productionTip = false

Vue.use(Vuex)
/* eslint-disable */
const store = new Vuex.Store({
  state: {
    count: 0,
    shoppingCart: [],
    discountMultiplier: 1 
  },
  mutations: {
    increment (state) {
      state.count++
    },

    addToCart(state, payload) {
      debugger;
      state.shoppingCart.push(payload);
    },

    SetDiscount(newDiscount) {
      state.discountMultiplier = newDiscount;
    }
  }
})



new Vue({
  render: h => h(App),
  store: store
}).$mount('#app')




