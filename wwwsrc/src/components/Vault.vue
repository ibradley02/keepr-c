<template>
    <div>
        <div v-for="item in vaults" class="col-sm-4">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <button class="pull-right" @click="deleteVault(item.id)"><i class="fa fa-trash"></i></button>
                    <h3>{{item.name}}</h3>
                </div>
                <div class="panel-body">
                    <h5>{{item.description}}</h5>
                </div>
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
        // mounted() {
        //     this.$store.dispatch('getVaultsById', this.user.id)
        // },
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