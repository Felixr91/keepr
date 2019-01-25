<template>
  <div class="row">
    <div class="col-12 nav-color pt-3 pb-3 d-flex justify-content-around">
      <div class="col-2">
        <h3 class="logo-font">Keepr <i class="fas fa-archive"></i></h3>
      </div>
      <div class="col-10 d-flex justify-content-end">
        <!-- <div v-if="isLoggedIn()"> -->
        <button type="button" class="btn btn-outline-dark mr-2" @click="logout()">Logout</button>
        <!-- </div> -->
        <!-- <div class="" v-else> -->
        <button type="button" class="btn btn-outline-dark mr-2" @click="loginScreen()">Login</button>
        <!-- </div> -->

        <button type="button" class="btn btn-outline-dark mr-2" @click="goToUserVaults()">My Vaults</button>

        <button type="button" class="btn btn-outline-dark mr-2" @click="seeMyKeeps()">My Keeps</button>
        <button type="button" class="btn btn-outline-dark mr-2" @click="goHome()"><i class="fas fa-home"></i></button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'navigation',
    data() {
      return {

      }
    },
    computed: {

    },
    methods: {
      goToUserVaults() {
        console.log(this.$store.state.user.id);
        this.$store.dispatch("goToMyVaults");
      },
      goHome() {
        this.$store.dispatch("goHome");
      },
      seeMyKeeps() {
        this.$store.dispatch("myKeeps");
      },
      logout() {
        this.$store.dispatch("logout");
      },
      isLoggedIn() {
        return (this.user.id) ? true : false;
      },
      loginScreen() {
        this.$store.dispatch("loginScreen");
      }
    }
  }

</script>

<style>
  .nav-color {
    background-color: rgb(181, 250, 250);
  }

  .logo-font {
    font-family: 'Fredoka One', cursive;
  }
</style>