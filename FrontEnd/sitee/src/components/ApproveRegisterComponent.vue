<template>
<div class="card text-center">
  
  <div class="card-body">
    <h5 class="card-title">Регистрация прошла успешно</h5>
    <p class="card-text">Теперь вы можете вернуться на главную страницу</p>
    <a href="/" class="btn">Вернуться обратно</a>
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
     
          name: 'ApproveRegisterComponent',
        
          mounted(){
          
  axios({
                method: 'PUT',
                url: 'https://localhost:44303/verification',
                params: { userkey: this.$route.params.userkey, }
            }).then((response) => {
             
            });
         
     
          },
          methods:{
    
           
          Register:function () {
           
          }

             },

          
           
        
          
  }

</script>