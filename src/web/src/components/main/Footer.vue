<template>
  <el-row class="row-bg" justify="space-evenly">
    <el-col :span="6"
      ><div class="grid-content ep-bg-purple" />
      <div class="footer-title">Hỗ trợ khách hàng</div>
      <div class="footer-text">
        Số điện thoại: <span style="font-weight: 600">+1234567809</span>
      </div>
      <a href="#" class="footer-text text-decoration-none"
        >Các câu hỏi thường gặp</a
      >
      <a href="#" class="footer-text text-decoration-none"
        >Gửi yêu cầu hỗ trợ</a
      >
      <a href="#" class="footer-text text-decoration-none"
        >Hướng dẫn thanh toán</a
      >
      <a href="#" class="footer-text text-decoration-none"
        >Phương thức thanh toán</a
      >
      <a href="#" class="footer-text text-decoration-none">Chính sách</a>
      <div class="footer-text">
        Email: <span style="font-weight: 600">dong200220@gmail.com</span>
      </div>
    </el-col>
    <el-col :span="6"
      ><div class="grid-content ep-bg-purple-light" />
      <div class="footer-title">Về chúng tôi</div>
      <a href="#" class="footer-text text-decoration-none">Giới thiệu</a>
      <a href="#" class="footer-text text-decoration-none">Blog</a>
      <a href="#" class="footer-text text-decoration-none">Tuyển dụng</a>
      <a href="#" class="footer-text text-decoration-none"
        >Chính sách bảo mật</a
      >
      <a href="#" class="footer-text text-decoration-none"
        >Thông tin vận chuyển</a
      >
      <div class="footer-title">Phương thức thanh toán</div>
      <font-awesome-icon :icon="['fab', 'cc-paypal']" class="icon-payment" />
      <font-awesome-icon :icon="['fab', 'cc-visa']" class="icon-payment" />
      <font-awesome-icon :icon="['fab', 'cc-jcb']" class="icon-payment" />
    </el-col>
    <el-col :span="6"
      ><div class="grid-content ep-bg-purple" />
      <div class="footer-title">kết nối với chúng tôi</div>
      <font-awesome-icon :icon="['fab', 'facebook']" class="icon-social"/>
      <font-awesome-icon :icon="['fab', 'youtube']" class="icon-social"/>
      <font-awesome-icon :icon="['fab', 'twitter']" class="icon-social"/>

      <img src="../../../public/vite.svg" alt="" class="d-flex icon-app">
    </el-col>
  </el-row>
</template>
<script>

export default {

}
</script>
<style scoped>
.footer-title {
  font-size: 16px;
  font-weight: 600;
}
.footer-text {
  font-size: 14px;
  color: #808089;
  display: flex;
  margin: 4px 0;
}
.icon-payment {
  height: 24px;
  padding: 4px;
}
.icon-social{
    height: 24px;
    padding: 4px;
}
.icon-app{
    margin: 32px;
    width: 30%;
}
.el-row{
  padding-top:  24px;
}
</style>
