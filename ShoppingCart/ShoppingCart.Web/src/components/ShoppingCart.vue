<template>
    <b-container class="shoppingCart">        
        <div class="basketContainer" v-if="!(this.$store.state.shoppingCart && Object.keys(this.$store.state.shoppingCart).length === 0)">
            <h4>Basket</h4>
            <div class="border">
                <b-row class="align-items-center"  v-for="(item, index) in this.$store.state.shoppingCart" :key="index">
                    <b-col cols="5" class="mx-auto">
                        {{item.title}}
                    </b-col>
                    <b-col cols="3">
                        {{item.artist}}
                    </b-col>
                    <b-col>
                        <b-input type="number" :value="item.quantity" :min="0" @change="setQuantity($event, item.id, item)"/>
                    </b-col>
                    <b-col >
                        <b-icon-trash @click="remove(index)"></b-icon-trash>
                    </b-col>
                    <b-col>
                        @ {{item.price}}
                    </b-col>
                </b-row>
            </div>
            <div>
                Total: £{{totalBeforeDiscount()}}
            </div>
        </div>
        <div class="emptyBasketMessage" v-else>
            Come on buy a record for the road
        </div>
    </b-container>    
</template>

<script>
import { BIconTrash } from 'bootstrap-vue'

export default {
    name: "ShoppingCart",
      components: {
    BIconTrash,
  },
  methods: {
      remove(index)
      {
          alert(index);
      },

      totalBeforeDiscount()
      {
          let total = 0;

            if(!(this.$store.state.shoppingCart && Object.keys(this.$store.state.shoppingCart).length === 0))
            {
                for (const key in this.$store.state.shoppingCart) {
                    total += this.$store.state.shoppingCart[key].price * this.$store.state.shoppingCart[key].quantity;
                }                
            }  
            return total        
      },

      setQuantity(value, id, item)
      {
          this.$store.commit('setQuantity', { id, item, value})
      }
  }
}
</script>
