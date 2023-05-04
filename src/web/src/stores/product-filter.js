import { defineStore } from "pinia";

export const useProductFilter = defineStore("productFilter", {
  state: () => ({
    keyword: "",
    categoryslug: "",
  }),

  actions: {
    updateCategorySlug(slug) {
      this.categoryslug = slug;
    },
  },
});
