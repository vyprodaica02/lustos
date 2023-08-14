import Vue from "vue";
import VueRouter from "vue-router";
// import HomeView from "../views/HomeView.vue";
import TableUserComponent from "../components/TableUserComponent.vue";
import TableProjectComponent from "../components/TableProjectComponent.vue";
import TableAttendances from "../components/TableAttendances.vue";
import AddUserComponent from "../components/AddUserComponent.vue";
import UpdateUserComponent from "../components/UpdateUserComponent.vue";
Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    component: TableUserComponent,
  },
  {
    path: "/TableProjectComponent",

    component: TableProjectComponent,
  },
  {
    path: "/TableAttendances",

    component: TableAttendances,
  },
  {
    path: "/AddUserComponent",

    component: AddUserComponent,
  },
  {
    path: "/UpdateUserComponent",

    component: UpdateUserComponent,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
