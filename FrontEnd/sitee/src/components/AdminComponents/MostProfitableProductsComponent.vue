<template  >
<div >

 
<div >
    <h2>Самые прибыльные игры </h2>
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
    <b-table label="asdas" striped hover  id="table2" :items="ProfitableProducts" :per-page="pagesize" :current-page="currentpage"  >    
       
      
     

      
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
                if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
           axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
             axios.get("https://localhost:44303/api/Platform").then(Response=> this.Platforms=Response.data)
               axios.get("https://localhost:44303/api/Localization").then(Response=> this.Localizations=Response.data)
             axios.get("https://localhost:44303/api/Series").then(Response=> this.Series=Response.data)
            axios.get("https://localhost:44303/api/Manufacture").then(Response=> this.Manufactures=Response.data)
            axios.get("https://localhost:44303/api/Genre").then(Response=> {this.Genres=Response.data; console.log(this.Genres)})
                     
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
            });
          },
             methods:{

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
                } )  
},
Reset:function(){

  this.from=""
  this.to=""
  this.Submit()
}

          }
           
        
          
  }
         

</script>