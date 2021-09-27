<template  >
<div >

 
<div >
  <notifications group="foo"/>
    <h2>Самые прибыльные игры </h2>
   <div>   
     
  
      <b-button variant="success" class="text-white" @click="Submit()" >Получить</b-button>
      <b-button @click="Reset()" variant="danger" >Очистить</b-button>
        <b-dropdown text="Фильтры"  variant="primary">
      <label for="genres">Жанр</label>
           <b-form-select v-model="selectedgenre" :options="Genres" size="sm" id="genres">

               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
        <label for="platform">Платформа</label>
           <b-form-select v-model="selectedplatform" :options="Platforms" size="sm"  id="platform">
               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="localization">Локализация:</label>
           <b-form-select v-model="selectedlocalization" :options="Localizations" size="sm"  id="localization">
               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="series">Серия Игр:</label>
           <b-form-select v-model="selectedserie" :options="Series" size="sm" id="series">
               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="manufacture">Производители:</label>
           <b-form-select v-model="selectedmanufacture" :options="Manufactures" size="sm"  id="manufacture">
            <b-form-select-option :value="[]" >Все</b-form-select-option>

           </b-form-select>
        </b-dropdown>
       </div>
    <b-table label="asdas" striped hover  id="table2" :items=" ratingProducts" :per-page="pagesize" :current-page="currentpage"  >    
       
      
     

      
      </b-table>



    
      <b-pagination
      v-model="currentpage"
      :total-rows="countPublication"
      :per-page="pagesize"
      aria-controls="table2"
    >
    
    
 
    </b-pagination>
    <b-button class="text-white bg-secondary" @click="SaveToExcel()">SaveToExcel</b-button>
</div>


<div  class="bg-dark">


</div>

</div>
</template>


<style >

.column {
  float: left;
  width: 50%;
  padding: 5px;
}

.row::after {
  content: "";
  clear: both;
  display: table;
}
</style>

<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'MostRatingProductsComponent',
          data(){
              return{
              
                 search: '',
            
             Games:[],
              Genres:[],
              Manufactures:[],
              Series:[],
              Localizations:[],
              Platforms:[],
              selectedgame:[],
               selectedgenre:[],
               selectedmanufacture:[],
               selectedserie:[],
               selectedlocalization:[],
               selectedplatform:[],
                 ratingProducts:[   ],
                 currentpage:1,
               countPublication:9,
               pagesize:3,
               Type:"",
               title:"",
                from:"",
               to:"",
              }
          },
              
      
         
          mounted(){
                if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }

                 axios.get("https://localhost:44303/api/Genre").then(Response=> {this.Genres=Response.data; console.log(this.Genres)}).catch(d=>{
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
           axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
             axios.get("https://localhost:44303/api/Platform").then(Response=> this.Platforms=Response.data).catch(d=>{
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
               axios.get("https://localhost:44303/api/Localization").then(Response=> this.Localizations=Response.data).catch(d=>{
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
             axios.get("https://localhost:44303/api/Series").then(Response=> this.Series=Response.data).catch(d=>{
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
            axios.get("https://localhost:44303/api/Manufacture").then(Response=> this.Manufactures=Response.data).catch(d=>{
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
            axios.get('ttps://localhost:44303/api/Record/ratingproducts',{headers:{
                    "Accept": "application/json",
                     "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie}},{params:{from:this.from, to:this.to,genres:this.selectedgenre.length==0? this.genres:this.selectedgenres,
                 manufactures:this.selectedmanufactures.length==0? this.manufactures:this.selectedmanufactures, 
                  platforms:this.selectedplatforms.length==0? this.platforms:this.selectedplatforms,
                  localizations:this.selectedlocalizations.length==0? this.localizations:this.selectedlocalizations, }}).then(Response=>
                           {  this.ratingProducts=Response.data;this.countPublication=this.ratingProducts.length; ;
              console.log(this.selectedmanufactures).catch(d=>{
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
});; 
                } ) 
          },
             methods:{

               SaveToExcel(){
axios({method:'PUT',url:'https://localhost:44303/api/Record/ratingproducts/savetoexcel',headers:{
                    "Accept": "application/json",
                     "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie},params:{genres:this.selectedgenre.length==0? this.Genres:[this.selectedgenre],
                 manufactures:this.selectedmanufacture.length==0? this.Manufactures:[this.selectedmanufacture], 
                  platforms:this.selectedplatform.length==0? this.Platforms:[this.selectedplatform],
                  localizations:this.selectedlocalization.length==0? this.Localizations:[this.selectedlocalizations] }}).then(Response=>
                           { 
              console.log(Response.data); 
                } ).catch(d=>{
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

Submit:function(){
       console.log(this.selectedplatform)
axios({method:'GET',url:'https://localhost:44303/api/Record/ratingproducts',headers:{
                    "Accept": "application/json",
                     "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie},params:{genres:this.selectedgenre.length==0? this.Genres:[this.selectedgenre],
                 manufactures:this.selectedmanufacture.length==0? this.Manufactures:[this.selectedmanufacture], 
                  platforms:this.selectedplatform.length==0? this.Platforms:[this.selectedplatform],
                  localizations:this.selectedlocalization.length==0? this.Localizations:[this.selectedlocalizations] }}).then(Response=>
                           { this.ratingProducts=Response.data;this.countPublication=this.ratingProducts.length; ;
              console.log(Response.data); 
                } ).catch(d=>{
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
Reset:function(){

  this.from=""
  this.to=""
  this.Submit()
}

          }
           
        
          
  }
         

</script>