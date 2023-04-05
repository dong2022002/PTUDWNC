<template>
      <nav class="navbar shadow mb-2 navbar-expand-lg navbar-light bg-light ">
  <div class="container-fluid d-flex">
    <div class="p-2 flex-grow-1 bd-highlight">
      <a class="navbar-brand" href="#">Navbar</a>
    </div>
    <div class="p-2 bd-highlight">
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" >
      <ul
              class="navbar-nav"
              v-for="(menu, index) in menuNav"
              :key="index"
            >
              <li class="nav-item" v-if="!menu.submenu">
                <a class="nav-link ps-4 fs-6" :href="menu.slug">
                  {{ menu.name }}
                </a>
              </li>
              <!-- sub menu -->
              <li class="nav-item dropdown position-relative" v-else>
                <a
                  class="nav-link dropdown-toggle"
                  id="navbarDarkDropdownMenuLink"
                  role="button"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  {{ menu.name }}
                </a>
                <ul
                  class="dropdown-menu mt-3 border border-white shadow-sm  bg-body rounded"
                >
                  <li
                    class="nav-item fs-6"
                    v-for="(subMenu, index) in menu.dataSubMenus"
                    :key="index"
                  >
                    <a class="dropdown-item" :href="subMenu.slug">{{
                      subMenu.name
                    }}</a>
                  </li>
                </ul>
              </li>
           </ul>
    </div>
    </div>
    <!-- Search -->
    <div class="p-2 bd-highlight ">
      <form class="d-flex justify-content-evenly ">
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        <button class="btn btn-outline search-dark" type="submit">Search</button>
      </form>
    </div>
    <div class="order-lg-last">
              <div class="float-end">
                <a href="#" class="btn  me-2">
                  <i class="fa fa-user purple"></i>
                  <span class="ms-1 d-none d-sm-inline-block"></span>
                </a>
                <a href="#" class="btn  me-2 cart-button">
                  <i class="fa fa-heart purple"></i>
                  <span class="ms-1 d-none d-sm-inline-block"></span>
                </a>
                <a
                  data-bs-toggle="offcanvas"
                  href="#offcanvas_cart"
                  class="btn dark "
                >
                  <i class="fa fa-shopping-cart"></i>
                  <span class="ms-1"> </span>
                </a>
              </div>
            </div>

  </div>
</nav>
</template>
<script>
export default {
  data() {
    return {
      menuNav: [
        {
          name: "Trang chủ",
          slug: "home",
          submenu: false,
          dataSubMenus: [

          ],
        },
        {
          name: "Cửa hàng",
          slug: "shop",
          submenu: true,
          dataSubMenus: [
            {
              name: "LapTop",
              slug: "lap-top",
            },
            {
              name: "Máy tính bàn",
              slug: "may-tinh-ban",
            },
            {
              name: "ổ cứng SSD",
              slug: "o-cung-ssd",
            },
          ],
        },
        {
          name: "CSKH",
          slug: "cskh",
          submenu: false,
          dataSubMenus: [

          ],
        },
        {
          name: "Theo dõi đơn hàng",
          slug: "theo-doi-don-hang",
          submenu: false,
          dataSubMenus: [],
        },
      ],
    };
  },
  setup() {},
};
</script>

<style>
.dark{
  color: var(--dark);
  border-color: var(--dark)
}
.search-dark{
  color: var(--dark);
  border-color: var(--dark)
}
.dark:hover{
  opacity:0.8;
  border-color: var(--dark)

}
.search-dark:hover{
  border-color: var(--dark)
}




</style>
