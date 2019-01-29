<template>
  <div class="row d-flex justify-content-center">
    <div class="col-12 modal-to-hide">
      <!-- Keeps Modal -->
      <form @submit.prevent="addKeep" id="modal">
        <div class="modal fade" id="orangeModalSubscription" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
          aria-hidden="true">
          <div class="modal-dialog d-flex justify-content-center" role="document">
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
                <div class="md-form mb-1">
                  <input type="text" v-model="newKeep.name" id="form3" class="form-control validate">
                  <label data-error="wrong" data-success="right" for="form3">Keep Name</label>
                </div>

                <div class="md-form mb-1">
                  <input type="text" v-model="newKeep.img" id="form2" class="form-control validate">
                  <label data-error="wrong" data-success="right" for="form2">Image Link</label>
                </div>

                <div class="md-form">
                  <input type="text" v-model="newKeep.description" id="form2" class="form-control validate">
                  <label data-error="wrong" data-success="right" for="form2">Description</label>
                </div>

                <!-- Checkbox -->
                <div class="col-12 d-flex justify-content-center mt-3">
                  <div class="card d-flex justify-content-center bg-light" style="width: 5rem">
                    <div class="">
                      <p>Private</p>
                      <input type="checkbox" id="checkbox" v-model="newKeep.isPrivate">
                      <label for="checkbox"></label>
                    </div>
                  </div>
                </div>
              </div>

              <!--Footer-->
              <div class="d-flex justify-content-center">
                <button class="btn btn-primary mt-3 mb-4 close-on-create" style="width: 5rem" @click="submitKeep">Create</button>
              </div>
            </div>
            <!--/.Content-->
          </div>
        </div>
      </form>
      <div class="col-12">
        <div class="text-center">
          <a href="" class="btn btn-success btn-rounded mt-4 mb-4" data-toggle="modal" data-target="#orangeModalSubscription">Create
            Keep!</a>
        </div>
      </div>
    </div>
    <!-- End of modal form -->

    <div class="home">
      <div class="d-flex justify-content-center">
        <div class="card-columns" style="width: 88%">
          <div v-for="keep in keeps" class="d-flex justify-content-around">
            <div class="col pl-0 pr-0">
              <div class="card">
                <div class="container hover-wrapper">
                  <img class="card-img-top" :src="keep.img" @click="goToKeepView(keep.id)">
                  <div class="img-info bottom-left pl-1 pr-1 hover-show"><i class="fas fa-trash-alt" @click="deleteKeep(keep.id)"></i></div>
                  </li>
                </div>
              </div>
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
        this.$store.dispatch('addKeep', this.newKeep);
      },
      goToKeepView(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      },
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId)
      },
      submitKeep() {
        this.$store.dispatch('addKeep', this.newKeep);
        // document.querySelector(".modal-content").style.display = "none";
        // document.querySelector(".modal-backdrop").hidden = true;
        // closeModal(){

        // }
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