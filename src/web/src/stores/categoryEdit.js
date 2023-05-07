import { defineStore } from "pinia";

export const useCategoryEdit = defineStore("useCategoryEdit", {
  state: () => ({
    category: {},
  }),

  actions: {
    updateCategory(data) {
      this.category = data;
    },

    $reset() {
      this.category = {};
    },
  },
});
