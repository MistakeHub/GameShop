import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Catalog from "../views/Catalog.vue"
import GameDetail from "../views/GameDetail.vue"

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },

  {
   path:"/game/:titleofgame",
   name:"Game",
   component:GameDetail

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
