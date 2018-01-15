<template>
    <div class="row">
        <div class="col-sm-12">
            <form>
                <div class="form-group">
                    <input placeholder="Search">
                    <button>
                        <span class="glyphicon glyphicon-search"></span>
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'search',
        data() {
            return {

            }
        }
    }
</script>
<style scoped>
    input,
    button {
        display: inline-block;
        text-align: center;
    }
</style>