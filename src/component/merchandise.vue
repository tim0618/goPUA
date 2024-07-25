<template>
  <div class="q-pa-md row items-start q-gutter-md">
    <q-card class="my-card" v-if="merchandiseitem">
      <q-card-section class="merchandise">
        <q-img :src="merchandiseitem.img" class="item-image"> </q-img>
        <div class="text-h6 content">{{ merchandiseitem.name }}</div>
        <div class="text-subtitle2 content">{{ merchandiseitem.type }}</div>
        <div class="text-subtitle2 content">{{ merchandiseitem.price }}</div>
        <div class="text-subtitle2 content">{{ merchandiseitem.amount }}</div>
        <q-btn>查看更多詳細資訊</q-btn>
      </q-card-section>
    </q-card>
  </div>
</template>

<script setup>
import { defineProps } from "vue";
// prop 父=>子 emit 子=>父
const prop = defineProps(["merchandiseitem"]);
</script>

<style scoped>
.my-card {
  width: 250px;
  padding: 10px;
}
.content {
  margin: 5px;
}
</style>
