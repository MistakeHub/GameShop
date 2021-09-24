<template >
<body  >
  <div id="app"  v-if="!$route.meta.AdminLayout && !$route.meta.AdminPanelLayout && !$route.meta.LoginAdmin"  >
   <div>
<notifications group="foo" />
   <div>
  <header class="header trans_300">
  <!-- Top Navigation -->
  
  <!-- Main Navigation -->
  <div class="main_nav_container">
    <div class="container">
      <div class="row">
        <div class="col-lg-12 text-right">
          <div class="logo_container">
            <a href="#">Game<span>Shop</span></a>
          </div>
          <nav class="navbar">
            <ul class="navbar_menu">
              <li><a href="/">Главная</a></li>
              <li><a href="/catalog">каталог</a></li>
               


        <b-nav-item-dropdown v-if="Login.local==null" text="вход" variant="success" >
    <!-- Default form login -->
  
   <div class="wrapper">
  <form class="login" @submit.prevent="loginUser">
    <p class="title">Log in</p>
    <input type="text" placeholder="Username" autofocus v-model="Login.login"/>
    <i class="fa fa-user"></i>
    <input type="password" placeholder="Password"  v-model="Login.password"/>
    <i class="fa fa-key"></i>
     <div class="modal-footer">
                    <div class="options font-weight-light">
                        <p>Ещё не зарегистрированны? <a href="/register">Зарегистрироваться</a></p>
                        <p>Забыли пароль? <a href="/requestrestore">Восстановить пароль</a></p>
                    </div>
                </div>
    <button type="submit">
      <i class="spinner"></i>
      <span  class="state">Log in</span>
    </button>
  </form>
 
  
</div>

 
  <!-- Default form login -->
   </b-nav-item-dropdown>
  
    <b-nav-item  v-if="Login.local!==null" @click="Logout">выход</b-nav-item>
       <b-nav-item  v-if="Login.local!==null" :href="'/userprofile/'+Login.user">Здравствуйте,{{Login.user}}</b-nav-item>
    
            </ul>
            <ul class="navbar_user">
              <li><a href="#"><i class="fa fa-search" aria-hidden="true"></i></a></li>
              <li><a href="#"><i class="fa fa-user" aria-hidden="true"></i></a></li>
              <li class="checkout">
                <a :href="'/cart/'+Login.user" v-if="Login.local !==null">
                  <i class="fa fa-shopping-cart" aria-hidden="true" ></i>
                  
                </a>
              </li>
            </ul>
            <div class="hamburger_container">
              <i class="fa fa-bars" aria-hidden="true"></i>
            </div>
          </nav>
        </div>
      </div>
    </div>
  </div>
</header>
 

    
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
  <div id="app" v-if="$route.meta.AdminLayout "   >
   <div class="basic-layout">
    
   

   <router-view></router-view>

   
  </div>
  </div>
 

  

   <div id="app" v-if="$route.meta.LoginAdmin"><router-view></router-view> </div>
  <div id="app" v-if="$route.meta.AdminPanelLayout"    >
   <div class="basic-layout">
    
  

<div class="c-app " >
    <div class="bg-dark" >
    <b-button v-b-toggle.sidebar-1>Меню</b-button>
    <b-sidebar id="sidebar-1" title="Меню" shadow>
      <div class="px-3 py-2">
        <b-nav vertical>
           <b-button @click="AdminLogOut()" variant="danger">Выйти</b-button> 
              <label   v-b-toggle.my-collapse3>Таблицы &#8595;</label>
               

<b-collapse id="my-collapse3">
   
      <b-nav-item href="/admin-panel/TablesOfPublication"  v-b-toggle.my-collapse3>Публикации</b-nav-item>
    <b-nav-item href="/admin-panel/TablesOfCountries"  v-b-toggle.my-collapse3>Страны</b-nav-item>
     <b-nav-item href="/admin-panel/TablesOfGenre"  v-b-toggle.my-collapse3>Жанры</b-nav-item>
      <b-nav-item href="/admin-panel/TablesOfLocalization"  v-b-toggle.my-collapse3>Локализации</b-nav-item>
       <b-nav-item href="/admin-panel/TablesOfManufacture"  v-b-toggle.my-collapse3>Издатели</b-nav-item>
        <b-nav-item href="/admin-panel/TablesOfPlatform"  v-b-toggle.my-collapse3>Платформы</b-nav-item>
         <b-nav-item href="/admin-panel/TablesOfRole"  v-b-toggle.my-collapse3>Роли</b-nav-item>
          <b-nav-item href="/admin-panel/TablesOfSeries"  v-b-toggle.my-collapse3>Серии Игр</b-nav-item>
           <b-nav-item href="/admin-panel/TablesOfStatuse"  v-b-toggle.my-collapse3>Статусы</b-nav-item>
            <b-nav-item href="/admin-panel/TablesOfUser"  v-b-toggle.my-collapse3>Пользователи</b-nav-item>
      </b-collapse>
         
               
     <label   v-b-toggle.my-collapse4>Отчёты &#8595;</label>
<b-collapse id="my-collapse4">
   
      <b-nav-item href="/admin-panel/dashboards/Visitors"  v-b-toggle.my-collapse3>Глафик Посещения </b-nav-item>
    <b-nav-item href="/admin-panel/dashboards/MostProfitable"  v-b-toggle.my-collapse3>Самые Прибыльные Продукты</b-nav-item>
     <b-nav-item href="/admin-panel/dashboards/MostPurcheasable"  v-b-toggle.my-collapse3>Самые Продаваемые Продукты</b-nav-item>
       <b-nav-item href="/admin-panel/dashboards/MostRating"  v-b-toggle.my-collapse3>Самые Рейтинговые Продукты</b-nav-item>
    
      </b-collapse>
            </b-nav>
      </div>
    </b-sidebar>
  
              <router-view  class="bg-light" ></router-view>
    </div>
  </div>

   
  </div>

  </div>
      
</body>



 </template>

<style lang="scss">
$image-path: '~@/../mdb/mdbvue/img';
@import '~@/../mdb/mdbvue/scss/mdb-free.scss';

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

.wrapper {
  display: flex;
  align-items: center;
  flex-direction: column; 
  justify-content: center;
  width: 100%;
  min-height: 100%;
  padding: 20px;
  background: rgba(darken($primary,40%), 0.85);
}


.login {
  
  border-radius: 2px 2px 5px 5px;
  padding: 10px 20px 20px 20px;
  width: 90%;
  max-width: 320px;
  background: #ffffff;
  position: relative;
  padding-bottom: 80px;
  box-shadow: 0px 1px 5px rgba(0,0,0,0.3);
  
  &.loading {
    button {
      max-height: 100%;
      padding-top: 50px;
      .spinner {
        opacity: 1;
        top: 40%;
      }
    }  
  }
  
  &.ok {
    button {
      background-color: #8bc34a;
      .spinner{
        border-radius: 0;
        border-top-color: transparent;
        border-right-color: transparent;
        height: 20px;
        animation: none;
        transform: rotateZ(-45deg);
      }
    }
  }
  
  input {
    display: block;
    padding: 15px 10px;
    margin-bottom: 10px;
    width: 100%;
    border: 1px solid #ddd;
    transition: border-width 0.2s ease;
    border-radius: 2px;
    color: #ccc;
    
    &+ i.fa {
        color: #fff;
      font-size: 1em;
      position: absolute;
      margin-top: -47px;
      opacity: 0;
      left: 0;
      transition: all 0.1s ease-in;
    }
    
    &:focus {
      &+ i.fa {
        opacity: 1;
        left: 30px;
      transition: all 0.25s ease-out;
      }
      outline: none;
      color: #444;
      border-color: $primary;
      border-left-width: 35px;
    }
    
  }
  
  a {
   font-size: 0.8em;   
    color: $primary;
    text-decoration: none;
  }
  
  .title {
    color: #444;
    font-size: 1.2em;
    font-weight: bold;
    margin: 10px 0 30px 0;
    border-bottom: 1px solid #eee;
    padding-bottom: 20px;
  }
  
  button {
    width: 100%;
    height: 100%;
    padding: 10px 10px;
    background: $primary;
    color: #fff;
    display: block;
    border: none;
    margin-top: 20px;
    position: absolute;
    left: 0;
    bottom: 0;
    max-height: 60px;
    border: 0px solid rgba(0,0,0,0.1);
  border-radius: 0 0 2px 2px;
    transform: rotateZ(0deg);
    
    transition: all 0.1s ease-out;
      border-bottom-width: 7px;
    
    .spinner {
      display: block;
      width: 40px;
      height: 40px;
      position: absolute;
      border: 4px solid #ffffff;
      border-top-color: rgba(255,255,255,0.3);
      border-radius: 100%;
      left: 50%;
      top: 0;
      opacity: 0;
      margin-left: -20px;
      margin-top: -20px;
      animation: spinner 0.6s infinite linear;
      transition: top 0.3s 0.3s ease,
                opacity 0.3s 0.3s ease,
                border-radius 0.3s ease;
      box-shadow: 0px 1px 0px rgba(0,0,0,0.2);
    }
    
  }
  
    &:not(.loading) button:hover {
      box-shadow: 0px 1px 3px $primary;
    }
    &:not(.loading) button:focus {
      border-bottom-width: 4px;
    }
    
  
}

footer {
  display: block;
  padding-top: 50px;
  text-align: center;
  color: #ddd;
  font-weight: normal;
  text-shadow: 0px -1px 0px rgba(0,0,0,0.2);
  font-size: 0.8em;
  a, a:link {
    color: #fff;
    text-decoration: none;
  }
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




</style>


<script>

  
import axios from 'axios'
import store from './store/index'
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
        user:localStorage.getItem("username"),
        admin:localStorage.getItem("admin"),
        
        session:  document.cookie
      }
    };
  },
   mounted(){
                this.$hostname=true  
                console.log(this.$hostname)
                
               if(this.session ==undefined){
                 this.$cookie.set('usersession', 'usersession', { expires: '1h' });

               }
               console.log(localStorage.getItem('user'))
             if(localStorage.getItem('user')!=null && localStorage.getItem("username")!=null)
               axios({
                method: 'GET',
                url: 'https://localhost:44303/checkuser',
                params: { username: localStorage.getItem('username'), password:localStorage.getItem("password") },
                  headers:{
                    "Accept": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("user")}
            }).catch(d=>{
           localStorage.removeItem("user");
      localStorage.removeItem("username")
     localStorage.removeItem("password")

});

              
          },

  methods: {
    async Logout(){

      await localStorage.removeItem("user");
      await localStorage.removeItem("username")
       await localStorage.removeItem("password")
          await localStorage.removeItem("role")
      window.location.reload();

    },

     async AdminLogOut(){

      await localStorage.removeItem("user");
      await localStorage.removeItem("username")
       await localStorage.removeItem("password")
          await localStorage.removeItem("role")
              await localStorage.removeItem("admin")
                 this.$router.replace({ name: "Admin" });
   

    },
    async loginUser() {
     
         await axios({
                method: 'POST',
                url: 'https://localhost:44303/token',
                params: { login: this.Login.login, password:this.Login.password }
            }).then((response) => {
              var data=response.data;
                localStorage.setItem("user",data.access_token);
                localStorage.setItem("username",this.Login.login)
                localStorage.setItem("password", this.Login.password)
                localStorage.setItem("role",data.role )
                
                window.location.reload();
               
             
            }).catch(d=>{
              if(d.response)
              console.log(d.response)
              this.$notify({
  group: 'foo',
  type:'error',
  title: d.response.status,
   duration:10000,
  text: d.response.data.error
});

});
         
     
     
        // navigate to a protected resource 
      
    
     
    }
  }
};
</script>

