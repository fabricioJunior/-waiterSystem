<template>
  <div>
    <button id="back" @click="voltar">
      <div id="arrow"></div>
      <p id="voltaText">Voltar</p>
    </button>
    <h1>Cozinha</h1>
    <div>
      <table id="customers">
        <tr>
          <th>Pedido</th>
          <th>Mesa</th>
          <th>Nome</th>
          <th>Descrição</th>
          <th>Quantidade</th>
          <th>Pronto</th>
        </tr>
        <tr v-for="b in pratos" :key="b.id">
          <td>{{ b.idPedido }}</td>
          <td>{{ b.Pedido.mesa }}</td>
          <td>{{ b.Menu.nome }}</td>
          <td>{{ b.Menu.descricao }}</td>
          <td>{{ b.quantidade }}</td>
          <td><input type="checkbox" v-model="b.pronto" /></td>
        </tr>
      </table>
    </div>

    <input
      class="input"
      type="submit"
      value="Atualizar Pratos Prontos"
      @click="atualizarBebidas"
    />
    <input
      class="input"
      type="submit"
      value="Atualizar Pratos"
      @click="atualizar"
    />
  </div>
</template>
<style scoped>
.input {
  border: none;
  padding: 15px 20px;
  border-radius: 25px;
  background: white;
  font-family: "Helvetica";
  position: relative;
  right: 0px;
  margin-top: 10px;
  display: inline-block;
}
h1 {
  text-align: center;
  color: white;
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
import url from "@/utils";
import rotas from "@/routers";
//import rotas from "@/routers";
export default {
  data() {
    return {
      pratos: [],
    };
  },
  methods: {
    atualizarBebidas: function () {
      let array = Array.from(this.pratos);

      let prontas = array.filter(function (x) {
        return x.pronto;
      });
      prontas.forEach((element) => {
        element.pronto = 1;
      });
      console.log(prontas);
      if (prontas.length >= 1) {
        axios
          .post(url + "cozinha", prontas)
          .then((d) => {
            console.log(d);
            this.atualizar();
          })
          .catch((erro) => {
            console.log(erro);
          });
      }
    },
    atualizar: function () {
      document.location.reload();
    },
    voltar: function () {
      rotas.replace("menu");
    },
  },
  mounted: function () {
    axios.get(url + "cozinha").then((resp) => {
      this.pratos = resp.data;
      console.log(resp.data);
    });
  },
};
</script>