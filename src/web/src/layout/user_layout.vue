<template>
  <div class="">
    <Header-view />
    <router-view />
    <footer-view />
  </div>
</template>

<script>
import HeaderView from "../components/Shared/HeaderView.vue";
import FooterView from "../components/Shared/FooterView";

export default {
  components: {
    HeaderView: HeaderView,
    FooterView: FooterView,
  },
};
</script>
