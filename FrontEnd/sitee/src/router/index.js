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
import CountryTable from "../views/AdminPanelViews/AdminTables/CountryTable.vue"
import GameTable from "../views/AdminPanelViews/AdminTables/GameTable.vue"
import GenreTable from "../views/AdminPanelViews/AdminTables/GenreTable.vue"
import LocalizationTable from "../views/AdminPanelViews/AdminTables/LocalizationTable.vue"
import ManufactureTable from "../views/AdminPanelViews/AdminTables/ManufactureTable.vue"
import PlatformTable from "../views/AdminPanelViews/AdminTables/PlatformTable.vue"
import RoleTable from "../views/AdminPanelViews/AdminTables/RoleTable.vue"
import SeriesTable from "../views/AdminPanelViews/AdminTables/SeriesTable.vue"
import StatuseTable from "../views/AdminPanelViews/AdminTables/StatuseTable.vue"
import UserTable from "../views/AdminPanelViews/AdminTables/UserTable.vue"
import AddPublicationForm from "../views/AdminPanelViews/AddFormViews/AddPublicationForm.vue"
import AddEditUserForm from "../views/AdminPanelViews/AddFormViews/AddEditUserForm.vue"
import AcceptPurchase from "../views/AcceptPurchase.vue"
import MostPurcheasable from "../views/AdminPanelViews/MostPurcheasable.vue"
import MostProfitable from "../views/AdminPanelViews/MostProfitable.vue"

// Containers


// Views
const VisitorsGraph = () => import('@/views/AdminPanelViews/VisitorsGraph')



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
    path: '/admin-panel/dashboards/Visitors',
    name:"Visitors",
  
    component: VisitorsGraph,
     
 

    meta: {
      AdminPanelLayout: true,
    }, 

    },

    {
      path: '/admin-panel/dashboards/MostPurcheasable',
      name:"Mostpurcheasable",
    
      component: MostPurcheasable,
       
   
  
      meta: {
        AdminPanelLayout: true,
      }, 
  
      },

      {
        path: '/admin-panel/dashboards/MostProfitable',
        name:"MostProfitable",
      
        component: MostProfitable,
         
     
    
        meta: {
          AdminPanelLayout: true,
        }, 
    
        },
    {
      path: '/admin-panel/TablesOfPublication',
      name:"Tables1",
      component: GameTable,
      meta: {
        AdminPanelLayout: true,
        publication:true
      },  
    },

    {
      path: '/admin-panel/TablesOfCountry',
      name:"Tables2",
      component: CountryTable,
      meta: {
        AdminPanelLayout: true,
        country:true
      },  
    },

    {
      path: '/admin-panel/TablesOfGenre',
      name:"Tables3",
      component: GenreTable,
      meta: {
        AdminPanelLayout: true,
        genre:true
      },  
    },

    {
      path: '/admin-panel/TablesOfLocalization',
      name:"Tables4",
      component: LocalizationTable,
      meta: {
        AdminPanelLayout: true,
        localization:true
      },  
    },

    {
      path: '/admin-panel/TablesOfManufacture',
      name:"Tables5",
      component: ManufactureTable,
      meta: {
        AdminPanelLayout: true,
        manufacture:true
      },  
    },

    {
      path: '/admin-panel/TablesOfPlatform',
      name:"Tables6",
      component:PlatformTable,
      meta: {
        AdminPanelLayout: true,
        platform:true
      },  
    },

    {
      path: '/admin-panel/TablesOfRole',
      name:"Tables7",
      component: RoleTable,
      meta: {
        AdminPanelLayout: true,
        role:true
      },  
    },

    {
      path: '/admin-panel/TablesOfSeries',
      name:"Tables8",
      component: SeriesTable,
      meta: {
        AdminPanelLayout: true,
        series:true
      },  
    },

    {
      path: '/admin-panel/TablesOfStatuse',
      name:"Tables9",
      component: StatuseTable,
      meta: {
        AdminPanelLayout: true,
        statuse:true
      },  
    },

    {
      path: '/admin-panel/TablesOfUser',
      name:"Tables10",
      component: UserTable,
      meta: {
        AdminPanelLayout: true,
        user:true
      },  
    },

    {
      path: '/admin-panel/TablesOfCountries',
      name:"Tables11",
      component: CountryTable,
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
    path:"/cart/AcceptPurchase/:id",
    name:"AcceptPurchase",
    component:AcceptPurchase
 
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
