<template>
  <div class="main p-4">
    <div class="main-container">
      <el-row :gutter="20">
        <el-col :span="8"
          ><div class="grid-content ep-bg-purple" />
          <div class="img p-3">
            <el-image :src="imageUrl" fit="cover" />
          </div>
        </el-col>
        <el-col :span="16"
          ><div class="grid-content ep-bg-purple" />
          <div class="fs-5 mt-2">
            {{ product.name }}
          </div>
          <div class="d-flex rate">
            <el-rate class="m-0" disabled show-score v-model="value" />
            <el-divider direction="vertical" class="mt-2" />
            <div class="buy mt-1">Đã bán 500</div>
          </div>
          <div class="price py-4 px-2">
            <div class="fs-4 color-price fw-bold">
              {{ formatPrice(discountPrice) }}
              <el-text tag="del" class="ms-3 text-color">
                {{ formatPrice(price) }}
              </el-text>
              <el-text class="mx-1" type="danger"
                >-{{ discountPercent }}%</el-text
              >
            </div>
          </div>
          <div class="guarantee d-flex fw-bold">
            Bảo hành:
            <p class="text-color ms-2">12 tháng</p>
          </div>
          <div class="Acount mb-2">Số lượng</div>
          <el-input-number v-model="num" size="small" />
          <div class="mt-4">
            <el-button type="danger" class="buy-button">Chọn mua</el-button>
          </div>
        </el-col>
      </el-row>
    </div>
    <div class="body-container my-4 p-3">
      <div class="Header fs-5">Thông tin chi tiết</div>
      <div class="desc fs-6 mt-2">
        {{ product.description }}
      </div>
    </div>
    <div class="review-container my-4 p-3">
      <div class="Header fs-5">Đánh giá, Nhận xét</div>
      <div class="desc fs-6 mt-2">
        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Suscipit quos
        quidem eum velit mollitia? Nemo, quas! Optio, vel qui! Quae tempore
        nulla accusantium totam perspiciatis, aperiam et obcaecati consectetur
        sint? Quod rerum, tempora dolores doloremque ducimus temporibus harum id
        aperiam exercitationem delectus cum nobis similique, vero modi quos
        beatae dolor?
      </div>
    </div>
  </div>
</template>

<script>
import { ref } from "vue";
import { useRoute } from "vue-router";
import { getProductById } from "../../services/ProductRepository";
import { formatPrice } from "../../utils/CurrencyVN";
import { getImageAssetsSlider } from "../../utils/GetImageUrl.js";
export default {
  setup() {
    window.scrollTo(0, 0);
    const route = useRoute();
    const idProduct = route.params.id;
    const product = ref({ name: "" });
    const imageUrl = ref("https://localhost:7277/uploads/pictures/default.jpg");
    const price = ref(0);
    const discountPrice = ref(0);
    const discountPercent = ref(0);
    getProductById(idProduct).then((data) => {
      product.value = data;
      if (data.imageUrl !== null) {
        imageUrl.value = data.imageUrl;
      }
      price.value = data.price;
      discountPrice.value =
        data.price - data.price * data.discount.discountPercent;
      discountPercent.value = data.discount.discountPercent * 100;
    });

    const value = ref(3.7);
    const num = ref(1);
    return {
      getImageAssetsSlider,
      value,
      num,
      product,
      discountPercent,
      imageUrl,
      formatPrice,
      price,
      discountPrice,
    };
  },
};
</script>

<style scoped>
.main {
  min-height: 100vh;
  background: #f5f5fa;
}
.main-container,
.body-container,
.review-container {
  background: #fff;
  min-height: 400px;
  border-radius: 4px;
}
.el-image {
  max-height: 50vh;
  border-radius: 4px;
}
.rate {
  font-size: 16px;
  color: var(--text);
}
.color-price {
  color: var(--price);
}
.text-color {
  color: var(--text);
}
.price {
  background: var(--background);
  min-height: 80px;
  width: 50%;
  border-radius: 12px;
}
.guarantee {
  font-size: 14px;
}
.buy-button {
  height: 48px;
  width: 200px;
}
.desc {
  color: var(--text);
  min-height: 20vh;
}
</style>
