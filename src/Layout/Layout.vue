<template>
    <div>
      <q-layout view="hHh Lpr lff" container style="height: 100vh" class="shadow-2 rounded-borders">
        <q-header elevated :class="$q.dark.isActive ? 'bg-secondary' : 'bg-black'">
          <q-toolbar>
            <q-toolbar-title>Header</q-toolbar-title>
          </q-toolbar>
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
              <q-item clickable v-ripple>
                <q-item-section avatar>
                  <q-icon name="inbox" />
                </q-item-section>
  
                <q-item-section>
                  Inbox
                </q-item-section>
              </q-item>
  
              <q-item active clickable v-ripple>
                <q-item-section avatar>
                  <q-icon name="star" />
                </q-item-section>
  
                <q-item-section>
                  Star
                </q-item-section>
              </q-item>
  
              <q-item clickable v-ripple>
                <q-item-section avatar>
                  <q-icon name="send" />
                </q-item-section>
  
                <q-item-section>
                  Send
                </q-item-section>
              </q-item>
  
              <q-item clickable v-ripple>
                <q-item-section avatar>
                  <q-icon name="drafts" />
                </q-item-section>
  
                <q-item-section>
                  Drafts
                </q-item-section>
              </q-item>
            </q-list>
          </q-scroll-area>
  
          <div class="q-mini-drawer-hide absolute" style="top: 15px; right: -17px">
            <q-btn
              dense
              round
              unelevated
              color="accent"
              icon="chevron_left"
              @click="miniState = true"
            />
          </div>
        </q-drawer>
  
        <q-page-container>
          <router-view />
        </q-page-container>
      </q-layout>
    </div>
  </template>
  
  <script>
  import { ref } from 'vue'
  
  export default {
    setup () {
      const miniState = ref(false)
  
      return {
        drawer: ref(false),
        miniState,
  
        drawerClick (e) {
          
          if (miniState.value) {
            miniState.value = false
  
            e.stopPropagation()
          }
        }
      }
    }
  }
  </script>
  