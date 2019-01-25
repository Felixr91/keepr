<template>
  <div class="row d-flex justify-content-center">
    <div class="col-12">
      <!-- Modal Form Vaults -->
      <form @submit.prevent="addVault">
        <div class="modal fade" id="modalLoginForm" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
          aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header text-center">
                <h3 class="logo-font">Keepr <i class="fas fa-archive"></i></h3>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <h4 class="modal-title w-100 font-weight-bold mt-3">New Vault!</h4>
              <div class="modal-body mx-3">
                <div class="md-form mb-5">
                  <input type="text" v-model="newVault.name" id="defaultForm-email" class="form-control validate">
                  <label data-error="wrong" data-success="right" for="defaultForm-email">Vault Name</label>
                </div>

                <div class="md-form mb-4">
                  <input type="text" v-model="newVault.description" id="defaultForm-email" class="form-control validate">
                  <label data-error="wrong" data-success="right" for="defaultForm-email">Vault Description</label>
                </div>
              </div>
              <div class="d-flex justify-content-center">
                <button class="btn btn-primary mt-3 mb-4" style="width: 5rem" type="submit">Create</button>
              </div>
            </div>
          </div>
        </div>
      </form>
      <div class="text-center">
        <a href="" class="btn btn-default btn-rounded mb-4 mt-4" data-toggle="modal" data-target="#modalLoginForm">Make
          a
          New
          Vault!</a>
      </div>
    </div>
    <!-- End of Modal Log in form -->

    <div class="row">
      <div style="width: 18rem;">
        <ul class="list-group list-group-flush">
          <div v-for="vault in Vaults">
            <div class="card d-flex justify-content-between mb-2">
              <li class="list-group-item">
                {{vault.name}}
              </li>
              <li class="list-group-item">
                <p class="mb-0 text-danger" @click="deleteVault(vault.id)">Delete</p>
              </li>
              <button type="button" class="btn btn-light" @click="goToVaultKeeps(vault.id)">Open</button>
            </div>
          </div>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaults',
    data() {

      return {
        adding: false,
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {
      //returns array of user's vaults
      Vaults() {
        return this.$store.state.activeUsersVaults;
      }

    },
    mounted() {
      this.$store.dispatch('getUsersVaults');
    },
    methods: {
      goToVaultKeeps(vaultid) {
        this.$store.dispatch('goToVaultKeeps', vaultid);
        this.$store.dispatch('getSelectedVault', vaultid);
      },
      formAppear() {
        this.adding = !this.adding;
      },
      addVault() {
        this.$store.dispatch('addVault', this.newVault);
        this.adding = !this.adding;
      },
      deleteVault(vaultid) {
        this.$store.dispatch('deleteVault', vaultid);
      }
    }
  }

</script>

<style>


</style>