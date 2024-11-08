<template>
  <div class="head">
    <q-layout
      view="hHh Lpr lff"
      container
      style="height: 100vh"
      class="shadow-2 rounded-borders"
    >
      <q-header
        elevated
        :class="$q.dark.isActive"
        style="display: flex; background-color: rgb(203, 225, 243)"
        class="header"
      >
        <q-toolbar>
          <q-toolbar-title>
            <a href="/" class="title">GoPUA</a>
          </q-toolbar-title>
          <div>
            {{ userLogin }}
            <a href="/Cart"> <font-awesome-icon :icon="['fas', 'user']" /> </a>
            <a href="/User"> <font-awesome-icon :icon="['fas', 'user']" /> </a>
            <q-btn v-if="userLogin" label="登出" @click="" class="loginbtn" />
          </div>
          <div>
            <q-btn
              v-if="userLogin"
              label="登入"
              @click="choiceLogin"
              class="loginbtn"
            />
          </div>
        </q-toolbar>
      </q-header>

      <q-drawer
        v-model="drawer"
        show-if-above
        :mini="!drawer || miniState"
        @click.capture="drawerClick"
        :width="240"
        :breakpoint="500"
        bordered
        :class="$q.dark.isActive"
        style="background-color: lightsteelblue"
      >
        <q-scroll-area class="fit" :horizontal-thumb-style="{ opacity: 0 }">
          <q-list padding class="list">
            <q-expansion-item
              clickable
              v-ripple
              href="/HotAct"
              :content-inset-level="0.5"
              expand-separator
              icon="mail"
              label="熱門活動"
              expand-icon="null"
            >
            </q-expansion-item>

            <q-expansion-item
              clickable
              v-ripple
              href="/NewAct"
              :content-inset-level="0.5"
              expand-separator
              icon="mail"
              label="最新活動"
              expand-icon="null"
            >
            </q-expansion-item>

            <q-expansion-item
              :content-inset-level="0.5"
              expand-separator
              icon="mail"
              label="活動分類"
              expand-icon="null"
            >
              <q-expansion-item
                :content-inset-level="0.5"
                href="/Article"
                icon="receipt"
                label="藝文表演"
                expand-icon="null"
              >
              </q-expansion-item>
              <q-expansion-item
                :content-inset-level="0.5"
                href="/Show"
                icon="receipt"
                label="活動展覽"
                expand-icon="null"
              >
              </q-expansion-item>
              <q-expansion-item
                :content-inset-level="0.5"
                href="/Concert"
                icon="receipt"
                label="演唱會"
                expand-icon="null"
              >
              </q-expansion-item>
              <q-expansion-item
                :content-inset-level="0.5"
                href="/Event"
                icon="receipt"
                label="體育賽事"
                expand-icon="null"
              >
              </q-expansion-item>
            </q-expansion-item>

            <q-expansion-item
              :content-inset-level="0.5"
              expand-separator
              icon="mail"
              label="周邊商品"
              expand-icon="null"
            >
              <q-expansion-item
                :content-inset-level="0.5"
                href="/HotItem"
                icon="receipt"
                label="熱門周邊"
                expand-icon="null"
              >
              </q-expansion-item>
              <q-expansion-item
                :content-inset-level="0.5"
                href="/ArticleItem"
                icon="receipt"
                label="藝文周邊"
                expand-icon="null"
              >
              </q-expansion-item>
              <q-expansion-item
                :content-inset-level="0.5"
                href="/ShowItem"
                icon="receipt"
                label="展覽周邊"
                expand-icon="null"
              >
              </q-expansion-item>
              <q-expansion-item
                :content-inset-level="0.5"
                href="/ConcertItem"
                icon="receipt"
                label="演唱會周邊"
                expand-icon="null"
              >
              </q-expansion-item>
              <q-expansion-item
                :content-inset-level="0.5"
                href="/EventItem"
                icon="receipt"
                label="體育周邊"
                expand-icon="null"
              >
              </q-expansion-item>
            </q-expansion-item>

            <q-expansion-item
              clickable
              v-ripple
              href="/AAA"
              :content-inset-level="0.5"
              expand-separator
              icon="mail"
              label="留言區"
              expand-icon="null"
            >
            </q-expansion-item>
          </q-list>
        </q-scroll-area>

        <div
          class="q-mini-drawer-hide absolute"
          style="top: 15px; right: -17px"
        >
          <q-btn
            denses
            round
            unelevated
            style="background-color: rgb(144, 137, 183)"
            icon="chevron_left"
            @click="miniState = true"
          />
        </div>
      </q-drawer>

      <!-- 全部內容 -->
      <q-page-container> <router-view /> </q-page-container>
    </q-layout>
  </div>
</template>

<script setup>
import { ref, h } from "vue";
import { useQuasar } from "quasar";
import LoginPage from "../page/Login.vue";
import axios from "axios";
import LoginApi from "../js/Login";

const miniState = ref(false);
const drawer = ref(false);

const drawerClick = (e) => {
  if (miniState.value) {
    miniState.value = false;

    e.stopPropagation();
  }
};

const $q = useQuasar();
const userRegister = ref({
  account: "",
  email: "",
  password: "",
  passwordcheck: "",
});
const userLogin = ref({
  account: "",
  password: "",
});

const choiceLogin = () => {
  const contentRef = ref(null);

  const content = h(LoginPage, {
    onRegister: (data) => {
      userRegister.value = data;
    },
    onLogin: (data) => {
      userLogin.value = data;
      LoginApi.login(data);
      // login(data);
      contentRef.value.hide();
    },
    onCancel: () => {
      console.log("dialog canceled");
      contentRef.value.hide();
    },
  });

  contentRef.value = $q.dialog({
    component: content,
  });
};
</script>
<style scoped>
.head {
  font-weight: bold;
  font-size: 16px;
}

.header {
  display: flex;
  flex-direction: row;
}

.title {
  font-size: 32px;
  font-weight: bold;
  text-decoration: none;
  color: rgb(22, 13, 81);
}

.loginbtn {
  width: 75px;
  margin: 15px;
  background-color: white;
  color: black;
  font-weight: bold;
}
</style>
