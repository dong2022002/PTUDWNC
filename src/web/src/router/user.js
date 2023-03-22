const user = [{
    path: "/",
    component: () =>
        import ("../layout/user_layout"),
    children: [
        // Quản lý Users
        {
            path: "/",
            name: "home",
            component: () =>
                import ("../Pages/user/HomeView/HomeView")
        },
        {
            path: "product",
            name: "detail-product",
            component: () =>
                import ("../Pages/user/products/ProductView")
        },


    ]
}];

export default user;
