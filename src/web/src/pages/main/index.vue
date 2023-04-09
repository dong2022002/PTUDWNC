<template>
  <div class="main">
    <el-row >
      <el-col :span="5"><div class="grid-content ep-bg-purple" />
      <side-bar class="sider-bar" />
      </el-col>
      <el-col :span="17"><div class="grid-content ep-bg-purple" />
      <carousel class="carousel"/>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import SideBar from '../../components/main/SideBar.vue'
import Carousel from '../../components/main/Carousel.vue'
export default {
  components: { SideBar,Carousel },}
</script>

<style scoped>
.main {
  min-height: 100vh;
  background: #f5f5fa;
  margin: 0;
}
.carousel{
  margin-top: 24px;
  border-radius: 12px;
}

</style>
