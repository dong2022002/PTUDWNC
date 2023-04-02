<template>
  <div class="">
    <the-header />
    Content
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
