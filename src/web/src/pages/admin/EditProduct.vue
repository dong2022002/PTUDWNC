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
    <el-form-item label="Tên sản phẩm" prop="name">
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
    <el-form-item>
      <el-image
        style="width: 100px; height: 100px"
        :src="ruleForm.imageUrl"
      ></el-image>
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
      <el-input v-model="ruleForm.quantity" type="number" autocomplete="off" />
    </el-form-item>
    <el-form-item label="Danh mục" prop="category">
      <el-select v-model="ruleForm.valueCategory" placeholder="Select">
        <el-option
          v-for="item in optionsCategories"
          :key="item.value"
          :label="item.text"
          :value="item.value"
        />
      </el-select>
    </el-form-item>
    <el-form-item label="Giá giảm" prop="discount">
      <el-select v-model="ruleForm.valueDiscount" placeholder="Select">
        <el-option
          v-for="item in optionsDiscounts"
          :key="item.value"
          :label="item.text"
          :value="item.value"
        />
      </el-select>
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
import { defineEmits, reactive, ref } from "vue";
import { useRouter } from "vue-router";
import {
  addOrUpdateProduct,
  getFilterCategoriesDiscount,
} from "../../services/ProductRepository";
import { useProductEdit } from "../../stores/productEdit";

export default {
  setup() {
    const ruleForm = reactive({
      id: 0,
      name: "",
      description: "",
      price: 0,
      imageUrl: "",
      quantity: 0,
      valueCategory: "",
      valueDiscount: "",
      imageFile: null,
    });
    const store = useProductEdit();
    if (store.product !== {} && store.product.id !== undefined) {
      ruleForm.id = store.product.id;
      ruleForm.name = store.product.name;
      ruleForm.description = store.product.description;
      ruleForm.price = store.product.price;
      ruleForm.imageUrl = store.product.imageUrl;
      const quantity = store.product.quantity;
      ruleForm.quantity = parseInt(quantity);
      ruleForm.valueCategory = store.product.productCategory.id.toString();
      ruleForm.valueDiscount = store.product.discount.id.toString();
    }
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
          let formData = new FormData();
          formData.append("id", ruleForm.id);
          formData.append("name", ruleForm.name);
          formData.append("description", ruleForm.description);
          formData.append("price", ruleForm.price);
          formData.append("productCategoryId", ruleForm.valueCategory);
          formData.append("quantity", parseInt(ruleForm.quantity));
          formData.append("discountId", ruleForm.valueDiscount);
          if (ruleForm.imageFile !== null) {
            formData.append("imageFile", ruleForm.imageFile[0]);
          }
          addOrUpdateProduct(formData, ruleForm.id).then((data) => {
            if (data) {
              console.log(data);
              router.replace({ name: "admin-products" });
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
      router.replace({ name: "admin-products" });
    };
    return {
      handleReturn,
      defineEmits,
      file,
      optionsCategories,
      optionsDiscounts,
      handleFileUpload,
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
