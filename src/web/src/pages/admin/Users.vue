<template>
  <div class="">User</div>
</template>
<script>
import { useBreadCurmb } from "../../stores/breadcrumb.js";

export default {
  setup() {
    const breadcrumb = useBreadCurmb();
    breadcrumb.updateTitle("Quản lý khách hàng");
  },
};
</script>
