import { defineStore } from "pinia";

export const useDiscountEdit = defineStore("useDiscountEdit", {
  state: () => ({
    discount: {},
  }),

  actions: {
    updateDiscount(data) {
      this.discount = data;
    },

    $reset() {
      this.discount = {};
    },
  },
});
