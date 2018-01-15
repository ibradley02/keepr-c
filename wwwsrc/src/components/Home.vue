<template>
  <div class="hello">
    <navbar></navbar>
    <search></search>
    <login></login>
  </div>
</template>

<script>
  import Search from './Search'
  import Login from './Login'
  import Navbar from './Navbar'
  export default {
    name: 'Home',
    data() {
      return {
        msg: 'Welcome to Keepr'
      }
    },
    components: {
      Login,
      Navbar,
      Search
    },
    methods: {
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