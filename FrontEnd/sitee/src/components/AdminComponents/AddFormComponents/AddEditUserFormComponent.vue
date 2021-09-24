<template>
 <div >

    <b-form class=" bg-white" >
      <h1 v-if="$route.meta.EditFormUser">Редактирование Пользователя "{{Login}}"</h1>
     <h1 v-if="!$route.meta.EditFormUser">Добавление нового Пользователя</h1>
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
          placeholder="Enter Title"
          required
        ></b-form-input>
         <b-form-invalid-feedback id="input-1-live-feedback">{{ veeErrors.first('login') }}</b-form-invalid-feedback>
      </b-form-group>

        <b-form-group
        id="input-group-1"
        label="Пароль(Хэширован):"
        label-for="input-2"
      
      >
        </b-form-group>
      
        <b-form-input
      id="input-2"
        name="password"

      v-model="Password"
      placeholder="Enter something..."
      rows="3"
      max-rows="6"
    ></b-form-input>
     <b-form-invalid-feedback id="input-1-live-feedback">{{ veeErrors.first('password') }}</b-form-invalid-feedback>
    

      <b-form-group
        id="input-group-1"
        label="Почта:"
        label-for="input-3"
      
      >
      
 <b-form-input
      id="input-3"
             name="input-2"
               v-validate="'required|email'"
               :state="validateState('input-2')"
      v-model="Email"
      placeholder="Enter something..."
      rows="3"
      max-rows="6"
    ></b-form-input>
     <b-form-invalid-feedback id="input-1-live-feedback">{{ veeErrors.first('input-2') }}</b-form-invalid-feedback>
     
      
   

    

    
         <b-form-group label="Статусы"  >
      <b-form-radio-group
      v-for="elem in statuse"
        id="radiobutton-group-1"
      
    
        name="flavour-2"
      >
        <b-form-radio :value=elem class="d-flex justify-content-start"  v-model="selectedstatuse" >{{elem}}</b-form-radio>
     
      </b-form-radio-group>
    
    </b-form-group>
   <b-form-group label="Роли"  >

   
      <b-form-radio-group
      v-for="elem in roles"
        id="radiobutton-group-2"
     
   
        name="flavour-3"
      >
        <b-form-radio :value=elem class="d-flex"  v-model="selectedrole">{{elem}}</b-form-radio>
     
      </b-form-radio-group>
   
   </b-form-group>
 
   
      
      <div class="col-md-5 offset-md-1" v-if="$route.meta.EditFormUser">
      <h5>1. single file</h5>
      <form>
        <div class="form-group">
          <label for="my-file">Select Image</label>
          <input type="file" accept="image/*" @change="createImage" class="form-control-file" id="my-file">
    
          <div class="border p-2 mt-3">
            <p>Preview Here:</p>
            <template v-if="preview">
              <img :src="preview" class="img-fluid" />
              <p class="mb-0">file name: {{ image.name }}</p>
              <p class="mb-0">size: {{ image.size/1024 }}KB</p>
            </template>
          </div>
        </div>
      </form>
    </div>
    </b-form-group> 
  
        
        


   

  
    
    </b-form>
       <b-button type="submit" variant="primary" @click="upload()">Submit</b-button>
        <notifications group="foo" />
  </div>
</template>

<style >


.container .btn {
    position: absolute;
    top: 0%;
    left:100%;
    transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
    background-color: #555;
    color: white;
    font-size: 16px;
    padding: 12px 24px;
    border: none;
    cursor: pointer;
    border-radius: 5px;
    text-align: center;
}
</style>

<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'AddEditUserFormComponent',
          data(){
              return{
              id:0,
               Avatar:{},
               Login:"", 
               Password:"",
               Email:"",
               roles:[],
               statuse:[],
          
               selectedrole:"",
               selectedstatuse:"",
              files:new FormData(),
           preview: null,
      image: null,
     
              
            
        
              }
          },
          mounted(){

  if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
          
            axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
             axios.get("https://localhost:44303/api/Statuse").then(Response=> this.statuse=Response.data)
               axios.get("https://localhost:44303/api/Role").then(Response=> this.roles=Response.data)
             

            if(this.$route.meta.EditFormUser)     axios.get("https://localhost:44303/getfulluser/"+this.$route.params.id, {headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("admin")}},).
            then(Response=> {
                 console.log(Response.data);
                 this.id=Response.data.id
            this.selectedrole=Response.data.role==null? 1:Response.data.role.titleofRole; 
            this.selectedstatuse=Response.data.statuse==null? 1:Response.data.status.titleofstatuse; 
          this.Login=Response.data.login;
          console.log(  this.selectedrole)
           console.log(this.selectedstatuse)
          this.Password=Response.data.password
          this.Email=Response.data.email;
           this.Avatar=Response.data.avatar    
                      
                    
                      
             
           
            
              const filename= this.Avatar.filename;
               
                         this.preview=this.Avatar.url
               axios.get(this.Avatar.url).then(response=>    {
                 var file=new File([response.data], filename, {type:"image/jpg"}); file.$path=""
                 this.image=file;} )
                 console.log(this.preview)
               
         
                   
              

            }

             )


          
          
          },
          
          methods:{
                  fileChange(fileList) {
        this.files.append("file", fileList[0], fileList[0].name);
    },
          
             validateState(ref) {
      if (
        this.veeFields[ref] &&
        (this.veeFields[ref].dirty || this.veeFields[ref].validated)
      ) {
        return !this.veeErrors.has(ref);
      }
      return null;
    },
          
      


    
    upload:function() {

        
        axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'
  
   
 
  
      

      if(this.$route.meta.EditFormUser){
         let formData = new FormData()

    let file = this.image

   formData.append('avatar', file, file.name)
       this.$validator.validate().then(valid => {
        if (valid) {
          axios({method:'PUT', url:`https://localhost:44303/edituser/`+this.id, headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("admin")},data:formData,params:{ login:this.Login, password:this.Password, email:this.Email, statuse:this.selectedstatuse, role:this.selectedrole }  }).then(response => {
         this.$notify({
  group: 'foo',
  type:'success',
 duration:10000,
  text: "Успешно!"
});
             
            }).catch(d=>{
              if(d.response)
         
              this.$notify({
  group: 'foo',
  type:'error',
  title: d.response.status,
   duration:10000,
  text: d.message
});
  if(d.request){
         console.log(d.request.status)
     this.$notify({
  group: 'foo',
  type:'error',
  title: 'Ошибка',
   duration:10000,
  text:d.message
});
  }
});
        }
      });
    
      }

else 

this.$validator.validate().then(valid => {
        if (valid) {
            axios({method:'POST', url:`https://localhost:44303/register`,headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("user")}, params:{ login:this.Login, password:this.Password, email:this.Email, status:this.selectedstatuse, role:this.selectedrole }  }).then(response => {

          this.$notify({
  group: 'foo',
  type:'success',
 
  text: "Успешно!"
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
      

    },

    onFileChange(e) {
    
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length) return;
      this.createImage(files);
    },
    createImage(event) {
      
    var input = event.target;
      if (input.files) {
        var reader = new FileReader();
        reader.onload = (e) => {
          this.preview = e.target.result;
        }
        this.image=input.files[0];
        reader.readAsDataURL(input.files[0]);
      }
    },
  RemoveImage:function(index){

   this.image_list.splice(index,1);
   this.preview_list.splice(index,1)

  }
          }
  }
  
  
</script>       