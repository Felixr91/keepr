<template>
  <div class="row d-flex justify-content-around">
    <div v-for=" vaultkeep in VaultKeeps" class="justify-content-around">
      <div class="d-flex card mt-5">
        <div style="width: 18rem;">
          <div class="card-header">
            {{vaultkeep.name}}
          </div>
          <img class="card-img-top" :src="vaultkeep.img" alt="Card image cap" @click="goToKeepView(vaultkeep.id)">
          <ul class="
            list-group list-group-flush">
            <!-- <li class="list-group-item">Shares: {{vaultkeep.shares}}</li> -->
            <a href="#" class="btn btn-danger" @click="deleteVaultKeep(vaultkeep.id)">Delete</a>
          </ul>
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
      },
      goToKeepView(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      }
    }
  }

</script>

<style>


</style>