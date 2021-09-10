<template>

  <div class="home">
    
     <GameTableComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import  GameTableComponent from '@/components/AdminComponents/AdminTables/GameTableComponent.vue'

export default {
  methods: {
  },
  name: 'GameTable',
  components: {
  GameTableComponent
  }
}
</script>
