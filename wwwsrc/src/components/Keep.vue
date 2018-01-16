<template>
    <div class="row">
        <!-- Modal -->
        <div id="keepModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <a @click="toggleForm" v-if="createForm">Create Keep</a>
                        <a @click="toggleForm" v-else>Create Vault</a>
                    </div>
                    <div class="modal-body">
                        <div v-if="createForm">
                            <form @submit.prevent="addVault">
                                <div class="form-group">
                                    <label for="vault">Vault</label>
                                    <input type="text" placeholder="Name" v-model="vault.Name">
                                    <input type="text" placeholder="Description" v-model="vault.Description">
                                </div>
                                <div>
                                </div>
                                <div class="form-group">
                                    <button type="submit">Create</button>
                                </div>
                            </form>
                        </div>
                        <div v-else>
                            <form @submit.prevent="addKeep">
                                <div class="form-group">
                                    <label for="keep">Keep</label>
                                    <input type="text">
                                </div>
                                <div class="form-group">
                                    <button type="submit">Submit</button>
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
    </div>
</template>

<script>
    export default {
        name: 'Keep',
        data() {
            return {
                createForm: true,
                vault: {
                    Name: '',
                    Description: ''
                }
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        methods: {
            toggleForm(){
                this.createForm = !this.createForm
            },
            toggleLoginForm() {
                this.loginForm = !this.loginForm;
            },
            addVault() {
                var createVault = {
                    userId: this.user.id,
                    name: this.vault.Name,
                    description: this.vault.Description
                };
                this.$store.dispatch('createVault', createVault)
                this.vault = {
                    Name: '',
                    Description: '',

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

    label,
    input {
        display: block;
        float: none;
        margin: 0 auto;
        text-align: center;
    }
</style>