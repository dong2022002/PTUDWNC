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

    ]
}];

export default userView;