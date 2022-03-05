<template>
    <div class="post">
    <div v-if="loading" class="loading">Loading...</div>

    <div v-if="error" class="error">{{ error }}</div>

      <div v-if="post" 
      class="content d-flex align-items-center justify-content-center"
      style="bottom: 0; overflow-y: auto">
          <b-card-group >
            <record-card v-for="record in records[0]"
              v-bind:key="record.id"
              :item="record"  />
          </b-card-group>
      </div>
  </div>
</template>

<script>

import RecordCard from './RecordCard.vue'

export default {
  name: 'CatalogueContainer',
  components: { RecordCard },

   data() {
    return {
      loading: false,
      post: null,
      error: null,
      records: []
    }
  },
   created() {
    this.loading = true;
    // GET request using fetch with async/await
    fetch("https://localhost:7136/api/Records").then(async response => {
        this.loading = false;
        const data =  await response.json();
        this.post = true;
        this.records.push(data);
    }).catch(error => {
        this.error = error
    });
            
    },
  methods: {

  },
}

</script>
