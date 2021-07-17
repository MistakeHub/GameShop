<template>

  <div class="home">
    
     <CartComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import CartComponent from '@/components/CartComponent.vue'

export default {
  methods: {
  },
  name: 'Cart',
  components: {
    CartComponent
  }
}
</script>
