<template>
  <div class="main">
    <el-row>
      <el-col :span="5"
        ><div class="grid-content ep-bg-purple" />
        <side-bar />
      </el-col>
      <el-col :span="17"
        ><div class="grid-content ep-bg-purple" />
        <div class="feature-products">
          <div class="d-flex justify-content-between ms-3">
            <div class="fs-6 mb-2 fw-bold">{{ nameCategory }}</div>
            <a href="#" class="text-decoration-none"> </a>
          </div>
          <el-row>
            <el-col
              v-if="hasData"
              v-for="(product, index) in listProducts.data"
              :key="product.id"
              :span="5"
              :offset="1"
            >
              <product-card :product="product" class="m-1" />
            </el-col>
            <div class="d-flex justify-content-between notify" v-else>
              <el-text size="small" class="d-block text-notify" type="small"
                >Hiện chưa có sản phẩm nào</el-text
              >
            </div>
          </el-row>
        </div>
        <div class="bottom-main"></div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { reactive, ref, watch } from "vue";
import SideBar from "../../components/main/SideBar.vue";
import { getCategoryBySlug } from "../../services/CategoriesRepository";
import { getProductsFilter } from "../../services/ProductRepository";
import { useProductFilter } from "../../stores/product-filter";
export default {
  components: {
    SideBar,
  },
  setup() {
    const filter = useProductFilter();
    const listProducts = reactive({});
    const nameCategory = ref("");
    const hasData = ref(false);

    const getNameCategory = () => {
      getCategoryBySlug(filter.categoryslug).then((data) => {
        nameCategory.value = data.name;
      });
    };
    const getProducts = () => {
      window.scrollTo(0, 0);

      getProductsFilter(
        filter.keyword,
        filter.categoryslug,
        10,
        1,
        filter.SortColumn,
        filter.SortOrder
      ).then((data) => {
        if (data) {
          listProducts.data = data.items;

          if (listProducts.data.length > 0) {
            hasData.value = true;
          } else {
            hasData.value = false;
          }
        }
      });
    };
    if (filter.categoryslug !== "") {
      getNameCategory();
    }
    getProducts();
    watch(filter, () => {
      getProducts();
      getNameCategory();
    });

    return {
      hasData,
      nameCategory,
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
.notify {
  width: 100%;
  height: 20vh;
}
.text-notify {
  margin: auto;
}
</style>
