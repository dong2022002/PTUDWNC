<template>
  <div class="main">
    <el-row>
      <el-col :span="5"
        ><div class="grid-content ep-bg-purple" />
        <side-bar />
      </el-col>
      <el-col :span="17"
        ><div class="grid-content ep-bg-purple" />
        <carousel class="carousel" />
        <featured-product />
        <new-product />
        <price-products />
        <today-product class="margin-bottom-main" />
      </el-col>
    </el-row>
  </div>
</template>

<script>
import Carousel from "../../components/main/Carousel.vue";
import FeaturedProduct from "../../components/main/FeaturedProduct.vue";
import NewProduct from "../../components/main/NewProduct.vue";
import PriceProducts from "../../components/main/PriceProducts.vue";
import SideBar from "../../components/main/SideBar.vue";
import TodayProduct from "../../components/main/TodayProduct.vue";
import { useProductFilter } from "../../stores/product-filter";

export default {
  components: {
    SideBar,
    Carousel,
    FeaturedProduct,
    NewProduct,
    PriceProducts,
    TodayProduct,
  },
  setup() {
    const filter = useProductFilter();
    filter.$reset();
    return { filter };
  },
};
</script>

<style scoped>
.main {
  min-height: 100vh;
  background: #f5f5fa;
}
.carousel {
  margin-top: 24px;
  border-radius: 12px;
}
.margin-bottom-main {
  margin-bottom: 60px;
}
</style>
