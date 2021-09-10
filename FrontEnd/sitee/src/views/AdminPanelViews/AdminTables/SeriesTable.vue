<template>

  <div class="home">
    
     <SeriesTableComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import  SeriesTableComponent from '@/components/AdminComponents/AdminTables/SeriesTableComponent.vue'

export default {
  methods: {
  },
  name: 'SeriesTable',
  components: {
 SeriesTableComponent
  }
}
</script>
