<template>
  <h1><b>編輯區</b></h1>
  <!-- <input id="introduction" ref="introduction" @input="handleInputChange" /> -->
  <input v-model="inputValue" />

</template>

<script setup>
import { ref, watch } from 'vue';
import { debounce } from 'lodash';


const channel = new BroadcastChannel("inputChannel");

// 定義一個 ref 來存儲輸入框的值
const inputValue = ref("");

// 使用 debounce 來防抖動
const debouncedPostMessage = debounce((newValue) => {
  channel.postMessage({ value: newValue });
}, 300);

watch(inputValue, (newValue) => {
  // console.log("inputValue",inputValue)
  // console.log("newValue",newValue)
  debouncedPostMessage(newValue);
})

channel.onmessage = (event) => {
  inputValue.value = event.data.value
}


</script>
