<template>

  <div class="home">
    
     <CatalogComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import CatalogComponent from '@/components/CatalogComponent.vue'

export default {
  methods: {
  },
  name: 'Catalog',
  components: {
    CatalogComponent
  }
}
</script>
