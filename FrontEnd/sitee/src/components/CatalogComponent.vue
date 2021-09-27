<template>
<div style="    padding-top: 10%;">
<div class="d-flex justify-content-center"  >
<b-card bg-variant="dark" class="d-flex align-items-start" text-variant="white" style="text-white "  >
 <div style="width:200px" >
   <b-card-title class="text-white">Фильтры</b-card-title>
   <br>

    
   <b-form >
     <div class="d-flex align-items-start">
 
     </div>
     <b-form-group label="Жанры" v-b-toggle.my-collapse v-slot="{ ariaDescribedby }" >
 <b-collapse id="my-collapse">
    
      
      <b-form-checkbox-group
      v-for="elem in genres"
        id="checkbox-group-2"
      
        :aria-describedby="ariaDescribedby"
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedgenres" @change="Filter()">{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
       </b-collapse>
    </b-form-group>
   <b-form-group label="Производители" v-b-toggle.my-collapse2 v-slot="{ ariaDescribedby }" >
<b-collapse id="my-collapse2">
   
      <b-form-checkbox-group
      v-for="elem in manufactures"
        id="checkbox-group-2"
     
        :aria-describedby="ariaDescribedby"
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedmanufactures" @change="Filter()">{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
      </b-collapse>
    </b-form-group>
 
    <b-form-group label="Платформы:" v-b-toggle.my-collapse3 v-slot="{ ariaDescribedby }" >
<b-collapse id="my-collapse3">
   
      <b-form-checkbox-group
      v-for="elem in platforms"
        id="checkbox-group-2"
    
        :aria-describedby="ariaDescribedby"
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedplatforms" @change="Filter()">{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>
      </b-collapse>
    </b-form-group>

 
      <b-form-group label="Языки:" v-b-toggle.my-collapse4  v-slot="{ ariaDescribedby }" >
<b-collapse id="my-collapse4">
    
      <b-form-checkbox-group
      v-for="elem in localizations"
        id="checkbox-group-2"
       
        :aria-describedby="ariaDescribedby"
        name="flavour-2"
      >
        <b-form-checkbox :value=elem class="d-flex justify-content-start"  v-model="selectedlocalizations"  @change="Filter()" >{{elem}}</b-form-checkbox>
     
      </b-form-checkbox-group>

      </b-collapse>
    </b-form-group>
 <label> Цена (	&#8381):</label>
    <vue-slider v-model="value3"  :min-range="0"
      :max-range="50000" :marks="[0, 4000]"  @dragleave="Filter()"  :min="min"
      :max="max" ></vue-slider>
      <b-button variant="success" @click="Filter()">OK</b-button>

</b-form>

  </div>
 
</b-card>
<b-list-group class="bg-white" style="width:700px">
    
  <b-list-group-item   active class="flex-column align-items-start bg-white">
    <h5 class="mb-1 text-dark">Сортировка по:</h5>
    <div>
    
      

      <b-button variant="success" @click="SortByDateRealese()">Дате выхода</b-button>
       <b-button variant="success" @click="SortByTitle()">Названию</b-button>
         <b-button variant="success" @click="SortByPrice()">Цене</b-button>
           <b-button variant="success" @click="SortByRating()">Рейтингу</b-button>

         
    </div>
    <div >
    </div>
     <div>
          <b-col sm="3">
        <label for="title">Поиск</label>
      </b-col>
      <b-col sm="9">
          <b-input-group prepend="Поиск" class="mb-2">
        <b-form-input id="title" type="text" v-model="search"></b-form-input>
          </b-input-group>
      </b-col>
      <br>
    
   <div v-for="elem in filteredItems" >
 
     <b-card class="d-flex justify-content-center" style="overflow: auto;   float: none;">
  <img :src="elem.images[0]" style="max-width: 25rem;" img-center />
      <b-card-title  >
        <p class="text-danger d-flex justify-content-center">{{elem.titleofgame}}</p>
       
           
      </b-card-title>
      
      <small class="text-black-50 d-flex justify-content-center"> {{elem.dateRealese}},</small>
      <div class="d-flex justify-content-center" >  <div v-for="genre in elem.genres">  <small class="text-black-50">{{genre}},</small></div></div>
        <b class="text-primary d-flex justify-content-center"> Цена:{{elem.price}}руб</b>
      <b-button variant="success" class="text-white" :href="'/game/'+elem.titleofgame" >Подробнее </b-button>
     </b-card>

   </div>
    </div>

 


  </b-list-group-item>
  <div >
  <b-pagination
      v-model="currentpage"
      :total-rows="count"
      :per-page="pagesize"
      aria-controls="my-table"
      class="customPagination"
      @change="handlePageChange"
    ></b-pagination>
  </div>
</b-list-group>


</div>
</div>

</template>

<style>
.customPagination > li > a {
  color: red;
}

.range-slider {
  width: 300px;
  margin: auto;
  text-align: center;
  position: relative;
  height: 6em;
}

.range-slider input[type=range] {
  position: absolute;
  left: 0;
  bottom: 0;
}

input[type=number] {
  border: 1px solid #ddd;
  text-align: center;
  font-size: 1.6em;
  -moz-appearance: textfield;
}

input[type=number]::-webkit-outer-spin-button,
input[type=number]::-webkit-inner-spin-button {
  -webkit-appearance: none;
}

input[type=number]:invalid,
input[type=number]:out-of-range {
  border: 2px solid #ff6347;
}

input[type=range] {
  -webkit-appearance: none;
  width: 100%;
}

input[type=range]:focus {
  outline: none;
}

input[type=range]:focus::-webkit-slider-runnable-track {
  background: #2497e3;
}

input[type=range]:focus::-ms-fill-lower {
  background: #2497e3;
}

input[type=range]:focus::-ms-fill-upper {
  background: #2497e3;
}

input[type=range]::-webkit-slider-runnable-track {
  width: 100%;
  height: 5px;
  cursor: pointer;
  animate: 0.2s;
  background: #2497e3;
  border-radius: 1px;
  box-shadow: none;
  border: 0;
}

input[type=range]::-webkit-slider-thumb {
  z-index: 2;
  position: relative;
  box-shadow: 0px 0px 0px #000;
  border: 1px solid #2497e3;
  height: 18px;
  width: 18px;
  border-radius: 25px;
  background: #a1d0ff;
  cursor: pointer;
  -webkit-appearance: none;
  margin-top: -7px;
}

</style>
<script>



import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'Catalog',
          data(){
              return{
      search:'',
      value3:[10,4000],
 min: 0,
        max: 4000,
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
               currentpage:1,
               count:9,
               pagesize:3,
               isfilted:false,
               isSorted:false,
               sliderdata:[0,10000]
            
              
              
            
        
              }
          },
          mounted(){
              if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
            axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
             axios.get("https://localhost:44303/api/Platform").then(Response=> this.platforms=Response.data)
               axios.get("https://localhost:44303/api/Localization").then(Response=> this.localizations=Response.data)
             axios.get("https://localhost:44303/api/Series").then(Response=> this.series=Response.data)
            axios.get("https://localhost:44303/api/Manufacture").then(Response=> this.manufactures=Response.data)
            axios.get("https://localhost:44303/api/Genre").then(Response=> this.genres=Response.data)
           axios({method: 'GET', url:'https://localhost:44303/api/Catalog/1', params:{pagesize:3}}).then(Response=>{   this.games=Response.data.item1; console.log(this.games);this.count=Response.data.item2  } )
          },
                  computed: {
    filteredItems () {
      return this.games.filter(item => {
         return item.titleofgame.toLowerCase().indexOf(this.search.toLowerCase()) > -1
      })
    }
    
              
            
        
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
                  pricefrom:this.value3[0], priceto:this.value3[1] 
                }
            }).then((response) => {
                 
                this.games=response.data.item1; this.count = response.data.item2 / this.pagesize;
                console.log(this.games)
                 this.isfilted=true
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
                    pricefrom:this.value3[0], priceto:this.value3[1] 
                }
            }).then((response) => {
                 
               this.games=response.data.item1; this.count = response.data.item2 / this.pagesize;
                 this.isfilted=true
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
                    pricefrom:this.value3[0], priceto:this.value3[1]  
                }
            }).then((response) => {
                 
              this.games=response.data.item1; this.count = response.data.item2 / this.pagesize;
                 this.isfilted=true
                 console.log(this.games)
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
                    pricefrom:this.value3[0], priceto:this.value3[1] 
                }
            }).then((response) => {
                 
              this.games=response.data.item1; this.count = response.data.item2/ this.pagesize;
               this.isfilted=true
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
                    pricefrom:this.value3[0], priceto:this.value3[1] 
                }
            }).then((response) => {
                 
             this.games=response.data.item1; this.count =response.data.item2 / this.pagesize;
                 this.isfilted=true
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
});

             },

             GetGames:function(){
                    

                  axios({method: 'GET', url:'https://localhost:44303/api/Catalog/'+this.currentpage, headers:{
                    'set-cookie':document.cookie},params:{pagesize:3}}).then(Response=>{ this.games=Response.data.item1; } )

             },

             handlePageChange(value) {
             
               this.currentpage=value
                     console.log(this.currentpage)
                   if(this.isfilted == false){ this.GetGames(); }
                   else this.Filter();
    
    },




          }
        
    
  }

</script>