<template>
<div>
   
 <!-- Header -->

<div class="fs_menu_overlay"></div>
<div class="hamburger_menu">
  <div class="hamburger_close"><i class="fa fa-times" aria-hidden="true"></i></div>
  <div class="hamburger_menu_content text-right">
    <ul class="menu_top_nav">
      <li class="menu_item has-children">
        <a href="#">
          usd
          <i class="fa fa-angle-down"></i>
        </a>
        <ul class="menu_selection">
          <li><a href="#">cad</a></li>
          <li><a href="#">aud</a></li>
          <li><a href="#">eur</a></li>
          <li><a href="#">gbp</a></li>
        </ul>
      </li>
      <li class="menu_item has-children">
        <a href="#">
          English
          <i class="fa fa-angle-down"></i>
        </a>
        <ul class="menu_selection">
          <li><a href="#">French</a></li>
          <li><a href="#">Italian</a></li>
          <li><a href="#">German</a></li>
          <li><a href="#">Spanish</a></li>
        </ul>
      </li>
      <li class="menu_item has-children">
        <a href="#">
          My Account
          <i class="fa fa-angle-down"></i>
        </a>
        <ul class="menu_selection">
          <li><a href="#"><i class="fa fa-sign-in" aria-hidden="true"></i>Sign In</a></li>
          <li><a href="#"><i class="fa fa-user-plus" aria-hidden="true"></i>Register</a></li>
        </ul>
      </li>
      <li class="menu_item"><a href="#">home</a></li>
      <li class="menu_item"><a href="#">shop</a></li>
      <li class="menu_item"><a href="#">promotion</a></li>
      <li class="menu_item"><a href="#">pages</a></li>
      <li class="menu_item"><a href="#">blog</a></li>
      <li class="menu_item"><a href="#">contact</a></li>
    </ul>
  </div>
</div>
<!-- Slider -->
<div class="main_slider " style="background-image:url(assets/images/osaMlV.png) ">
  <div class="container fill_height">
    <div class="row align-items-center fill_height">
      <div class="col">
        <div class="main_slider_content">
            <div class="logo_container">
            <a href="#">Game<span>Shop</span></a>
          </div>
         
        </div>
      </div>
    </div>
  </div>
</div>
<!-- Banner -->

<!-- New Arrivals -->
<div class="new_arrivals bg-dark row" >
  <div class="container">
    <div class="row">
      <div class="col text-center">
        <div class="section_title new_arrivals_title">
          <h2>Новинки</h2>
        </div>
      </div>
    </div>
  <div class="row">
 <div class="container  px-lg-4 "  v-for="item in games" style="max-width:700px;">
       <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center  " >
            <div class="col " style="display:table-cell;">
                <div class="card h-100" style="width:200px; display:table-cell;">
                    <!-- Product image-->
                    <img class="card-img-top" style="max-height:120px" :src="item.images[0]" alt="...">
                    <!-- Product details-->
                    <div class="card-body p-3">
                        <div class="text-center">
                            <!-- Product name-->
                            <a href="#" ><h5 class="fw-bolder">{{item.titleofgame}}</h5></a>
                            <!-- Product price-->
                         {{item.price}} руб
                        </div>
                        <br>
                         <div class="card-footer p-4 pt-2 border-top-0 ">
                        <div class="text-left" ><a class="btn btn-green " style="color:black;"  :href="'/game/'+item.titleofgame">Подробнее...</a></div>
                    </div>
                    </div>
                    <!-- Product actions-->
                   
                </div>
            </div>
         
        </div>
            </div>
  </div>
  </div>
</div>
<!-- Deal of the week -->
<div class="deal_ofthe_week">
  <div class="container">
    <div class="row align-items-center">
      <div class="col-lg-6">
        <div class="deal_ofthe_week_img">
          <img src="assets/images/150-1501332_grand-theft-auto-v-game-png-hd-background.png" alt="">
        </div>
      </div>
      <div class="col-lg-6 text-right deal_ofthe_week_col">
        <div class="deal_ofthe_week_content d-flex flex-column align-items-center float-right">
         
          
          <div class="red_button deal_ofthe_week_button"><a href="/catalog">каталог</a></div>
        </div>
      </div>
    </div>
  </div>
</div>
<!-- Best Sellers -->

<!-- Benefit -->

<!-- Footer -->
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
                    "Authorization": "Bearer " + localStorage.getItem("user") ,
                    'set-cookie':document.cookie // передача токена в заголовке
                }}).then(Response =>{this.games=Response.data;       console.log(this.games[0].images[0]); });
                console.log(this.games);
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

