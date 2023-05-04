<template>
  <div class="feature-products">
    <div class="d-flex justify-content-between ms-3">
      <div class="fs-6 fw-bold">Gợi ý hôm nay</div>
    </div>
    <el-row class="ms-3">
      <el-col
        v-for="(product, index) in listProducts.data"
        :key="product.id"
        :span="5"
        :offset="index == 0 || index == 4 ? 0 : 1"
      >
        <product-card class="m-2" :product="product" />
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { DArrowRight } from "@element-plus/icons-vue";
import { reactive } from "vue";
import { getRandomProduct } from "../../services/ProductRepository";
import ProductCard from "./ProductCard.vue";

export default {
  components: {
    DArrowRight,
    ProductCard,
  },
  setup() {
    const listProducts = reactive({});
    getRandomProduct(8).then((data) => {
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
