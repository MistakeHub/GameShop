<template>
 <div  style="height:500px; width:900px; margin-left:520px; margin-top:220px; margin-bottom:100px">

    <b-form class=" bg-white" >

     <h1>Запрос На восстановление</h1>
     

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
    

    
  
     
    </b-form>
       <b-button type="submit" variant="primary" @click="RequestRestore">Submit</b-button>

       <notifications group="foo" />
  </div>

</template>




<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'RestoreAccountRequestComponent',
          data(){
              return{
      
           
             Email:"",
           
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
          RequestRestore:function () {
 
         this.$validator.validate().then(valid => {
        if (valid) {
          axios({
                method: 'POST',
                url: 'https://localhost:44303/restorerequest',
                params: { email:this.Email }
            }).then((response) => {
             
 this.$notify({
  group: 'foo',
  type:'success',
   title:"Успешно!",

   duration:10000,
  
  text: "Вам на почту пришло будет отправлено письмо с подтверждением"
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