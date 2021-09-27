<template>
 <div  style="height:500px; width:900px; margin-left:520px; margin-top:150px; margin-bottom:100px">

    <b-form class=" bg-white" >

     <h1>Регистрация</h1>
      <b-form-group
        id="input-group-1"
        label="Логин:"
        label-for="input-1"
      
      >
      
        <b-form-input
          id="input-1"
         name="login"
           v-validate="{required:true,min:3,max:20,regex:/^[a-zA-Z](.[a-zA-Z0-9_-]*)$/}"
            :state="validateState('login')"
         v-model="Login"
          type="text"
          placeholder="Enter login"
          required
        ></b-form-input>

        
           <b-form-invalid-feedback id="input-1-live-feedback">{{ veeErrors.first('login') }}</b-form-invalid-feedback>
      </b-form-group>

        <b-form-group
        id="input-group-1"
        label="Почта:"
        label-for="input-2"
      
      >
      
        <b-form-input
          id="input-2"
            name="input-2"
               v-validate="'required|email'"
               :state="validateState('input-2')"
             v-model="Email"
          type="email"
          placeholder="Enter email"
          required
        ></b-form-input>
         <b-form-invalid-feedback id="input-1-live-feedback">{{ veeErrors.first('input-2') }}</b-form-invalid-feedback>
      </b-form-group>
    

      <b-form-group id="input-group-2" label="Пароль:" label-for="input-2">
        <b-form-input
          id="input-3"
          name="password"
       v-validate="{required:true,min:3,max:20,regex:/^[a-zA-Z](.[a-zA-Z0-9_-]*)$/}"
            :state="validateState('password')"
            v-model="Password"
          placeholder="Enter password"
          required
        ></b-form-input>
           <b-form-invalid-feedback id="input-1-live-feedback">{{ veeErrors.first('password') }}</b-form-invalid-feedback>
      </b-form-group>

      <b-form-group id="input-group-3" label="Подтверждение паролья:" label-for="input-3">
        <b-form-input
        v-validate="'required|confirmed:password'"
        name="confirmpassword"
          :state="validateState('confirmpassword')"
          id="input-4"
            v-model="Confirmpass"
        placeholder="confirm password"
          required
        ></b-form-input>
   <b-form-invalid-feedback id="input-1-live-feedback">{{ veeErrors.first('confirmpassword') }}</b-form-invalid-feedback>
      </b-form-group>

     
  
     
    </b-form>
       <b-button type="submit" variant="success" @click="Register">Зарегистрироваться</b-button>

       <notifications group="foo" />
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
             Confirmpass:"",
             errors:[]
            
              
              
            
        
              }
          },
          mounted(){
          

         
     
          },

          methods:{
    
             validateState(ref) {

         
      if (
        this.veeFields[ref] &&
        (this.veeFields[ref].dirty || this.veeFields[ref].validated)
      ) {
        return !this.veeErrors.has(ref);
      }
      return null;
    },
          Register:function () {
 
         this.$validator.validate().then(valid => {
        if (valid) {
          axios({
                method: 'POST',
                url: 'https://localhost:44303/register',
                params: { login: this.Login, email:this.Email,password:this.Password }
            }).then((response) => {
             
 this.$notify({
  group: 'foo',
  type:'success',
   title:"Успешно!",

   duration:10000,
  
  text: "Вам на почту пришло письмо с подтверждением регистрации"
});
             
            }).catch(d=>{
              if(d.response)
         
              this.$notify({
  group: 'foo',
  type:'error',
  title: d.response.status,
  text: d.message
});
  if(d.request){
         console.log(d.request.status)
     this.$notify({
  group: 'foo',
  type:'error',
  title: 'Ошибка',
  text:d.message
});
  }
});
        }
      });
             
          }

             },

          
           
        
          
  }

</script>