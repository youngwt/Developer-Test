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
    shoppingCart: {},
  },
  mutations: {

    addToCart(state, {id, item}) {
      debugger;
      item.quantity = ++item.quantity || 1;
      
      state.shoppingCart = {
        ...state.shoppingCart,
        [id] : {...item}
      }
    },

    removeFromCart(state, {id, item})
    {
      const {[id] : removed, ...rest} = state.shoppingCart;
      state.shoppingCart = rest;
    },

    setQuantity(state, {id, item, value})
    {
      debugger;
      item.quantity = value;
      
      state.shoppingCart = {
        ...state.shoppingCart,
        [id] : {...item}
      }
    }
  }
})



new Vue({
  render: h => h(App),
  store: store
}).$mount('#app')




