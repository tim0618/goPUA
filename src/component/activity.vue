<template>
  <div class="q-pa-md row items-start q-gutter-md hotactivity">
    <q-card class="my-card" v-if="activityitem">
      <q-card-section class="acivity">
        <div class="text-h6">{{ activityitem.name }}</div>
        <div class="text-subtitle2">{{ activityitem.type }}</div>
        <div class="text-subtitle2">{{ activityitem.address }}</div>
        <div class="text-subtitle2">{{ activityitem.day }}</div>
        <div class="text-subtitle2">{{ activityitem.time }}</div>
      </q-card-section>
    </q-card>
  </div>
</template>

<script setup>
import { defineProps } from "vue";
// prop 父=>子 emit 子=>父
const prop = defineProps(["activityitem"]);
</script>

<style  scoped>
.my-card{
  width: 100%;
  max-width: 250px;
}

</style>
