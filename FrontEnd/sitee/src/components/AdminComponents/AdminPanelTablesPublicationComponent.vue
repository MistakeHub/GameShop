<template  >
<div >

    <b-table striped hover  id="publication-table" :items="publications" :per-page="pagesize" :current-page="currentpage" :fields="fileds">     <template #cell(actions)="row" >
      
        <b-button size="sm" @click="Remove(row.item.id)" class="mr-1">
          Info modal
        </b-button>
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
              
              
              
            
        
              }
          },
          mounted(){
          
                             if(this.$route.meta.publication)
                           axios.get('https://localhost:44303/api/Catalog/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications); this.fileds=['id','titleofgame', 'localizations', 'manufactures', 'genres','regionRestricts', 'platforms', 'series', 'rating', 'dateRealese',  { key: 'actions', label: 'Actions' }]  } )

                            if(this.$route.meta.user)
                           axios.get('https://localhost:44303/users').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications); this.fileds=['id', 'avatar','login', 'password', 'dateofregistration','statuse','role', { key: 'actions', label: 'Actions' }]  } )

                            if(this.$route.meta.country)
                           axios.get('https://localhost:44303/api/Country/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications); this.fileds=['id', 'titleofcountry', { key: 'actions', label: 'Actions' }]  } )

                            if(this.$route.meta.genre)
                           axios.get('https://localhost:44303/api/Genre/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications); this.fileds=['id', 'titleofgenre', { key: 'actions', label: 'Actions' }]  } )

                            if(this.$route.meta.localization)
                           axios.get('https://localhost:44303/api/Localization/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications) ; this.fileds=['id', 'titleoflocalization', { key: 'actions', label: 'Actions' }] } )

                            if(this.$route.meta.manufacture)
                           axios.get('https://localhost:44303/api/Manufacture/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications) ; this.fileds=['id', 'titleofmanufactures', { key: 'actions', label: 'Actions' }] } )

                            if(this.$route.meta.platform)
                           axios.get('https://localhost:44303/api/Platform/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications)  ;this.fileds=['id', 'titleofplatform', { key: 'actions', label: 'Actions' }]} )

                            if(this.$route.meta.role)
                           axios.get('https://localhost:44303/api/Role/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications) ; this.fileds=['id', 'titleofRole', { key: 'actions', label: 'Actions' }] } )

                            if(this.$route.meta.series)
                           axios.get('https://localhost:44303/api/Series/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications) ; this.fileds=['id', 'titleofseries', { key: 'actions', label: 'Actions' }] } )

                            if(this.$route.meta.statuse)
                           axios.get('https://localhost:44303/api/Statuse/getAll').then(Response=>
                           { this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications) ; this.fileds=['id', 'titleofstatuse', { key: 'actions', label: 'Actions' }] } )

                          
          },
          methods:{
    
         
        Remove:function(index){

 axios.delete('https://localhost:44303/api/Catalog/removePublication/'+index).then(Response=>{ this.getPublication(); alert("Удалён")  } )
         
        },

      getPublication:function(){

          axios.get('https://localhost:44303/api/Catalog/getAll').then(Response=>{ this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications)  } )
      }
          
   
          }
          
           
        
          
  }

</script>