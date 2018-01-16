<template>
    <div class="row">
        <div class="col-sm-12">
            <form>
                <div class="form-group">
                    <input placeholder="Search">
                    <button>
                        <span class="fa fa-search"></span>
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>
<script>
export default {
  name: "search",
  data() {
    return {};
  }
};
</script>
<style scoped>
button {
  position: absolute;
  top: 0;
  right: 0;
  width: 80px;
}
input {
  /* float: left; */
  box-sizing: border-box;
  padding-right: 80px;
  width: 100%;
  text-align: center;
}
.form-group{
    position: relative;
    width: 75%;
    border-radius: 10px;
    margin: 1vh auto;
}
</style>