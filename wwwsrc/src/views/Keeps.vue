<template>
  <div class="row">

    <!-- Keeps Modal -->
    <form @submit.prevent="addKeep">
      <div class="modal fade" id="orangeModalSubscription" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-notify modal-warning" role="document">
          <!--Content-->
          <div class="modal-content">
            <!--Header-->
            <div class="modal-header text-center">
              <h3 class="logo-font">Keepr <i class="fas fa-archive"></i></h3>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true" class="white-text">&times;</span>
              </button>
            </div>
            <h4 class="modal-title w-100 font-weight-bold mt-3">New Keep!</h4>
            <!--Body-->
            <div class="modal-body">
              <div class="md-form mb-5">
                <input type="text" v-model="newKeep.name" id="form3" class="form-control validate">
                <label data-error="wrong" data-success="right" for="form3">Keep Name</label>
              </div>

              <div class="md-form mb-5">
                <input type="text" v-model="newKeep.img" id="form2" class="form-control validate">
                <label data-error="wrong" data-success="right" for="form2">Image Link</label>
              </div>

              <div class="md-form">
                <input type="text" v-model="newKeep.description" id="form2" class="form-control validate">
                <label data-error="wrong" data-success="right" for="form2">Description</label>
              </div>

              <!-- Checkbox -->
              <div class="col-12 d-flex justify-content-center mt-3">
                <div class="card d-flex justify-content-center bg-light" style="width: 6rem">
                  <div class="mb-2 mt-2">
                    <p>Private</p>
                    <input type="checkbox" id="checkbox" v-model="newKeep.isPrivate">
                    <label for="checkbox"></label>
                  </div>
                </div>
              </div>
            </div>

            <!--Footer-->
            <div class="d-flex justify-content-center">
              <button class="btn btn-primary mt-3 mb-4" style="width: 5rem" type="submit">Create</button>
            </div>
          </div>
          <!--/.Content-->
        </div>
      </div>
    </form>
    <div class="col-12">
      <div class="text-center">
        <a href="" class="btn btn-default btn-rounded mt-4 mb-4" data-toggle="modal" data-target="#orangeModalSubscription">Create
          Keep!</a>
      </div>
    </div>
    <!-- End of modal form -->


    <div class="row">
      <div class="col-12 d-flex">
        <div v-for="keep in keeps" class="d-flex justify-content-around mt-5">
          <div>
            <div class="card" style="width: 18rem">
              <li class="list-group-item bg-warning">{{keep.name}} </li>
              <img class="card-img-top" :src="keep.img" alt="Card image cap">
              <li class="list-group-item d-flex justify-content-around">
                <div class="card pl-1 pr-1">Keeps: {{keep.keeps}}</div>
                <div class="card pl-1 pr-1">Views: {{keep.views}}</div>
                <div class="card pl-1 pr-1">Shares: {{keep.shares}}</div>
              </li>
              <li class="list-group-item d-flex justify-content-around">
                <!-- <i class="fas fa-folder-plus fa-lg" @click="addKeepToVault(keep.id)"></i> -->
                <i class="fas fa-trash-alt" @click="deleteKeep(keep.id)"></i>
                <i class="far fa-eye" @click="goToKeepView(keep.id)"></i>
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
    name: 'keeps',
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
          isPrivate: false
        },
      }
    },
    computed: {
      keeps() {
        return this.$store.state.activeUsersKeeps
      }
    },
    mounted() {
      this.$store.dispatch('getUsersKeeps');
    },
    methods: {
      addKeep() {
        if (this.newKeep.isPrivate) {
          this.newKeep.isPrivate = 1
        } else {
          this.newKeep.isPrivate = 0
        }
        // this.newKeep.UserId = this.$store.state.user.id
        this.$store.dispatch('addKeep', this.newKeep);
      },
      goToKeepView(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      },
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId)
      }
    }
  }
</script>

<style>


</style>