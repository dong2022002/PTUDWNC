import { defineStore } from "pinia";

export const useProductFilter = defineStore("productFilter", {
  state: () => ({
    keyword: "",
    categoryslug: "",
    SortColumn: "",
    SortOrder: "desc",
  }),

  actions: {
    updateCategorySlug(slug) {
      this.categoryslug = slug;
    },
    updateKeyword(keyword) {
      this.keyword = keyword;
    },
    updateSortColumn(SortColumn) {
      this.SortColumn = SortColumn;
    },
    updateSortOrder(SortOrder) {
      this.SortOrder = SortOrder;
    },
    $reset() {
      this.keyword = "";
      this.categoryslug = "";
      this.SortColumn = "";
      this.SortOrder = "desc";
    },
  },
});
