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
                            <form @submit.prevent="addKeep">
                                <div class="form-group">
                                    <label for="vault">Vault</label>
                                    <input type="text">
                                </div>
                                <div class="form-group">
                                    <button type="submit">Submit</button>
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
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
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
                createForm: true
            }
        },
        methods: {
            toggleForm(){
                this.createForm = !this.createForm
            },
            toggleLoginForm() {
                this.loginForm = !this.loginForm;
            },
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