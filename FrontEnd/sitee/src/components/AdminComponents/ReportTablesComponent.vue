<template  >
<div class="row" >
<div class="column">
    <h2>Самые продаваемые продукты </h2>
    <b-table striped hover  id="table1" :items="PurcheasableProducts" :per-page="pagesize" :current-page="currentpage" >    
       
      
     

      
      </b-table>



    
      <b-pagination
      v-model="currentpage"
      :total-rows="countPublication"
      :per-page="pagesize"
      aria-controls="table1"
    >
    
    
 
    </b-pagination>
</div>
 
<div class="column">
    <h2>Самые прибыльные игры </h2>
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


  <b-modal ref="bv-modal-example2" hide-footer>
    <template #modal-title>
    <h1>Редактирование</h1>
    </template>
    
    <div class="d-block text-center">
      <label>навзание</label>
      <b-input v-model="title"></b-input>
    </div>
    <b-button class="mt-3" block @click="EditElement()">Подтвердить </b-button>
  </b-modal>
</div>
   <router-view></router-view>
  
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
     
          name: 'ReportTablesComponent',
          data(){
              return{
              
            
             PurcheasableProducts:[   ],
            
                 ProfitableProducts:[   ],
                 currentpage:1,
               countPublication:9,
               pagesize:3,
               Type:"",
               title:"",
               
              
              
              
            
        
              }
          },
          mounted(){
          
                     axios.get('https://localhost:44303/api/Record/purcheasableproducts').then(Response=>
                           { this.PurcheasableProducts=Response.data;this.countPublication=this.PurcheasableProducts.length; ;
              console.log(Response.data); 
                } )   
     axios.get('https://localhost:44303/api/Record/profitableproducts').then(Response=>
                           { this.ProfitableProducts=Response.data ;
              console.log(this.ProfitableProducts); 
                } )  
                        

                          
          },
           
        
          
  }

</script>