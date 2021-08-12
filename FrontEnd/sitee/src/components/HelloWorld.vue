<template>
<div>
 
 <div  >
   <b-carousel 
    id="carousel-fade"
    style="text-shadow: 0px 0px 2px #000;"
    fade
    indicators
   
  >
    
    <b-carousel-slide v-for="elem in games"   >

     <img
          slot="img"

         style=" max-width:700px;   min-height:500px"
          :src="require(`../assets/${elem.titleofgame.replace(/\s+/g, '')}.jpg`)"
          alt="image slot"
        >
        <b-card-title class=" badge bg-primary text-wrap fs-4">  {{elem.titleofgame}} </b-card-title>
        <b-button variant="success" class="fs-5" :href="'/game/'+elem.titleofgame">Подробнее</b-button>
        
    </b-carousel-slide>
  </b-carousel>

  
  </div>
<h1 class="badge bg-primary text-wrap fs-1" > Новинки:</h1>
<div class="d-flex justify-content-center">
        <b-card-group v-for="elem in games" style="display:table-cell; widht:18 rem">
  <b-card
    
   
    img-alt="Image"
    img-top
    tag="article"
    style="max-width: 20rem;"
    class="mb-2"
  >
  <b-card-img :src="require(`../assets/${elem.titleofgame.replace(/\s+/g, '')}.jpg`)"> </b-card-img>
       <b-card-title>
      {{elem.titleofgame}}
    </b-card-title>

    <b-card-text>
      {{elem.description}}
    </b-card-text>

    <b-button href="#" variant="primary" :href="'/game/'+elem.titleofgame">Подробнее</b-button>
  </b-card>
        </b-card-group>
</div>
</div>

    
</template>

<script>

import axios from 'axios'
  export default{
  props: {
  },
     
          name: 'HelloWorld',
          data(){
              return{
                 slide: 0,
        sliding: null,
              games:[]
              }
          },
          mounted(){

           axios.get('https://localhost:44303/api/Home',{headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("user")  // передача токена в заголовке
                }}).then(Response =>this.games=Response.data );
                console.log(localStorage.getItem("user"));
          },
          methods: {
              setMessage: function(event){
                  this.message = event.target.value;
              },
     onSlideStart(slide) {
        this.sliding = true
      },
      onSlideEnd(slide) {
        this.sliding = false
      },
      

      
   
          }
    
  }

</script>

