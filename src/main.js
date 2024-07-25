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
import HotAct from "./page/HotAct.vue";
import NewAct from "./page/NewAct.vue";
import Article from "./page/Article.vue";
import Show from "./page/Show.vue";
import Concert from "./page/Concert.vue";
import Event from "./page/Event.vue";
import HotItem from "./page/HotItem.vue";
import ArticleItem from "./page/ArticleItem.vue";
import ShowItem from "./page/ShowItem.vue";
import ConcertItem from "./page/ConcertItem.vue";
import EventItem from "./page/EventItem.vue";

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
        path: "/HotAct",
        name: "HotAct",
        component: HotAct,
      },
      {
        path: "/NewAct",
        name: "NewAct",
        component: NewAct,
      },
      {
        path: "/Article",
        name: "Article",
        component: Article,
      },
      {
        path: "/Show",
        name: "Show",
        component: Show,
      },
      {
        path: "/Concert",
        name: "Concert",
        component: Concert,
      },
      {
        path: "/Event",
        name: "Event",
        component: Event,
      },
      {
        path: "/HotItem",
        name: "HotItem",
        component: HotItem,
      },
      {
        path: "/ArticleItem",
        name: "ArticleItem",
        component: ArticleItem,
      },
      {
        path: "/ShowItem",
        name: "ShowItem",
        component: ShowItem,
      },
      {
        path: "/ConcertItem",
        name: "ConcertItem",
        component: ConcertItem,
      },
      {
        path: "/EventItem",
        name: "EventItem",
        component: EventItem,
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
