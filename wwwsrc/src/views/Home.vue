<template>
  <div class="home">
    <nav></nav>
    <h1>Keepr</h1>
    <publicKeeps></publicKeeps>
  </div>
</template>

<script>
  import publicKeeps from '@/components/publicKeeps.vue'
  import nav from '@/components/nav.vue'
  export default {
    name: "home",
    data() {
      return {

      }
    },
    mounted() {
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch('getPublicKeeps');
    },
    components: {
      publicKeeps,
      nav
    },
    computed: {
      // getKeeps() {
      //   return this.$store.state.publicKeeps;
      //   console.log(this.$store.state.publicKeeps);
      // }
    }
  };
</script>