<template>
  <div class="main p-4">
    <div class="main-container">
      <el-row :gutter="20">
        <el-col :span="8"
          ><div class="grid-content ep-bg-purple" />
          <div class="img p-3">
            <el-image
              style="width: 100%"
              :src="getImageAssetsSlider(1)"
              fit="cover"
            />
          </div>
        </el-col>
        <el-col :span="16"
          ><div class="grid-content ep-bg-purple" />
          <div class="fs-5 mt-2">
            Laptop Dell Vostro 13 5320 M32DH1 (i5-1240P/8GB/256GB/13.3"
            FHD/Windows 11 + Office)
          </div>
          <div class="d-flex rate">
            <el-rate class="m-0" disabled show-score v-model="value" />
            <el-divider direction="vertical" class="mt-2" />
            <div class="buy mt-1">Đã bán 500</div>
          </div>
          <div class="price py-4 px-2">
            <div class="fs-4 color-price fw-bold">
              1.000.000
              <el-text class="fs-4 color-price" tag="ins">đ</el-text>
              <el-text tag="del" class="ms-3 text-color">2.000.000</el-text>
              <el-text tag="ins" class="ms-1 text-color">đ</el-text>
              <el-text class="mx-1" type="danger">-50%</el-text>
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
  </div>
</template>

<script>
import { getImageAssetsSlider } from '../../utils/GetImageUrl.js'
import { ref } from 'vue'
export default {
  setup() {
    const value = ref(3.7)
    const num = ref(1)
    return { getImageAssetsSlider, value, num }
  }
}
</script>

<style scoped>
.main {
  min-height: 100vh;
  background: #f5f5fa;
}
.main-container {
  background: #fff;
  min-height: 400px;
  border-radius: 4px;
}
.el-image {
  max-height: 30vh;
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
</style>
