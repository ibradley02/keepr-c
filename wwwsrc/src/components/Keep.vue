<template>
    <div class="row">
        <div v-for="item in keeps" style="color: black;">
            <div class="col-sm-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="pull-right" v-if="item.userId == user.id">
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
        <div id="vaultKeepModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="col-sm-12">
                            <h4>Add Keep To Vault</h4>
                        </div>
                    </div>
                    <div class="modal-body">
                        <form @submit.prevent="addKeepToVault">
                            <div class="form-group">
                                <div class="dropdown-style" title="choose category">
                                    <select class="form-control text-center" v-model="tempVault.vaultId">
                                        <option class="col-sm-12" selected disabled>Select Vault</option>
                                        <option class="col-sm-12" v-for="vault in vaults" :value="vault.id">{{vault.name}}</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <button>Keep</button>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default btn-danger col-sm-12" data-dismiss="modal">Close</button>
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
                tempVault: {
                    vaultId: ''
                },
                show: {
                    button: true
                }
            }
        },
        methods: {
            deleteKeep(id) {
                this.$store.dispatch('deleteKeep', id)
            },
            addKeepToVault() {
                var newVault = {
                    UserId: this.user.id,
                    KeepId: this.activeKeep.id,
                    VaultId: this.tempVault.vaultId
                }
                this.incrementKeepCount(newVault)
                this.$store.dispatch('addKeepToVault', newVault)
                this.tempVault = {
                    id: ''
                }
            },
            incrementKeepCount(keep) {
                keep.views++
                this.$store.dispatch('incrementKeepCount', keep)
            },
            addActiveKeep(id) {
                this.$store.dispatch('getActiveKeep', id)
            }
        },
        mounted() {
            this.$store.dispatch('getKeeps')
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            user() {
                return this.$store.state.user
            },
            vaults() {
                return this.$store.state.vaults
            },
            activeKeep() {
                return this.$store.state.activeKeep
            }
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