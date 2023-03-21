<template>
  <div class="d-flex min-vh-100">
    <div class="col-8 p-4 position-relative">
      <div class="ps-4 row">
        <div class="col-4 border border-3 border-secondary-2">
          <img src="../../assets/images/items/12.webp" class="w-100 h-auto" />
        </div>
        <div class="col-6">
          <h1 class="title">Tên Sản Phẩm</h1>
          <p>Mô tả</p>
          <h4>Giá : 400.000đ</h4>
          <p>Bảo hành : 36 tháng</p>
          <div class="mb-4">
            <input
              type="number"
              step="1"
              min="1"
              max="99"
              title="Số lượng"
              size="4"
              pattern="[0-9]*"
              inputmode="numeric"
              style="width: 60px; height: 35px"
              value="1"
            />
          </div>
          <button class="btn btn-primary mb-4">Mua ngay</button>
          <p>Chuyên mục : máy bàn</p>
        </div>
      </div>
      <div class="ps-4 mt-4">Mô tả</div>
    </div>
    <div class="col"><navbar-view /></div>
  </div>
</template>
<script>
import NavbarView from "../Shared/NavBar.vue";
export default {
  components: {
    NavbarView,
  },
};
</script>
