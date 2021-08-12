<template>

  <div class="home">
    
     <AddPublicationFormComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import AddPublicationFormComponent from '@/components/AdminComponents/AddFormComponents/AddPublicationFormComponent.vue'

export default {
  methods: {
  },
  name: 'AddPublicationForm',
  components: {
AddPublicationFormComponent
  }
}
</script>
