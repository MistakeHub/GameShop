<template>

  <div class="home">
    
     <GameDetailComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import GameDetailComponent from '@/components/GameDetailComponent.vue'

export default {
  methods: {
  },
  name: 'GameDetail',
  components: {
    GameDetailComponent
  }
}
</script>