<template>
 <div  style="height:500px; width:900px; margin-left:520px; margin-top:220px; margin-bottom:100px" >

    <b-form class=" bg-white"  >

     <h1>Восстановление пароля</h1>
    
    

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

     
  
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
       <b-button type="submit" variant="primary" @click="Register">Submit</b-button>

       <notifications group="foo" />
  </div>

</template>




<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'RestoreAccountFormComponent',
          data(){
              return{
      
           
             Password:"",
             Confirmpass:"",
             errors:[],
             restoreid:"",
            iserror:false
              
              
            
        
              }
          },
          mounted(){
          

           axios.post("https://localhost:44303/checkuserforrestore/"+this.$route.params.restoreid)
           .then((response)=>{ console.log(this.$route.params.restoreid);this.restoreid=this.$route.params.restoreid })
           .catch((error)=>{ if(error.statuscode==400)  this.iserror=true;window.location.href = 'http://yourprojectname:8080/error'; } )
     
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
                url: 'https://localhost:44303/restore',
                params: {restoreid:this.restoreid ,password:this.Password }
            }).then((response) => {
             
 this.$notify({
  group: 'foo',
  type:'success',
   title:"Успешно!",

   duration:10000,
  
  text: "Ваш пароль был изменён"
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