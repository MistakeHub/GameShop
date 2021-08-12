<template>
 <div  style="height:500px; width:900px; margin-left:520px; margin-top:50px">

    <b-form class=" bg-white" >

     <h1>Регистрация</h1>
      <b-form-group
        id="input-group-1"
        label="Логин:"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
         v-model="Login"
          type="text"
          placeholder="Enter login"
          required
        ></b-form-input>
      </b-form-group>

        <b-form-group
        id="input-group-1"
        label="Почта:"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
             v-model="Email"
          type="email"
          placeholder="Enter email"
          required
        ></b-form-input>
      </b-form-group>
    

      <b-form-group id="input-group-2" label="Пароль:" label-for="input-2">
        <b-form-input
          id="input-2"
            v-model="Password"
          placeholder="Enter password"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Подтверждение паролья:" label-for="input-3">
        <b-form-input
          id="input-3"
            v-model="Confirmpass"
        placeholder="confirm password"
          required
        ></b-form-input>
      </b-form-group>

   
       <b-form-group
        id="input-group-1"
        label="Название Игры:"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
         v-model="titleofgame"
          type="text"
          placeholder="Enter Title"
          required
        ></b-form-input>

            <b-form-group
        id="input-group-1"
        label="Название Игры:"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
         v-model="titleofgame"
          type="text"
          placeholder="Enter Title"
          required
        ></b-form-input>

            <b-form-group
        id="input-group-1"
        label="Название Игры:"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
         v-model="titleofgame"
          type="text"
          placeholder="Enter Title"
          required
        ></b-form-input>

            <b-form-group
        id="input-group-1"
        label="Название Игры:"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
         v-model="titleofgame"
          type="text"
          placeholder="Enter Title"
          required
        ></b-form-input>
            </b-form-group>
            </b-form-group>
            </b-form-group>
       </b-form-group>
       
  
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
       <b-button type="submit" variant="primary" @click="Register">Submit</b-button>
  </div>
</template>




<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'RegisterComponent',
          data(){
              return{
      
             Login:"",
             Email:"",
             Password:"",
             Confirmpass:""
            
              
              
            
        
              }
          },
          mounted(){
          

         
     
          },
          methods:{
    
           
          Register:function () {
             axios({
                method: 'POST',
                url: 'https://localhost:44303/register',
                params: { login: this.Login, email:this.Email,password:this.Password }
            }).then((response) => {
             
            });
          }

             },

          
           
        
          
  }

</script>