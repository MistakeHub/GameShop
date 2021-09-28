<template>
<div class="card text-center " style="margin-top:7.5%; margin-bottom:220px;">
  <div class="card-header">
    
  </div>
  <div class="card-body">
    <h5 class="card-title">Успешно!</h5>
   
    <a href="/" class="btn btn-primary text-white">Вернуться обратно</a>
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
              if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
          
  axios({
                method: 'DELETE',
                url: 'https://localhost:44303/api/Cart/purchase/'+this.$route.params.id,
                headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("user")}
            }).then((response) => {
             
            });
         
     
          },
          methods:{
    
           
          Register:function () {
           
          }

             },

          
           
        
          
  }

</script>