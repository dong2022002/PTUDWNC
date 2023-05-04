import { defineStore } from "pinia";

export const useMenu = defineStore("menuIdAdmin", {
  state: () => ({
    menuId: 1,
  }),

  actions: {
    onSelectedKeys(data) {
      this.menu = data;
    },
  },
  getters: {
    getMenu() {
      return this.menuId;
    },
  },
});
