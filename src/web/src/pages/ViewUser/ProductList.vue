<template>
    <div class="row">
        <div class="col-9">
            <section class="padding-top">
    <div class="container">
      <header class="section-heading">
        <h3 class="section-title text-center pt-4 pb-4 text-center">Danh mục</h3>
      </header>


      <div class="row d-flex">
        <div class="col-lg-3 col-md-6 col-sm-6"  v-for="n in 20" :key="n">
          <figure class="card card-product-grid">
            <a href="product" class="img-wrap">
              <span class="topbar">
                <b class="badge bg-success"> Offer </b>
              </span>
              <img
                src="../../assets/images/items/12.webp"
                class="w-100 h-100"
              />
            </a>
            <figcaption class="info-wrap border-top">
              <a href="#" class="float-end btn btn-light btn-icon">
                <i class="fa fa-heart"></i>
              </a>
              <div class="row">
                <a href="#" class="title text-truncate">Blue T-shirt for Men</a>
                <small class="text-muted">Sizes: S, M, XL</small>
                <div class="price-wrap">
                  <span class="price">$15.90</span>
                  <del class="price-old">$20</del>
                </div>
              </div>

              <!-- price-wrap.// -->
            </figcaption>
          </figure>
        </div>

      </div>
      <!-- row end.// -->
    </div>
    <!-- container end.// -->
  </section>
        </div>
        <div class="col-3 pt-4">
            <NavbarView />
        </div>
    </div>
  </template>
  <script>
  import NavbarView from "../../components/UserComponents/NavBar.vue";
  export default {
    components: {
      NavbarView,
    },
  };
  </script>
