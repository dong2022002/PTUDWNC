<template>
  <div class="common-layout">
    <el-container>
      <el-aside width="200px">
        <aside-admin />
      </el-aside>
      <el-container>
        <el-header @checkAdmin="checkAdmin" class="el-header">
          <header-admin />
        </el-header>
        <el-main>
          <router-view></router-view>
        </el-main>
        <el-footer>
          <footer-admin />
        </el-footer>
      </el-container>
    </el-container>
  </div>
</template>
<script>
import { useRouter } from "vue-router";
import AsideAdmin from "../components/admin/AsideAdmin.vue";
import FooterAdmin from "../components/admin/FooterAdmin.vue";
import HeaderAdmin from "../components/admin/HeaderAdmin.vue";
import { useAdminAccount } from "../stores/accountAdmin";
export default {
  components: {
    HeaderAdmin,
    AsideAdmin,
    FooterAdmin,
  },
  setup() {
    const storeAdmin = useAdminAccount();
    const router = useRouter();

    const checkAdmin = () => {
      if (storeAdmin.username === "" && storeAdmin.password === "") {
        router.replace({ name: "loginAdmin" });
        console.log("logout");
      }
    };
    checkAdmin();

    return {
      checkAdmin,
    };
  },
};
</script>
<style scoped>
.el-header {
  padding: 0 !important;
}
.el-footer {
  padding: 0 !important;
}
.container {
  max-width: 100%;
  margin: auto;
}

.el-main {
  background: #eef1f4;
  height: 100vh;
}
</style>
