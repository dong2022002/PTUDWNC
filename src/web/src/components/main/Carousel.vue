<template>
  <el-carousel>
    <el-carousel-item v-for="item in 4" :key="item">
      <el-image style="width: 100%; height: 100%" :src="getImageUrl(item)" fit="cover" />
    </el-carousel-item>
  </el-carousel>
</template>
<script>
export default {

  setup() {
 const getImageUrl = (item) => {
        return new URL(`../../assets/slider/slider${item}.jpg`, import.meta.url).href
    }
  return { getImageUrl }
    }

}
</script>
<style scoped>
.el-carousel__item h3 {
  display: flex;
  color: #475669;
  opacity: 0.75;
  line-height: 300px;
  margin: 0;
}
.img {
  object-fit: cover;
}
.el-carousel__item:nth-child(2n) {
  background-color: #99a9bf;
}

.el-carousel__item:nth-child(2n + 1) {
  background-color: #d3dce6;
}
.el-carousel-item {
  height: 100px;
  width: 100px;
}
</style>
