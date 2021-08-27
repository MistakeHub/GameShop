import Vue from 'vue'
import Vuex from 'vuex'
import VueCharts from 'vue-chartjs'
import VueCookie from 'vue-cookie'
import tough  from 'tough-cookie'
Vue.use(VueCookie)
Vue.use (tough)


Vue.use(Vuex)
Vue.use(VueCharts);

export default new Vuex.Store({
  state: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
  }
})
