<template>
  <div class="common-layout">
    <el-container>
      <el-header height="92px">
        <header-main />
      </el-header>
      <el-main>
        <router-view></router-view>
      </el-main>
      <el-footer>
        <footer-main />
      </el-footer>
    </el-container>
  </div>
</template>
<script>
import HeaderMain from '../components/main/Header.vue'
import FooterMain from '../components/main/Footer.vue'
export default {
  components: {
    HeaderMain,
    FooterMain,
  },
  setup() {}
}
</script>
<style scoped>
.el-main{
  padding: 0;
}
.el-header {
  padding: 0 !important;
}
.el-footer{
  padding: 0 !important;
}
</style>
