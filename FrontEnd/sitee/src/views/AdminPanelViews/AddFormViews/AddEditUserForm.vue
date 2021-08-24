<template>

  <div class="home">
    
     <AddEditUserFormComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import AddEditUserFormComponent from '@/components/AdminComponents/AddFormComponents/AddEditUserFormComponent.vue'

export default {
  methods: {
  },
  name: 'AddEditUserForm',
  components: {
AddEditUserFormComponent
  }
}
</script>
