<template>
  <div>
    <div class="top">
      <div class="title">展覽周邊</div>
      <q-input class="search" v-model="text" input-class="text-left">
        <template v-slot:append>
          <q-btn><q-icon name="search" /></q-btn>
        </template>
      </q-input>
    </div>

    <div class="ShowItem">
      <div v-for="showitem in showitems">
        <Merchandise :merchandiseitem="showitem" />
      </div>
    </div>
  </div>
</template>

<script setup>
import { reactive, ref } from "vue";
import Merchandise from "../component/merchandise.vue";

const text = ref("");

const showitems = reactive([
  {
    name: "腦筋急轉彎",
    type: "電影周邊",
    price: "350$",
    amount: "14",
    img: "https://cdn1.cybassets.com/media/W1siZiIsIjIwNzY3L3Byb2R1Y3RzLzQ2OTQwOTQzLzE3MTg2MDcxNDZfYjhjODAzMTZkODFiYTcxZDdmMGUuanBlZyJdLFsicCIsInRodW1iIiwiNjAweDYwMCJdXQ.jpeg?sha=73da33df754eabed",
  },
  {
    name: "趣動漫",
    type: "展覽周邊",
    price: "250$",
    amount: "5",
    img: "https://a.rimg.com.tw/c1/166/76a/matildawallace32/5/86/22426856414598_708.jpg",
  },
  {
    name: "aespa手燈",
    type: "演唱會周邊",
    price: "1200$",
    amount: "3",
    img: "https://shoplineimg.com/6528e1e10660e20062880be5/6541dbac5cc3e20017d7443e/800x.jpg?",
  },
  {
    name: "腦筋急轉彎",
    type: "電影周邊",
    price: "350$",
    amount: "14",
    img: "https://cdn1.cybassets.com/media/W1siZiIsIjIwNzY3L3Byb2R1Y3RzLzQ2OTQwOTQzLzE3MTg2MDcxNDZfYjhjODAzMTZkODFiYTcxZDdmMGUuanBlZyJdLFsicCIsInRodW1iIiwiNjAweDYwMCJdXQ.jpeg?sha=73da33df754eabed",
  },
  {
    name: "趣動漫",
    type: "展覽周邊",
    price: "250$",
    amount: "5",
    img: "https://a.rimg.com.tw/c1/166/76a/matildawallace32/5/86/22426856414598_708.jpg",
  },
  {
    name: "腦筋急轉彎",
    type: "電影周邊",
    price: "350$",
    amount: "14",
    img: "https://cdn1.cybassets.com/media/W1siZiIsIjIwNzY3L3Byb2R1Y3RzLzQ2OTQwOTQzLzE3MTg2MDcxNDZfYjhjODAzMTZkODFiYTcxZDdmMGUuanBlZyJdLFsicCIsInRodW1iIiwiNjAweDYwMCJdXQ.jpeg?sha=73da33df754eabed",
  },
  {
    name: "趣動漫",
    type: "展覽周邊",
    price: "250$",
    amount: "5",
    img: "https://a.rimg.com.tw/c1/166/76a/matildawallace32/5/86/22426856414598_708.jpg",
  },
]);
</script>

<style>
.ShowItem {
  display: flex;
  flex-wrap: wrap;
  padding-left: 30px;
}
.search {
  width: 400px;
  border-radius: 6px;
  margin: 10px;
  font-size: 18px;
}
.top {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  padding-right: 50px;
  padding-left: 50px;
}
.title {
  font-size: 36px;
}
</style>
