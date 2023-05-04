const user = [
  {
    path: "/",
    component: () => import("../layout/index.vue"),
    children: [
      {
        path: "/",
        name: "home",
        component: () => import("../pages/main/index.vue"),
      },
      {
        path: "/products/:slug",
        name: "products",
        component: () => import("../pages/main/ProductsList.vue"),
      },
      {
        path: "/product/:id",
        name: "product",
        component: () => import("../pages/main/DetailProduct.vue"),
      },
    ],
  },
];

export default user;
