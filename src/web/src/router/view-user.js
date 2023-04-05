const userView = [{
    path: "/",
    component: () =>
        import ("../layouts/user.vue"),
    children: [{

            path: "/",
            name: "HomePage",
            component: () =>
                import ("../pages/ViewUser/HomePage.vue")
        },

        {

            path: "product",
            name: "product",
            component: () =>
                import ("../pages/ViewUser/ProductPage.vue")
        },

        {
            path: "Category",
            name: "category",
            component: () =>
                import ("../pages/ViewUser/ProductList.vue")
        },
        {
            path: "cskh",
            name: "cskh",
            component: () =>
                import ("../pages/ViewUser/ContactPage.vue")
        },

    ]
}];

export default userView;