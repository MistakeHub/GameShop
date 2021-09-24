<template>

<div class="row py-5 px-4" style="margin-top:10%">
    <div class="col-md-5 mx-auto">
        <!-- Profile widget -->
        <div class="bg-white shadow rounded overflow-hidden">
            <div class="px-4 pt-0 pb-4 cover">
                <div class="media align-items-end profile-head">
                    <div class="profile mr-3"><img :src="user.avatar==null?'https://localhost:44303/getImage/Avatar/Default.jpg':user.avatar" alt="..." style="max-widht:180px; max-height:220px" class="rounded mb-2 img-thumbnail">
                           <h4 class="mt-0 mb-0">{{user.login}}</h4>
                           <br>
                                <form v-if="localusername==user.login || localrole=='Редактор'" enctype="multipart/form-data">
        <input type="file" name="photo"  v-on:change="fileChange($event.target.files)"/>
        <button type="button" class="btn btn-outline-dark btn-sm btn-block" @click="upload()">Upload</button>
    </form>
                  
         <div class="media-body mb-5 text-white">
                 
                        <p class="small mb-4"> <i class="fas fa-map-marker-alt mr-2"></i>New York</p>
                    </div>
                </div>
            </div>
            <div class="bg-light p-4 d-flex justify-content-end text-center">
                <ul class="list-inline mb-0">
                    <li class="list-inline-item">
                        <h5 class="font-weight-bold mb-0 d-block">{{user.countofComments}}</h5><small class="text-muted"> <i class="fas fa-image mr-1"></i>Комментарии</small>
                    </li>
                       <li class="list-inline-item">
                        <h5 class="font-weight-bold mb-0 d-block">{{user.numberOfPurchases}}</h5><small class="text-muted"> <i class="fas fa-image mr-1"></i>Покупки</small>
                    </li>
                 
                </ul>
            </div>
           
            <div class="py-4 px-4">
              <b-button bv-modal-example1  v-if="localrole=='Редактор' && user.statuse=='Онлайн' " variant="danger" @click="ShowBanModal()"  >Заблокировать</b-button>
              <b-button bv-modal-example1  v-if="localrole=='Редактор' && user.statuse=='Заблокирован' " variant="success" @click="UnBanUser()"  >Разблокировать</b-button>
            </div>
              <div>
   

  <b-modal ref="bv-modal-example1" hide-footer>
    <template #modal-title>
    <h1>Блокировка пользователя</h1>
    </template>
    
    <div class="d-block text-center">
      <label>Причина</label>
      <b-input v-model="reason"></b-input>
    </div>
    <b-button class="mt-3" block @click="BanUser()">Подтвердить </b-button>
  </b-modal>
</div>
        </div>
    </div>
</div>
</div>
    
</template>
<style >
.profile-head {
    transform: translateY(5rem)
}

.cover {

    background-size: cover;
    background-repeat: no-repeat
}

body {
    background: #654ea3;
    background: linear-gradient(to right, #e96443, #904e95);
    min-height: 100vh;
    overflow-x: hidden
}
</style>
<script>


import axios from 'axios'
  export default{
  props: {
  },
     
          name: 'UserProfileComponent',
          data(){
              return{
                 user:{},
               files: new FormData(),
               localusername:localStorage.getItem("username"),
               localrole:localStorage.getItem("role"),
               reason:""
              }
          },
          mounted(){
                if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
               console.log(this.localusername)
            axios.get("https://localhost:44303/getuser/"+this.$route.params.userlogin).then((response)=> {this.user=response.data; console.log(this.user)});

          },
          methods: {

                ShowBanModal:function(){
        
 this.$refs['bv-modal-example1'].show();
           

      },

          

              BanUser(){

                 axios({method:'POST',url:"https://localhost:44303/banuser/"+this.$route.params.userlogin, params:{reason:this.reason},headers:{
                
                    'Content-Type': 'multipart/form-data',
                        "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("user")

                
            }}).then((response)=> {this.user=response.data; console.log(this.user);window.location.reload();});
                  
              },


                 UnBanUser(){

                 axios({method:'POST',url:"https://localhost:44303/unbanuser/"+this.$route.params.userlogin,headers:{
                
                    'Content-Type': 'multipart/form-data',
                        "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("user")

                
            }}).then((response)=> {this.user=response.data; console.log(this.user); window.location.reload();});
                  
              },
      
            fileChange(fileList) {
        this.files.append("photo", fileList[0], fileList[0].name);
        console.log(fileList[0].name)
    },

             upload: function(){
        const photo = this.files;
        var password=localStorage.getItem("password")
        axios({method:'POST', url:"https://localhost:44303/uploadavatar/"+this.user.login, headers:{
                
                    'Content-Type': 'multipart/form-data',
                        "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("user")

                
            }, data:photo ,params:{
             password: password

        },
           }).then(response => {
                window.location.reload();
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
});},

      
   
          }
    
  }

</script>

