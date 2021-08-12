<template>

  <div class="home">
    
     <AdminComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import  AdminComponent from '@/components/AdminComponents/AdminComponent.vue'

export default {
  methods: {
  },
  name: 'Admin',
  components: {
   AdminComponent
  }
}
</script>
