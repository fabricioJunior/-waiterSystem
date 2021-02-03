<template>
  <div class="login-wrap">
    <div class="login-html">
      <input id="tab-1" type="radio" name="tab" class="sign-in" checked /><label
        for="tab-1"
        class="tab"
        >Entrar</label
      >
      <input id="tab-2" type="radio" name="tab" class="sign-up" /><label
        for="tab-2"
        class="tab"
        >Cadastro</label
      >
      <div class="login-form">
        <div class="sign-in-htm">
          <div class="group">
            <label for="user" class="label">Usuário</label>
            <input id="user" type="text" class="input" v-model="usuarioLogin" />
          </div>
          <div class="group">
            <label for="pass" class="label">Senha</label>
            <input
              id="pass"
              type="password"
              class="input"
              data-type="password"
              v-model="senhaLogin"
            />
          </div>

          <div class="group">
            <input type="submit" class="button" value="Entrar" @click="login" />
          </div>
          <div class="hr"></div>
        </div>
        <div class="sign-up-htm">
          <div class="group">
            <label for="user" class="label">Seu nome</label>
            <input
              id="user"
              type="text"
              class="input"
              v-model="usuarioCadastro"
            />
          </div>
          <div class="group">
            <label for="pass" class="label">Senha</label>
            <input
              id="pass"
              type="password"
              class="input"
              v-model="senhaCadastro"
              data-type="password"
            />
          </div>
          <div class="group">
            <label for="pass" class="label">Repita a senha</label>
            <input
              id="pass"
              type="password"
              class="input"
              v-model="repitaSenha"
              data-type="password"
            />
            <label
              for="pass"
              id="confereSenha"
              v-show="repitaSenha != senhaCadastro"
            >
              A confirmação de senha não confere
            </label>
          </div>
          <div class="group">
            <label for="pass" class="label">Email</label>
            <input
              id="pass"
              type="text"
              v-model="emailCadastro"
              class="input"
            />
          </div>
          <div class="group">
            <input
              type="submit"
              @click="cadastra"
              class="button"
              value="Cadastrar"
            />
          </div>
          <div class="hr"></div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import axios from "axios";
import Vue from 'vue';
import rotas from '@/routers'
import url from '@/utils'
import usuario from '@/User/user'
export default {
  data() {
    return {
      usuarioLogin: "",
      senhaLogin: "",
      usuarioCadastro: "",
      senhaCadastro: "",
      repitaSenha: "",
      emailCadastro: "",
      
    };
  },
  methods: {
    cadastra: function () {
      console.log("Clickou");
      if (this.senhaCadastro == this.repitaSenha) {
        console.log({
          id: -1,
          nome: this.usuarioCadastro,
          senhaCadastro: this.senhaCadastro,
          cpf: null,
          emailCadastro: this.emailCadastro,
        });
        axios
          .post("https://localhost:44396/api/garcom", {
            id: -1,
            nome: this.usuarioCadastro,
            senha: this.senhaCadastro,
            cpf: null,
            login: this.emailCadastro,
          })
          .catch((erro) => {
            alert("O correu um erro, por favor tente mais tarde!");
            console.log(erro);
          });
      }
    },
    login: function () {
///    var context = this;
      console.log(url + "login");
      axios
        .post(url + "login",[this.senhaLogin,this.usuarioLogin])
        .then((resp) => {
         // console.log(resp.data);
           usuario.data = resp.data;
           rotas.replace('menu');
           
           console.log(Vue.user);
        })
        .catch((erro) => {
          console.log(erro);
        });
    },
  },
};
</script>


<style scoped>
body {
  margin: 0;
  color: #6a6f8c;
  background: #c8c8c8;
  font: 600 16px/18px "Open Sans", sans-serif;
}
*,
:after,
:before {
  box-sizing: border-box;
}
.clearfix:after,
.clearfix:before {
  content: "";
  display: table;
}
.clearfix:after {
  clear: both;
  display: block;
}
a {
  color: inherit;
  text-decoration: none;
}

.login-wrap {
  width: 100%;
  margin: auto;
  max-width: 525px;
  min-height: 670px;
  position: relative;
  background: url(https://st.depositphotos.com/1006214/1461/i/950/depositphotos_14616401-stock-photo-waiter-with-silver-tray.jpg)
    no-repeat center;
  box-shadow: 0 12px 15px 0 rgba(0, 0, 0, 0.24),
    0 17px 50px 0 rgba(0, 0, 0, 0.19);
}
#confereSenha {
  font: 600 16px/18px "Open Sans", sans-serif;
  color: red;
}
.login-html {
  width: 100%;
  height: 100%;
  position: absolute;
  padding: 90px 70px 50px 70px;
  background: rgba(41, 59, 104, 0.9);
}
.login-html .sign-in-htm,
.login-html .sign-up-htm {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  transform: rotateY(180deg);
  backface-visibility: hidden;
  transition: all 0.4s linear;
}
.login-html .sign-in,
.login-html .sign-up,
.login-form .group .check {
  display: none;
}
.login-html .tab,
.login-form .group .label,
.login-form .group .button {
  text-transform: uppercase;
}
.login-html .tab {
  font-size: 22px;
  margin-right: 15px;
  padding-bottom: 5px;
  margin: 0 15px 10px 0;
  display: inline-block;
  border-bottom: 2px solid transparent;
}
.login-html .sign-in:checked + .tab,
.login-html .sign-up:checked + .tab {
  color: #fff;
  border-color: #1161ee;
}
.login-form {
  min-height: 345px;
  position: relative;
  perspective: 1000px;
  transform-style: preserve-3d;
}
.login-form .group {
  margin-bottom: 15px;
}
.login-form .group .label,
.login-form .group .input,
.login-form .group .button {
  width: 100%;
  color: #fff;
  display: block;
}
.login-form .group .input,
.login-form .group .button {
  border: none;
  padding: 15px 20px;
  border-radius: 25px;
  background: rgba(255, 255, 255, 0.1);
}
.button {
  transition: 0.5s;
}
.button:hover {
  background-color: white;
  color: black;
}

.login-form .group input[data-type="password"] {
  text-security: circle;
  -webkit-text-security: circle;
}
.login-form .group .label {
  color: #aaa;
  font-size: 12px;
}
.login-form .group .button {
  background: #1161ee;
}
.login-form .group label .icon {
  width: 15px;
  height: 15px;
  border-radius: 2px;
  position: relative;
  display: inline-block;
  background: rgba(255, 255, 255, 0.1);
}
.login-form .group label .icon:before,
.login-form .group label .icon:after {
  content: "";
  width: 10px;
  height: 2px;
  background: #fff;
  position: absolute;
  transition: all 0.2s ease-in-out 0s;
}
.login-form .group label .icon:before {
  left: 3px;
  width: 5px;
  bottom: 6px;
  transform: scale(0) rotate(0);
}
.login-form .group label .icon:after {
  top: 6px;
  right: 0;
  transform: scale(0) rotate(0);
}
.login-form .group .check:checked + label {
  color: #fff;
}
.login-form .group .check:checked + label .icon {
  background: #1161ee;
}
.login-form .group .check:checked + label .icon:before {
  transform: scale(1) rotate(45deg);
}
.login-form .group .check:checked + label .icon:after {
  transform: scale(1) rotate(-45deg);
}
.login-html
  .sign-in:checked
  + .tab
  + .sign-up
  + .tab
  + .login-form
  .sign-in-htm {
  transform: rotate(0);
}
.login-html .sign-up:checked + .tab + .login-form .sign-up-htm {
  transform: rotate(0);
}

.hr {
  height: 2px;
  margin: 60px 0 50px 0;
  background: rgba(255, 255, 255, 0.2);
}
.foot-lnk {
  text-align: center;
}
</style>
