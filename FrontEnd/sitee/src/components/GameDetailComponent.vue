<template>
<div class="  d-flex justify-content-center">
<body>
 
  <div id="app">
    <div class="container container-space">
      <div class="row">
        <div class="col-md-6">
          <img class="img-fluid" :src="require(`../assets/${games.titleofgame.replace(/\s+/g, '')}.jpg`)" alt="" />
          <div class="product-thumbnails">
            <ul>
              <li  ><img :src="require(`../assets/${games.titleofgame.replace(/\s+/g, '')}.jpg`)" alt="" /></li>
            </ul>
          </div>
        </div>
        <div class="col-md-5 ">
          <h1 class="my-4"></h1>
          <h3 class="my-3">
            <svg width="36" height="36" viewBox="0 0 24 24">
              <path d="M17,18C15.89,18 15,18.89 15,20A2,2 0 0,0 17,22A2,2 0 0,0 19,20C19,18.89 18.1,18 17,18M1,2V4H3L6.6,11.59L5.24,14.04C5.09,14.32 5,14.65 5,15A2,2 0 0,0 7,17H19V15H7.42A0.25,0.25 0 0,1 7.17,14.75C7.17,14.7 7.18,14.66 7.2,14.63L8.1,13H15.55C16.3,13 16.96,12.58 17.3,11.97L20.88,5.5C20.95,5.34 21,5.17 21,5A1,1 0 0,0 20,4H5.21L4.27,2M7,18C5.89,18 5,18.89 5,20A2,2 0 0,0 7,22A2,2 0 0,0 9,20C9,18.89 8.1,18 7,18Z" />
            </svg>
            {{cart}}
          </h3>
          <h4 >{{games.titleofgame}}</h4>

        
         <div  class="d-flex align-items-end"><b> Производители:</b><div v-for="elem in games.manufactures" class="d-flex align-items-start">  <p>{{elem}}, </p></div></div>

           <div  class="d-flex align-items-start"><b> Локализация:</b><div v-for="elem in games.localizations" class="d-flex align-items-start">  <p>{{elem}}, </p></div></div>
           
           <div  class="d-flex align-items-start"><b> Жанры:</b><div v-for="elem in games.genres" class="d-flex align-items-start">  <p>{{elem}}, </p></div></div>
           
           <div  class="d-flex align-items-start"><b> Региональные ограничения:</b><div v-for="elem in games.regionRestricts" class="d-flex align-items-start">  <p>{{elem}}, </p></div></div>
           
           <div  class="d-flex align-items-start"><b> Платформы:</b><div v-for="elem in games.platforms" class="d-flex align-items-start">  <p>{{elem}}, </p></div></div>

           
           <div  class="d-flex align-items-start"><b> Серия игр:</b><div class="d-flex align-items-start">  <p>{{games.series}}, </p></div></div>

           
         
         
           
      

     

           
           <div class="description"><b> Дата Выпуска:</b><div  class="d-flex align-items-start">  <p>{{games.dateRealese}}</p></div></div>
 <div>
    <b-form-rating v-model="games.rating" ></b-form-rating>
    <p class="mt-2">Value: {{ value }}</p>
  </div>
          <h3>Цена :{{games.price}}руб</h3>
          <button type="button" class="  btn-outline-primary btn-lg btn-block btn-custom-color" @click="addToCart">
            ADD TO CART
          </button>
        </div>
      </div>
<hr>
      <div class="product-detail-columns-container">
<div class="product-detail-desc">
<div class="product-detail-tabs-btns">

<p>Ищешь где <span class="hard">купить лицензионный ключ {{games.titleofgame}}</span>? Ты пришел по адресу!<br>

<hr>

<p style="margin-left:0cm; margin-right:0cm">{{games.description}}</p>

<hr>


</div>

  </div>
</div>
</div>
 </div>
  
  

  
    
 

</body>


</div>
</template>



<style clas>

.product-detail-columns-container {
    display: -webkit-box;
    display: -webkit-flex;
    display: -ms-flexbox;
    display: flex;
    margin-top: 20px;
    -webkit-box-pack: justify;
    -webkit-justify-content: space-between;
    -ms-flex-pack: justify;
    justify-content: space-between;
}
.product-detail-desc {
    width: 732px;
    background-color: #fafafa;
}

.product-detail-tabs{position:relative;box-sizing:border-box;width:100%;min-height:100px;padding:20px 20px 20px 125px;color:#434343;background:#fff}

body {
  font-family: "Nunito", sans-serif;
  background-color: #eeeeee;
}
#container-space {
  margin-top: 2rem;
}
#product-thumbnails {
  display: flex;
  margin-top: 2rem;
}
.product-thumbnails > ul {
  display: flex;
  list-style: none;
  padding-left: 0;
}
.product-thumbnails > li {
  margin-right: 10px;
}
.product-thumbnails > ul > li > img {
  width: 100px;
  cursor: pointer;
}
.thumbnail-active {
  border: 2px solid #000;
}
.nav-link > img {
  width: 40px;
  border-radius: 8px;
  margin-right: 10px;
}
.btn-custom-color {
  border: 2px solid #4fc08d;
  color: #4fc08d;
}
.btn-custom-color:hover {
  border: 2px solid #4fc08d;
  background-color: #4fc08d;
  color: #ffffff;
}
.desctiption{line-height:32px;position:relative;margin-bottom:30px;padding-bottom:25px}


</style>
<script>
import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'GameDetailComponent',
          data(){
              return{
      
              games:{},
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
          axios({
                method: 'GET',
                url: 'https://localhost:44303/api/GameDetail/'+this.$route.params.titleofgame ,
             
              
            }).then((response) => {
                 
               this.games=response.data
            });
          },
          methods:{
    
           addToCart:function(){



           }

        
    
  }
          
  }

</script>