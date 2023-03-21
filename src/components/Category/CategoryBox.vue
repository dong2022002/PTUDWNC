<template>
  <div class="card w-100 h-100">
    <div class="embed-responsive">
      <img class="card-img-top" :src="category.imageUrl" alt="Card image cap" />
    </div>
    <div class="card-body">
      <h5 class="card-title">{{ category.categoryName }}</h5>
      <p class="card-text">
        {{ category.Description }}
      </p>
      <a href="#" class="btn btn-primary">Go somewhere</a>
    </div>
  </div>
</template>
<script>
export default {
  name: "CategoryBox",
  props: ["category"],
  methods: {},
};
</script>
<style scoped>
.card-img-top {
  object-fit: cover;
}
</style>
