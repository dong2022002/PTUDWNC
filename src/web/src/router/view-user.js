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
        //login - regis
        {
            path: "user/login",
            name: "LoginUser",
            component: () =>
                import ("../pages/ViewUser/LoginPage.vue")
        },
        {
            path: "user/register",
            name: "RegisterUser",
            component: () =>
                import ("../pages/ViewUser/RegisPage.vue")
        },

    ]
}];

export default userView;