import { defineStore } from "pinia";

export const useProductEdit = defineStore("useProductEdit", {
  state: () => ({
    product: {},
  }),

  actions: {
    updateProduct(data) {
      this.product = data;
    },

    $reset() {
      this.product = {};
    },
  },
});
