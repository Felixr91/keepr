<template>
  <div class="row d-flex justify-content-center">
    <div class="card-columns" style="width: 95%">
      <div v-for=" vaultkeep in VaultKeeps" class="d-flex justify-content-center">
        <div class="col pl-0 pr-0">
          <div class="card">
            <div class="container hover-wrapper">
              <img class="card-img-top" :src="vaultkeep.img" alt="Card image cap" @click="goToKeepView(vaultkeep.id)">
              <div class="img-info bottom-left pl-1 pr-1 hover-show"><i class="fas fa-trash-alt" @click="deleteVaultKeep(vaultkeep.id)"></i></div>
            </div>
            </ul>
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
      },
      goToKeepView(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      }
    }
  }

</script>

<style>


</style>