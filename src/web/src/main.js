import { createApp } from 'vue'
import { createPinia } from 'pinia'
import "./assets/styles/global.css"
import router from './router/index.js'
import axios from 'axios'
window.axios = axios;
import "bootstrap/dist/css/bootstrap.min.css"
import 'bootstrap/dist/js/bootstrap.js';

import {
    Checkbox,
    Input,
    Select,
    Avatar,
    Table,
    Card,
    Menu,
    List,
    Drawer,
    Button,
    message,
    Form,
} from 'ant-design-vue';

import App from './App.vue';
import './static/fontawesome/css/all.min.css';

import 'ant-design-vue/dist/antd.css';
const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(Checkbox);
app.use(Input);
app.use(Select);
app.use(Avatar);
app.use(Table);
app.use(Card);
app.use(Menu);
app.use(List);
app.use(Button);
app.use(Drawer);
app.mount('#app');

app.config.globalProperties.$message = message;