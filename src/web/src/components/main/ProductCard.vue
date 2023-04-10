<template>
  <el-card :body-style="{ padding: '16px 0 0 0' }">
          <img
            src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
            class="image"
          />
          <div style="padding: 14px">
            <text-clamp text='Yummy hamburger' class="title" :max-lines='2' />
            <div class="d-flex">
              <el-rate
                class="m-0"
                disabled
                show-score
                max="1"
                v-model="value"
              />
              <el-divider direction="vertical" class="mt-2" />
              <div class="buy mt-2">Đã bán 500</div>
            </div>

            <div class="bottom">
              <div class="price">
                230.000 đ <span class="discount">-34%</span>
              </div>
            </div>
          </div>
        </el-card>
</template>

<script>
import { ref } from 'vue'
import { DArrowRight } from '@element-plus/icons-vue'
export default {
  components: {
    DArrowRight
  },
  setup() {
    const value = ref(3.7)
    return {  value }
  }
}
</script>

<style scoped>
.image {
  border-radius: 12px;
  margin: auto;
  width: 120px;
  object-fit: cover;
  display: block;
}
.more {
  color: var(--text);
}
.buy {
  font-size: 12px;
  color: var(--text);
}
.discount {
  font-size: 12px;
  color: var(--text);
}
.title{
  font-size: 14px;
  font-weight: bold;
}
</style>