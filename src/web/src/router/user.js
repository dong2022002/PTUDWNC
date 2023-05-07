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
        path: "/contact",
        name: "contact",
        component: () => import("../pages/main/ContactPage.vue"),
      },
      {
        path: "/products/:slug",
        name: "products",
        component: () => import("../pages/main/ProductsList.vue"),
      },

      {
        path: "/products/:slug/:keyword",
        name: "productsKeywords",
        redirect: (to) => {
          return {
            path: "/products",
            query: { k: to.params.keyword, slug: to.params.slug },
          };
        },
        component: () => import("../pages/main/ProductsList.vue"),
      },

      {
        path: "/products/",
        name: "productQuery",
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
