<template>
<div class="card text-center">
  <div class="card-header">
    Featured
  </div>
  <div class="card-body">
    <h5 class="card-title">Успешно!</h5>
    <p class="card-text">Продукт был отправлен на вашу почту</p>
    <a href="/" class="btn btn-primary">Вернуться обратно</a>
  </div>
  <div class="card-footer text-muted">
   
  </div>
</div>
</template>




<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'AcceptPurchaseComponent',
        
          mounted(){
          
  axios({
                method: 'DELETE',
                url: 'https://localhost:44303/api/Cart/purchase/'+this.$route.params.id,
                
            }).then((response) => {
             
            });
         
     
          },
          methods:{
    
           
          Register:function () {
           
          }

             },

          
           
        
          
  }

</script>