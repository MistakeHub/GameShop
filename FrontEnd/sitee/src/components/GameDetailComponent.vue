<template>
<div class="  d-flex justify-content-center">
<body>
 
  <div id="app">
    <div class="container container-space">
      <div class="row">
        <div class="col-md-6" >
          <div style="min-height:1px;" width="500px">
          <img class="img-fluid"  style="min-height:400px; max-height:500px;" width="600px" :src="selectedimage" alt="" />
          </div>
          <div class="product-thumbnails" >
            <ul >
              <li v-for="item in games.images" ><img v-bind:class="selectedimage===item? 'selected' : 'img'"
    :src="item" alt="" @click="selectimage(item)"/></li>
            </ul>
          </div>
            <b-form-rating v-model="games.rating" @change="setRating(games.id)" ></b-form-rating>
        </div>
        
        <div class="col-md-5 ">
          <h1 class="my-4"></h1>
          <h3 class="my-3">
            <svg width="36" height="36" viewBox="0 0 24 24">
              <path d="M17,18C15.89,18 15,18.89 15,20A2,2 0 0,0 17,22A2,2 0 0,0 19,20C19,18.89 18.1,18 17,18M1,2V4H3L6.6,11.59L5.24,14.04C5.09,14.32 5,14.65 5,15A2,2 0 0,0 7,17H19V15H7.42A0.25,0.25 0 0,1 7.17,14.75C7.17,14.7 7.18,14.66 7.2,14.63L8.1,13H15.55C16.3,13 16.96,12.58 17.3,11.97L20.88,5.5C20.95,5.34 21,5.17 21,5A1,1 0 0,0 20,4H5.21L4.27,2M7,18C5.89,18 5,18.89 5,20A2,2 0 0,0 7,22A2,2 0 0,0 9,20C9,18.89 8.1,18 7,18Z" />
            </svg>
          
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
  
   
  </div>
          <h3>Цена :{{games.price}}руб</h3>
          <b-button v-b-modal.modal-1 type="button" class="  btn-outline-primary btn-lg btn-block btn-custom-color" @click="addToCart()" > 
            В корзину
          </b-button>
 

  <b-modal id="modal-1" v-bind:title="resultcode===200?'Товар Успешно Добавлен' : 'Ошибка!' " ref="cart-modal">
    <div v-if="resultcode===200">
     
     <table class="table table-borderless">
                                                <thead>
                                                    <tr>
                                                     
                                                                                                     
                                                        <th scope="col">Фото</th>
                                                        <th scope="col">Название</th>
                                                    
                                                        <th scope="col">Цена</th>
                                                      
                                                    </tr>
                                                </thead>
                                                <tbody >
                                                    <tr>
                                                      
                                                       
                                                        <td><img :src="games.images[0]" class="img-fluid" width="100" ></td>
                                                        <td>{{games.titleofgame}}</td>
                                                       
                                                        <td>{{games.price}}</td>
                                                        <td class="text-right"></td>
                                                    </tr>
                                                   
                                                </tbody>
                                            </table>
    </div>
  </b-modal>
        </div>
      </div>
<hr>
      <div class="product-detail-columns-container">
<div >
<div >

<p>Ищешь где <span >купить лицензионный ключ {{games.titleofgame}}</span>? Ты пришел по адресу!<br>

<hr>

<p style="overflow:float;">{{games.description}}</p>

<hr>
 
</div>


  </div>
</div>
</div>
 </div>
  
  
<div class="container mt-5 mb-5">
    <div class="d-flex justify-content-center row">
        <div class="d-flex flex-column col-md-8">
            <div class="d-flex flex-row align-items-center text-left comment-top p-2 bg-white border-bottom px-4">
                <div class="profile-image"><img class="rounded-circle" src="https://i.imgur.com/t9toMAQ.jpg" width="70"></div>
                <div class="d-flex flex-column-reverse flex-grow-0 align-items-center votings ml-1"><i class="fa fa-sort-up fa-2x hit-voting"></i><span>127</span><i class="fa fa-sort-down fa-2x hit-voting"></i></div>
                <div class="d-flex flex-column ml-3">
                    <div class="d-flex flex-row post-title">
                        <h5>{Is sketch 3.9.1 stable?}</h5><span class="ml-2">(Jesshead)</span>
                    </div>
                    <div class="d-flex flex-row align-items-center align-content-center post-title"><span class="bdge mr-1">video</span><span class="mr-2 comments">13 comments&nbsp;</span><span class="mr-2 dot"></span><span>6 hours ago</span></div>
                </div>
            </div>
            <div class="coment-bottom bg-white p-2 px-4">
                <div class="d-flex flex-row add-comment-section mt-4 mb-4"><img class="img-fluid img-responsive rounded-circle mr-2"  width="38"><input type="text" class="form-control mr-3" placeholder="Add comment" v-model="comment"> <button class="btn btn-primary" type="button" @click="addComment()">Comment</button></div>
               <div class="card p-3" v-for="item in games.comments">
                <div class="d-flex justify-content-between align-items-center">
                    <div class="user d-flex flex-row align-items-center"> <img src="https://i.imgur.com/hczKIze.jpg" width="30" class="user-img rounded-circle mr-2"> <span><small class="font-weight-bold text-primary">{{username}}</small> <small class="font-weight-bold">{{item.text}}</small></span> </div> <small>2 days ago</small>
                </div>
                <div class="action d-flex justify-content-between mt-2 align-items-center">
                    <div class="reply px-4"> <small>Remove</small> <span class="dots"></span> <small>Reply</small> <span class="dots"></span> <small>Translate</small> </div>
                    <div class="icons align-items-center"> <i class="fa fa-star text-warning"></i> <i class="fa fa-check-circle-o check-icon"></i> </div>
                </div>
            </div>
              
            </div>
        </div>
    </div>
</div>
  
    
 

</body>


</div>
</template>



<style clas>

*{
    padding: 0;
    margin: 0;
    font-family: Arial, Helvetica, sans-serif;
    font-size: 16px;
}

#demo{
    margin: 20px 0 0 0;
}

.comment-form{
    display: block;
    width: 80%;
    margin: auto;
}

textarea{
    width: 100%;
    border: 2px solid #ccc;
    border-radius: 7px;
    height: 70px;
    font-family: Verdana, Helvetica, sans-serif;
    padding: 5px;
}

input{
    border: 2px solid #ccc;
    border-radius: 5px;
    padding: 5px;
}

button{
    background: #333;
    color: #ccc;
    border: 0;
    padding: 5px;
    cursor: pointer;
}

/*Comment Box*/

.comments-box{
    width: 40%;
    margin: auto;
    padding: 20px 0;
    border-bottom: 1px solid #000;
}

.delete{
    background: red;
    color: #fff;
    font-size: 12px;
    cursor: pointer;
    display: inline;
    padding: 3px;
}

.author{
    margin: 10px 0;
    font-weight: bold;
}

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

.img{ min-height:50px; max-height:50px; margin-left: 10px; margin-top:10px;}
.product-detail-tabs{position:relative;box-sizing:border-box;width:100%;min-height:100px;padding:20px 20px 20px 125px;color:#434343;background:#fff}
.selected{
   box-shadow:0px 12px 22px 1px #333;
   min-height:50px; max-height:50px; margin-left: 10px; margin-top:10px;
}

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
body {
    background-color: #eee
}

.bdge {
    height: 21px;
    background-color: orange;
    color: #fff;
    font-size: 11px;
    padding: 8px;
    border-radius: 4px;
    line-height: 3px
}

.comments {
    text-decoration: underline;
    text-underline-position: under;
    cursor: pointer
}

.dot {
    height: 7px;
    width: 7px;
    margin-top: 3px;
    background-color: #bbb;
    border-radius: 50%;
    display: inline-block
}

.hit-voting:hover {
    color: blue
}

.hit-voting {
    cursor: pointer
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
               selectedimage:"",
               resultcode:0,
               comment:"",
               username:localStorage.getItem("username")
            
              
              
            
        
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
                console.log(this.games)
                 this.selectedimage=this.games.images[0]
            });
           
              
              
          },
          methods:{
    
           addToCart:function(){
                 axios({
                method: 'POST',
                url: 'https://localhost:44303/api/Cart/',
             
                params: { username:localStorage.getItem("username"), game:this.games.titleofgame
                }
            }).then((response) => {
                  this.resultcode=response.status;
                this.$refs['cart-modal'].show();
            });

            

           },
          
           showimgur:function(){
             axios({
method:"GET",
url:"https://api.imgur.com/3/image/HgVYU3U",
headers:{
Authorization:"Bearer 3641054d57d0b5106c837d64d0a6f2b43746b8eb",


}

              }).then((response) => {
                 
               this.src=response.data.link
            });

           },
           selectimage:function(image){

                    this.selectedimage=image
                    console.log(this.selectedimage)

           },
            setRating:function(id){

                 axios({
                method: 'PUT',
                url: 'https://localhost:44303/api/GameDetail/',
             
                params: { username:this.username, idpublication:id, numberofmark:this.games.rating
                }
            }).then((response) => {
                 
               this.resultcode=response.status;
            });


           },
           addComment:function(){

             axios({
                method: 'PUT',
                url: 'https://localhost:44303/api/GameDetail/addComment',
             
                params: { username:localStorage.getItem("username"), idpublication:this.games.id, text:this.comment
                }
            }).then((response) => {
                 
               this.games.comments=response.data;
            });


           }
        
    
  }
          
  }

</script>