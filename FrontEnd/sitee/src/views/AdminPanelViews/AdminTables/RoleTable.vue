<template>

  <div class="home">
    
     <RoleTableComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import  RoleTableComponent from '@/components/AdminComponents/AdminTables/RoleTableComponent.vue'

export default {
  methods: {
  },
  name: 'PlarformTable',
  components: {
  RoleTableComponent
  }
}
</script>
