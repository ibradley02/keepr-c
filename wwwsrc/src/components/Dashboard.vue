<template>
    <div>
        <navbar></navbar>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2>{{user.username}}'s Vault</h2>
            </div>
            <div class="panel-body">
                <vault></vault>
            </div>
        </div>
    </div>
</template>

<script>
    import Navbar from './Navbar'
    import Vault from './Vault'
    export default {
        name: "Dashboard",
        data() {
            return {
            }
        },
        methods: {
        },
        mounted() {
            this.$store.dispatch('authenticate')
        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        components: {
            Navbar,
            Vault
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