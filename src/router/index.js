import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView/HomeView'
import ProductView from '../views/products/ProductView'
const routes = [{
        path: '/',
        name: 'home',
        component: HomeView
    },
    {
        path: '/product/',
        name: 'Detail-product',
        component: ProductView
    },




]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router