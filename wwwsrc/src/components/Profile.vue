<template>
    <div>
        <navbar></navbar>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2>Profile</h2>
            </div>
            <div class="panel-body">
                <h3>Email: {{user.email}}</h3>
                <h3>Username: {{user.username}}</h3>
            </div>
        </div>
    </div>
</template>

<script>
    import Navbar from './Navbar'
    export default {
        name: "profile",
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