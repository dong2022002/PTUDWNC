const Page404 = [{
    path: "/:pathMatch(.*)*",
    component: () =>
        import ("../pages/ViewUser/404Page.vue"),
    children: [

    ]
}];

export default Page404;