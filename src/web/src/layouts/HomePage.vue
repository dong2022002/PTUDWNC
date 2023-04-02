<template>
  <a-layout-sider>
    <the-header />
  </a-layout-sider>
  <a-layout-content>Content</a-layout-content>
  <a-layout-footer>Footer</a-layout-footer>
</template>
<script>
import TheHeader from "../components/UserComponents/TheHeader.vue";

export default {
  components: {
    TheHeader,
  },
};
</script>
