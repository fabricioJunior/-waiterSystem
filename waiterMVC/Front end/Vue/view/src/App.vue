<template>
   <body id="bg">
    <div id="app">
      
     <router-view/>
           
      
    </div>
  </body>

  
</template>
<script>
//import Atendimento from './components/Atendimento';
import Vue from 'vue';

export default {
   components:{
  //  Atendimento
    
   },
      
      Atendimentouounted:function(){
       Vue.url = "https://localhost:44396/api/";
   }
}
</script>
  
<style >
 body{
    background-color: rgba(62, 81, 128, 0.8);  
  }
</style>