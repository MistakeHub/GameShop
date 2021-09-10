<template>

  <div class="home">
    
     <MostPurchesableProductsComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import MostPurchesableProductsComponent from '@/components/AdminComponents/MostPurcheasableProductsComponent.vue'

export default {
  methods: {
  },
  name: 'MostPurchase',
  components: {
 MostPurchesableProductsComponent
  }
}
</script>
