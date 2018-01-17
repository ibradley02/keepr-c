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
                    <div class="panel-footer">
                        <h5>Tags:
                            <a>{{item.tags}}</a>
                        </h5>
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
            }
        },
        methods: {
            deleteKeep(id) {
                this.$store.dispatch('deleteKeep', id)
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
            }
        }
    }
</script>
<style scoped>
    .panel-heading {
        align-items: center;
    }

    .panel-body {
        align-content: center;
    }
    img{
        height: 40vh;
        width: 20vw;
    }
</style>