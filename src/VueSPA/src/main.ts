import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import BootstrapVue from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import axios from "axios";

import Vuelidate from "vuelidate";

Vue.config.productionTip = false;
Vue.use(BootstrapVue);

Vue.use(Vuelidate);

axios.defaults.baseURL = "https://localhost:44399/";

new Vue({
	router,
	store,
	render: h => h(App)
}).$mount("#app");

console.log("started");
