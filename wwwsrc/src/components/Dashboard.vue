<template>
    <div>
        <navbar></navbar>
        <create></create>
        <div class="row">
            <div class="col-sm-12">
                <div class="title">
                    <h3>Welcome to the Dashboard. Here you can create, manage, and delete your Vaults and Keeps</h3>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-sm-12">
                                <h2>Your Dashboard</h2>
                                <button @click="viewToggle" v-if="vault.show">View Keeps</button>
                                <button @click="viewToggle" v-else>View Vaults</button>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" v-if="vault.show">
                        <vault></vault>
                    </div>
                    <div class="panel-body" v-else>
                        <keep></keep>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Navbar from './Navbar'
    import Vault from './Vault'
    import Create from './Create'
    import Keep from './Keep'
    export default {
        name: "Dashboard",
        data() {
            return {
                vault: {
                    show: true
                }
            }
        },
        methods: {
            viewToggle() {
                this.vault.show = !this.vault.show
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        components: {
            Navbar,
            Vault,
            Create,
            Keep
        }
    }  
</script>

<style scoped>
    .panel{
        margin-top: 5vh;
    }
    .title{
        margin-top: 5vh;
        background-color: rgba(137, 43, 226, 0.527);
    }
</style>