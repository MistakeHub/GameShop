<template  >
<div >

    <b-table striped hover  id="publication-table" :items="publications" :per-page="pagesize" :current-page="currentpage" :fields="fileds">     <template #cell(actions)="row" >
      
        <b-button size="sm" @click="Remove(row.item.id)" class="mr-1">
          Info modal
        </b-button>
      </template></b-table>
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
     
          name: 'AdminPanelTablesComponent',
          data(){
              return{
               fileds:['id','titleofgame', 'localizations', 'manufactures', 'genres','regionRestricts', 'platforms', 'series', 'rating', 'dateRealese',  { key: 'actions', label: 'Actions' }],
            
             publications:[],
             
                 currentpage:1,
               countPublication:9,
               pagesize:3,
              
              
              
            
        
              }
          },
          mounted(){
          
     
                           axios.get('https://localhost:44303/api/Catalog/getAll').then(Response=>{ this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications)  } )
               
          },
          methods:{
    
         
        Remove:function(index){

 //axios({methods:'DELETE',url:'https://localhost:44303/api/Catalog/getAll', params:{id:index}}).then(Response=>{ this.publications=Response.data.item1;this.countPublication=Response.data.item2;   console.log(this.publications)  } )
          console.log(index)
        }
          
   
          }
          
           
        
          
  }

</script>