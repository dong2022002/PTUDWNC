<template>
  <el-row class="ms-4 mt-3" style="height: 40px">
    <el-col :span="2"
      ><div class="grid-content ep-bg-purple" />
      <img src="../../../public/vite.svg" alt="" />
    </el-col>
    <el-col :span="13"
      ><div class="grid-content ep-bg-purple" />
      <div>
        <el-input
          v-model="keyword"
          size="large"
          placeholder="Nhập tìm kiếm "
          class="input-with-select"
        >
          <template #prepend> </template>
          <template #append>
            <el-button @click="handleKeyword(keyword)">
              <el-icon><search /></el-icon>
            </el-button>
          </template>
        </el-input>
      </div>
    </el-col>
    <el-col :span="9">
      <el-row>
        <el-col :span="7" class="center-col"
          ><div class="grid-content ep-bg-purple" />
          <router-link to="/">
            <el-button
              size="large"
              type="primary"
              text
              class="fs-6"
              :icon="HomeFilled"
              >Trang chủ</el-button
            >
          </router-link>
        </el-col>
        <el-col :span="7" class="center-col"
          ><div class="grid-content ep-bg-purple" />
          <router-link to="/contact">
            <el-button size="large" class="fs-6" text :icon="Service"
              >Liên hệ</el-button
            >
          </router-link>
        </el-col>
        <el-col :span="6" class="center-col"
          ><div class="grid-content ep-bg-purple" />
          <Login></Login>
        </el-col>

        <el-col :span="3" class="center-col">
          <div class="grid-content ep-bg-purple" />
          <el-button size="large" type="primary" text>
            <el-icon size="28px"><shopping-cart /> </el-icon> </el-button
        ></el-col>
      </el-row>
      <div class="grid-content ep-bg-purple" />
    </el-col>
  </el-row>
  <el-row>
    <el-col :span="3"><div class="grid-content ep-bg-purple" /></el-col>
    <el-col :span="12"
      ><div class="grid-content ep-bg-purple" />
      <div class="d-flex justify-content-evenly bottom-menu">
        <div
          v-for="(category, index) in listCategories.data"
          :key="category.id"
        >
          <router-link
            @click="handleSlugCategory(category.slug)"
            class="text-decoration-none text_bottom-menu"
            :to="{ name: 'products', params: { slug: category.slug } }"
          >
            {{ category.name }}
          </router-link>
        </div>
      </div>
    </el-col>
    <el-col :span="9"><div class="grid-content ep-bg-purple" /></el-col>
  </el-row>
</template>

<script>
import {
  HomeFilled,
  Search,
  Service,
  ShoppingCart,
  UserFilled,
} from "@element-plus/icons-vue";
import { reactive, ref } from "vue";
import { useRoute, useRouter } from "vue-router";
import { getRandomCategories } from "../../services/CategoriesRepository";
import { useProductFilter } from "../../stores/product-filter";
export default {
  components: {
    Search,
    ShoppingCart,
  },
  setup() {
    const filter = useProductFilter();
    const activeIndex = ref("1");
    const route = useRoute();
    const router = useRouter();
    const handleSelect = (key, keyPath) => {
      console.log(key, keyPath);
    };
    const keyword = ref("");

    const select = ref("");
    const listCategories = reactive({});
    getRandomCategories(5).then((data) => {
      if (data) {
        listCategories.data = data;
      }
    });
    const handleSlugCategory = (slug) => {
      filter.updateCategorySlug(slug);
    };

    const handleKeyword = (keyword) => {
      if (keyword === "") return;
      filter.updateKeyword(keyword);
      router.push({
        name: "productsKeywords",
        params: {
          slug: filter.categoryslug === "" ? "all" : filter.categoryslug,
          keyword: keyword,
        },
      });
    };
    return {
      handleKeyword,
      handleSlugCategory,
      activeIndex,
      listCategories,
      handleSelect,
      keyword,
      select,
      HomeFilled,
      UserFilled,
      Service,
      filter,
    };
  },
};
</script>

<style scoped>
.flex-grow {
  flex-grow: 1;
}
.select-input {
  width: 20px;
}
.el-menu-demo {
  border-bottom: none;
}
/* .el-row {
  margin-bottom: 20px;
} */
.el-row:last-child {
  margin-bottom: 0;
}
.el-col {
  border-radius: 4px;
}

.grid-content {
  border-radius: 4px;
  min-height: 4px;
}
.center-col {
  margin-top: 4px;
  display: flex;
  justify-content: center;
}
.bottom-menu {
  margin-top: 6px;
  font-size: 13px;
}
.text_bottom-menu {
  color: #808089;
}
</style>
