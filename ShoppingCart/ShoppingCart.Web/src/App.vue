<template>
  <div id="app">
    <catalogue-container />
  </div>
</template>

<script>

import CatalogueContainer from './components/Catalogue.vue'

export default {
  name: 'App',
  components: {
    CatalogueContainer
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
