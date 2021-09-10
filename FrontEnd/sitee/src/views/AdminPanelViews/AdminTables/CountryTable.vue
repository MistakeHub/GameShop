<template>

  <div class="home">
    
     <CountryTableComponent/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import  CountryTableComponent from '@/components/AdminComponents/AdminTables/CountryTableComponent.vue'

export default {
  methods: {
  },
  name: 'CountryTable',
  components: {
  CountryTableComponent
  }
}
</script>
