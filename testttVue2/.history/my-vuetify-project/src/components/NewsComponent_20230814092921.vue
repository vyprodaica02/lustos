<template>
  <v-container class="mt-14">
    <v-text-field v-model="value1" label="Số thứ nhất" solo></v-text-field>
    <v-text-field v-model="value2" label="Số thứ hai" solo></v-text-field>
    <span>{{ result }}</span>
    <v-btn @click="calculate">Tính</v-btn>
  </v-container>
</template>

<script lang="ts">
@Component
export default class MyCalculator extends Vue {
  private value1: number = 0;
  private value2: number = 0;
  private result: number = 0;

  private calculate() {
    this.result = this.value1 + this.value2;
  }
}
</script>

<style></style>
