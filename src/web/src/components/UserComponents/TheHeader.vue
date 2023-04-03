<template>
  <div class="">
    <header class="section-header">
      <section class="header-main">
        <div class="container">
          <div class="row gy-3 pt-2 pb-2 align-items-center">
            <div class="col-lg-2 col-sm-4 col-4">
              <a href="/" class="navbar-brand"> RichEcom </a>
              <!-- brand end.// -->
            </div>
            <div class="order-lg-last col-lg-5 col-sm-8 col-8">
              <div class="float-end">
                <a href="#" class="btn btn-light me-2">
                  <i class="fa fa-user"></i>
                  <span class="ms-1 d-none d-sm-inline-block">Sign in </span>
                </a>
                <a href="#" class="btn btn-light me-2">
                  <i class="fa fa-heart"></i>
                  <span class="ms-1 d-none d-sm-inline-block">Wishlist</span>
                </a>
                <a
                  data-bs-toggle="offcanvas"
                  href="#offcanvas_cart"
                  class="btn btn-primary"
                >
                  <i class="fa fa-shopping-cart"></i>
                  <span class="ms-1">My cart </span>
                </a>
              </div>
            </div>
            <!-- col end.// -->
            <div class="col-lg-5 col-md-12 col-12">
              <form action="#" class="">
                <div class="input-group">
                  <input
                    type="search"
                    class="form-control"
                    style="width: 55%"
                    placeholder="Search"
                  />
                  <select class="form-select">
                    <option value="">All type</option>
                    <option value="codex">Special</option>
                    <option value="comments">Only best</option>
                    <option value="content">Latest</option>
                  </select>
                  <button class="btn btn-primary">
                    <i class="fa fa-search"></i>
                  </button>
                </div>
                <!-- input-group end.// -->
              </form>
            </div>
            <!-- col end.// -->
          </div>
          <!-- row end.// -->
        </div>
        <!-- container end.// -->
      </section>
      <!-- header-main end.// -->

      <nav class="navbar navbar-light bg-primary border-top navbar-expand-lg">
        <div class="container">
          <button
            class="navbar-toggler border"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbar_main"
          >
            <span class="navbar-toggler-icon"></span>
          </button>

          <div class="collapse navbar-collapse" id="navbar_main">
            <ul
              class="navbar-nav"
              v-for="(menu, index) in menuNav"
              :key="index"
            >
              <li class="nav-item" v-if="!menu.submenu">
                <a class="nav-link ps-4" :href="menu.slug">
                  {{ menu.name }}
                </a>
              </li>
              <!-- sub menu -->
              <li class="nav-item dropdown" v-else>
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
                  class="dropdown-menu dropdown-menu-dark"
                  aria-labelledby="navbarDarkDropdownMenuLink"
                >
                  <li
                    class="nav-item"
                    v-for="(subMenu, index) in menu.dataSubMenus"
                    :key="index"
                  >
                    <a class="dropdown-item" :href="subMenu.slug">{{
                      subMenu.name
                    }}</a>
                  </li>
                </ul>
              </li>

              <!--
              <li class="nav-item">
                <a class="nav-link" href="#">Linh kiện PC</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">Linh kiện</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">Menu name</a>
              </li>
            
            --></ul>
          </div>
          <!-- collapse end.// -->
        </div>
        <!-- container end.// -->
      </nav>
      <!-- navbar end.// -->
    </header>
    <!-- section-header end.// -->
  </div>
</template>
<script>
export default {
  data() {
    return {
      menuNav: [
        {
          name: "Laptop",
          slug: "laptop",
          submenu: true,
          dataSubMenus: [
            {
              name: "Laptop Mới",
              slug: "new-laptop",
            },
            {
              name: "Laptop Cũ",
              slug: "old-laptop",
            },
          ],
        },
        {
          name: "Máy tính bàn",
          slug: "may-tinh-ban",
          submenu: false,
          dataSubMenus: [],
        },
        {
          name: "Link kiện PC",
          slug: "linh-kien",
          submenu: true,
          dataSubMenus: [
            {
              name: "CPU",
              slug: "linh-kien-cpu",
            },
            {
              name: "RAM",
              slug: "linh-kien-ram",
            },
            {
              name: "SDD",
              slug: "linh-kien-sdd",
            },
          ],
        },
        {
          name: "Link kiện Laptop",
          slug: "linh-kien-laptop",
          submenu: true,
          dataSubMenus: [
            {
              name: "CPU",
              slug: "linh-kien-cpu",
            },
            {
              name: "RAM",
              slug: "linh-kien-ram",
            },
            {
              name: "SDD",
              slug: "linh-kien-sdd",
            },
          ],
        },
        {
          name: "Bàn, ghế Gaming",
          slug: "ban-ghe-gaming",
          submenu: false,
          dataSubMenus: [],
        },
        {
          name: "dịch vụ",
          slug: "dịch vụ",
          submenu: false,
          dataSubMenus: [],
        },
        {
          name: "liên hệ",
          slug: "lien-he",
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
.dropdown-submenu {
  position: relative;
}

.dropdown-submenu .dropdown-menu {
  top: 0;
  left: 100%;
  margin-top: -1px;
}

.navbar-nav li:hover > ul.dropdown-menu {
  display: block;
}
</style>
