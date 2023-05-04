const admin = [{
    path: "/admin",
    component: () =>
        import ("../layout/admin.vue"),
    children: [{
            path: "/admin",
            name: "dashboard",
            component: () =>
                import ("../pages/admin/Dashboard.vue"),
        },
        //Quản lý Users
        {
            path: "users",
            name: "admin-users",
            component: () =>
                import ("../pages/admin/Users.vue")
        },
        {
            path: "products",
            name: "admin-products",
            component: () =>
                import ("../pages/admin/Products.vue")
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
    ]
}];

export default admin;