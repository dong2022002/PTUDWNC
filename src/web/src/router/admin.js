const admin = [
  {
    path: "/admin",
    name: "admin",
    component: () => import("../layout/admin.vue"),
    children: [
      //dashboard
      {
        path: "/admin",
        name: "dashboard",
        component: () => import("../pages/admin/Products.vue"),
      },
      //Quản lý Users
      {
        path: "users",
        name: "admin-users",
        component: () => import("../pages/admin/Users.vue"),
      },
      {
        path: "edit-product",
        name: "edit-product",
        component: () => import("../pages/admin/EditProduct.vue"),
      },
      {
        path: "edit-category",
        name: "edit-category",
        component: () => import("../pages/admin/EditCategory.vue"),
      },

      {
        path: "edit-discount",
        name: "edit-discount",
        component: () => import("../pages/admin/EditDiscount.vue"),
      },
      {
        path: "products",
        name: "admin-products",
        component: () => import("../pages/admin/Products.vue"),
      },
      {
        path: "category",
        name: "admin-category",
        component: () => import("../pages/admin/Category.vue"),
      },

      {
        path: "discount",
        name: "admin-discount",
        component: () => import("../pages/admin/Discount.vue"),
      },
      // {
      //     path: "users/create",
      //     name: "admin-users-create",
      //     component: () => import ("../pages/admin/users/create.vue")
      // },
      // {
      //     path: "users/:id/edit",
      //     name: "admin-users-edit",
      //     component: () => import ("../pages/admin/users/edit.vue")
      // },

      // // Quản lý Roles
      // {
      //     path: "roles",
      //     name: "admin-roles",
      //     component: () => import ("../pages/admin/roles/index.vue")
      // },

      // // Quản lý Settings
      // {
      //     path: "settings",
      //     name: "admin-settings",
      //     component: () => import ("../pages/admin/settings/index.vue")
      // }
    ],
  },
];

export default admin;
