<template>
  <div class="row">
    <div class="col-12 d-flex justify-content-center">
      <!-- {{keeps}} -->
      <div class="card mt-5 mb-5">
        <!-- <div class=" card-header bg-warning">
        {{keep.name}}
      </div> -->
        <img class="card-img-top" style="height: 100%;" :src="keep.img" alt="Card image cap">
        <li class="list-group-item text-center bg-warning">
          Add this to a vault!
        </li>
        <div class="d-flex justify-content-center">
          <div class="mt-1 mb-1">
            <div v-for="vault in vaults" class="mb-3 mt-2">
              <li class="list-group-item">
                {{vault.name}}
                <i class="fas fa-plus-circle" @click="createVaultKeep(vault.id)"></i>
              </li>
            </div>
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