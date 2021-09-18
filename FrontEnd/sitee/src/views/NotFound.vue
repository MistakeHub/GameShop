<template>

  <div class="home">
    
     <NotFoundComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import NotFoundComponent from '@/components/NotFoundComponent.vue'

export default {
  methods: {
  },
  name: 'NotFound',
  components: {
 NotFoundComponent
  }
}
</script>
