<template>
  <div class="geral">
  

    <nav>
      <label for="touch"><span>Menu</span></label>
      <input type="checkbox" id="touch" />

      <ul class="slide">
        <li><a href="/atendimento">Atendimento</a></li>
        <li><a href="/cozinha">Cozinha</a></li>
        <li><a href="/copa">Copa</a></li>
      </ul>
    </nav>
  </div>
</template>
<script>

import rotas from '@/routers';

export default {
  data() {
    return {
     
    };
  },methods:{
     atendimento:function(){
        rotas.replace("atendimento");
     }
  }
};
</script>

<style scoped  > 
.geral{
    width: 100%;
  height: 100vh;
}
body {
  background-color: rgba(41, 59, 104, 0.9);
  color: white;
  font-family: "Open Sans", sans-serif;
}

h1 {
  padding: 40px;
  text-align: center;
  font-size: 1.5em;
}

li a {
  text-decoration: none;
  color: #2d2f31;
  text-align: left;
}

nav {
  width: 300px;
  background: #d9d9d9;
  margin: 40px auto;
  position: relative;
  top: 30%
}

span {
  padding: 30px;
  background: #2d2f31;
  color: white;
  font-size: 1.2em;
  font-variant: small-caps;
  cursor: pointer;
  display: block;
}

span::after {
  float: right;
  right: 10%;
  content: "+";
}

.slide {
  clear: both;
  width: 100%;
  height: 0px;
  overflow: hidden;
  text-align: center;
  transition: height 0.4s ease;
}

.slide li {
  padding: 30px;
}

#touch {
  position: absolute;
  opacity: 0;
  height: 0px;
}

#touch:checked + .slide {
  height: 300px;
}
</style>