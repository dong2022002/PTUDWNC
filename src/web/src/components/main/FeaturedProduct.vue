<template>
  <div class="feature-products" v-if="loading">
    <div class="d-flex justify-content-between ms-3">
      <div class="fs-6 mb-4 fw-bold">Sản phẩm nổi bật</div>
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
  <div class="loading" v-else>Loading...</div>
</template>

<script>
import { DArrowRight } from "@element-plus/icons-vue";
import { reactive, ref } from "vue";
import { getFeaturedProducts } from "../../services/ProductRepository";
import ProductCard from "./ProductCard.vue";
export default {
  components: {
    DArrowRight,
    ProductCard,
  },
  setup() {
    let loading = ref(true);
    let listProducts = reactive({});
    getFeaturedProducts(4).then((data) => {
      if (data) {
        listProducts.data = data;
        console.log(listProducts.data);
        loading = false;
      }
    });
    return {
      listProducts,
      loading,
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
