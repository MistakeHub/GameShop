<template>
<div class="d-flex justify-content-center">
<b-card bg-variant="dark" class="d-flex align-items-start" text-variant="white" title="Фильтры">
 <div >
   <b-form >
  

    <b-form-group label="Жанры:"  v-slot="{ ariaDescribedby }" >
      <b-form-checkbox-group
      v-for="elem in genres"
        id="checkbox-group-2"
      
        :aria-describedby="ariaDescribedby"
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedgenres" @change="Filter()">{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
    </b-form-group>

      <b-form-group label="Издатель:"  v-slot="{ ariaDescribedby }" >
      <b-form-checkbox-group
      v-for="elem in manufactures"
        id="checkbox-group-2"
     
        :aria-describedby="ariaDescribedby"
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedmanufactures" @change="Filter()">{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
    </b-form-group>

      <b-form-group label="Палтформа:"  v-slot="{ ariaDescribedby }" >
      <b-form-checkbox-group
      v-for="elem in platforms"
        id="checkbox-group-2"
    
        :aria-describedby="ariaDescribedby"
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedplatforms" @change="Filter()">{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
    </b-form-group>

    
      <b-form-group label="Языки:"  v-slot="{ ariaDescribedby }" >
      <b-form-checkbox-group
      v-for="elem in localizations"
        id="checkbox-group-2"
       
        :aria-describedby="ariaDescribedby"
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedlocalizations"  @change="Filter()" >{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>

      
    </b-form-group>

</b-form>
  
  </div>
  <b-button href="#" variant="primary" @click.prevent="Filter()">Go somewhere</b-button>
</b-card>
<b-list-group class="">
  <b-list-group-item href="#" active class="flex-column align-items-start">
    <div class="d-flex w-100 justify-content-between">
      <h5 class="mb-1">Сортировка по</h5>
      <b-button variant="success" @click="SortByDateRealese()">Дате выхода</b-button>
       <b-button variant="success" @click="SortByTitle()">Названию</b-button>
         <b-button variant="success" @click="SortByPrice()">Цене</b-button>
           <b-button variant="success" @click="SortByRating()">Рейтингу</b-button>

         
    </div>
    <div >
   <div v-for="elem in games"  >
 
     <b-card class="d-flex justify-content-center" style="overflow: auto;   float: none;">
  <b-card-img :src="require(`../assets/${elem.titleofgame.replace(/\s+/g, '')}.jpg`)"    style="max-width: 25rem;" img-center ></b-card-img>
      <b-card-title  >
        <p class="text-danger d-flex justify-content-center">{{elem.titleofgame}}</p>
       
           
      </b-card-title>
      
      <small class="text-black-50 d-flex justify-content-center"> {{elem.dateRealese}},</small>
      <div class="d-flex justify-content-center" >  <div v-for="genre in elem.genres">  <small class="text-black-50">{{genre}},</small></div></div>
        <b class="text-primary d-flex justify-content-center"> Цена:{{elem.price}}руб</b>
      <b-button variant="success" :href="'/game/'+elem.titleofgame" >Подробнее </b-button>
     </b-card>

   </div>
    </div>

 


  </b-list-group-item>
</b-list-group>

</div>

</template>

<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'Catalog',
          data(){
              return{
      
              games:[],
              genres:[],
              manufactures:[],
              series:[],
              localizations:[],
              platforms:[],
              selectedgames:[],
               selectedgenres:[],
               selectedmanufactures:[],
               selectedseries:[],
               selectedlocalizations:[],
               selectedplatforms:[],
              
              
            
        
              }
          },
          mounted(){
            axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
             axios.get("https://localhost:44303/api/Platform").then(Response=> this.platforms=Response.data)
               axios.get("https://localhost:44303/api/Localization").then(Response=> this.localizations=Response.data)
             axios.get("https://localhost:44303/api/Series").then(Response=> this.series=Response.data)
            axios.get("https://localhost:44303/api/Manufacture").then(Response=> this.manufactures=Response.data)
            axios.get("https://localhost:44303/api/Genre").then(Response=> this.genres=Response.data)
           axios.get('https://localhost:44303/api/Catalog/1').then(Response=>{this.games=Response.data;} )
          },
          methods:{
    
             Filter:function(){
                    
           console.log(this.selectedseries)
            axios({
                method: 'GET',
                url: 'https://localhost:44303/api/Catalog/filter/',
             
                params: { genres:this.selectedgenres.length==0? this.genres:this.selectedgenres,
                 manufactures:this.selectedmanufactures.length==0? this.manufactures:this.selectedmanufactures, 
                  platforms:this.selectedplatforms.length==0? this.platforms:this.selectedplatforms,
                  localizations:this.selectedlocalizations.length==0? this.localizations:this.selectedlocalizations, 
                }
            }).then((response) => {
                 
               this.games=response.data
            });

          

             },
             SortByDateRealese:function(){

                axios({
                method: 'GET',
                url: 'https://localhost:44303/api/Catalog/sortbydaterealese/',
             
                params: { genres:this.selectedgenres.length==0? this.genres:this.selectedgenres,
                 manufactures:this.selectedmanufactures.length==0? this.manufactures:this.selectedmanufactures, 
                  platforms:this.selectedplatforms.length==0? this.platforms:this.selectedplatforms,
                  localizations:this.selectedlocalizations.length==0? this.localizations:this.selectedlocalizations, 
                }
            }).then((response) => {
                 
               this.games=response.data
            });

             },

              SortByTitle:function(){

                 axios({
                method: 'GET',
                url: 'https://localhost:44303/api/Catalog/sortbytitle/',
             
                params: { genres:this.selectedgenres.length==0? this.genres:this.selectedgenres,
                 manufactures:this.selectedmanufactures.length==0? this.manufactures:this.selectedmanufactures, 
                  platforms:this.selectedplatforms.length==0? this.platforms:this.selectedplatforms,
                  localizations:this.selectedlocalizations.length==0? this.localizations:this.selectedlocalizations, 
                }
            }).then((response) => {
                 
               this.games=response.data
            });

             },

              SortByPrice:function(){

            axios({
                method: 'GET',
                url: 'https://localhost:44303/api/Catalog/sortbyprice/',
             
                params: { genres:this.selectedgenres.length==0? this.genres:this.selectedgenres,
                 manufactures:this.selectedmanufactures.length==0? this.manufactures:this.selectedmanufactures, 
                  platforms:this.selectedplatforms.length==0? this.platforms:this.selectedplatforms,
                  localizations:this.selectedlocalizations.length==0? this.localizations:this.selectedlocalizations, 
                }
            }).then((response) => {
                 
               this.games=response.data
            });

             },

              SortByRating:function(){
  axios({
                method: 'GET',
                url: 'https://localhost:44303/api/Catalog/sortbyrating/',
             
                params: { genres:this.selectedgenres.length==0? this.genres:this.selectedgenres,
                 manufactures:this.selectedmanufactures.length==0? this.manufactures:this.selectedmanufactures, 
                  platforms:this.selectedplatforms.length==0? this.platforms:this.selectedplatforms,
                  localizations:this.selectedlocalizations.length==0? this.localizations:this.selectedlocalizations, 
                }
            }).then((response) => {
                 
               this.games=response.data
            });

             },


          }
        
    
  }

</script>