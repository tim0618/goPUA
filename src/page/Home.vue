<template>
  <div>
    <p>最新資訊</p>
    <div class="q-pa-md">
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

    <p>熱門活動</p>
    <div class="HotActivity">
      <div class="activity" v-for="activity in activitys">
        <hotActivity :activityitem="activity"  />
      </div>
    </div>

    <p>熱門商品</p>
    <div class="HotMerchandise">
      <div class="merchandise" v-for="merchandise in merchandises">
        <hotMerchandise :merchandiseitem="merchandise"  />
      </div>
    </div>

  </div>
</template>

<script setup>
import { reactive, ref } from "vue";
import hotActivity from '../component/activity.vue';
import hotMerchandise from '../component/merchandise.vue';


const slide = ref(1);

const activitys = reactive([
  {
    "name": "雲門舞集",
    "type": "藝術表演",
    "address": "台中歌劇院",
    "day": "2024/7/7",
    "time": "15:30~17:30 "
  },
  {
    "name": "趣動漫",
    "type": "展覽",
    "address": "華山文化園區",
    "day": "2024/8/5~9/30",
    "time": "9:00-17:00"
  },
  {
    "name": "大聯盟",
    "type": "體育賽事",
    "address": "台中洲際棒球場",
    "day": "2024/9/7",
    "time": "9:00~12:00"
  },
  {
    "name": "aespa全球巡演",
    "type": "演唱會",
    "address": "高雄巨蛋",
    "day": "2024/10/3",
    "time": "18:00~21:00"
  },
]);

const merchandises = reactive([
  {
    "name": "腦筋急轉彎",
    "type": "電影周邊",
    "price": "350$",
    "amount": "14",
    "img": "https://cdn1.cybassets.com/media/W1siZiIsIjIwNzY3L3Byb2R1Y3RzLzQ2OTQwOTQzLzE3MTg2MDcxNDZfYjhjODAzMTZkODFiYTcxZDdmMGUuanBlZyJdLFsicCIsInRodW1iIiwiNjAweDYwMCJdXQ.jpeg?sha=73da33df754eabed"
  },
  {
    "name": "趣動漫",
    "type": "展覽周邊",
    "price": "250$",
    "amount": "5",
    "img": "https://a.rimg.com.tw/c1/166/76a/matildawallace32/5/86/22426856414598_708.jpg"
  },
  {
    "name": "紙風車劇團",
    "type": "劇場周邊",
    "price": "450$",
    "amount": "20",
    "img": "https://www.allupeopletheatre.com/archive/image/product1/images/layoutlist/1700552653.jpg"
  },
  {
    "name": "aespa手燈",
    "type": "演唱會周邊",
    "price": "1200$",
    "amount": "3",
    "img": "https://shoplineimg.com/6528e1e10660e20062880be5/6541dbac5cc3e20017d7443e/800x.jpg?"
  },
]);

</script>

<style scoped>
.HotActivity{
  display: flex;
  flex-wrap: wrap;
}
.HotMerchandise{
  display: flex;
  flex-wrap: wrap;
}
.activity{
  width: 20%;
}
.merchandise{
  width: 20%;
}
</style>
