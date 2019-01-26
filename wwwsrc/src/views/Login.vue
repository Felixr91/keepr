<template>
    <div class="login">
        <div class="row d-flex justify-content-center">
            <div class="card align-items-center pt-3" style="width: 20rem">
                <form v-if="loginForm" @submit.prevent="loginUser">
                    <p class="navbar-brand logo-font ml-3">Login </p>
                    <!-- <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit">Login</button> -->
                    <div class="form-group align-items-center" style="width: 17rem">
                        <label for="exampleInputEmail1">Email address</label>
                        <input type="email" name="email" class="form-control" id="email" aria-describedby="emailHelp"
                            placeholder="Enter email" v-model="creds.email">
                    </div>
                    <div class="form-group" style="width: 17rem">
                        <label for=" exampleInputEmail1">Password</label>
                        <input type="password" v-model="creds.password" name="password" id="password" class="form-control"
                            aria-describedby="emailHelp" placeholder="Enter Password">
                    </div>
                    <button class="btn btn-primary mb-3" type="submit">Login</button>
                </form>
                <form v-else @submit.prevent="register">
                    <p class="navbar-brand logo-font ml-3">Register </p>
                    <div class="form-group align-items-center" style="width: 17rem">
                        <label for="exampleInputEmail1">Username</label>
                        <input type="text" name="username" class="form-control" id="username" aria-describedby="Username"
                            placeholder="Enter Username" v-model="newUser.username">
                    </div>
                    <div class="form-group align-items-center" style="width: 17rem">
                        <label for="exampleInputEmail1">Email address</label>
                        <input type="email" name="email" class="form-control" id="email" aria-describedby="emailHelp"
                            placeholder="Enter email" v-model="newUser.email">
                    </div>
                    <div class="form-group" style="width: 17rem">
                        <label for=" exampleInputEmail1">Password</label>
                        <input type="password" v-model="newUser.password" name="password" id="password" class="form-control"
                            aria-describedby="emailHelp" placeholder="Enter Password">
                    </div>
                    <button class="btn btn-primary mb-3" type="submit">Login</button>

                    <!-- <input type="text" v-model="newUser.username" placeholder="name">
                    <input type="email" v-model="newUser.email" placeholder="email">
                    <input type="password" v-model="newUser.password" placeholder="password">
                    <button type="submit">Create Account</button> -->
                </form>
                <div @click="loginForm = !loginForm">
                    <p v-if="loginForm">No account? <br> <u>Click to Register</u></p>
                    <p v-else>Already have an account? <br> <u>Click to Login</u></p>
                </div>
            </div>
        </div>
        <!-- <publicKeeps></publicKeeps> -->
    </div>

</template>

<script>
    import publicKeeps from '@/components/publicKeeps.vue'
    export default {
        name: "login",
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                // console.log("trying to login!")
                this.$store.dispatch("login", this.creds);
            }
        },
        mounted() {
            // this.$store.dispatch('getPublicKeeps');

        },
        components: {
            // publicKeeps
        }
    };
</script>