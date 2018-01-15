<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <form @submit="">
      <div class="form-group">
        <label for="email">Email</label>
        <input type="text" placeholder="email">
      </div>
      <div class="form-group">
        <label for="password">Password</label>
        <input type="password">
      </div>
      <div class="form-group">
        <button type="submit" class="btn btn-default">Submit</button>
      </div>
    </form>
  </div>
</template>

<script>
  export default {
    name: 'HelloWorld',
    data() {
      return {
        msg: 'Welcome to Your Vue.js App'
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h1,
  h2 {
    font-weight: normal;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }
</style>