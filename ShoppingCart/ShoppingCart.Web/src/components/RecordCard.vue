<template>
  <b-card
    :title="title"
    :img-src="imageUrl"
    :img-alt="title"
    img-width="200px"
    img-height="200px"
    img-top
    style="max-width: 15rem;"
    class="mb-2">
    <b-card-text>
      {{artist}} <br />
      £{{price}} <br />
    </b-card-text>

    <template #footer>
        <b-button href="#" variant="primary">Add to basket</b-button>
    </template>
    
  </b-card>
</template>

<script>
export default {
  name: 'RecordCard',
  props: {
    title: String,
    imageUrl: String,
    artist: String,
    price: Number
  }
}
</script>