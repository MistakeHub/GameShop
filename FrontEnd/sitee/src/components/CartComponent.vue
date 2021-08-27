<template>
   <div class="container">                
<div class="contentbar">                
        <!-- Start row -->
        <div class="row">
            <!-- Start col -->
            <div class="col-md-12 col-lg-12 col-xl-12">
                <div class="card m-b-30">
                    <div class="card-header">
                        <h5 class="card-title">Cart</h5>
                    </div>
                    <div class="card-body">
                        <div class="row justify-content-center">
                            <div class="col-lg-10 col-xl-8">
                                <div class="cart-container">
                                    <div class="cart-head">
                                        <div class="table-responsive">
                                            <table class="table table-borderless">
                                                <thead>
                                                    <tr>
                                                     
                                                        <th scope="col">Действие</th>                                               
                                                        <th scope="col">Фото</th>
                                                        <th scope="col">Название</th>
                                                    
                                                        <th scope="col">Цена</th>
                                                        <th scope="col" class="text-right">Total</th>
                                                    </tr>
                                                </thead>
                                                <tbody v-for="elem in cart.publication">
                                                    <tr>
                                                      
                                                        <td><a href="#" @click="RemoveFromCart(elem)"  class="text-danger" >Убрать<i class="ri-delete-bin-3-line"></i></a></td>
                                                        <td><img :src="elem.images[0].url" class="img-fluid" width="35" alt="product"></td>
                                                        <td>{{elem.game.titleofgame}}</td>
                                                        <td>
                                                           
                                                        </td>
                                                        <td>{{elem.price}}</td>
                                                        <td class="text-right"></td>
                                                    </tr>
                                                   
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="cart-body">
                                        
                                            <div class="col-md-12 order-1 order-lg-2 col-lg-7 col-xl-6">
                                                <div class="order-total table-responsive ">
                                                    <table class="table table-borderless text-right">
                                                        <tbody>
                                                          
                                                                <td class="f-w-7 font-18"><h4>Итого :</h4></td>
                                                                <td class="f-w-7 font-18"><h4>{{cart.sumof}}</h4></td>
                                                           
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="cart-footer text-right">
                                      
                                        <a :href="'/cart/AcceptPurchase/'+cart.id" class="btn btn-success my-1" >Оплатить<i class="ri-arrow-right-line ml-2"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End col -->
        </div>
        <!-- End row -->
    </div>
    </div>
</template>

<style>
body{
    background: #f4f5f7;
    margin-top:20px;
}
.cart-container {
  border: 1px solid rgba(0, 0, 0, 0.05);
  padding: 30px;
}
.cart-container .cart-body {
  border-top: 1px solid rgba(0, 0, 0, 0.05);
  border-bottom: 1px solid rgba(0, 0, 0, 0.05);
  padding: 30px 0 20px;
  margin: 20px 0 30px;
}
</style>

<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'CartComponent',
          data(){
              return{
      
              cart:{},
              selectedimage:""
            
              
              
            
        
              }
          },
          mounted(){
            axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
                           
         axios({
                method: 'GET',
                url: 'https://localhost:44303/api/Cart/'+this.$route.params.user ,
             
              
            }).then((response) => {
                 
               this.cart=response.data
               console.log(this.cart)
           
               
            
                
            });

         
     
          },
          methods:{
    
             RemoveFromCart:function(elem){
     
           axios({
                method: 'DELETE',
                url: 'https://localhost:44303/api/Cart/'+this.$route.params.user ,
                params:{ game:elem.game.titleofgame}
             
              
            }).then((response) => {
                 
               window.location.reload();
            
               
            
                
            });
          

             },

          
           
        
          }
  }

</script>