<template>
  <div id="geral">
    <div id="top">
      <button id="back" @click="voltar">
        <div id="arrow"></div>
        <p id="voltaText">Voltar</p>
      </button>
      <h1>Atendimento ao cliente</h1>
    </div>

    <div v-show="!listaPedidos">
      <div class="container">
        <table id="customers">
          <tr>
            <th>Mesa</th>
            <th data-priority="1">Cliente</th>
            <th data-priority="2">Valor</th>
            <th data-priority="3">Primeiro Atendimento</th>
          </tr>
          <tr v-for="dados in pedidos" v-bind:key="dados.id">
            <td>{{ dados.mesa }}</td>
            <td>{{ dados.cliente }}</td>
            <td>{{ dados.valor }}</td>
            <td>{{ dados.Garcom.nome }}</td>
          </tr>
        </table>
      </div>

      <div class="inputBox">
        <input
          class="input"
          type="submit"
          placeholder="Novo Pedido"
          value="Novo Pedido"
          @click="novoPedido"
        />
      </div>
    </div>
  </div>
</template>

<style scoped>
#geral {
  width: 100%;
  height: 100vh;
}
#customers {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
  height: 100%;
}

#customers td,
#customers th {
  border: 1px solid #ddd;
  padding: 8px;
}

#customers tr:nth-child(even) {
  background-color: #f2f2f2;
}
#customers tr:nth-child(odd) {
  background-color: #d0d0d0;
}
#customers tr:hover {
  background-color: #ddd;
}

#customers th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: rgba(62, 81, 128, 0.8);
  color: white;
}
div {
  background-color: rgba(62, 81, 128, 0.8);
}
body {
  background-color: rgba(62, 81, 128, 0.8);
}
.inputBox {
  position: absolute;
  right: 100px;
}
.input {
  border: none;
  padding: 15px 20px;
  border-radius: 25px;
  background: white;
  font-family: "Helvetica";
  position: relative;
  left: 70px;
  margin-top: 10px;
  display: inline-block;
}
h1 {
  display: block;
  color: white;
  text-align: center;
  font-family: Arial, Helvetica, sans-serif;
}
#top {
  margin-bottom: 50px;
}
* {
  box-sizing: border-box;
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
}

h2 {
  text-align: center;
  font-size: 18px;
  text-transform: uppercase;
  letter-spacing: 1px;
  color: white;
  padding: 30px 0;
}
#back {
  align-items: center;
  display: flex;
  justify-content: center;
  padding: 8px;
  background-color: rgba(62, 81, 128, 0.8);
}
</style>

<script>
import axios from "axios";

import rotas from "@/routers";
import url from "@/utils";
export default {
  data() {
    return {
      pedidos: [],
      listaPedidos: false,
    };
  },
  components: {},
  methods: {
    novoPedido: function () {
      rotas.replace("pedidos");
    }, voltar: function () {
      rotas.replace("menu");
    }
  },
  mounted: function () {
    var vm = this;
    console.log(url + "pedido");
    axios
      .get("https://localhost:44396/api/" + "pedido")
      .then((resp) => {
        vm.pedidos = resp.data;
        console.log(resp.data);
      })
      .catch((erro) => {
        console.log(erro);
      });
  },
};
</script>