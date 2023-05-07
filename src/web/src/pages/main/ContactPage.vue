<template>
  <div class="">
    <a-form
      layout="inline"
      :model="formState"
      @finish="handleFinish"
      @finishFailed="handleFinishFailed"
    >
      <!--Google map-->
      <div
        id="map-container-google-1"
        class="z-depth-1-half map-container"
        style="height: 150px"
      >
        <iframe
          src="https://maps.google.com/maps?q=manhatan&t=&z=13&ie=UTF8&iwloc=&output=embed"
          frameborder="0"
          style="border: 0"
          allowfullscreen
        ></iframe>
      </div>

      <!--Google Maps-->
      <div class="spacing-contact">
        <div class="row w-100">
          <div class="col-5">
            <div class="fs-4 px-3 fw-bold">Liên hệ với chúng tôi</div>
            <div class="my-2">
              <div class="fs-5 p-3">Số điện thoại</div>
              <span class="p-3 fs-6">+123456789</span>
            </div>
            <div class="my-4">
              <div class="fs-5 p-3">Địa chỉ liên hệ</div>
              <span class="p-3 fs-6"> 123 Phan Đình Phùng, tp Đà Lạt </span>
            </div>
            <div class="my-4">
              <div class="fs-5 p-3">Email</div>
              <span class="p-3 fs-6"> dong200220@gmail.com</span>
            </div>
          </div>

          <div class="col-6">
            <div class="mb-4 fs-4 fw-bold">Để lại lời nhắn</div>
            <div class="d-flex justify-content-between">
              <div class="">
                <input
                  type="text"
                  class="form-control w-auto"
                  id="inputHovaTen"
                  placeholder="Họ và tên"
                />
              </div>
              <div class="">
                <input
                  type="email"
                  class="form-control pe-4"
                  id="InputEmail"
                  placeholder="email"
                />
              </div>
            </div>
            <div class="my-4">
              <textarea
                class="form-control"
                id="textareDesc"
                rows="5"
                placeholder="Lời nhắn"
              ></textarea>
            </div>
            <div class="">
              <button class="btn btn-primary px-4" type="submit">Gửi</button>
            </div>
          </div>
        </div>
      </div>
    </a-form>
  </div>
</template>
<script>
export default {
  setup() {},
};
</script>
<style scoped>
.spacing-contact {
  margin-top: 32px;
  padding: 32px 64px;
}
.map-container {
  overflow: hidden;
  padding-bottom: 30.25%;
  position: relative;
  height: 0;
}
.map-container iframe {
  left: 0;
  top: 0;
  height: 100%;
  width: 100%;
  position: absolute;
}
</style>
