<template>
    <div>
        <div v-if="loginForm">
            <form @submit="login">
                <div class="form-group">
                    <label for="email">Email</label>
                    <input type="text">
                </div>
                <div class="form-group">
                    <label for="password">Password</label>
                    <input type="password">
                </div>
                <div class="form-group">
                    <button type="submit" class="btn btn-default">Login</button>
                </div>
            </form>
        </div>
        <div v-else>
            <form @submit="register">
                <div class="form-group">
                    <label for="email">Email:</label>
                    <input type="text">
                </div>
                <div class="form-group">
                    <label for="password">Username:</label>
                    <input type="password">
                </div>
                <div class="form-group">
                    <label for="password">Password:</label>
                    <input type="password">
                </div>
                <div class="form-group">
                    <button type="submit" class="btn btn-default">Register</button>
                </div>
            </form>
        </div>
        <button @click="toggleLoginForm">Don't have an account? Click to Register.</button>
    </div>
</template>

<script>
    export default {
        name: 'Login',
        data() {
            return {
                loginForm: true,
                login: {
                    email: '',
                    password: ''
                },
                register: {
                    email: '',
                    username: '',
                    password: ''
                }
            }
        },
        methods: {
            toggleLoginForm() {
                this.loginForm = !this.loginForm;
            },
            Login() {
                this.$store.dispatch('login', this.login)
                this.login = {
                    email: '',
                    password: ''
                }
            },
            Register() {
                this.$store.dispatch('register', this.register)
                this.register = {
                    email: '',
                    username: '',
                    password: ''
                }
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h1,
    h2 {
        font-weight: normal;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>