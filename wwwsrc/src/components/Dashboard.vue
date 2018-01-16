<template>
    <div>
        <navbar></navbar>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2>{{user.username}}'s Dashboard</h2>
            </div>
            <div class="panel-body">
                
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
            showProfile() {
                return this.$store.state.showProfile
            }
        },
        components: {
            Navbar
        }
    }  
</script>

<style>
</style>