<template>
  <div class="q-pa-md row items-start q-gutter-md">
    <q-card class="my-card" v-if="merchandiseitem">
      <q-card-section class="merchandise">
        <q-img :src="merchandiseitem.img" class="item-image"> </q-img>
        <div class="text-h6 content">{{ merchandiseitem.name }}</div>
        <div class="text-subtitle2 content">{{ merchandiseitem.type }}</div>
        <div class="text-subtitle2 content">{{ merchandiseitem.price }}</div>
        <div class="text-subtitle2 content">{{ merchandiseitem.amount }}</div>
      </q-card-section>

      <div class="q-pa-md q-gutter-sm">
        <q-btn
          v-for="filter in backdropFilterList"
          :key="filter.label"
          :label="filter.label"
          no-caps
          @click="filter.onClick"
        />

        <q-dialog v-model="dialog" :backdrop-filter="backdropFilter">
          <q-card style="width: 500px">
            <q-card-section class="row items-center q-pb-none text-h6">
              {{ merchandiseitem.name }}
            </q-card-section>

            <q-card-section>
              超級細項
              <div class="text-subtitle2 content">
                {{ merchandiseitem.type }}
              </div>
            </q-card-section>

            <q-card-actions align="right">
              <q-btn flat label="Close" color="primary" v-close-popup />
            </q-card-actions>
          </q-card>
        </q-dialog>
      </div>
    </q-card>
  </div>
</template>

<script setup>
import { defineProps, ref, computed } from "vue";
// prop 父=>子 emit 子=>父
const prop = defineProps(["merchandiseitem"]);

const backdropFilter = ref("");
const dialog = ref(false);
const list = ["查看更多詳細資訊"];

const backdropFilterList = computed(() =>
  list.map((filter) => ({
    label: filter,
    onClick: () => {
      backdropFilter.value = filter;
      dialog.value = true;
    },
  }))
);
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
