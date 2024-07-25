<template>
  <div class="body">
    <div class="q-pa-md carousel">
      <p>最新資訊</p>
      <q-carousel animated v-model="slide" arrows navigation infinite>
        <q-carousel-slide
          :name="1"
          img-src="https://cdn.quasar.dev/img/mountains.jpg"
        />
        <q-carousel-slide
          :name="2"
          img-src="https://cdn.quasar.dev/img/parallax1.jpg"
        />
        <q-carousel-slide
          :name="3"
          img-src="https://cdn.quasar.dev/img/parallax2.jpg"
        />
        <q-carousel-slide
          :name="4"
          img-src="https://cdn.quasar.dev/img/quasar.jpg"
        />
      </q-carousel>
    </div>

    <div class="q-pa-md menu">
      <div class="more">
        <p>熱門活動</p>
        <q-btn flat href="/HotAct" label="查看更多" />
      </div>
      <q-virtual-scroll :items="activitys" virtual-scroll-horizontal>
        <template v-slot="{ item }">
          <hotActivity :activityitem="item" />
        </template>
      </q-virtual-scroll>
    </div>

    <div class="q-pa-md menu">
      <div class="more">
        <p>熱門周邊</p>
        <q-btn flat href="/HotItem" label="查看更多" />
      </div>
      <q-virtual-scroll :items="merchandises" virtual-scroll-horizontal>
        <template v-slot="{ item }">
          <hotMerchandise :merchandiseitem="item" />
        </template>
      </q-virtual-scroll>
    </div>
  </div>
</template>

<script setup>
import { reactive, ref } from "vue";
import hotActivity from "../component/activity.vue";
import hotMerchandise from "../component/merchandise.vue";

const slide = ref(1);

const activitys = reactive([
  {
    name: "雲門舞集",
    type: "藝術表演",
    address: "台中歌劇院",
    day: "2024/7/7",
    time: "15:30~17:30 ",
  },
  {
    name: "趣動漫",
    type: "展覽",
    address: "華山文化園區",
    day: "2024/8/5~9/30",
    time: "9:00-17:00",
  },
  {
    name: "大聯盟",
    type: "體育賽事",
    address: "台中洲際棒球場",
    day: "2024/9/7",
    time: "9:00~12:00",
  },
  {
    name: "aespa全球巡演",
    type: "演唱會",
    address: "高雄巨蛋",
    day: "2024/10/3",
    time: "18:00~21:00",
  },
  {
    name: "趣動漫",
    type: "展覽",
    address: "華山文化園區",
    day: "2024/8/5~9/30",
    time: "9:00-17:00",
  },
  {
    name: "大聯盟",
    type: "體育賽事",
    address: "台中洲際棒球場",
    day: "2024/9/7",
    time: "9:00~12:00",
  },
  {
    name: "aespa全球巡演",
    type: "演唱會",
    address: "高雄巨蛋",
    day: "2024/10/3",
    time: "18:00~21:00",
  },
]);

const merchandises = reactive([
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
    name: "紙風車劇團",
    type: "劇場周邊",
    price: "450$",
    amount: "20",
    img: "https://www.allupeopletheatre.com/archive/image/product1/images/layoutlist/1700552653.jpg",
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

<style scoped>
p {
  font-size: 24px;
}
.body {
  display: flex;
  flex-direction: column;
  padding: 50px;
}

.carousel {
  margin-bottom: 50px;
}
.menu {
  margin-bottom: 50px;
}
.q-virtual-scroll {
  overflow-y: auto;
}

.q-virtual-scroll::-webkit-scrollbar {
  width: 5px;
}

.q-virtual-scroll::-webkit-scrollbar-thumb {
  background: rgb(203, 225, 243);
  border-radius: 5px;
}

.q-virtual-scroll::-webkit-scrollbar-thumb:hover {
  background: lightsteelblue;
}
.more {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
</style>
