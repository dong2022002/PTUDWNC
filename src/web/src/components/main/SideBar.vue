<template>
    <div class="siderbar">
      <div class="h6">Nổi bật</div>
      <el-menu
        router="true"
        default-active="feature-product"
        class="el-menu"
        @select="handleSelect"
        background-color="#fff"
      >
        <el-menu-item route="/admin/products" index="products">
          <el-icon><box /></el-icon>
          <span>Sản phẩm Nổi bật</span>
        </el-menu-item>
        <el-menu-item route="/admin/users" index="users">
          <el-icon><goods /></el-icon>
          <span>Hàng mới về</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Giá ưu đãi</span>
        </el-menu-item>
      </el-menu>
    </div>
    <div class="siderbar mb-4">
      <div class="h6">Danh mục</div>
      <el-menu
        router="true"
        default-active="feature-product"
        class="el-menu"
        @select="handleSelect"
        background-color="#fff"
      >
        <el-menu-item route="/admin/products" index="products">
          <el-icon><box /></el-icon>
          <span>Máy tính</span>
        </el-menu-item>
        <el-menu-item route="/admin/users" index="users">
          <el-icon><goods /></el-icon>
          <span>Lap top</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Card Đồ họa</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Card Đồ họa</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Card Đồ họa</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Card Đồ họa</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Card Đồ họa</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Card Đồ họa</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Card Đồ họa</span>
        </el-menu-item>
        <el-menu-item index="cart">
          <el-icon><shopping-cart /></el-icon>
          <span>Card Đồ họa</span>
        </el-menu-item>
      </el-menu>
    </div>
</template>

<script>
import { ref, defineComponent } from 'vue'
import {
  Box,
  Menu as IconMenu,
  ShoppingCart,
  Setting,
  Goods
} from '@element-plus/icons-vue'
export default defineComponent({
  components: {
    Box,
    IconMenu,
    ShoppingCart,
    Setting,
    Goods
  },
  setup() {
    const index = ref()
    const handleSelect = (key) => {
      menu.onSelectedKeys(key)
    }
    return { index, handleSelect }
  }
})
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
.el-scrollbar{

}

</style>
