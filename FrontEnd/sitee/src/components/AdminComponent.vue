<template>
<section class="form-simple">
    <mdb-row>
      <mdb-col md="5">
        <mdb-card>
          <div class="header pt-3 grey lighten-2">
            <mdb-row class="d-flex justify-content-start">
              <h3 class="deep-grey-text mt-3 mb-4 pb-1 mx-5">Log in</h3>
            </mdb-row>
          </div>
          <mdb-card-body class="mx-4 mt-4">
            <mdb-input label="Your email" type="text"/>
            <mdb-input label="Your password" type="password" containerClass="mb-0"/>
            <p class="font-small grey-text d-flex justify-content-end">Forgot <a href="#" class="dark-grey-text font-weight-bold ml-1"> Password?</a></p>
            <div class="text-center mb-4 mt-5">
              <mdb-btn color="danger" type="button" class="btn-block z-depth-2">Log in</mdb-btn>
            </div>
            <p class="font-small grey-text d-flex justify-content-center">Don't have an account? <a href="#" class="dark-grey-text font-weight-bold ml-1"> Sign up</a></p>
          </mdb-card-body>
        </mdb-card>
      </mdb-col>
    </mdb-row>
  </section>
</template>




<script>

import axios from 'axios'
  export default{
    
  props: {
  },
     
          name: 'AdminComponent',
          data(){
              return{
      
            
            
              
              
            
        
              }
          },
     

          
           
        
          
  }

</script>