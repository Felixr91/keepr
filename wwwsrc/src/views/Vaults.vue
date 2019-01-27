<template>
  <div class="row d-flex justify-content-center">
    <div class="col-12">
      <!-- Modal Form Vaults -->
      <form @submit.prevent="addVault" id="modal">
        <div class="modal fade" id="modalLoginForm" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
          aria-hidden="true">
          <div class="modal-dialog d-flex justify-content-center" role="document">
            <div class="modal-content mt-4">
              <div class="modal-header text-center">
                <h3 class="logo-font">Keepr <i class="fas fa-archive"></i></h3>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <h4 class="modal-title w-100 font-weight-bold mt-3">New Vault!</h4>
              <div class="modal-body mx-3">
                <div class="md-form mb-1">
                  <input type="text" v-model="newVault.name" id="defaultForm-email" class="form-control validate">
                  <label data-error="wrong" data-success="right" for="defaultForm-email">Vault Name</label>
                </div>

                <div class="md-form mb-1">
                  <input type="text" v-model="newVault.description" id="defaultForm-email" class="form-control validate">
                  <label data-error="wrong" data-success="right" for="defaultForm-email">Vault Description</label>
                </div>
              </div>
              <div class="d-flex justify-content-center">
                <button class="btn btn-primary mb-4" style="width: 5rem" type="submit">Create</button>
              </div>
            </div>
          </div>
        </div>
      </form>
      <div class="text-center">
        <a href="" class="btn btn-success btn-rounded mt-4" data-toggle="modal" data-target="#modalLoginForm">Make
          a
          New
          Vault!</a>
      </div>
    </div>
    <!-- End of Modal Log in form -->


    <table class="table table-striped mt-5">
      <thead>
        <tr>
          <th scope="col">Vault Name</th>
          <th scope="col">Delete</th>
          <th scope="col">Open</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="vault in Vaults">
          <td>{{vault.name}}</td>
          <td><i class="fas fa-dumpster-fire" @click="deleteVault(vault.id)"></i></td>
          <td><i class="fas fa-box-open" @click="goToVaultKeeps(vault.id)"></i></td>
        </tr>
      </tbody>
    </table>
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
        this.$router.push({ name: 'vaults' })
      },
      deleteVault(vaultid) {
        this.$store.dispatch('deleteVault', vaultid);
      }
    }
  }

</script>

<style>
  @media only screen and (max-width: 600px) {
    .modal-content {
      width: 80%;
    }
  }
</style>