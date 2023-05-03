import { library } from "@fortawesome/fontawesome-svg-core";
import {
  faCcJcb,
  faCcPaypal,
  faCcVisa,
  faFacebook,
  faTwitter,
  faYoutube,
} from "@fortawesome/free-brands-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { createPinia } from "pinia";
import { createApp } from "vue";
import TextClamp from "vue3-text-clamp";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";
import App from "./App.vue";
import router from "./router/index.js";
import "./style.css";
library.add(faCcPaypal, faCcVisa, faCcJcb, faFacebook, faYoutube, faTwitter);

import axios from "axios";
import VueAxios from "vue-axios";
createApp(App)
  .use(createPinia())
  .use(VueAxios, axios)
  .use(router)
  .use(TextClamp)
  .component("font-awesome-icon", FontAwesomeIcon)
  .mount("#app");
