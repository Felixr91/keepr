<template>
  <div class="home">
    <!-- <navigation></navigation> -->
    <publicKeeps></publicKeeps>
  </div>
</template>

<script>
  import publicKeeps from '@/components/publicKeeps.vue'
  import navigation from '@/components/navigation.vue'
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
      this.$store.dispatch('getUsersVaults');
    },
    components: {
      publicKeeps,
      navigation
    },
    computed: {
      // getKeeps() {
      //   return this.$store.state.publicKeeps;
      //   console.log(this.$store.state.publicKeeps);
      // }
    }
  };
</script>