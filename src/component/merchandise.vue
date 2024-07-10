<template>
  <div class="q-pa-md row items-start q-gutter-md">
    <q-card class="my-card" v-if="merchandiseitem">
      <q-card-section class="merchandise">
        <q-img :src="merchandiseitem.img" class="item-image">
            </q-img>
        <div class="text-h6">{{merchandiseitem.name}}</div>
        <div class="text-subtitle2">{{merchandiseitem.type}}</div>
        <div class="text-subtitle2">{{merchandiseitem.price}}</div>
        <div class="text-subtitle2">{{merchandiseitem.amount}}</div>
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
.my-card{
  width: 100%;
  max-width: 250px;
}

</style>
