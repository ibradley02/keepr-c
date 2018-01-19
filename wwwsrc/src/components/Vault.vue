<template>
    <div class="row">
        <div class="col-sm-12">
            <div v-for="item in vaults" class="col-sm-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <button class="pull-right" @click="deleteVault(item.id)">
                            <i class="fa fa-trash"></i>
                        </button>
                        <a @click="getActiveVault(item.id)">{{item.name}}</a>
                    </div>
                    <div class="panel-body">
                        <h5>{{item.description}}</h5>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <div v-if="activeVault">
                <h1>{{activeVault.name}}</h1>
            </div>
            <div v-for="item in vaultKeeps">
                <div class="col-sm-3">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="pull-right">
                                <button @click="deleteKeep(item.id)">
                                    <i class="fa fa-trash"></i>
                                </button>
                            </div>
                            <h1>{{item.name}}</h1>
                        </div>
                        <div class="panel-body">
                            <img :src="item.image">
                            <h5>{{item.description}}</h5>
                        </div>
                        <div class="panel-footer" @mouseover="show.button = true" @mouseleave="show.button = false">
                            <div v-show="show.button">
                                <button class="btn btn-info" data-toggle="modal" data-target="#vaultKeepModal" @click="addActiveKeep(item.id)">Keep</button>
                                <button class="btn btn-info" @click="incrementKeepCount(item)">View</button>
                            </div>
                            <h5>Views: {{item.views}}</h5>
                            <h5>Tags:
                                <a>{{item.tags}}</a>
                            </h5>
                        </div>
                    </div>
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
                show: {
                    button: true
                }
            }
        },
        methods: {
            deleteVault(id) {
                var update = {
                    userId: this.user.id,
                    id: id
                };
                this.$store.dispatch('deleteVault', update)

            },
            getActiveVault(id) {
                this.$store.dispatch('getActiveVault', id)
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            vaults() {
                return this.$store.state.vaults
            },
            activeVault() {
                return this.$store.state.activeVault
            },
            vaultKeeps() {
                return this.$store.state.vaultKeeps
            }
        },
        mounted() {
            this.$store.dispatch('getVaultsById', this.user.id)
        }
    }
</script>
<style scoped>
     .panel-heading {
        align-items: center;
    }

    .modal-dialog {
        margin: 25vh auto 0px auto;
    }

    .panel-body {
        align-content: center;
    }

    .form-group {
        margin: auto auto;
    }

    img {
        height: 40vh;
        width: 20vw;
    }
</style>