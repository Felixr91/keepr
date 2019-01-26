<template>
  <div class="row pl-2 pr-2 d-flex justify-content-around">
    <div v-for="keep in Keeps" class="d-flex justify-content-center mt-5 ml-2 mr-2">
      <div class="d-flex">
        <div>
          <div class="card" style="width: 18rem">
            <li class="list-group-item bg-dark text-white">{{keep.name}} </li>
            <div class="container1">
              <img class="card-img-top mt-2 mb-2" :src="keep.img" alt="Card image cap">
              <div class="d-flex justify-content-around">
                <div class="card img-info pl-1 pr-1 bottom-left">Keeps: {{keep.keeps}}</div>
                <div class="card img-info pl-1 pr-1 bottom-right">Views: {{keep.views}}</div>
                <div class="card img-info pl-1 pr-1 bottom-centered"><i class="fas fa-external-link-alt p-1" @click="goToKeepView(keep.id)"></i></div>
              </div>
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
    }
  }

</script>

<style>
  .container1 {
    position: relative;
    text-align: center;
    color: white;
  }

  .container {
    display: grid;
    grid-gap: 5px;
    grid-template-columns: repeat(auto-fill, minmax(100px, 1fr));
    grid-template-rows: 1fr 1fr;
  }

  /* Bottom left text */
  .bottom-left {
    position: absolute;
    bottom: 8px;
    left: 16px;
    margin-left: 5px;
    margin-bottom: 5px;
  }

  /* Bottom right text */
  .bottom-right {
    position: absolute;
    bottom: 8px;
    right: 16px;
    margin-right: 5px;
    margin-bottom: 5px;
  }

  /* Bottom centered text */
  .bottom-centered {
    position: absolute;
    bottom: 0px;
    left: 50%;
    transform: translate(-50%, -50%);
  }

  .img-info {
    background-color: rgba(0, 0, 0, 0.5);
  }

  /* .card-img-top {
    background: #e65100;
  } */

  img {
    border-radius: 4px;
  }
</style>