<template>
  <div class="">
    <HeaderView />
    <router-view />
    <footer-view />
  </div>
</template>

<script>
import HeaderView from "./views/Shared/HeaderView";
import FooterView from "./views/Shared/FooterView";

export default {
  components: {
    HeaderView: HeaderView,
    FooterView: FooterView,
  },
};
</script>
