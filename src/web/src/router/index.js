import { createRouter, createWebHistory } from "vue-router";
import Page404 from "./404.js";
import admin from "./admin.js";
import LoginAdmin from "./loginAdmin.js";
import user from "./user.js";
const routes = [...admin, ...user, ...Page404, ...LoginAdmin];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
