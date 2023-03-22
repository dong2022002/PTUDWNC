import { createRouter, createWebHistory } from 'vue-router';
import admin from './admin.js';
import user from './user'
const routes = [...admin, ...user];
console.log(routes)
const routerView = createRouter({
    history: createWebHistory(),
    routes
});

export default routerView;
