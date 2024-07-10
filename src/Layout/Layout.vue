<template>
  <div>
    <q-layout
      view="hHh Lpr lff"
      container
      style="height: 100vh"
      class="shadow-2 rounded-borders"
    >
      <q-header
        elevated
        :class="$q.dark.isActive ? 'bg-secondary' : 'bg-black'"
        style="display: flex"
      >
        <q-toolbar>
          <q-toolbar-title>
            <a href="/">GoPUA</a>
          </q-toolbar-title>
        </q-toolbar>
        <p>{{ userInput }}</p>
        <q-btn label="Login" color="primary" @click="confirm" />
      </q-header>

      <q-drawer
        v-model="drawer"
        show-if-above
        :mini="!drawer || miniState"
        @click.capture="drawerClick"
        :width="200"
        :breakpoint="500"
        bordered
        :class="$q.dark.isActive ? 'bg-grey-9' : 'bg-grey-3'"
      >
        <q-scroll-area class="fit" :horizontal-thumb-style="{ opacity: 0 }">
          <q-list padding>
            <q-item clickable v-ripple href="/Hot">
              <q-item-section avatar>
                <q-icon name="inbox" />
              </q-item-section>

              <q-item-section> Hot </q-item-section>
            </q-item>

            <q-item active clickable v-ripple href="/New">
              <q-item-section avatar>
                <q-icon name="star" />
              </q-item-section>

              <q-item-section> New </q-item-section>
            </q-item>

            <!-- <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="send" />
              </q-item-section>

              <q-item-section> Send </q-item-section>
            </q-item>

            <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="drafts" />
              </q-item-section>

              <q-item-section> Drafts </q-item-section>
            </q-item> -->
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
            color="accent"
            icon="chevron_left"
            @click="miniState = true"
          />
        </div>
      </q-drawer>

      <!-- 全部內容 -->
      <q-page-container>
        <router-view />
      </q-page-container>
    </q-layout>
  </div>
</template>

<script setup>
import { ref } from "vue";
import { useQuasar } from "quasar";

const miniState = ref(false);
const drawer = ref(false);

const drawerClick = (e) => {
  if (miniState.value) {
    miniState.value = false;

    e.stopPropagation();
  }
};

const $q = useQuasar();
const userInput = ref("");

const confirm = () => {
  $q.dialog({
    title: "Prompt",
    message: "What is your name?",
    prompt: {
      model: "",
      type: "text", // optional
    },
    cancel: true,
    persistent: true,
  })
    .onOk((data) => {
      userInput.value = data;
    })
    .onCancel(() => {
      console.log(">>>> Cancel");
    })
    .onDismiss(() => {
      console.log("I am triggered on both OK and Cancel");
    });
};
</script>
