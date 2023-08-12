<template>
  <div>
    <v-row class="wrapper">
      <v-col cols="">
        <v-app-bar
          color="white"
          class="rounded rounded-md header"
          style="z-index: 100"
        >
          <v-app-bar-nav-icon @click="toggleDrawer"
            ><v-icon>mdi-menu</v-icon></v-app-bar-nav-icon
          >
          <v-app-bar-title
            ><v-img
              src="https://insight.lotusacademy.edu.vn/static/img/logo_new.png"
              width="150"
              heightq="150"
            ></v-img
          ></v-app-bar-title>
          <v-spacer></v-spacer>
          <v-btn icon outlined small class="mx-1 pa-2"
            ><v-icon>mdi mdi-drupal</v-icon></v-btn
          >
          <v-btn icon outlined small class="mx-1 pa-2"
            ><v-icon>mdi-message-bulleted</v-icon></v-btn
          >
          <v-btn icon outlined small class="mx-1 pa-2">
            <v-icon>mdi-menu-down</v-icon></v-btn
          >
        </v-app-bar>
      </v-col>
    </v-row>
    <v-navigation-drawer v-model="drawer" app class="custom-drawer">
      <!-- :permanent="permanentDrawer" -->
      <NavigationComponent :items="items" />
    </v-navigation-drawer>
  </div>
</template>

<script>
import NavigationComponent from "./NavigationComponent.vue";
export default {
  components: {
    NavigationComponent,
  },
  data() {
    return {
      drawer: false,
      permanentDrawer: false, // Khởi tạo trạng thái permanent drawer là false
      items: [
        {
          title: "Học Viên",
          action: "mdi-grease-pencil",
          items: [
            {
              title: "User",
              active: false,
              icon: "mdi-grease-pencil",
              to: "/",
            },
          ],
        },
        {
          title: "Project",
          action: "mdi-folder",
          items: [
            {
              title: "Project",
              active: false,
              icon: "mdi-grease-pencil",
              to: "/TableProjectComponent",
            },
          ],
        },
        {
          title: "Attendances",
          action: "mdi-calendar-blank-multiple",
          items: [
            {
              title: "attendances",
              active: false,
              icon: "mdi-grease-pencil",
              to: "/TableAttendances",
            },
          ],
        },
      ],
    };
  },
  methods: {
    toggleDrawer() {
      this.drawer = !this.drawer;
      console.log(this.drawer);
    },
  },
};
</script>

<style>
.custom-drawer {
  z-index: 99; /* Adjust this value if needed */
}
.logo-container {
  width: 350px; /* Đặt chiều rộng cố định là 50px */
  height: 100%; /* Chiều cao tự điều chỉnh theo chiều cao của thanh v-toolbar */
  overflow: hidden; /* Giữ hình ảnh chỉ hiển thị trong khung cố định */
  background-size: cover;
}
.active-item {
  background-color: #ffeae5; /* Đổi màu nền khi phần tử được kích hoạt */
}
.v-navigation-drawer__content {
  transition: transform 0.3s ease;
}
.toolbar-drawer-container {
  top: 60px; /* Adjust this value to push the drawer down */
}
.header {
  position: fixed;
}
.v-navigation-drawer__content {
  position: fixed;
  top: 60px;
  left: 0;
  bottom: 0;
  z-index: 10; /* Make sure the drawer is above the content */
  overflow-y: auto;
  max-width: 280px; /* Set a maximum width for the drawer */
  width: 100%; /* Ensure the drawer takes full width */
}
</style>
