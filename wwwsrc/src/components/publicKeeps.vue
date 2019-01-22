<template>
  <div class="row d-flex justify-content-around">
    <div v-for="keep in Keeps" class="col-3 d-flex justify-content-center mt-5">
      <div class="card" style="width: 12rem;">
        <img class="card-img-top" :src="keep.img" alt="Card image cap">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <li class="list-group-item">Keeps: {{keep.keeps}} </li>
          <li class="list-group-item">Views: {{keep.views}}</li>
          <li class="list-group-item">Shares:{{keep.shares}}</li>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'publickeeps',
    data() {
      return {

      }
    },
    computed: {
      //returns array of public keeps
      Keeps() {
        return this.$store.state.publicKeeps;
        console.log(this.$store.state.publicKeeps);
      }
    },
    methods: {}
  }

</script>

<style>


</style>