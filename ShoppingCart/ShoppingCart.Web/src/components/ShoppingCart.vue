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
                        <b-icon-trash @click="remove(item.id, item)"></b-icon-trash>
                    </b-col>
                    <b-col>
                        @ {{item.price}}
                    </b-col>
                </b-row>
            </div>
            <b-row class="align-items-center">
                <b-col>
                    Total: £{{totalBeforeDiscount()}}
                </b-col>
            </b-row>
            <b-row class="align-items-center" v-if="!this.isValidDiscountCode">
                  
                    <b-col>                                      
                        <b-form-input v-model="discountCode" type="text" placeholder="Discount code"></b-form-input>                    
                    </b-col>
                    <b-col>
                        <b-button type="button" @click="onSubmitDiscountCode" variant="primary">Apply</b-button>
                    </b-col>
                               
            </b-row>
            <b-row v-else-if="this.showDiscountError">
                <b-col>
                    Discount Code could not be applied    
                </b-col>
            </b-row>
            <b-row v-else>
                <b-col>
                    After Discount ({{renderDiscount()}} off): £{{totalAfterDiscount()}} 
                </b-col>
            </b-row>
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

    data() {
        return {
            discountMultiplier: 1,
            discountCode: "",
            isValidDiscountCode: false,
            showDiscountError: false,
            error: null 
        }
    },

  methods: {
      remove(id, item)
      {
          this.$store.commit('removeFromCart', {id, item })
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
            return  total.toFixed(2)        
      },

      totalAfterDiscount()
      {
          let totalBeforeDiscount = this.totalBeforeDiscount()

          return (totalBeforeDiscount * this.discountMultiplier).toFixed(2);
      },

      renderDiscount()
      {
          return `${((1-this.discountMultiplier)*100).toFixed(0)}%`
      },

      setQuantity(value, id, item)
      {
          this.$store.commit('setQuantity', { id, item, value})
      },

      onSubmitDiscountCode()
      {
        fetch(`https://localhost:7136/api/cart/discount/${this.discountCode}`).then(async response => {
            const body =  await response.text();
            
            this.discountMultiplier = parseFloat(body);
            
            if(this.discountMultiplier > 0 && this.discountMultiplier < 1)
            {
                this.isValidDiscountCode = true;
                this.showDiscountError = false;
            } else {
                this.isValidDiscountCode = false;
                this.showDiscountError = true;
            }

        }).catch(error => {
            this.error = error
            this.isValidDiscountCode = false;
        });
      }
  }
}
</script>
