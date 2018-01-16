<template>
  <div class="hello">
    <navbar></navbar>
    <search></search>
    <create></create>
    <keep></keep>
  </div>
</template>

<script>
  import Search from './Search'
  import Login from './Login'
  import Navbar from './Navbar'
  import Keep from './Keep'
  import Create from './Create'
  export default {
    name: 'Home',
    data() {
      return {
        msg: 'Welcome to Keepr'
      }
    },
    computed: {
    },
    components: {
      Login,
      Navbar,
      Search,
      Keep,
      Create
    },
    mounted() {
      this.$store.dispatch('getKeeps')
    },
    methods: {
    }
  }
</script>
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

  .keep{
    color: black;
    margin-top: 15vh;
  }
</style>