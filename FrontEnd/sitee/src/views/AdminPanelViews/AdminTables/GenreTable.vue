<template>

  <div class="home">
    
     <GenreTableComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import  GenreTableComponent from '@/components/AdminComponents/AdminTables/GenreTableComponent.vue'

export default {
  methods: {
  },
  name: 'GenreTable',
  components: {
  GenreTableComponent
  }
}
</script>
