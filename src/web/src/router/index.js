import { createRouter, createWebHistory } from 'vue-router';
import admin from './admin.js';
import user from './user.js';
import Page404 from './404.js';
const routes = [...admin, ...user, ...Page404];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;