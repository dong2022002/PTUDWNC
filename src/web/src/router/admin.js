const admin = [{
    path: "/admin",
    component: () =>
        import ("../layout/admin_layout"),
    children: [
        // {
        //       path: '/admin/',
        //       name: 'Dashboard-admin',
        //       component: DashboardView
        //   },
        // Quản lý Users
        {
            path: "",
            name: "dashboard-admin",
            component: () =>
                import ("../Pages/admin/DashboardView")
        },
        // {
        //     path: "users/create",
        //     name: "admin-users-create",
        //     component: () =>
        //         import ("../pages/admin/users/create.vue")
        // },
        // {
        //     path: "users/:id/edit",
        //     name: "admin-users-edit",
        //     component: () =>
        //         import ("../pages/admin/users/edit.vue")
        // },

        // // Quản lý Roles
        // {
        //     path: "roles",
        //     name: "admin-roles",
        //     component: () =>
        //         import ("../pages/admin/roles/index.vue")
        // },

        // // Quản lý Settings
        // {
        //     path: "settings",
        //     name: "admin-settings",
        //     component: () =>
        //         import ("../pages/admin/settings/index.vue")
        // }
    ]
}];

export default admin;
