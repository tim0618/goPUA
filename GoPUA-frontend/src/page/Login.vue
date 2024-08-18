<template>
  <q-dialog v-model="isVisible" persistent>
    <q-card class="dialog">
      <q-card-actions align="right">
        <q-btn flat label="X" v-close-popup @click="onCancel" />
      </q-card-actions>
      <q-card-section class="title">
        <q-btn flat label="登入" @click="setType('login')" />
        <q-btn flat label="註冊" @click="setType('register')" />
      </q-card-section>

      <q-card-section class="input">
        <q-input v-model="model.account" :type="account" label="帳號" />
        <q-input
          v-if="type === 'register'"
          v-model="model.email"
          :type="email"
          label="信箱"
        />
        <q-input v-model="model.password" :type="password" label="密碼" />
        <q-input
          v-if="type === 'register'"
          v-model="model.passwordcheck"
          :type="passwordcheck"
          label="密碼確認"
        />
      </q-card-section>

      <q-card-actions align="center">
        <q-btn v-if="type === 'register'" flat label="註冊" @click="Register" />
        <q-btn v-if="type === 'login'" flat label="登入" @click="Login" />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script setup>
import { ref } from "vue";

const emit = defineEmits(["register", "login", "cancel"]);

const type = ref("login");
const isVisible = ref(true);

const model = ref({
  account: "",
  email: "",
  password: "",
  passwordcheck: "",
});

const Register = () => {
  emit("register", model.value);
  setType("login");
};

const Login = () => {
  const filteredData = Object.fromEntries(
    Object.entries(model.value).filter(([key, value]) => value !== "")
  );
  emit("login", filteredData);
};
const onCancel = () => {
  emit("cancel");
  isVisible.value = false;
};

const setType = (newtype) => {
  type.value = newtype;
};
</script>

<style scoped>
.title {
  display: flex;
  justify-content: center;
  align-items: center;
}
.dialog {
  width: 400px;
  height: auto;
  padding: 15px;
}
</style>
