const Page404 = [{
    path: "/:pathMatch(.*)*",
    component: () =>
        import ("../layout/404.vue"),
    children: [

    ]
}];

export default Page404;