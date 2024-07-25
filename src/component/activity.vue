<template>
  <div class="q-pa-md row items-start q-gutter-md">
    <q-card class="my-card" v-if="activityitem">
      <q-card-section class="acivity">
        <div class="text-h6 content">{{ activityitem.name }}</div>
        <div class="text-subtitle2 content">{{ activityitem.type }}</div>
        <div class="text-subtitle2 content">{{ activityitem.address }}</div>
        <div class="text-subtitle2 content">{{ activityitem.day }}</div>
        <div class="text-subtitle2 content">{{ activityitem.time }}</div>
        <q-btn>查看更多詳細資訊</q-btn>
      </q-card-section>
    </q-card>
  </div>
</template>

<script setup>
import { defineProps } from "vue";
// prop 父=>子 emit 子=>父
const prop = defineProps(["activityitem"]);
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
