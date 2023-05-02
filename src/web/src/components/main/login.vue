<template>
  <!-- Form -->
  <el-button
    size="large"
    class="fs-6"
    text
    :icon="UserFilled"
    @click="dialogFormVisible = true"
  >
    Tài khoản
  </el-button>

  <el-dialog v-model="dialogFormVisible" title="Đăng nhập" width="30%" center>
    <el-form
      ref="ruleFormRef"
      :model="ruleForm"
      status-icon
      :rules="rules"
      label-width="25%"
      class="demo-ruleForm"
    >
      <el-form-item label="Tài khoản" prop="account">
        <el-input v-model="ruleForm.account" type="text" autocomplete="off" />
      </el-form-item>
      <el-form-item label="Mật khẩu" prop="pass">
        <el-input v-model="ruleForm.pass" type="password" autocomplete="off" />
      </el-form-item>
      <div class="register">
        <el-text size="small"
          >Chưa có tài khoản
          <el-button
            @click="
              (dialogFormVisible = false), (dialogFormVisibleRegister = true)
            "
            size="small"
            type="primary"
            text
          >
            Đăng ký</el-button
          ></el-text
        >
      </div>
    </el-form>
    <template #footer>
      <span class="dialog-footer">
        <el-button @click="dialogFormVisible = false">Trở về</el-button>
        <el-button type="primary" @click="submitForm(ruleFormRef)">
          Xác nhận
        </el-button>
      </span>
    </template>
  </el-dialog>
  <!-- Đăng ký -->
  <el-dialog
    v-model="dialogFormVisibleRegister"
    title="Đăng ký"
    width="40%"
    center
  >
    <el-form
      ref="ruleFormRef"
      :model="ruleForm"
      status-icon
      :rules="rules"
      label-width="20%"
      class="demo-ruleForm"
    >
      <el-form-item label="Tài khoản" prop="account">
        <el-input v-model="ruleForm.account" type="text" autocomplete="off" />
      </el-form-item>
      <el-form-item label="Mật khẩu" prop="pass">
        <el-input v-model="ruleForm.pass" type="password" autocomplete="off" />
      </el-form-item>
    </el-form>
    <div class="register">
      <el-text size="small"
        >Chưa có tài khoản
        <el-button
          @click="
            (dialogFormVisible = true), (dialogFormVisibleRegister = false)
          "
          >Trở về</el-button
        ></el-text
      >
    </div>

    <template #footer>
      <span class="dialog-footer">
        <el-button
          @click="
            (dialogFormVisible = false), (dialogFormVisibleRegister = false)
          "
          >Trở về</el-button
        >
        <el-button type="primary" @click="submitForm(ruleFormRef)">
          Xác nhận
        </el-button>
      </span>
    </template>
  </el-dialog>
</template>
<script>
import { UserFilled } from "@element-plus/icons-vue";
import { reactive, ref } from "vue";
export default {
  setup() {
    const ruleFormRef = ref();

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
          console.log("submit!");
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
    };
  },
};
</script>
<style scoped>
.el-button--text {
  margin-right: 15px;
}
.el-select {
  width: 300px;
}
.el-input {
  width: 300px;
}
.dialog-footer button:first-child {
  margin-right: 10px;
}
.register {
  margin-top: 30px;
  margin-left: 48px;
}
</style>
