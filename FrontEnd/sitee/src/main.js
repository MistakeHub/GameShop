

import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import CoreuiVue from '@coreui/vue'
import VueMaterial from 'vue-material'
import 'bootstrap-css-only/css/bootstrap.min.css'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import 'core-js'

import {BootstrapVue, IconsPlugin} from 'bootstrap-vue'

Vue.use(CoreuiVue)
Vue.use(VueMaterial)
Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
Vue.prototype.$hostname = false
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
