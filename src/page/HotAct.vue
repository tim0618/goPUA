<template>
  <div>
    <div class="top">
      <div class="title">熱門活動</div>
      <q-input class="search" v-model="text" input-class="text-left">
        <template v-slot:append>
          <q-btn><q-icon name="search" /></q-btn>
        </template>
      </q-input>
    </div>

    <div class="HotAct">
      <div v-for="hotAct in hotActs">
        <Activity :activityitem="hotAct" />
      </div>
    </div>
  </div>
</template>

<script setup>
import { reactive, ref } from "vue";
import Activity from "../component/activity.vue";

const text = ref("");

const hotActs = reactive([
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
</script>

<style>
.HotAct {
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
