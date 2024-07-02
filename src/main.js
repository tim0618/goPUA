import { createApp } from "vue";
import { Quasar } from "quasar";
import quasarLang from "quasar/lang/zh-TW";
// import './style.css'
import App from "./App.vue";

// Import icon libraries
import "@quasar/extras/material-icons/material-icons.css";
// Import Quasar css
import "quasar/src/css/index.sass";

import { createRouter, createWebHistory } from "vue-router";
import Layout from "./Layout/Layout.vue";
import Home from "./page/Home.vue";
import test from "./page/test.vue";

const routes = [
  {
    path: "/",
    component: Layout,
    children: [
      {
        path: "/",
        name: "Home",
        component: Home,
      },
      {
        path: "/test",
        name: "test",
        component: test,
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
    plugins: {},
    lang: quasarLang,
  })
  .mount("#app");
