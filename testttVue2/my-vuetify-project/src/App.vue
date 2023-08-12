<template>
  <v-app>
    <HeaderComponent />
    <v-main class="bg-main">
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
import HeaderComponent from "../src/components/HeaderComponent.vue";

export default {
  name: "App",
  components: {
    HeaderComponent,
  },
  data: () => ({
    //
  }),
};
</script>
