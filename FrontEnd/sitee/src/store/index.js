import Vue from 'vue'
import VeeValidate from "vee-validate";
import Vuex from 'vuex'
import VueCharts from 'vue-chartjs'
import VueCookie from 'vue-cookie'
import tough  from 'tough-cookie'
import Notifications from 'vue-notification'




Vue.use(VueCookie)
Vue.use (tough)


Vue.use(Vuex)
Vue.use(VueCharts);
Vue.use(VeeValidate, {
  inject: true,
  fieldsBagName: "veeFields",
  errorBagName: "veeErrors"
});
Vue.use(Notifications)


export default new Vuex.Store({
  state: {
    isAdmin:false,
    count:0
  },
  mutations: {
    updateIsAdmin(state,value){
      Vue.set(this.state,'count',1)
      Vue.set(this.state,'isAdmin',true)
    },
  },
  actions: {
  },
  modules: {
  }
})
