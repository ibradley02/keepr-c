<template>
    <div>
        <navbar></navbar>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2>{{user.username}}'s Vault</h2>
            </div>
            <div class="panel-body row">
                <div v-for="item in vaults" class="col-sm-4" >
                    <div class="vault-heading">
                        <h3>{{item.name}}</h3>
                    </div>
                    <div class="vault-body">
                        <h5>{{item.description}}</h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Navbar from './Navbar'
    export default {
        name: "Dashboard",
        data() {
            return {
                profile: {
                    Email: '',
                    Username: '',
                    Password: ''
                }
            }
        },
        methods: {
            submitProfile() {
                this.$store.dispatch('updateProfile' )
                this.profile = {
                    Email: '',
                    Username: '',
                    Password: ''
                }
            }
        },
        mounted() {
            this.$store.dispatch('authenticate')
            this.$store.dispatch('getVaultsById', this.user.id)
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            vaults() {
                return this.$store.state.vaults
            },
            showProfile() {
                return this.$store.state.showProfile
            }
        },
        components: {
            Navbar
        }
    }  
</script>

<style scoped>
    .vault-heading{
        display: inline-block;
    }
    .vault-body{
        display: inline-block;
    }
</style>