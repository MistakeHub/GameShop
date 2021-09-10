<template>

  <div class="home">
    
     <MostProfitableProductsComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import MostProfitableProductsComponent from '@/components/AdminComponents/MostProfitableProductsComponent.vue'

export default {
  methods: {
  },
  name: 'MostProfitable',
  components: {
 MostProfitableProductsComponent
  }
}
</script>
