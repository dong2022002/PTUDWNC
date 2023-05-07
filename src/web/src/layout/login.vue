<template>
  <section class="h-100 gradient-form" style="background-color: #eee">
    <div class="container py-5 vh-100">
      <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-xl-10">
          <div class="card rounded-3 text-black">
            <div class="row g-0">
              <div class="col-lg-6">
                <div class="card-body p-md-5 mx-md-4">
                  <div class="text-center">
                    <img
                      src="../../public/vite.svg"
                      style="width: 115px"
                      alt="logo"
                    />
                    <h4 class="mt-1 mb-5 pb-1">Đăng nhập</h4>
                  </div>

                  <el-form
                    ref="ruleFormRef"
                    :model="ruleForm"
                    status-icon
                    :rules="rules"
                    class="demo-ruleForm w-100"
                  >
                    <el-form-item prop="account">
                      <el-input
                        placeholder="Tài khoản"
                        v-model="ruleForm.account"
                        type="text"
                        autocomplete="off"
                      />
                    </el-form-item>
                    <el-form-item prop="pass">
                      <el-input
                        placeholder="Mật khẩu"
                        v-model="ruleForm.pass"
                        type="password"
                        autocomplete="off"
                      />
                    </el-form-item>
                  </el-form>
                  <div class="d-flex justify-content-end">
                    <el-button type="primary" @click="submitForm(ruleFormRef)">
                      Đăng nhập
                    </el-button>
                  </div>
                </div>
                <div class="p-4 ps-6 text-danger" v-if="errorCheck">
                  Sai tài khoản hoặc mật khẩu
                </div>
              </div>

              <div class="col-lg-6">
                <el-image :src="getImageAssetsSlider(4)" :fit="fill"></el-image>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
import { getImageAssetsSlider } from "../utils/GetImageUrl";

import { UserFilled } from "@element-plus/icons-vue";
import { reactive, ref } from "vue";
import { useRouter } from "vue-router";
import { checkAdmin } from "../services/AdminRepository";
import { useAdminAccount } from "../stores/accountAdmin";
export default {
  setup() {
    const ruleFormRef = ref();
    const storeAdmin = useAdminAccount();
    const router = useRouter();
    const errorCheck = ref(false);
    const validateAccount = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("Nhập vào tài khoản"));
      } else {
        callback();
      }
    };
    const validatePass = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("Nhập vào mật khẩu"));
      } else {
        callback();
      }
    };
    const ruleForm = reactive({
      account: "",
      pass: "",
    });

    const rules = reactive({
      account: [{ validator: validateAccount, trigger: "blur" }],
      pass: [{ validator: validatePass, trigger: "blur" }],
    });

    const submitForm = (formEl) => {
      if (!formEl) return;
      formEl.validate((valid) => {
        if (valid) {
          let formData = new FormData();
          formData.append("username", ruleForm.account);
          formData.append("password", ruleForm.pass);

          checkAdmin(formData).then((data) => {
            if (data) {
              storeAdmin.updateCategory(data.username, data.password);
              router.replace({ name: "admin-products" });
            } else {
              console.log("Thao tác thất bại");
              errorCheck.value = true;
            }
          });
        } else {
          console.log("error submit!");
          return false;
        }
      });
    };
    const dialogFormVisible = ref(false);
    const dialogFormVisibleRegister = ref(false);
    const formLabelWidth = "100px";
    return {
      dialogFormVisible,
      dialogFormVisibleRegister,
      UserFilled,
      formLabelWidth,
      rules,
      submitForm,
      ruleForm,
      ruleFormRef,
      getImageAssetsSlider,
      errorCheck,
    };
  },
};
</script>

<style scoped>
.login {
  margin-top: 100px;
  border-radius: 16px;
}
.el-image {
  height: 100%;
  object-fit: cover;
  border-radius: 8px;
}
</style>
