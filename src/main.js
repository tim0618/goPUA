import { createApp } from "vue";
import { Quasar, Dialog } from "quasar";
import quasarLang from "quasar/lang/zh-TW";
// import './style.css'
import App from "./App.vue";

// Import icon libraries
import "@quasar/extras/material-icons/material-icons.css";
// Import Quasar css
import "quasar/src/css/index.sass";

import { createRouter, createWebHistory } from "vue-router";
import Layout from "./Layout/Layout.vue";
import GoPUA from "./page/Home.vue";
import Hot from "./page/Hot.vue";
import New from "./page/New.vue";

const routes = [
  {
    path: "/",
    component: Layout,
    children: [
      {
        path: "/",
        name: "GoPUA",
        component: GoPUA,
      },
      {
        path: "/Hot",
        name: "Hot",
        component: Hot,
      },
      {
        path: "/New",
        name: "New",
        component: New,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

const myApp = createApp(App)
  .use(router)
  .use(Quasar, {
    plugins: { Dialog },
    lang: quasarLang,
  })
  .mount("#app");
