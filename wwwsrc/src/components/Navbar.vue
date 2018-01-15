<template>
    <div class="row">
        <nav class="navbar navbar-default navbar-fixed-top myNavbar">
            <div class="col-sm-8">
                <h4 class="pull-left">Keepr</h4>
            </div>
            <div class="col-sm-4 login">
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
        }
    }
</script>

<style>
    .myNavbar {
        background-color: rgb(0, 1, 3);
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
</style>