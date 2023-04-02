import { createRouter, createWebHistory } from 'vue-router';
import admin from './admin.js';
import ViewUser from './view-user.js';
import Page404 from './404.js';
const routes = [...admin, ...ViewUser, ...Page404];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;