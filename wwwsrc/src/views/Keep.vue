<template>
  <div class="row">
    <div class="col-12 d-flex justify-content-center">
      <!-- {{keeps}} -->
      <div class="card" style="width: 80%;">
        <img class="card-img-top" :src="keep.img" alt="Card image cap">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <!-- <p class="card-text">Select a vault to add it to below: </p> -->
          <a href="#" class="btn btn-primary" @click="toggleShowVaults">+ Vault</a>
          <div class="d-flex justify-content-center">
            <!-- <div v-if="showVaults"> -->
            <div class="card mt-5 mb-5" style="width: 12rem;">
              <div v-for="vault in vaults">
                <li class="list-group-item d-flex justify-content-between">
                  {{vault.name}}
                  <i class="fas fa-plus-circle" @click="createVaultKeep(vault.id)"></i>
                </li>
                <ul class="list-group list-group-flush"></ul>
              </div>
            </div>
            <!-- </div> -->
          </div>
        </div>
      </div>


    </div>

  </div>
</template>

<script>
  export default {
    name: 'keep',
    props: ["keepid"],
    data() {
      showVaults: false
      return {}
    },
    computed: {
      // keepid() {
      //   return this.$route.params.keepid
      // },
      keep() {
        return this.$store.state.publicKeeps.find(k => k.id == this.keepid) || {}
      },
      keeps() {
        return this.$store.state.publicKeeps
      },
      vaults() {
        return this.$store.state.activeUsersVaults

      }
    },
    mounted() {
      // this.$store.dispatch("incrementViewCount", this.keep.id)
      this.editKeepViews()
    },
    methods: {
      toggleShowVaults() {
        this.showVaults = !this.showVaults;
      },
      createVaultKeep(vaultId) {
        let payload = { vaultId, keepId: this.keep.id }
        this.incrementKeepsCount();
        this.$store.dispatch('postVaultKeep', payload)
      },
      editKeepViews() {
        let payload =
        {
          name: this.keep.name,
          description: this.keep.description,
          id: this.keep.id,
          img: this.keep.img,
          isPrivate: this.keep.isPrivate,
          views: this.keep.views + 1
        }
        this.$store.dispatch("editKeep", payload)
      },
      incrementKeepsCount() {
        let payload =
        {
          name: this.keep.name,
          description: this.keep.description,
          id: this.keep.id,
          img: this.keep.img,
          isPrivate: this.keep.isPrivate,
          views: this.keep.views,
          keeps: this.keep.keeps + 1
        }
        this.$store.dispatch("editKeep", payload)
      }
    }
  }

</script>

<style>


</style>