const user = [{
    path: "/",
    component: () =>
        import ("../layout/index.vue"),
    children: [{
            path: "/",
            name: "home",
            component: () =>
                import ("../pages/main/index.vue"),
        },
        {
            path: "/category",
            name: "category",
            component: () =>
                import ("../pages/main/ProductsList.vue"),
        },
        {
            path: "/product",
            name: "product",
            component: () =>
                import ("../pages/main/DetailProduct.vue"),
        },
    ]
}];

export default user;