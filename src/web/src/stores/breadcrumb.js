import { defineStore } from "pinia";

export const useBreadCurmb = defineStore("useBreadCurmb", {
  state: () => ({
    title: "",
  }),

  actions: {
    updateTitle(title) {
      this.title = title;
    },

    $reset() {
      this.product = {};
    },
  },
});
