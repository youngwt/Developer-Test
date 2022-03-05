<template>
    <div class="shoppingCart">
        <h4>Basket</h4>

        <b-table-lite v-if="cartItems.length > 0">
        </b-table-lite>
        <p v-else>
            Put some records in!
        </p>
    </div>    
</template>

<script>

export default {
    name: "ShoppingCart",


    data() {
        return {
            cartItems: []
        }
    }
}
</script>
