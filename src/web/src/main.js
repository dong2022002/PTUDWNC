import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from './router/index.js'
import { createPinia } from 'pinia'
import TextClamp from 'vue3-text-clamp';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import {
    faCcPaypal,
    faCcVisa,
    faCcJcb,
    faFacebook,
    faYoutube,
    faTwitter
} from "@fortawesome/free-brands-svg-icons"
library.add(faCcPaypal,
    faCcVisa,
    faCcJcb,
    faFacebook,
    faYoutube,
    faTwitter)
createApp(App)
    .use(createPinia())
    .use(router)
    .use(TextClamp)
    .component("font-awesome-icon", FontAwesomeIcon)
    .mount('#app')