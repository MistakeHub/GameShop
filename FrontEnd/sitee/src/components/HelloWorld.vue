<template>
<div>
 
 <div  >
   <b-carousel 
    id="carousel-fade"
    style="text-shadow: 0px 0px 2px #000"
    fade
    indicators
    img-width="1024"
    img-height="480"
  >
    
    <b-carousel-slide v-for="elem in games"  >

     <img
          slot="img"
         
          width="1200"
          height="480"
          :src="require(`../assets/${elem.titleofgame.replace(/\s+/g, '')}.jpg`)"
          alt="image slot"
        >
        <b-card-title class=" badge bg-primary text-wrap fs-4">  {{elem.titleofgame}} </b-card-title>
        <b-button variant="success" class="fs-5">Подробнее</b-button>
        
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

    <b-button href="#" variant="primary">Подробнее</b-button>
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

           axios.get('https://localhost:44303/api/Home').then(Response =>this.games=Response.data );
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
      }
   
          }
    
  }

</script>

