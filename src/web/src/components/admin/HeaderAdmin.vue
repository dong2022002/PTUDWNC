<template>
  <el-menu
    :default-active="activeIndex"
    class="el-menu"
    mode="horizontal"
    :ellipsis="false"
    @select="handleSelect"
  >
    <!-- Breadcrumb -->
    <el-breadcrumb :separator-icon="ArrowRight" class="breadcrumb">
      <el-breadcrumb-item :to="{ path: '/admin' }"
        >Dashboard</el-breadcrumb-item
      >
      <el-breadcrumb-item>{{ store.title }}</el-breadcrumb-item>
    </el-breadcrumb>
    <div class="flex-grow" />

    <el-sub-menu index="2">
      <template #title>Admin</template>
      <router-link :to="{ path: '/admin/login' }"
        ><el-menu-item index="2-1">Đăng xuất</el-menu-item></router-link
      >
    </el-sub-menu>
  </el-menu>
</template>

<script>
import { ArrowRight } from "@element-plus/icons-vue";
import { ref } from "vue";
import { useRouter } from "vue-router";
import { useBreadCurmb } from "../../stores/breadcrumb.js";
export default {
  components: {
    ArrowRight,
  },
  emits: ["checkAdmin"],
  setup(props, { emit }) {
    const store = useBreadCurmb();
    const activeIndex = ref("1");
    const router = useRouter();
    const handleSelect = (key, keyPath) => {
      if (key == 2) {
        store.$reset;
        emit["checkAdmin"];
      }
    };
    return {
      store,
      activeIndex,
      handleSelect,
      ArrowRight,
    };
  },
};
</script>

<style>
.flex-grow {
  flex-grow: 1;
}
.breadcrumb {
  padding: 24px;
}
</style>
