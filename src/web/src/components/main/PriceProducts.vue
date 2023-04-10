<template>
  <div class="feature-products ">
    <div class="d-flex justify-content-between ms-3">
      <div class="fs-6 mb-4 fw-bold">Giá ưu đãi</div>
      <a href="#" class="text-decoration-none">
        <div class="more">
          Xem thêm
          <el-icon size="small">
            <d-arrow-right />
          </el-icon>
        </div>
      </a>
    </div>
    <el-row class="ms-3">
      <el-col
        v-for="(o, index) in 4"
        :key="o"
        :span="5"
        :offset="index > 0 ? 1 : 0"
      >
        <product-card s/>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { ref } from 'vue'
import { DArrowRight } from '@element-plus/icons-vue'
import ProductCard from './ProductCard.vue'
export default {
  components: {
    DArrowRight,
    ProductCard
  },
  setup() {
  }
}
</script>

<style scoped>
.feature-products {
  padding: 24px;
  margin-top: 24px;
  border-radius: 12px;
  min-height: 200px;
  width: 100%;
  background: #fff;
}
.more {
  color: var(--text);
}
</style>
