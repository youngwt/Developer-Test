<template>
    <b-container class="shoppingCart">        
        <div class="basketContainer" v-if="!(this.$store.state.shoppingCart && Object.keys(this.$store.state.shoppingCart).length === 0 && Object.getPrototypeOf(this.$store.state.shoppingCart) === Object.prototype)">
            <h4>Basket</h4>
            
            <b-row  v-for="(item, index) in this.$store.state.shoppingCart" :key="index">
                <b-col>
                    {{item.title}}
                </b-col>
                <b-col>
                    {{item.artist}}
                </b-col>
                <b-col>
                    {{item.quantity}}
                </b-col>
                <b-col>
                    @ {{item.price}}
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
