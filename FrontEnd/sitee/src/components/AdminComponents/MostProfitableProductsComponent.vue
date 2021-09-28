<template  >
<div >

 
<div >
    <h2>Самые прибыльные продукты </h2>
   <div>   
       <label for="from">От:</label>  
    <input type="date" id="from" v-model="from" name="trip-start">
          <label for="to">До:</label>  
     <input type="date" id="to" v-model="to" name="trip-start">
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
            <label for="localization">Локализация</label>
           <b-form-select v-model="selectedlocalization" :options="Localizations" size="sm"  id="localization">
               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="series">Серия Игр</label>
           <b-form-select v-model="selectedserie" :options="Series" size="sm"  id="series">
               <b-form-select-option :value="[]" >Все</b-form-select-option>
           </b-form-select>
            <label for="manufacture">Производители</label>
           <b-form-select v-model="selectedmanufacture" :options="Manufactures" size="sm"  id="manufacture">
            <b-form-select-option :value="[]" >Все</b-form-select-option>

           </b-form-select>
        </b-dropdown>
        <b-button class="text-white bg-secondary" @click="SaveToExcel()">Сохранить в CSV</b-button>
       </div>
       <br>
          <h1 v-if="from==='' && to===''" > За всё время</h1>
    <div style=" display: table; width: 100%;  ">
     <h3 v-if="from!==''" style="display: table-cell; "> от:{{from}} </h3>
      <h3 v-if="to!==''" style="display: table-cell;"> до:{{to}} </h3>
    </div>
    <b-table label="asdas" striped hover  id="table2" :items="ProfitableProducts" :per-page="pagesize" :current-page="currentpage"  :fields="fields" >    
       
      
     

      
      </b-table>



    
      <b-pagination
      v-model="currentpage"
      :total-rows="countPublication"
      :per-page="pagesize"
      aria-controls="table2"
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
     
          name: 'MostProfitableProductsComponent',
          data(){
              return{
              
                 search: '',
             fields:[{key:"game", label:"Название Игр"},{key:"total", label:"Всего"}],
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
                 ProfitableProducts:[   ],
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
               
           axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
             axios.get("https://localhost:44303/api/Platform",{headers:{'set-cookie':document.cookie}}).then(Response=> this.Platforms=Response.data).catch(d=>{
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
               axios.get("https://localhost:44303/api/Localization",{headers:{'set-cookie':document.cookie}}).then(Response=> this.Localizations=Response.data).catch(d=>{
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
             axios.get("https://localhost:44303/api/Series",{headers:{'set-cookie':document.cookie}}).then(Response=> this.Series=Response.data).catch(d=>{
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
            axios.get("https://localhost:44303/api/Manufacture",{headers:{'set-cookie':document.cookie}}).then(Response=> this.Manufactures=Response.data).catch(d=>{
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
            axios.get("https://localhost:44303/api/Genre",{headers:{'set-cookie':document.cookie}}).then(Response=> {this.Genres=Response.data; console.log(this.Genres)}).catch(d=>{
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
                     
     axios({
                method: 'GET',
                url: 'https://localhost:44303/api/Record/profitableproducts/',
                headers:{
                    "Accept": "application/json",
                     "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie},
             
                params: {from:"", to:"", genres:this.Genres,
                 manufactures:"", 
                  platforms:"",
                  localizations:"", 
                }
            }).then((response) => {
                 
                this.games=response.data.item1; this.count = response.data.item2 / this.pagesize;
                console.log(this.games)
                 this.isfilted=true
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
});;
          },
             methods:{

                SaveToExcel(){
axios({method:'PUT',url:'https://localhost:44303/api/Record/profitableproducts/savetoexcel',headers:{
                    "Accept": "application/json",
                     "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie},params:{from:this.from, to:this.to,genres:this.selectedgenre.length==0? this.Genres:[this.selectedgenre],
                 manufactures:this.selectedmanufacture.length==0? this.Manufactures:[this.selectedmanufacture], 
                  platforms:this.selectedplatform.length==0? this.Platforms:[this.selectedplatform],
                  localizations:this.selectedlocalization.length==0? this.Localizations:[this.selectedlocalization], }}).then(Response=>
                           { 
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

Submit:function(){
       console.log(this.selectedplatform)
axios({method:'GET',url:'https://localhost:44303/api/Record/profitableproducts/',headers:{
                    "Accept": "application/json",
                     "Authorization": "Bearer " + localStorage.getItem("admin")
                    ,
                    'set-cookie':document.cookie},params:{from:this.from, to:this.to,genres:this.selectedgenre.length==0? this.Genres:[this.selectedgenre],
                 manufactures:this.selectedmanufacture.length==0? this.Manufactures:[this.selectedmanufacture], 
                  platforms:this.selectedplatform.length==0? this.Platforms:[this.selectedplatform],
                  localizations:this.selectedlocalization.length==0? this.Localizations:[this.selectedlocalizations] }}).then(Response=>
                           { this.ProfitableProducts=Response.data;this.countPublication=this.ProfitableProducts.length; ;
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