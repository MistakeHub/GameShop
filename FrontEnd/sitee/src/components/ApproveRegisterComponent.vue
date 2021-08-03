<template>
 <h1>Урааа</h1>
</template>




<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'ApproveRegisterComponent',
          data(){
              return{
      
            
            
              
              
            
        
              }
          },
          mounted(){
          
  axios({
                method: 'PUT',
                url: 'https://localhost:44303/verification',
                params: { userkey: this.$route.params.userkey, email:this.$route.params.email}
            }).then((response) => {
             
            });
         
     
          },
          methods:{
    
           
          Register:function () {
           
          }

             },

          
           
        
          
  }

</script>