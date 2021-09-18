<template>

  <div class="home">
    
     <MostRatingProductsComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import MostRatingProductsComponent from '@/components/AdminComponents/MostRatingProductsComponent.vue'

export default {
  methods: {
  },
  name: 'MostRatingProducts',
  components: {
 MostRatingProductsComponent
  }
}
</script>
