<template  >
<div >

    <b-table striped hover  id="publication-table" :items="publications" :per-page="pagesize" :current-page="currentpage" :fields="fileds">    
       <template #cell(actions)="row" >
      
        <b-button size="sm" @click="Remove(row.item.id)" class="mr-1">
         Удаление
        </b-button>

        
        
        <b-button v-if="row.item.titleofplatform!=undefined" size="sm" bv-modal-example2 @click="ShowEditModal(row.item.id, row.item.titleofplatform)" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.titleofstatuse!=undefined" size="sm" bv-modal-example2 @click="ShowEditModal(row.item.id, row.item.titleofstatuse)" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.titleoflocalization!=undefined" size="sm" bv-modal-example2 @click="ShowEditModal(row.item.id, row.item.titleoflocalization)" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.titleofmanufactures!=undefined" size="sm" bv-modal-example2 @click="ShowEditModal(row.item.id, row.item.titleofmanufactures)" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.titleofgenre!=undefined" size="sm" bv-modal-example2 @click="ShowEditModal(row.item.id, row.item.titleofgenre)" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.titleofcountry!=undefined" size="sm" bv-modal-example2 @click="ShowEditModal(row.item.id, row.item.titleofcountry)" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.titleofRole!=undefined" size="sm" bv-modal-example2 @click="ShowEditModal(row.item.id, row.item.titleofRole)" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.titleofseries!=undefined" size="sm" bv-modal-example2 @click="ShowEditModal(row.item.id, row.item.titleofseries)" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.titleofgame!=undefined" size="sm" bv-modal-example2 :href="AddRef+'/'+row.item.id" class="mr-1"> Редактирование</b-button>
        <b-button v-if="row.item.login!=undefined" size="sm" bv-modal-example2 :href="AddRef+'/'+row.item.id" class="mr-1"> Редактирование</b-button>
      
      
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
     
          name: 'AdminPanelTablesPublicationComponent',
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
              Index:0,
              
              
            
        
              }
          },
          mounted(){
              if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
          
                             if(this.$route.meta.publication)
                           axios.get('https://localhost:44303/api/Catalog/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   ;this.Type="Catalog"; this.AddRef="/admin-panel/EditPublication"; console.log(this.publications); this.fileds=['id','titleofgame', 'localizations', 'manufactures', 'genres','regionRestricts', 'platforms', 'series', 'rating', 'dateRealese',  { key: 'actions', label: 'Actions' }]  } )

                            if(this.$route.meta.user)
                           axios.get('https://localhost:44303/users', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2; ;this.Type="User"; this.AddRef="/admin-panel/EditUser";  console.log(this.publications); this.fileds=['id', 'avatar','login', 'password', 'dateofregistration','statuse','role', { key: 'actions', label: 'Actions' }]  } )

                            if(this.$route.meta.country)
                           axios.get('https://localhost:44303/api/Country/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2; 
                           this.isHaveModal=true;this.Type="Country";   console.log(this.publications); this.fileds=['id', 'titlecountry', { key: 'actions', label: 'Actions' }]  } )

                            if(this.$route.meta.genre)
                           axios.get('https://localhost:44303/api/Genre/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;  
                           this.isHaveModal=true;this.Type="Genre";  console.log(this.publications); this.fileds=['id', 'titleofgenre', { key: 'actions', label: 'Actions' }]  } )

                            if(this.$route.meta.localization)
                           axios.get('https://localhost:44303/api/Localization/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2; 
                           this.isHaveModal=true;this.Type="Localization";   console.log(this.publications) ; this.fileds=['id', 'titlelocalization', { key: 'actions', label: 'Actions' }] } )

                            if(this.$route.meta.manufacture)
                           axios.get('https://localhost:44303/api/Manufacture/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { 
                             this.publications=Response.data.item1;this.countPublication=Response.data.item2; 
                             this.isHaveModal=true;this.Type="Manufacture";   console.log(this.publications) ; this.fileds=['id', 'titleofmanufacture', { key: 'actions', label: 'Actions' }] } )

                            if(this.$route.meta.platform)
                           axios.get('https://localhost:44303/api/Platform/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2; this.isHaveModal=true;this.Type="Platform";   console.log(this.publications)  ;this.fileds=['id', 'titleofplatform', { key: 'actions', label: 'Actions' }]} )

                            if(this.$route.meta.role)
                           axios.get('https://localhost:44303/api/Role/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2; this.isHaveModal=true;this.Type="Role";   console.log(this.publications) ; this.fileds=['id', 'titleofRole', { key: 'actions', label: 'Actions' }] } )

                            if(this.$route.meta.series)
                           axios.get('https://localhost:44303/api/Series/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2; this.isHaveModal=true;this.Type="Series";   console.log(this.publications) ; this.fileds=['id', 'titleofseries', { key: 'actions', label: 'Actions' }] } )

                            if(this.$route.meta.statuse)
                           axios.get('https://localhost:44303/api/Statuse/getAll', {headers:{
                    'set-cookie':document.cookie}}).then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2; this.isHaveModal=true;this.Type="Status";  this.publications.titleofstatuse=this.publications.title;  console.log(this.publications) ; this.fileds=['id', 'titleofstatuse', { key: 'actions', label: 'Actions' }] } )

                          
          },
          methods:{
    
         
        Remove:function(index){

 axios.delete('https://localhost:44303/api/'+this.Type+'/remove'+this.Type+'/'+index,{headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("admin")}}).then(Response=>{  window.location.reload(); alert("Удалён")  } )
         
        },

      getPublication:function(){

          axios.get('https://localhost:44303/api/Catalog/getAll').then(Response=>{ this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications)  } )
      },
      Add:function(){
           axios({method:'POST',url:'https://localhost:44303/api/'+this.Type+'/add', headers: {
                    "Accept": "application/json",
                   "Authorization": "Bearer " + localStorage.getItem("admin")}, params:{ title:this.title}}).then(response=>{  window.location.reload();  alert("Элемент успешно добавлен")})

      },

        EditElement:function(){
           axios({method:'PUT',url:'https://localhost:44303/api/'+this.Type+'/edit/'+this.Index, headers:{
                    "Accept": "application/json",
                   "Authorization": "Bearer " + localStorage.getItem("admin")}, params:{ title:this.title}}).then(response=>{  window.location.reload();  alert("Элемент успешно добавлен")})

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
                "Authorization": "Bearer " + localStorage.getItem("admin")},}).then(response=>{  window.location.reload();  alert("Успешно Сохранено")})

      },
        LoadFromJson:function(){

         axios({method:'POST',url:'https://localhost:44303/api/'+this.Type+'/loadfromjson', headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("admin")}, }).then(response=>{  window.location.reload();  alert("Успешно Сохранено")})

      }
          
   
          }
          
           
        
          
  }

</script>