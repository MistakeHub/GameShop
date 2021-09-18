<template  >
<div >

    <b-table striped hover  id="publication-table" :items="publications" :per-page="pagesize" :current-page="currentpage" :fields="fileds">    
       <template #cell(actions)="row" >
      
        <b-button size="sm" @click="Remove(row.item.id)" class="mr-1">
         Удаление
        </b-button>

        
        
      
        <b-button v-if="row.item.login!=undefined" size="sm" bv-modal-example2 :href="EditRef+'/'+row.item.id" class="mr-1"> Редактирование</b-button>
      
      
      </template>
  
     <template #cell(avatar)="row" > <img :src="row.item.avatar==null?'https://localhost:44303/getImage/Avatar/Default.jpg':row.item.avatar.url" width="30" class="user-img rounded-circle mr-2"></template>
    <template #cell(role)="row" >{{row.item.role.titleofRole}}</template>
        <template #cell(statuse)="row" >{{row.item.status.titleofstatuse}}</template>
      </b-table>



    
      <b-pagination
      v-model="currentpage"
      :total-rows="countPublication"
      :per-page="pagesize"
      aria-controls="publication-table"
    >
    
    
      <notifications group="foo" />
    </b-pagination>
  

<div>

<b-button v-if="!isHaveModal" variant="succes" @click="$bvModal.show('bv-modal-example')"  :href=AddRef > New</b-button>
<b-button v-if="isHaveModal" v-b-modal.modal-1 variant="succes"  @click="$bvModal.show('bv-modal-example')"  > New</b-button>
<b-button @click="SaveToJson()" variant="warning">SaveToJson</b-button>
<b-button @click="LoadFromJson()" variant="warning">LoadFromJson</b-button>
  <b-modal id="bv-modal-example" hide-footer>
    <template #modal-title>
    <h1>Добавление нового элемента</h1>
    </template>
    
    <div class="d-block text-center">
      <label>навзание</label>
      <b-input v-model="title"></b-input>
    </div>
    <b-button class="mt-3" block @click="Add()">Подтвердить </b-button>
  </b-modal>
</div>

<div>


  <b-modal ref="bv-modal-example2" hide-footer>
    <template #modal-title>
    <h1>Редактирование</h1>
    </template>
    
    <div class="d-block text-center">
      <label>навзание</label>
      <b-input v-model="title"></b-input>
    </div>
    <b-button class="mt-3" block @click="EditElement()">Подтвердить </b-button>
  </b-modal>
</div>
   <router-view></router-view>
  
</div>
</template>




<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'UserTableComponent',
          data(){
              return{
               fileds:[],
            
             publications:[],
            
             
                 currentpage:1,
               countPublication:9,
               pagesize:3,
               Type:"",
               title:"",
               isHaveModal:false,
               isModal:false,
               AddRef:"",
               EditRef:"",
              Index:0,
              
              
            
        
              }
          },
          mounted(){
              if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
          
                       
                            if(this.$route.meta.user)
                           axios.get('https://localhost:44303/users', {headers:{
                               "Authorization": "Bearer " + localStorage.getItem("admin"),
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2; ;this.Type="User"; this.AddRef="/admin-panel/AddUser";  this.EditRef="/admin-panel/EditUser";  console.log(this.publications); this.fileds=['id', 'avatar','login', 'password', 'dateofregistration','statuse','role', { key: 'actions', label: 'Actions' }]  } ).catch(d=>{
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

                        
                          
          },
          methods:{
    
         
        Remove:function(index){

 axios.delete('https://localhost:44303/api/'+this.Type+'/remove'+this.Type+'/'+index,{headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("admin")}}) .then(Response=>{  window.location.reload(); this.$notify({
  group: 'foo',
  type:'success',
 
  text: "Успешно Удален"
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
         
        },

     
      Add:function(){
           axios({method:'POST',url:'https://localhost:44303/api/'+this.Type+'/add', headers: {
                    "Accept": "application/json",
                   "Authorization": "Bearer " + localStorage.getItem("admin")}, params:{ title:this.title}}).then(response=>{  window.location.reload();  this.$notify({
  group: 'foo',
  type:'success',
 
  text: "Успешно добавлен"
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


      },

        EditElement:function(){
           axios({method:'PUT',url:'https://localhost:44303/api/'+this.Type+'/edit/'+this.Index, headers:{
                    "Accept": "application/json",
                   "Authorization": "Bearer " + localStorage.getItem("admin")}, params:{ title:this.title}}).then(response=>{  window.location.reload(); this.$notify({
  group: 'foo',
  type:'success',
 
  text: "Успешно изменён"
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


      },

      ShowEditModal:function(value,value2){
        this.title=value2
        this.Index=value
        console.log(value2)
 this.$refs['bv-modal-example2'].show();
           

      },

      SaveToJson:function(){

         axios({method:'POST',url:'https://localhost:44303/api/'+this.Type+'/savetojson', headers:{
                    "Accept": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("admin")},}).then(response=>{  window.location.reload(); this.$notify({
  group: 'foo',
  type:'success',
 
  text: "Успешно Сохранён"
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

      },
        LoadFromJson:function(){

         axios({method:'POST',url:'https://localhost:44303/api/'+this.Type+'/loadfromjson', headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("admin")}, }) .then(response=>{  window.location.reload(); this.$notify({
  group: 'foo',
  type:'success',
 
  text: "Успешно загружен"
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
          
   
          }
          
           
        
          
  }

</script>