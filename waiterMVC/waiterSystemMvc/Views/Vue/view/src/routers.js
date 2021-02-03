import VueRouter from "vue-router";
import Login from '@/components/login';
import Menu from  '@/components/Menu';
import Atendimento from '@/components/Atendimento';
import Pedidos from '@/components/Pedidos';
import Vue from 'vue';
import Copa from '@/components/Copa';
import Cozinha from '@/components/Cozinha';
//import Atendimento from '@/components/Atendimento';

Vue.use(VueRouter);

const rotas = new VueRouter({
  routes: [
    {
      path: '*',
      redirect: '/menu'
    },
    {
      path: '/',
      redirect: '/login'
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/menu',
      name: 'Menu',
      component: Menu
    },{
       path: '/atendimento',
       name: 'atendimento',
       component: Atendimento
    },{
        path:'/pedidos',
        name: 'pedidos',
        component: Pedidos 
    },{
       path:'/copa',
       name:'copa',
       component: Copa
    },{
      path:'/cozinha',
      name:'cozinha',
      component: Cozinha
    }
  ]
,mode:"history"} );
/*
const router = new VueRouter({
  rotas,
  mode: "history",
});
*/
export default rotas;