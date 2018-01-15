<template>
    <div class="row">
        <nav class="navbar navbar-default navbar-fixed-top myNavbar">
            <div class="col-sm-8">
                <router-link :to="'/'">
                    <h4 class="pull-left">Keepr</h4>
                </router-link>
            </div>
            <div class="col-sm-4" v-if="user.id">
                <button type="button" class="btn" data-toggle="modal" data-target="#keepModal">
                    <span class="glyphicon glyphicon-plus"></span>
                </button>
                <router-link :to="'/profile'">
                    <h4>Welcome, {{user.username}}</h4>
                </router-link>
                <button @click="Logout">Logout</button>
            </div>
            <div class="col-sm-4 login" v-else>
                <button type="button" class="btn btn-success btn-lg" data-toggle="modal" data-target="#loginModal">Login</button>
            </div>
        </nav>
    </div>
</template>

<script>
    import Login from './Login'
    export default {
        name: 'navbar',
        data() {
            return {

            }
        },
        components: {
            Login
        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        methods: {
            Logout() {
                this.$store.dispatch('logout')
            }
        }
    }
</script>

<style scoped>
    .myNavbar {
        background-color: rgb(0, 1, 3) !important;
        color: white;
        display: flex;
        margin-bottom: 0px;
    }

    .navbar {
        border: 0px;
    }

    .navbar-btn {
        background: black;
        border: 0px;
    }

    .logout {
        margin-bottom: 2vh
    }

    .login {
        margin: auto auto;
        color: black;
    }
    h4, button {
        display: inline-block;
    }
    button {
        color: black;
        margin-left: 1vw;
    }
</style>