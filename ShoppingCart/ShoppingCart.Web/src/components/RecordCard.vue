<template>
  <b-card
    :title="item.title"
    :img-src="item.imageUrl"
    :img-alt="item.title"
    img-width="200px"
    img-height="200px"
    img-top
    style="max-width: 15rem;"
    class="mb-2">
    <b-card-text>
      {{item.artist}} <br />
      £{{item.price}} <br />
    </b-card-text>

    <template #footer>
        <b-button href="#" variant="primary" @click="addToCart(item.id, item)">Add to basket</b-button>
    </template>
    
  </b-card>
</template>

<script>
export default {
  name: 'RecordCard',
  props: {
    item: {    
      title: String,
      imageUrl: String,
      artist: String,
      price: Number
    }
  },

    methods: {
    addToCart(id, item) {
      this.$store.commit('addToCart', { id, item})
    }    
  }
}
</script>