<template>
    <b-container class="shoppingCart">        
        <div class="basketContainer" v-if="this.$store.state.shoppingCart.length > 0">
            <h4>Basket</h4>
            <b-row  v-for="cartItem in this.$store.state.shoppingCart" v-bind:key="cartItem.id">
                <b-col>
                    {{cartItem.title}}
                </b-col>
                <b-col>
                    {{cartItem.artist}}
                </b-col>
                <b-col>
                    {{cartItem.quantity}}
                </b-col>
                <b-col>
                    @ {{cartItem.price}}
                </b-col>
            </b-row>
        </div>
        <div class="emptyBasketMessage" v-else>
            Come on buy a record for the road
        </div>
    </b-container>    
</template>

<script>

export default {
    name: "ShoppingCart"
}
</script>
