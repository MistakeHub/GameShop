import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Admin from '../views/Admin.vue'
import Adminpanel from '../Adminpanel.vue'
import Catalog from "../views/Catalog.vue"
import GameDetail from "../views/GameDetail.vue"
import Cart from "../views/Cart.vue"
import Register from "../views/Register.vue"
import UserProfile from "../views/UserProfile.vue"
import ApproveRegister from "../views/ApproveRegister.vue"
import AdminPaneltables from "../views/AdminPanelViews/AdminPaneltables.vue"
import AddPublicationForm from "../views/AdminPanelViews/AddFormViews/AddPublicationForm.vue"

// Containers


// Views
const Dashboard = () => import('@/views/AdminPanelViews/Dashboard')



Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    
  },

  {
    path: '/admin-panel',
    name: 'Admin',
    component:Admin,
    
    meta: {
      AdminLayout: true,
    },  
    
  },

  {
    path: '/admin-panel/Home',
    name:"HomeAdmin",
  
    component: Dashboard,
     
 

    meta: {
      AdminPanelLayout: true,
    }, 

    },
    {
      path: '/admin-panel/Tables',
      name:"Tables",
      component: AdminPaneltables,
      meta: {
        AdminPanelLayout: true,
      },  
    },

    {
      path: '/admin-panel/AddPublication',
      name:"AddPublication",
      component: AddPublicationForm,
      meta: {
        AdminPanelLayout: true,
      },  
    },
 
  {
    path: '/userProfile/:userlogin',
    name: 'UserProfile',
    component: UserProfile,
  
  },


 
  {
   path:"/game/:titleofgame",
   name:"Game",
   component:GameDetail

  },

  {
    path:"/cart/:user",
    name:"Cart",
    component:Cart
 
   },
   {
    path:"/register",
    name:"Register",
    component:Register

   },

   {
    path:"/register/approve/:userkey/:email",
    name:"ApproveRegister",
    component:ApproveRegister

   },
  {
    path: '/catalog',
    name: 'Catalog',
    component:Catalog
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})



export default router
