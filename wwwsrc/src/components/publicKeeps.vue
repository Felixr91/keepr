<template>
  <div class="row d-flex justify-content-around">

    <div v-for="keep in Keeps" class="d-flex justify-content-center mt-5">
      <div class="d-flex">
        <div>
          <div class="card" style="width: 18rem">
            <li class="list-group-item bg-warning">{{keep.name}} </li>
            <img class="card-img-top" :src="keep.img" alt="Card image cap">
            <li class="list-group-item d-flex justify-content-around">
              <!-- Keeps: {{keep.keeps}} Views: {{keep.views}} Shares: {{keep.shares}}  -->
              <div class="card pl-1 pr-1">Keeps: {{keep.keeps}}</div>
              <div class="card pl-1 pr-1">Views: {{keep.views}}</div>
              <div class="card pl-1 pr-1">Shares: {{keep.shares}}</div>
            </li>
            <!-- <li class="list-group-item">Views: {{keep.views}}</li>
            <li class="list-group-item">Shares:{{keep.shares}}</li> -->
            <li class="list-group-item d-flex justify-content-around">
              <!-- <i class="fas fa-folder-plus fa-lg" @click="addKeepToVault(keep.id)"></i> -->
              <i class="far fa-eye" @click="goToKeepView(keep.id)"></i>
            </li>
          </div>
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
    methods: {
      addKeepToVault(id) {
        console.log(id)
      },
      goToKeepView(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      }
    }
  }

</script>

<style>


</style>