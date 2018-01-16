<template>
    <div class="row">
        <div v-for="item in keeps" style="color: black;">
            <div class="panel panel-default col-sm-3">
                <div class="panel-heading">
                    <h1>{{item.name}}</h1>
                </div>
                <div class="panel-body">
                    <h3>{{item.description}}</h3>
                    <h5>{{item.tags}}</h5>
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
        },
        mounted() {
            this.$store.dispatch('getKeeps')
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            }
        }
    }
</script>
<style scoped>
</style>