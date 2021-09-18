<template  >
<div >
<div >
    <h2>Самые продаваемые продукты </h2>
    <div>   
       <label for="from">От:</label>  
    <input type="date" id="from" v-model="from" name="trip-start">
          <label for="to">До:</label>  
     <input type="date" id="to" v-model="to" name="trip-start">
     <b-button @click="Submit()" >OK</b-button>
      <b-button @click="Reset()" variant="danger" >Очистить</b-button>

        <label for="genres">Жанр</label>
           <b-form-select v-model="selectedgenre" :options="Genres" size="sm" class="mt-3" id="genres">

               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="platform">Палтформа</label>
           <b-form-select v-model="selectedplatform" :options="Platforms" size="sm" class="mt-3" id="platform">
               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="localization">Локализация</label>
           <b-form-select v-model="selectedlocalization" :options="Localizations" size="sm" class="mt-3" id="localization">
               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="series">Серия Игр</label>
           <b-form-select v-model="selectedserie" :options="Series" size="sm" class="mt-3" id="series">
               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="manufacture">Производители</label>
           <b-form-select v-model="selectedmanufacture" :options="Manufactures" size="sm" class="mt-3" id="manufacture">
            <b-form-select-option :value="[]" >Все</b-form-select-option>

           </b-form-select>
       </div>
       
    
    <b-table striped hover  id="table1" :items="PurcheasableProducts" :per-page="pagesize" :current-page="currentpage" >    
       
      
     

      
      </b-table>



    
      <b-pagination
      v-model="currentpage"
      :total-rows="countPublication"
      :per-page="pagesize"
      aria-controls="table1"
    >
    
    
 
    </b-pagination>
</div>
 


<div>


</div>

<div>


  
   <router-view></router-view>
  
</div>
</div>
</template>




<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'MostPurchesableProductsComponent',
          data(){
              return{
              
            search:'',
             PurcheasableProducts:[   ],
            
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
                 currentpage:1,
               countPublication:9,
               pagesize:3,
               Type:"",
               title:"",
               from:"",
               to:""
               
              
              
              
            
        
              }
          },

               
       
          mounted(){
                if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
          
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
            axios.get("https://localhost:44303/api/Genre").then(Response=> this.Genres=Response.data).catch(d=>{
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
                     axios.get('https://localhost:44303/api/Record/purcheasableproducts',{headers:{
                    "Accept": "application/json",
                     "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie}},{params:{from:this.from, to:this.to,genres:this.selectedgenre.length==0? this.genres:this.selectedgenres,
                 manufactures:this.selectedmanufactures.length==0? this.manufactures:this.selectedmanufactures, 
                  platforms:this.selectedplatforms.length==0? this.platforms:this.selectedplatforms,
                  localizations:this.selectedlocalizations.length==0? this.localizations:this.selectedlocalizations, }}).then(Response=>
                           {  this.PurcheasableProducts=Response.data;this.countPublication=this.PurcheasableProducts.length; ;
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

Submit:function(){
       
axios({method:'GET',url:'https://localhost:44303/api/Record/purcheasableproducts',headers:{
                    "Accept": "application/json",
                     "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie},params:{from:this.from, to:this.to,genres:this.selectedgenre.length==0? this.Genres:[this.selectedgenre],
                 manufactures:this.selectedmanufacture.length==0? this.Manufactures:[this.selectedmanufacture], 
                  platforms:this.selectedplatform.length==0? this.Platforms:[this.selectedplatform],
                  localizations:this.selectedlocalization.length==0? this.Localizations:[this.selectedlocalization], }}).then(Response=>
                           { this.PurcheasableProducts=Response.data;this.countPublication=this.PurcheasableProducts.length; ;
              console.log(Response.data); 
                } ) .catch(d=>{
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