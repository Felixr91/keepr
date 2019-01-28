<template>
  <!--Navbar-->

  <div class="row container-fluid no-gutters">
    <div class="col-12">
      <b-navbar class="navbar align-items-start navbar-light amber lighten-4 header bg-nav-white" fixed="top">
        <!-- Navbar brand -->

        <div class="d-flex justify-content-start">
          <a class="navbar-brand logo-font" href="#" @click="goHome()">Keepr <i class="fas fa-archive"></i></a>
        </div>
        <!-- Collapse button -->
        <button class="navbar-toggler first-button btn d-flex justify-content-end mr-2" onclick="this.blur();" type="button"
          data-toggle="collapse" data-target="#navbarSupportedContent20" aria-controls="navbarSupportedContent20"
          aria-expanded="false" aria-label="Toggle navigation">
          <div class="animated-icon1"><span></span><span></span><span></span></div>
        </button>

        <!-- Collapsible content -->
        <div class="collapse navbar-collapse bg-white-collapse" id="navbarSupportedContent20">

          <!-- Links -->
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navbarSupportedContent20" aria-controls="navbarSupportedContent20"
                aria-expanded="false" aria-label="Toggle navigation" @click="goHome()">Home
                <span class="sr-only">(current)</span></a>
            </li>
            <li class="nav-item" v-if="isLoggedIn()">
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navbarSupportedContent20" aria-controls="navbarSupportedContent20"
                aria-expanded="false" aria-label="Toggle navigation" @click="logout()">Logout</a>
            </li>
            <li class="nav-item" v-else>
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navbarSupportedContent20" aria-controls="navbarSupportedContent20"
                aria-expanded="false" aria-label="Toggle navigation" @click="loginScreen()">Login</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navbarSupportedContent20" aria-controls="navbarSupportedContent20"
                aria-expanded="false" aria-label="Toggle navigation" @click="goToUserVaults()">My
                Vaults</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#" data-toggle="collapse" data-target="#navbarSupportedContent20" aria-controls="navbarSupportedContent20"
                aria-expanded="false" aria-label="Toggle navigation" @click="seeMyKeeps()">My
                Keeps</a>
            </li>
          </ul>
          <!-- Links -->

        </div>
        <!-- Collapsible content -->

      </b-navbar>
    </div>
  </div>

</template>

<script>
  export default {
    name: 'navigation',
    data() {
      return {
        loggedIn: false
      }
    },
    computed: {},
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
        return (this.$store.state.user.id) ? true : false;
      },
      loginScreen() {
        this.$store.dispatch("loginScreen");
      }
    }
  }

  $(document).ready(function () {

    $('.first-button').on('click', function () {

      $('.animated-icon1').toggleClass('open');
    });
    $('.second-button').on('click', function () {

      $('.animated-icon2').toggleClass('open');
    });
    $('.third-button').on('click', function () {

      $('.animated-icon3').toggleClass('open');
    });
  });

</script>

<style>
  .bg-nav-white {
    background-color: white;
  }

  .bg-white-collapse {
    background-color: white;
    margin-left: -10px;
    margin-right: -10px;
  }

  .header {
    position: fixed;
    /* fixing the position takes it out of html flow - knows
                   nothing about where to locate itself except by browser
                   coordinates */
    left: 0;
    /* top left corner should start at leftmost spot */
    top: 0;
    /* top left corner should start at topmost spot */
    width: 100vw;
    /* take up the full browser width */
    z-index: 200;
    /* high z index so other content scrolls underneath */
    height: 70px;
    /* define height for content */
  }

  .logo-font {
    /* font-family: 'Fredoka One', cursive; */
    font-size: 2rem;
  }

  /* Icon 1 */
  .btn:focus {
    outline: none;
  }

  .animated-icon1,
  .animated-icon2,
  .animated-icon3 {
    width: 30px;
    height: 30px;
    position: relative;
    margin-top: 7px;
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
    -webkit-transition: .5s ease-in-out;
    -moz-transition: .5s ease-in-out;
    -o-transition: .5s ease-in-out;
    transition: .5s ease-in-out;
    cursor: pointer;
  }

  .animated-icon1 span,
  .animated-icon2 span,
  .animated-icon3 span {
    display: block;
    position: absolute;
    height: 3px;
    width: 100%;
    border-radius: 9px;
    opacity: 1;
    left: 0;
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
    -webkit-transition: .25s ease-in-out;
    -moz-transition: .25s ease-in-out;
    -o-transition: .25s ease-in-out;
    transition: .25s ease-in-out;
  }

  .animated-icon1 span {
    background: #e65100;
  }

  .animated-icon2 span {
    background: #e3f2fd;
  }

  .animated-icon3 span {
    background: #f3e5f5;
  }

  .animated-icon1 span:nth-child(1) {
    top: 0px;
  }

  .animated-icon1 span:nth-child(2) {
    top: 10px;
  }

  .animated-icon1 span:nth-child(3) {
    top: 20px;
  }

  .animated-icon1.open span:nth-child(1) {
    top: 11px;
    -webkit-transform: rotate(135deg);
    -moz-transform: rotate(135deg);
    -o-transform: rotate(135deg);
    transform: rotate(135deg);
  }

  .animated-icon1.open span:nth-child(2) {
    opacity: 0;
    left: -60px;
  }

  .animated-icon1.open span:nth-child(3) {
    top: 11px;
    -webkit-transform: rotate(-135deg);
    -moz-transform: rotate(-135deg);
    -o-transform: rotate(-135deg);
    transform: rotate(-135deg);
  }

  /* Icon 3*/

  .animated-icon2 span:nth-child(1) {
    top: 0px;
  }

  .animated-icon2 span:nth-child(2),
  .animated-icon2 span:nth-child(3) {
    top: 10px;
  }

  .animated-icon2 span:nth-child(4) {
    top: 20px;
  }

  .animated-icon2.open span:nth-child(1) {
    top: 11px;
    width: 0%;
    left: 50%;
  }

  .animated-icon2.open span:nth-child(2) {
    -webkit-transform: rotate(45deg);
    -moz-transform: rotate(45deg);
    -o-transform: rotate(45deg);
    transform: rotate(45deg);
  }

  .animated-icon2.open span:nth-child(3) {
    -webkit-transform: rotate(-45deg);
    -moz-transform: rotate(-45deg);
    -o-transform: rotate(-45deg);
    transform: rotate(-45deg);
  }

  .animated-icon2.open span:nth-child(4) {
    top: 11px;
    width: 0%;
    left: 50%;
  }

  /* Icon 4 */

  .animated-icon3 span:nth-child(1) {
    top: 0px;
    -webkit-transform-origin: left center;
    -moz-transform-origin: left center;
    -o-transform-origin: left center;
    transform-origin: left center;
  }

  .animated-icon3 span:nth-child(2) {
    top: 10px;
    -webkit-transform-origin: left center;
    -moz-transform-origin: left center;
    -o-transform-origin: left center;
    transform-origin: left center;
  }

  .animated-icon3 span:nth-child(3) {
    top: 20px;
    -webkit-transform-origin: left center;
    -moz-transform-origin: left center;
    -o-transform-origin: left center;
    transform-origin: left center;
  }

  .animated-icon3.open span:nth-child(1) {
    -webkit-transform: rotate(45deg);
    -moz-transform: rotate(45deg);
    -o-transform: rotate(45deg);
    transform: rotate(45deg);
    top: 0px;
    left: 8px;
  }

  .animated-icon3.open span:nth-child(2) {
    width: 0%;
    opacity: 0;
  }

  .animated-icon3.open span:nth-child(3) {
    -webkit-transform: rotate(-45deg);
    -moz-transform: rotate(-45deg);
    -o-transform: rotate(-45deg);
    transform: rotate(-45deg);
    top: 21px;
    left: 8px;
  }
</style>