<template>

  <div class="home">
    
     <UserTableComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import  UserTableComponent from '@/components/AdminComponents/AdminTables/UserTableComponent.vue'

export default {
  methods: {
  },
  name: 'UserTable',
  components: {
  UserTableComponent
  }
}
</script>
