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
            <div class="fs-6 mb-2 fw-bold">{{ filter.categoryslug }}</div>
            <a href="#" class="text-decoration-none"> </a>
          </div>
          <el-row>
            <el-col
              v-for="(product, index) in listProducts.data"
              :key="product.id"
              :span="5"
              :offset="1"
            >
              <product-card :product="product" class="m-1" />
            </el-col>
          </el-row>
        </div>
        <div class="bottom-main"></div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { reactive, watch } from "vue";
import SideBar from "../../components/main/SideBar.vue";
import { getProductsFilter } from "../../services/ProductRepository";
import { useProductFilter } from "../../stores/product-filter";
export default {
  components: {
    SideBar,
  },
  setup() {
    const filter = useProductFilter();
    console.log("filter:" + filter.categoryslug);
    const listProducts = reactive({});
    const getProducts = () => {
      getProductsFilter("", filter.categoryslug).then((data) => {
        if (data) {
          listProducts.data = data.items;
        }
      });
    };
    getProducts();
    watch(filter, () => {
      getProducts();
    });

    return {
      listProducts,
      filter,
    };
  },
};
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
.bottom-main {
  margin-bottom: 64px;
}
</style>
