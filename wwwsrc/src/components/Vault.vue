<template>
    <div>
        <div v-for="item in vaults" class="col-sm-4">
            <div class="vault-heading">
                <h3>{{item.name}}</h3>
            </div>
            <div class="vault-body">
                <h5>{{item.description}}</h5>
                <button @click="deleteVault(item.id)"><i class="fa fa-trash"></i></button>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'Vault',
        data() {
            return {
            }
        },
        methods: {
            deleteVault(id){
                this.$store.dispatch('deleteVault', id)

            }
        },
        mounted() {
            this.$store.dispatch('getVaultsById', this.user.id)
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            vaults() {
                return this.$store.state.vaults
            }
        }
    }
</script>
<style scoped>
</style>