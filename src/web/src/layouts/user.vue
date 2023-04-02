<template>
  <div class="">
    <the-header />
    <RouterView />
    <FooterView />
  </div>
</template>
<script>
import TheHeader from "../components/UserComponents/TheHeader.vue";
import FooterView from "../components/UserComponents/FooterView.vue";
export default {
  components: {
    TheHeader,
    FooterView,
  },
};
</script>
