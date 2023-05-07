<template>
  <el-menu
    :router="true"
    :default-active="index"
    class="el-menu"
    @select="handleSelect"
    text-color="#ced2cc"
    background-color="#545c64"
    active-text-color="#000"
  >
    <div class="container-logo">
      <img src="../../../public/vite.svg" alt="" />
    </div>
    <el-menu-item route="/admin/products" index="products">
      <el-icon><box /></el-icon>
      <span>Sản phẩm</span>
    </el-menu-item>
    <el-menu-item route="/admin/category" index="categories">
      <el-icon><box /></el-icon>
      <span>Danh mục</span>
    </el-menu-item>
    <el-menu-item route="/admin/discount" index="discounts">
      <el-icon><box /></el-icon>
      <span>Giảm giá</span>
    </el-menu-item>
    <el-menu-item route="/admin/users" index="users">
      <el-icon><avatar /></el-icon>
      <span>Khách hàng</span>
    </el-menu-item>
    <el-menu-item route="/admin/cart" index="cart">
      <el-icon><shopping-cart /></el-icon>
      <span>Đơn hàng</span>
    </el-menu-item>
    <el-menu-item route="/admin/settings" index="settings">
      <el-icon><setting /></el-icon>
      <span>Cài đặt</span>
    </el-menu-item>
  </el-menu>
</template>

<script>
import {
  Avatar,
  Box,
  Menu as IconMenu,
  Setting,
  ShoppingCart,
} from "@element-plus/icons-vue";
import { storeToRefs } from "pinia";
import { defineComponent, ref } from "vue";
import { useMenu } from "../../stores/use-menu-admin.js";
export default defineComponent({
  components: {
    Box,
    IconMenu,
    ShoppingCart,
    Setting,
    Avatar,
  },
  setup() {
    const menu = useMenu();
    const index = ref("products");
    const handleSelect = (key) => {
      menu.onSelectedKeys(key);
    };
    return { index, handleSelect, ...storeToRefs(menu) };
  },
});
</script>

<style scoped>
.el-menu {
  height: 100%;
  border-right: 0 !important;
}
.el-sub-menu {
  pad: 0 !important;
}
.container-logo {
  padding: 22px;
  background: #323a50;
  color: #fff;
}
</style>
