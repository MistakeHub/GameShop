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
import AdminPanelTablesPublication from "../views/AdminPanelViews/AdminPanelTablesPublication.vue"
import AddPublicationForm from "../views/AdminPanelViews/AddFormViews/AddPublicationForm.vue"
import AddEditUserForm from "../views/AdminPanelViews/AddFormViews/AddEditUserForm.vue"

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
      path: '/admin-panel/TablesOfPublication',
      name:"Tables1",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        publication:true
      },  
    },

    {
      path: '/admin-panel/TablesOfCountry',
      name:"Tables2",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        country:true
      },  
    },

    {
      path: '/admin-panel/TablesOfGenre',
      name:"Tables3",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        genre:true
      },  
    },

    {
      path: '/admin-panel/TablesOfLocalization',
      name:"Tables4",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        localization:true
      },  
    },

    {
      path: '/admin-panel/TablesOfManufacture',
      name:"Tables5",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        manufacture:true
      },  
    },

    {
      path: '/admin-panel/TablesOfPlatform',
      name:"Tables6",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        platform:true
      },  
    },

    {
      path: '/admin-panel/TablesOfRole',
      name:"Tables7",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        role:true
      },  
    },

    {
      path: '/admin-panel/TablesOfSeries',
      name:"Tables8",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        series:true
      },  
    },

    {
      path: '/admin-panel/TablesOfStatuse',
      name:"Tables9",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        statuse:true
      },  
    },

    {
      path: '/admin-panel/TablesOfUser',
      name:"Tables10",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        user:true
      },  
    },

    {
      path: '/admin-panel/TablesOfCountries',
      name:"Tables11",
      component: AdminPanelTablesPublication,
      meta: {
        AdminPanelLayout: true,
        country:true
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
      path: '/admin-panel/EditPublication/:id',
      name:"EditPublication",
      component: AddPublicationForm,
      meta: {
        EditFormPublication: true,
        AdminPanelLayout: true,
      },  
    },

    {
      path: '/admin-panel/EditUser/:id',
      name:"EditUser",
      component: AddEditUserForm,
      meta: {
        EditFormUser: true,
        AdminPanelLayout: true,
      },  
    },

    {
      path: '/admin-panel/AddUser',
      name:"AddUser",
      component: AddEditUserForm,
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
