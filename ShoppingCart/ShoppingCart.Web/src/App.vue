<template>
  <div id="app">
    <site-header />
    <catalogue-container />
  </div>
</template>

<script>

import CatalogueContainer from './components/Catalogue.vue';
import SiteHeader from './components/Header.vue'

export default {
  name: 'App',
  components: {
    CatalogueContainer,
    SiteHeader
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
