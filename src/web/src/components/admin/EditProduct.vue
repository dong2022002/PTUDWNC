<template>
  <!-- Form -->
  <el-button
    type="success"
    class="mt-3 me-4"
    size="default"
    @click="dialogFormVisible = true"
  >
    Thêm sản phẩm
  </el-button>

  <el-dialog
    v-model="dialogFormVisible"
    title="Nhập thông tin"
    width="50%"
    center
  >
    <el-form
      ref="ruleFormRef"
      :model="ruleForm"
      status-icon
      :rules="rules"
      label-width="30%"
      class="demo-ruleForm"
    >
      <el-form-item label="Tên sản phẩm" prop="name">
        <el-input v-model="ruleForm.name" type="text" autocomplete="off" />
      </el-form-item>
      <el-form-item label="Mô tả" prop="description">
        <el-input
          v-model="ruleForm.description"
          :rows="3"
          type="textarea"
          autocomplete="off"
        />
      </el-form-item>
      <el-form-item label="Thêm hình ảnh" prop="ImageFile">
        <input
          ref="file"
          type="file"
          @change="handleFileUpload()"
          accept="image/*"
          capture
        />
      </el-form-item>
      <el-form-item label="Giá" prop="price">
        <el-input v-model="ruleForm.price" type="number" autocomplete="off" />
      </el-form-item>
      <el-form-item label="Số lượng" prop="quantity">
        <el-input
          v-model="ruleForm.quantity"
          type="number"
          autocomplete="off"
        />
      </el-form-item>
      <el-form-item label="Danh mục" prop="category">
        <el-select
          v-model="ruleForm.valueCategory"
          class="m-2"
          placeholder="Select"
        >
          <el-option
            v-for="item in optionsCategories"
            :key="item.value"
            :label="item.text"
            :value="item.value"
          />
        </el-select>
      </el-form-item>
      <el-form-item label="Giá giảm" prop="discount">
        <el-select
          v-model="ruleForm.valueDiscount"
          class="m-2"
          placeholder="Select"
        >
          <el-option
            v-for="item in optionsDiscounts"
            :key="item.value"
            :label="item.text"
            :value="item.value"
          />
        </el-select>
      </el-form-item>
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
</template>
<script>
import { UploadFilled, UserFilled } from "@element-plus/icons-vue";
import { defineEmits, reactive, ref } from "vue";
import {
  addOrUpdateProduct,
  getFilterCategoriesDiscount,
} from "../../services/ProductRepository";

export default {
  setup(props, { emit }) {
    const ruleForm = reactive({
      id: 0,
      name: "",
      description: "",
      price: 0,
      quantity: 0,
      valueCategory: "",
      valueDiscount: "",
      imageFile: null,
    });
    const file = ref(null);
    const optionsCategories = ref([]);
    const optionsDiscounts = ref([]);
    const ruleFormRef = ref();

    const getFilter = () => {
      getFilterCategoriesDiscount().then((data) => {
        optionsCategories.value = data.categoryList;
        optionsDiscounts.value = data.discountList;
      });
    };
    getFilter();

    const handleFileUpload = async () => {
      ruleForm.imageFile = file.value.files;
    };

    const validateName = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("Nhập vào tên sản phẩm"));
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
    const validatePrice = (rule, value, callback) => {
      if (value === 0) {
        callback(new Error("Nhập vào giá tiền"));
      } else {
        callback();
      }
    };
    const validateQuantity = (rule, value, callback) => {
      if (value === 0) {
        callback(new Error("Nhập vào số lượng"));
      } else {
        callback();
      }
    };

    const rules = reactive({
      name: [{ validator: validateName, trigger: "blur" }],
      description: [{ validator: validateDescription, trigger: "blur" }],
      price: [{ validator: validatePrice, trigger: "blur" }],
      quantity: [{ validator: validateQuantity, trigger: "blur" }],
    });

    const submitForm = (formEl) => {
      if (!formEl) return;
      formEl.validate((valid) => {
        if (valid) {
          console.log(ruleForm);
          let formData = new FormData();
          formData.append("id", ruleForm.id);
          formData.append("name", ruleForm.name);
          formData.append("description", ruleForm.description);
          formData.append("imageFile", ruleForm.imageFile[0]);
          formData.append("price", ruleForm.price);
          formData.append("productCategoryId", ruleForm.valueCategory);
          formData.append("quantity", ruleForm.quantity);
          formData.append("discountId", ruleForm.valueDiscount);
          addOrUpdateProduct(formData).then((data) => {
            if (data) {
              emit("updateTable");
              dialogFormVisible.value = false;
            } else {
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
      defineEmits,
      file,
      optionsCategories,
      optionsDiscounts,
      handleFileUpload,
      dialogFormVisible,
      dialogFormVisibleRegister,
      UserFilled,
      formLabelWidth,
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
.register {
  margin-top: 30px;
  margin-left: 48px;
}
</style>
