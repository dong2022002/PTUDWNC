<template>
  <HeaderView />
  <router-view :to="{ name: 'home' }"></router-view>
  <footer-view />
</template>

<script>
import HeaderView from "./views/HeaderView.vue";
import FooterView from "./views/FooterView.vue";
export default {
  components: {
    HeaderView: HeaderView,
    FooterView: FooterView,
  },
};
</script>
