<template :style="Login.bgImg">
<body  >
  <div id="app" :style="Login.bgImg"  >
   <div>
   <div>
   <b-card title="Card Title" no-body  >
    <b-card-header header-tag="nav" variant="dark">
      <b-nav>
        <b-navbar-brand active href="/" variant="dark">GameShop</b-navbar-brand>
        <b-nav-item active href="/catalog">Каталог</b-nav-item>
        <i class="fa" style="font-size:24px">&#xf07a;</i>

         <b-nav-item active :href="'/cart/'+Login.user" v-if="Login.local !==null">Корзина</b-nav-item>


        <b-dropdown v-if="Login.local==null" text="вход" variant="success" class="m-2">
    <!-- Default form login -->
   <form @submit.prevent="loginUser">
    <p class="h4 text-center mb-4">Sign in</p>
    <label for="defaultFormLoginEmailEx" class="grey-text">Your Login</label>
    <input type="text" id="defaultFormLoginEmailEx" class="form-control" v-model="Login.login"/>
    <br/>
    <label for="defaultFormLoginPasswordEx" class="grey-text">Your password</label>
    <input type="password" id="defaultFormLoginPasswordEx" class="form-control" v-model="Login.password"/>
    <div class="text-center mt-4">
      <b-button class="btn btn-indigo" type="submit" variant="success">Login</b-button>
    </div>
    <div class="modal-footer">
                    <div class="options font-weight-light">
                        <p>Ещё не зарегистрированны? <a href="#">Sign Up</a></p>
                        <p>Забыли пароль? <a href="#">Password?</a></p>
                    </div>
                </div>
   </form>
 
  <!-- Default form login -->
   </b-dropdown>
  
    <b-nav-item  v-if="Login.local!==null" @click="Logout">выход</b-nav-item>
       <b-nav-item  v-if="Login.local!==null">Здравствуйте,{{Login.user}}</b-nav-item>
      </b-nav>
    </b-card-header>

    
    
    
   </b-card>

    
   </div>
   </div>
   
    <router-view/>
   <!-- Footer -->
   <footer class="text-center text-lg-start bg-dark text-muted " >
   <!-- Section: Social media -->
   <section
    class="d-flex justify-content-center justify-content-lg-between p-4 border-bottom"
   >
    <!-- Left -->
    <div class="me-5 d-none d-lg-block">
      <span>Get connected with us on social networks:</span>
    </div>
    <!-- Left -->

    <!-- Right -->
    <div>
      <a href="" class="me-4 text-reset">
        <i class="fab fa-facebook-f"></i>
      </a>
      <a href="" class="me-4 text-reset">
        <i class="fab fa-twitter"></i>
      </a>
      <a href="" class="me-4 text-reset">
        <i class="fab fa-google"></i>
      </a>
      <a href="" class="me-4 text-reset">
        <i class="fab fa-instagram"></i>
      </a>
      <a href="" class="me-4 text-reset">
        <i class="fab fa-linkedin"></i>
      </a>
      <a href="" class="me-4 text-reset">
        <i class="fab fa-github"></i>
      </a>
    </div>
    <!-- Right -->
   </section>
   <!-- Section: Social media -->

   <!-- Section: Links  -->

   <section class="">
    <div class="container text-center text-md-start mt-5 ">
      <!-- Grid row -->
      <div class="row mt-3">
        <!-- Grid column -->
        <div class="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">
          <!-- Content -->
          <h6 class="text-uppercase fw-bold mb-4">
            <i class="fas fa-gem me-3"></i>Company name
          </h6>
          <p>
            Here you can use rows and columns to organize your footer content. Lorem ipsum
            dolor sit amet, consectetur adipisicing elit.
          </p>
        </div>
        <!-- Grid column -->

        <!-- Grid column -->
        <div class="col-md-2 col-lg-2 col-xl-2 mx-auto mb-4">
          <!-- Links -->
          <h6 class="text-uppercase fw-bold mb-4">
            Products
          </h6>
          <p>
            <a href="#!" class="text-reset">Angular</a>
          </p>
          <p>
            <a href="#!" class="text-reset">React</a>
          </p>
          <p>
            <a href="#!" class="text-reset">Vue</a>
          </p>
          <p>
            <a href="#!" class="text-reset">Laravel</a>
          </p>
        </div>
        <!-- Grid column -->

        <!-- Grid column -->
        <div class="col-md-3 col-lg-2 col-xl-2 mx-auto mb-4">
          <!-- Links -->
          <h6 class="text-uppercase fw-bold mb-4">
            Useful links
          </h6>
          <p>
            <a href="#!" class="text-reset">Pricing</a>
          </p>
          <p>
            <a href="#!" class="text-reset">Settings</a>
          </p>
          <p>
            <a href="#!" class="text-reset">Orders</a>
          </p>
          <p>
            <a href="#!" class="text-reset">Help</a>
          </p>
        </div>
        <!-- Grid column -->

        <!-- Grid column -->
        <div class="col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4">
          <!-- Links -->
          <h6 class="text-uppercase fw-bold mb-4">
            Contact
          </h6>
          <p><i class="fas fa-home me-3"></i> New York, NY 10012, US</p>
          <p>
            <i class="fas fa-envelope me-3"></i>
            info@example.com
          </p>
          <p><i class="fas fa-phone me-3"></i> + 01 234 567 88</p>
          <p><i class="fas fa-print me-3"></i> + 01 234 567 89</p>
        </div>
        <!-- Grid column -->
      </div>
      <!-- Grid row -->
    </div>
   </section>
   <!-- Section: Links  -->

   <!-- Copyright -->
   <div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.05);">
    © 2021 Copyright:
    <a class="text-reset fw-bold" href="https://mdbootstrap.com/">MDBootstrap.com</a>
   </div>
   <!-- Copyright -->
   </footer>
   <!-- Footer -->

  </div>
</body>
 </template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}

.badge {
  padding-left: 9px;
  padding-right: 9px;
  -webkit-border-radius: 9px;
  -moz-border-radius: 9px;
  border-radius: 9px;
}

.label-warning[href],
.badge-warning[href] {
  background-color: #c67605;
}
#lblCartCount {
    font-size: 12px;
    background: #ff0000;
    color: #fff;
    padding: 0 5px;
    vertical-align: top;
    margin-left: -10px; 
}
</style>

<script>

  
import axios from 'axios'
export default {
  data() {
    return {
      Login: {
           bgImg: {
                backgroundImage: 'url(' + require(`@/assets/background.jpg`) + ')' ,
                backgroundRepeat: "no-repeat",
                backgroundSize: '100% auto'
            },
        login: "",
        password: "",
        local:localStorage.getItem("user"),
        user:localStorage.getItem("username")
      }
    };
  },
  methods: {
    async Logout(){

      await localStorage.removeItem("user");
      await localStorage.removeItem("username")
      window.location.reload();

    },
    async loginUser() {
      
         await axios({
                method: 'POST',
                url: 'https://localhost:44303/token',
                params: { login: this.Login.login, password:this.Login.password }
            }).then((response) => {
                localStorage.setItem("user",response.data.access_token);
                localStorage.setItem("username",this.Login.login)
                window.location.reload();
            });
     
     
        // navigate to a protected resource 
      
    
     
    }
  }
};
</script>

