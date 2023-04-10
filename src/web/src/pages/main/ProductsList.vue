<template>
  <div class="main">
    <el-row>
      <el-col :span="5"
        ><div class="grid-content ep-bg-purple" />
        <side-bar class="sider-bar" />
      </el-col>
      <el-col :span="17"
        ><div class="grid-content ep-bg-purple" />
        <div class="feature-products">
          <div class="d-flex justify-content-between ms-3">
            <div class="fs-6 mb-4 fw-bold">Sản phẩm nổi bật</div>
            <a href="#" class="text-decoration-none"> </a>
          </div>
          <el-row>
            <el-col  v-for="index in 100" :key="index" :span="5" :offset="1">
              <product-card class="mt-4" />
            </el-col>
          </el-row>
        </div>
        <div  class="bottom-main"></div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import SideBar from '../../components/main/SideBar.vue'

export default {
  components: {
    SideBar
  }
}
</script>

<style scoped>
.main {
  min-height: 100vh;
  background: #f5f5fa;
}
.feature-products {
  padding: 24px;
  margin-top: 24px;
  border-radius: 12px;
  min-height: 200px;
  width: 100%;
  background: #fff;
}
.bottom-main{
  margin-bottom: 64px;
}
</style>
