<template>
    <div class="feature-products">
        <div class="fs-6">Sản phẩm nổi bật</div>
         <el-row>
    <el-col
      v-for="(o, index) in 5"
      :key="o"
      :span="4"
      :offset="index > 0 ? 1 : 0"
    >
      <el-card :body-style="{ padding: '16px 0 0 0'  }">
        <img
          src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
          class="image"

        />
        <div style="padding: 14px">
          <span>Yummy hamburger</span>
          <div class="bottom">
            <time class="time">{{ currentDate }}</time>
            <el-button text class="button">Operating</el-button>
          </div>
        </div>
      </el-card>
    </el-col>
  </el-row>
    </div>
</template>

<script>
import {ref} from 'vue'
export default {
    setup (){
const currentDate = ref(new Date())
return(currentDate)
    }
}
</script>

<style scoped>
.feature-products{
    padding: 24px;
    margin-top: 24px;
    border-radius: 12px;
    min-height:  200px;
    width: 100%;
    background: #fff;
}
.time {
  font-size: 12px;
  color: #999;
}

.bottom {
  margin-top: 13px;
  line-height: 12px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.button {
  padding: 0;
  min-height: auto;
}

.image {
  border-radius: 12px;
  margin: auto;
  width: 120px;
  object-fit: cover;
  display: block;
}

</style>