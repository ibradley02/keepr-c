<template>
    <div class="row">
        <!-- Modal -->
        <div id="loginModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="col-sm-12">
                            <h4>Account</h4>
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
                                    <button type="submit" class="btn btn-default btn-success">Login</button>
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
                                    <button type="submit" class="btn btn-default btn-success">Register</button>
                                </div>
                            </form>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a class="col-sm-10 text-footer" v-if="loginForm" @click="toggleLoginForm">Don't have an account? Click to Register.</a>
                        <a class="col-sm-10 text-footer" v-else @click="toggleLoginForm">Already have an account? Click to Login.</a>
                        <button type="button" class="btn btn-default btn-danger col-sm-2" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
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
  font-family: Helvetica, "FontAwesome", sans-serif;
}
.modal-dialog {
  margin: 25vh auto 0px auto;
}
.modal-header {
  background-color: darkgray;
}
.btn-success {
  width: 80%;
}
.text-footer {
  color: black;
  text-align: center;
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
  color: white;
}

label,
input {
  display: block;
  float: none;
  margin: 0 auto;
  text-align: center;
  width: 80%;
}
</style>