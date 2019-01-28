<template>
  <div class="d-flex justify-content-center">
    <div class="card-columns" style="width: 95%">
      <div v-for="keep in Keeps" class="d-flex justify-content-center">
        <div class="col pl-0 pr-0">
          <div class="card">
            <div class="container hover-wrapper">
              <img class="card-img-top" :src="keep.img" @click="goToKeepView(keep.id)">
              <div class="img-info bottom-left pl-1 pr-1 hover-show">Keeps: {{keep.keeps}}</div>
              <div class="img-info bottom-right pl-1 pr-1 hover-show">Views: {{keep.views}}</div>
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
      Keeps() {
        return this.$store.state.publicKeeps.sort(() => Math.random() - 0.5);
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

  /* I want 300px here but it breaks for some reason */
  @media (min-width: 580px) {
    .card-columns {
      -webkit-column-count: 2;
      -moz-column-count: 2;
      column-count: 2;
    }
  }

  @media (min-width: 48em) {
    .card-columns {
      -webkit-column-count: 3;
      -moz-column-count: 3;
      column-count: 3;
    }
  }

  @media (min-width: 62em) {
    .card-columns {
      -webkit-column-count: 4;
      -moz-column-count: 4;
      column-count: 4;
    }
  }

  @media (min-width: 75em) {
    .card-columns {
      -webkit-column-count: 5;
      -moz-column-count: 5;
      column-count: 5;
    }
  }
</style>