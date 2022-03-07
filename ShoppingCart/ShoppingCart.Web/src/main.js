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
    discountMultiplier: 1,
    discountCode: "" 
  },
  mutations: {

    addToCart(state, {id, item}) {
      item.quantity = ++item.quantity || 1;
      
      state.shoppingCart = {
        ...state.shoppingCart,
        [id] : {...item}
      }
    },

    SetDiscount(newDiscount) {
      state.discountMultiplier = newDiscount;
    },

    setQuantity(state, {id, item, value})
    {
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




