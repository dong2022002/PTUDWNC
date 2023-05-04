<template>
  <div class="feature-products">
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
        v-for="(product, index) in listProducts.data"
        :key="product.id"
        :span="5"
        :offset="index > 0 ? 1 : 0"
      >
        <product-card :product="product" />
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { DArrowRight } from "@element-plus/icons-vue";
import { reactive } from "vue";
import { getDiscountProduct } from "../../services/ProductRepository";
import ProductCard from "./ProductCard.vue";

export default {
  components: {
    DArrowRight,
    ProductCard,
  },
  setup() {
    const listProducts = reactive({});
    getDiscountProduct(4).then((data) => {
      if (data) {
        listProducts.data = data;
      }
    });
    return {
      listProducts,
    };
  },
};
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
