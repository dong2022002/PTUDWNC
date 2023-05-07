<template>
  <div class="siderbar">
    <div class="h6">Nổi bật</div>
    <el-menu
      :router="true"
      default-active="feature-product"
      class="el-menu"
      @select="handleSelectOutStanding"
      background-color="#fff"
      active-text-color="#303133"
    >
      <el-menu-item route="/products/featured" index="ViewCount">
        <el-icon><box /></el-icon>
        <span>Sản phẩm Nổi bật</span>
      </el-menu-item>
      <el-menu-item route="/products/newest-products" index="CreatedAt">
        <el-icon><goods /></el-icon>
        <span>Hàng mới về</span>
      </el-menu-item>
      <el-menu-item
        route="/products/discount-products"
        index="Discount.DiscountPercent"
      >
        <el-icon><shopping-cart /></el-icon>
        <span>Giá ưu đãi</span>
      </el-menu-item>
    </el-menu>
  </div>
  <div class="siderbar mb-4">
    <div class="h6">Danh mục</div>
    <el-menu
      :router="true"
      class="el-menu"
      @select="handleSelect"
      background-color="#fff"
      active-text-color="#303133"
      v-for="(category, index) in listCategories.data"
      :key="category.id"
    >
      <el-menu-item
        :route="'/products/' + category.slug"
        :index="category.slug"
      >
        <el-icon><box /></el-icon>
        <span>{{ category.name }}</span>
      </el-menu-item>
    </el-menu>
  </div>
</template>

<script>
import { Box, Goods, Setting, ShoppingCart } from "@element-plus/icons-vue";
import { defineComponent, reactive, ref } from "vue";
import { getAllCategories } from "../../services/CategoriesRepository";
import { useProductFilter } from "../../stores/product-filter";
export default defineComponent({
  components: {
    Box,
    ShoppingCart,
    Setting,
    Goods,
  },
  setup() {
    const index = ref();
    const filter = useProductFilter();
    const listCategories = reactive({});
    getAllCategories().then((data) => {
      if (data) {
        listCategories.data = data;
      }
    });
    const handleSelectOutStanding = (key, keyPath) => {
      filter.updateCategorySlug("");
      filter.updateSortColumn(keyPath[0]);
    };
    const handleSelect = (key, keyPath) => {
      filter.updateSortColumn("");
      filter.updateCategorySlug(keyPath[0]);
    };
    return { index, listCategories, handleSelect, handleSelectOutStanding };
  },
});
</script>

<style scoped>
.siderbar {
  border-radius: 12px;
  padding: 16px;
  background: #fff;
  width: 80%;
  margin-left: auto;
  margin-top: 24px;
  margin-right: auto;
}
.el-menu {
  border-right: none;
}
</style>
