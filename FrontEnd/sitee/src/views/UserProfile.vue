<template>

  <div class="home">
    
     <UserProfileComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import UserProfileComponent from '@/components/UserProfileComponent.vue'

export default {
  methods: {
  },
  name: 'UserProfile',
  components: {
    UserProfileComponent
  }
}
</script>
