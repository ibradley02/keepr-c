<template>
    <div class="row">
        <!-- Modal -->
        <div id="loginModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="col-sm-6">
                            <a @click="toggleLoginForm" class="modal-title">Login </a>
                        </div>
                        <div class="col-sm-6">
                            <a @click="toggleLoginForm" class="modal-title">Register</a>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div v-if="loginForm">
                            <form @submit.prevent="Login">
                                <div class="form-group">
                                    <input type="text" placeholder="E-mail">                                
                                </div>
                                <div class="form-group">
                                    <input type="password" placeholder="Password" v-model="login.Password">
                                </div>
                                <div class="form-group">
                                    <button type="submit" class="btn btn-default">Login</button>
                                </div>
                            </form>
                        </div>
                        <div v-else>
                            <form @submit.prevent="Register">
                                <div class="form-group">
                                    <input type="text" placeholder="E-mail" v-model="register.Email">
                                </div>
                                <div class="form-group">
                                    <input type="text" placeholder="Username" v-model="register.Username">
                                </div>
                                <div class="form-group">
                                    <input type="password" placeholder="Password" v-model="register.Password">
                                </div>
                                <div class="form-group">
                                    <button type="submit" class="btn btn-default">Register</button>
                                </div>
                            </form>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default btn-danger" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
        <!-- <button @click="toggleLoginForm">Don't have an account? Click to Register.</button> -->
    </div>
</template>

<script>
export default {
  name: "Login",
  data() {
    return {
      loginForm: true,
      login: {
        Email: "",
        Password: ""
      },
      register: {
        Email: "",
        Username: "",
        Password: ""
      }
    };
  },
  methods: {
    toggleLoginForm() {
      this.loginForm = !this.loginForm;
    },
    Login() {
      this.$store.dispatch("login", this.login);
      this.login = {
        Email: "",
        Password: ""
      };
    },
    Register() {
      this.$store.dispatch("register", this.register);
      this.register = {
        Email: "",
        Username: "",
        Password: ""
      };
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.fontAwesome {
  font-family: Helvetica, 'FontAwesome', sans-serif;
}
.modal-dialog {
    margin: 25vh auto 0px auto
}
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

label,
input {
  display: block;
  float: none;
  margin: 0 auto;
  text-align: center;
}
</style>