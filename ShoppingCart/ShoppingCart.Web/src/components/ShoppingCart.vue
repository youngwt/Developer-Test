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
                        <b-icon-trash @click="remove(item.id)" style="cursor: pointer"></b-icon-trash>
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
                        <b-form-input v-model="discountCode" @keydown="handleDiscountKeydown($event)" type="text" placeholder="Discount code"></b-form-input>                    
                    </b-col>
                    <b-col>
                        <b-button type="button" @click="onSubmitDiscountCode" variant="primary">Apply</b-button>
                    </b-col>
                               
            </b-row>
            <b-row v-if="this.isValidDiscountCode">
                <b-col>
                    After Discount ({{renderDiscount()}} off): £{{totalAfterDiscount()}} 
                </b-col>
            </b-row>
            <b-row class="mt-2" v-if="this.showDiscountError">
                <b-alert variant="danger" show>
                    Discount Code could not be applied. Please try again
                </b-alert>
            </b-row>
            <b-row class="mt-2">
                <b-col>
                    <b-btn class="btn-success" type="button" @click="order">Buy</b-btn>
                </b-col>
            </b-row>            
        </div>
        <b-jumbotron v-else header="Come on buy a record for the road" lead="use code 'madferit' for 50% off or 'rkid' for (19)95% off!">
        </b-jumbotron>
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
        }
    },

  methods: {
      remove(id)
      {
          this.$store.commit('removeFromCart', {id })
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

      handleDiscountKeydown($event)
      {
          // do a submit if the user presses enter
          if($event.keyCode == 13)
          {
              this.onSubmitDiscountCode();
          }
      },

      onSubmitDiscountCode()
      {
        fetch(process.env.VUE_APP_BASE_URL+`/api/cart/discount/${this.discountCode}`).then(async response => {
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
            this.isValidDiscountCode = false;
            this.showDiscountError = true;
            console.log(error);
        });
      },

      order()
      {
        // the next feature would be to wrap up the order as a JSON with the discount code and post it to an API
        // I would never leave an alert in production code but for the purposes of this test I will here
        alert("ordering has not been implemented yet")
      }
  }
}
</script>
