import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import "./style/style.css";
import vuetify from "./plugins/vuetify";
import axios from "axios";
import "roboto-fontface/css/roboto/roboto-fontface.css";
import "@mdi/font/css/materialdesignicons.css";
import "material-design-icons-iconfont/dist/material-design-icons.css";
import store from "./Store/store";
import VueSweetalert2 from "vue-sweetalert2";
import "sweetalert2/dist/sweetalert2.min.css";
Vue.config.productionTip = false;

// Add VueSweetalert2 to the Vue instance
Vue.use(VueSweetalert2);

new Vue({
  router,
  vuetify,
  axios,
  store,
  render: (h) => h(App),
}).$mount("#app");
