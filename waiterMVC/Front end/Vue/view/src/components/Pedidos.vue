<template>
  <div>
    <button id="back" @click="voltar">
      <div id="arrow"></div>
      <p id="voltaText">Voltar</p>
    </button>
    <h1>Pedido</h1>

    <input
      class="inputInfos"
      type="text"
      placeholder="Nome do cliente"
      v-model="cliente"
    />
    <input
      class="inputInfos"
      type="number"
      min="1"
      placeholder="Número da mesa"
      v-model="mesa"
    />
    <label class="inputInfos" for="valor"
      >Valor: {{ valorTotal.toFixed(2) }}</label
    >
    <div>
      <table id="customers">
        <tr>
          <th>Nome</th>
          <th>Descrição</th>
          <th>Valor</th>
          <th>Quantidade</th>
        </tr>
        <tr v-for="pratos in menu" :key="pratos.id">
          <td>{{ pratos.nome }}</td>
          <td>{{ pratos.descricao }}</td>
          <td>{{ pratos.valor }}</td>
          <td>
            <input
              class="qtdClass"
              type="number"
              placeholder="Quantidade"
              min="1"
              v-model="pratos.quantidade"
            />
          </td>
        </tr>
      </table>
    </div>

    <div style="height: 50px">
      <input
        class="inputAddItens"
        type="submit"
        placeholder="Adicionar Itens"
        value="Adicionar Itens"
        @click="addNewItens"
      />
    </div>

    <div>
      <table id="customers">
        <tr>
          <th>Nome</th>
          <th>Descrição</th>
          <th>Valor</th>
          <th>Quantidade</th>
        </tr>
        <tr v-for="pratos in pedido" :key="pratos.id">
          <td>{{ pratos.nome }}</td>
          <td>{{ pratos.descricao }}</td>
          <td>{{ pratos.valor }}</td>
          <td>
            <input
              class="qtdClass"
              type="number"
              min="1"
              placeholder="Quantidade"
              step="1"
              v-model="pratos.quantidade"
              @change="valorUpdate"
            />
          </td>
        </tr>
      </table>
    </div>

    <div style="height: 50px">
      <div class="buttonsBox">
        <input
          class="buttons"
          type="submit"
          placeholder="Atualizar Pedido"
          value="Atualizar Pedido"
          v-show="atualizacaoPedido"
        />
        <input
          class="buttons"
          type="submit"
          placeholder="Cancelar"
          value="Cancelar Pedido"
          v-show="atualizacaoPedido"
        />
        <input
          type="submit"
          class="buttons"
          placeholder="Enviar Pedido"
          value="Enviar Pedido"
          @click="enviarPedido"
        />
      </div>
    </div>
  </div>
</template>
<style scoped >
h1 {
  color: white;
  text-align: center;
}
.buttonsBox {
  display: block;
  position: absolute;
  right: 70px;
}
.qtdClass {
  text-align: center;
  border: solid;
  padding: 10px 5px;

  border-radius: 25px;
  background: rgba(85, 54, 54, 0.1);
}
.qtdClass::placeholder {
  color: black;

  font-style: italic;
}
#voltaText {
  display: block;
  margin: 10px;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  font-size: 20px;
  color: white;
}

.buttons {
  border: none;
  padding: 15px 20px;
  border-radius: 25px;
  background: white;
  font-family: "Helvetica";

  margin-left: 10px;
}
#arrow {
  /* Transparent background */
  background-color: transparent;

  /* Edges */
  border-bottom: 10px solid rgb(253, 253, 253);
  border-left: 10px solid rgb(255, 254, 254);
  transform: translateX(25%) rotate(45deg);

  /* Size */
  height: 12px;
  width: 12px;
}
#back {
  align-items: center;
  display: flex;
  justify-content: center;
  padding: 8px;
  background-color: rgba(62, 81, 128, 0.8);
}
.divGeral {
  border: blanchedalmond;
  border-style: solid;
  width: 100%;
  height: 100vh;
}
#cancelarPedido {
  border: none;
  padding: 15px 20px;
  border-radius: 25px;
  background-color: white;
  position: relative;
  left: 70px;
}
.inputAddItens {
  position: absolute;
  right: 70px;
  display: block;
  border: none;
  padding: 15px 20px;
  border-radius: 25px;
  background: white;
  font-family: "Helvetica";
}
.addDiv {
  margin-top: 10px;
}
.inputInfos {
  color: #fff;
  border: none;
  padding: 15px 20px;
  border-radius: 25px;
  background: rgba(255, 255, 255, 0.1);
  position: relative;
  left: 70px;
  margin-left: 10px;
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
::placeholder {
  /* Chrome, Firefox, Opera, Safari 10.1+ */
  color: white;
  opacity: 1; /* Firefox */
}

:-ms-input-placeholder {
  /* Internet Explorer 10-11 */
  color: white;
}

::-ms-input-placeholder {
  /* Microsoft Edge */
  color: white;
}
</style>
<script>
import axios from "axios";
import url from "@/utils";
import rotas from "@/routers";
export default {
  data() {
    return {
      menu: [],
      pedido: [],
      atualizacaoPedido: false,
      valorTotal: 0,
      mesa: null,
      cliente: null,
    };
  },
  props: {
    pedidoAtual: [],
  },
  methods: {
    addNewItens: function () {
      var filtered = this.menu.filter(function (x) {
        return x.quantidade >= 1;
      });
    
      filtered.forEach((a) => {
        a.qtd = parseInt(a.qtd);
        let novo = Object.assign({}, a);
        this.valorTotal += novo.valor * novo.quantidade;
        novo.idMenu = novo.id;
        let temp = this.pedido.find((x) => x.id == novo.id);
        if (temp != null) {
          temp.qtd += parseInt(novo.qtd);
        } else {
          this.pedido.push(novo);
        }

        a.qtd = 0;
      });
    },
    enviarPedido: function () {
      var novoPedido = {
        garcomId: 5,
        fechado: 0,
        pago: 0,
        valor: this.valorTotal,
        mesa: this.mesa,
        cliente: this.cliente,
        Itens: this.pedido,
      };
      if (this.mesa != null && this.cliente != null) {
          axios.post(url + "pedido", novoPedido).then(dados => {
             console.log(dados);
              this.voltar();
          }).catch((erro) => {
          console.log(erro);
        });
       
      }else{
        alert("Não é possível enviar um pedido sem o nome a mesa do cliente.");
      }
    },
    voltar: function () {
      rotas.replace("atendimento");
    },
    valorUpdate: function () {
      this.valorTotal = 0;
      this.pedido.forEach((dados) => {
        this.valorTotal += dados.valor * dados.qtd;
      });
    },
  },
  mounted: function () {
    var context = this;
    console.log(url);
    axios

      .get(url + "menu")
      .then((resp) => {
        context.menu = resp.data;
        console.log(resp.data);
      })
      .catch((erro) => {
        console.log(erro);
      });
  },
};
</script>