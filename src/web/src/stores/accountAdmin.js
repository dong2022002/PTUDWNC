import { defineStore } from "pinia";

export const useAdminAccount = defineStore("useAdminAccount", {
  state: () => ({
    username: "",
    password: "",
  }),

  actions: {
    updateCategory(username, pass) {
      this.username = username;
      this.password = pass;
    },

    $reset() {
      this.username = "";
      this.password = "";
    },
  },
});
