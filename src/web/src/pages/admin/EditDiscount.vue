<template>
  <h5 class="title mt-4">Nhập thông tin</h5>

  <el-form
    ref="ruleFormRef"
    :model="ruleForm"
    status-icon
    :rules="rules"
    label-width="15%"
    class="demo-ruleForm mt-4"
  >
    <el-form-item label="Tên mức giảm giá" prop="name">
      <el-input v-model="ruleForm.name" type="text" autocomplete="off" />
    </el-form-item>
    <el-form-item label="Mô tả" prop="description">
      <el-input
        v-model="ruleForm.description"
        :rows="3"
        class="w-50"
        type="textarea"
        autocomplete="off"
      />
    </el-form-item>
    <el-form-item label="Tỉ lệ" prop="discountPercent">
      <el-input
        v-model="ruleForm.discountPercent"
        type="text"
        autocomplete="off"
      />
    </el-form-item>
  </el-form>
  <div class="dialog-footer w-50 d-flex justify-content-center mt-4">
    <el-button style="font-size: 14px" @click="handleReturn">Trở về</el-button>
    <el-button type="primary" @click="submitForm(ruleFormRef)">
      Xác nhận
    </el-button>
  </div>
</template>
<script>
import { UploadFilled } from "@element-plus/icons-vue";
import { reactive, ref } from "vue";
import { useRouter } from "vue-router";
import { addOrUpdateDiscount } from "../../services/discountRepository";
import { useDiscountEdit } from "../../stores/discountEdit";

export default {
  setup() {
    const ruleForm = reactive({
      id: 0,
      name: "",
      description: "",
      discountPercent: 0,
    });
    const store = useDiscountEdit();
    if (store.discount !== {} && store.discount.id !== undefined) {
      ruleForm.id = store.discount.id;
      ruleForm.name = store.discount.name;
      ruleForm.description = store.discount.description;
      ruleForm.discountPercent = store.discount.discountPercent;
    }

    const ruleFormRef = ref();

    const validateName = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("Nhập vào tên mức giảm giá"));
      } else {
        callback();
      }
    };
    const validateDescription = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("Nhập vào mô tả"));
      } else {
        callback();
      }
    };

    const rules = reactive({
      name: [{ validator: validateName, trigger: "blur" }],
      description: [{ validator: validateDescription, trigger: "blur" }],
    });

    const submitForm = (formEl) => {
      if (!formEl) return;
      formEl.validate((valid) => {
        if (valid) {
          let formData = new FormData();
          formData.append("id", ruleForm.id);
          formData.append("name", ruleForm.name);
          formData.append("description", ruleForm.description);
          formData.append(
            "discountPercent",
            parseFloat(ruleForm.discountPercent)
          );
          formData.append("Active", true);

          addOrUpdateDiscount(formData, ruleForm.id).then((data) => {
            if (data) {
              router.replace({ name: "admin-discount" });
            } else {
              console.log("Thao tác thất bại");
            }
          });
        } else {
          console.log("error submit!");
          return false;
        }
      });
    };
    const router = useRouter();
    const handleReturn = () => {
      store.$reset();
      router.replace({ name: "admin-discount" });
    };
    return {
      handleReturn,
      rules,
      submitForm,
      ruleForm,
      ruleFormRef,
      UploadFilled,
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
.el-dialog {
  z-index: 5000 !important;
}
.register {
  margin-top: 30px;
  margin-left: 48px;
}
.title {
  padding: 12px;
}
</style>
