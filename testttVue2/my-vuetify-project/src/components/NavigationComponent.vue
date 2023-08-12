<template>
  <!-- v-model="drawer" -->
  <v-list>
    <v-list-item>
      <v-icon class="pr-2">mdi-home-circle</v-icon>
      <v-list-item-title> Bảng Tin </v-list-item-title>
    </v-list-item>
    <v-list-item>
      <v-icon class="pr-2">mdi-account-circle</v-icon>
      <v-list-item-title>Home</v-list-item-title>
    </v-list-item>
    <v-list-group
      v-for="item in items"
      :key="item.title"
      v-model="item.active"
      :prepend-icon="item.action"
      no-action
    >
      <template v-slot:activator>
        <v-list-item-content>
          <v-list-item-title v-text="item.title"></v-list-item-title>
        </v-list-item-content>
      </template>
      <v-list-item
        v-for="child in item.items"
        :key="child.title"
        :class="{ 'active-item': child.active }"
        class="pa-3 rounded-md"
        color="red"
        :to="child.to"
      >
        <v-list-item-content>
          <v-list-item-title class="text-center">
            <v-icon>
              {{ child.icon }}
            </v-icon>
            {{ child.title }}
          </v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list-group>
  </v-list>
</template>

<script>
export default {
  props: {
    items: {
      type: Array,
    },
  },
  data() {
    return {};
  },
};
</script>

<style></style>
