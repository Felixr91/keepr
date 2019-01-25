<template>
  <div class="row d-flex justify-content-around">
    <div v-for=" vaultkeep in VaultKeeps" class="d-flex justify-content-around">
      <div class="d-flex">
        <div class="card" style="width: 12rem;">
          <img class="card-img-top" :src="vaultkeep.img" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title">{{vaultkeep.name}}</h5>
            <p class="card-text">{{vaultkeep.shares}}</p>
            <a href="#" class="btn btn-primary" @click="deleteVaultKeep(vaultkeep.id)">Delete</a>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: 'vaultkeeps',
    data() {
      return {

      }
    },
    computed: {
      VaultKeeps() {
        return this.$store.state.activeVaultKeeps;
      },
      ActiveVault() {
        return this.$store.state.ActiveVault
      },
      // ActiveVaultName() {
      //   return this.$store.state.activeUsersVaults.find(k => k.id == this.ActiveVault) || {}
      // },
    },
    mounted() {
      // this.$store.dispatch('getVaultKeeps', this.$route.params.vaultid);
      // this.$store.dispatch('')
    },
    methods: {
      deleteVaultKeep(keepId) {

        // let payload = { vaultid: this.ActiveVault, keepid }
        this.$store.dispatch('deleteVaultKeep', { keepId, vaultId: this.ActiveVault })
      }
    }
  }

</script>

<style>


</style>