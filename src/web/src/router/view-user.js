const userView = [{
    path: "/",
    component: () =>
        import ("../layouts/HomePage.vue"),
    children: [{
            path: "*",
            name: "404",
            component: () =>
                import ("../pages/ViewUser/404Page.vue")
        },
        {

            path: "product/:id",
            name: "product",
            component: () =>
                import ("../pages/ViewUser/ProductPage.vue")
        },

    ]
}];

export default userView;