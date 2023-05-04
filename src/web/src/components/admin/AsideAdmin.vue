<template>
  <el-menu
    router="true"
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
    <el-menu-item route="/admin/users" index="users">
      <el-icon><avatar /></el-icon>
      <span>Khách hàng</span>
    </el-menu-item>
    <el-menu-item index="cart">
      <el-icon><shopping-cart /></el-icon>
      <span>Đơn hàng</span>
    </el-menu-item>
    <el-menu-item index="settings">
      <el-icon><setting /></el-icon>
      <span>Cài đặt</span>
    </el-menu-item>
  </el-menu>
</template>

<script>
import { defineComponent } from "vue";
import { storeToRefs } from "pinia";
import { useMenu } from "../../stores/use-menu-admin.js";
import { ref } from "vue";
import {
  Box,
  Menu as IconMenu,
  ShoppingCart,
  Setting,
  Avatar,
} from "@element-plus/icons-vue";
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
  min-height: 100vh;
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
