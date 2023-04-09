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
    <el-breadcrumb-item :to="{ path: '/' }">Dashboard</el-breadcrumb-item>
    <el-breadcrumb-item>promotion management</el-breadcrumb-item>
    <el-breadcrumb-item>promotion list</el-breadcrumb-item>
    <el-breadcrumb-item>promotion detail</el-breadcrumb-item>
  </el-breadcrumb>
    <div class="flex-grow" />

    <el-sub-menu index="2">
      <template #title>Admin</template>
      <el-menu-item index="2-1">Đăng xuất</el-menu-item>
    </el-sub-menu>
  </el-menu>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import { ArrowRight } from '@element-plus/icons-vue'
const activeIndex = ref('1')
const handleSelect = (key: string, keyPath: string[]) => {
  console.log(key, keyPath)
}
</script>

<style>
.flex-grow {
  flex-grow: 1;
}
.breadcrumb{
  padding: 24px;
}
</style>