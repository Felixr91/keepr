<template>
  <div class="d-flex justify-content-center">
    <div class="card-columns" style="width: 95%">
      <div v-for="keep in Keeps" class="d-flex justify-content-center">
        <div class="col pl-0 pr-0">
          <div class="card">
            <!-- <li class="list-group-item bg-dark text-white">{{keep.name}} </li> -->
            <div class="container hover-wrapper">
              <img class="card-img-top" :src="keep.img" @click="goToKeepView(keep.id)">

              <div class="img-info bottom-left pl-1 pr-1 hover-show">Keeps: {{keep.keeps}}</div>
              <div class="img-info bottom-right pl-1 pr-1 hover-show">Views: {{keep.views}}</div>
              <!-- <div class="img-info top-right"><i class="fas fa-external-link-alt p-1" @click="goToKeepView(keep.id)"></i></div> -->

            </div>
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
      // spanSizing() {
      //   console.log(document.getElementById("spanSizing").style);
      // },

    }
  }

</script>

<style>
  .container {
    position: relative;
    text-align: center;
    color: white;
    padding: 0px;
  }

  .bottom-left {
    position: absolute;
    bottom: 8px;
    left: 16px;
  }

  .bottom-right {
    position: absolute;
    bottom: 8px;
    right: 16px;
  }

  .hover-wrapper:hover .hover-show {
    display: block;
  }

  .hover-wrapper .hover-show {
    display: none;
    /* position: absolute; */
    /* width: 250px;
    height: 250px;
    left: 200px;
    top: 100px; */
  }

  .card-img-top {
    margin: 0px;
  }

  .img-info {
    background-color: rgba(0, 0, 0, 0.5);
    border-radius: 2px;
  }

  @media only screen and (max-width: 800px) {
    .img-info {
      font-size: 10px;
    }
  }

  @media only screen and (max-width: 575px) {
    .img-info {
      font-size: 15px;
    }
  }
</style>