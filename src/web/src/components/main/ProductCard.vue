<template>
  <el-card :body-style="{ padding: '16px 0 0 0' }">
    <img :src="img" class="image" />
    <div style="padding: 14px">
      <text-clamp :text="title" class="title" :max-lines="2" />
      <div class="d-flex">
        <el-rate class="m-0" disabled show-score max="1" v-model="stats" />
        <el-divider direction="vertical" class="mt-2" />
        <div class="buy mt-2">Đã bán 500</div>
      </div>

      <div class="bottom">
        <div class="price">
          {{ formatPrice(price) }}
          <span class="discount">-{{ discount }}%</span>
        </div>
      </div>
    </div>
  </el-card>
</template>

<script>
import { DArrowRight } from "@element-plus/icons-vue";
import { ref } from "vue";
import { formatPrice } from "../../utils/CurrencyVN";
export default {
  components: {
    DArrowRight,
  },
  props: {
    product: { type: Object, required: true },
  },
  setup(props, context) {
    const product = props.product;
    if (product !== undefined) {
      const img =
        product.imageUrl ??
        "https://localhost:7277/uploads/pictures/default.jpg";
      const discount = product.discount.discountPercent * 100;
      const price = product.price * product.discount.discountPercent;
      const stats = ref(3.7);
      const title = product.name;
      return { stats, title, img, discount, price, formatPrice };
    }
  },
};
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
.title {
  font-size: 14px;
  font-weight: bold;
}
</style>
