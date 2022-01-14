<template>
  <div>
    <h5>Registration Page</h5>
    <form
      v-on:submit.prevent="kaydet(form)"
      name="RegistrationForm"
      method="post"
    >
      <input v-model="form.categoryId" type="text" placeholder="CategoriId" />
      <input v-model="form.productName" type="text" placeholder="ProductName" />
      <br />
      <input
        v-model="form.productDescription"
        type="text"
        placeholder="ProductDescription"
      />
      <input
        v-model="form.productPrice"
        type="text"
        placeholder="ProductPrice"
      />
      <br />
      <input
        v-model="form.productStock"
        type="text"
        placeholder="ProductStock"
      />
      <br />
      <button>Kaydet</button>
    </form>
  </div>
</template>

<script lang="ts">
import axios from "axios";
import VueRouter from "vue-router";
import { Component, Vue } from "vue-property-decorator";
import Router from "vue-router";

export default {
  name: "SavePage",

  data() {
    return {
      form: {
        categoryId: "",
        productName: "",
        productDescription: "",
        productPrice: "",
        productStock: "",
      },
    };
  },

  methods: {
    kaydet(form1: FormData): void {
      axios.post("http://localhost:5000/Product/Add", form1);

      //   this.$router.push("/listele")
      //   .then(
      //  //used Arrow function here
      //  (success)=> {
      //     console.log(success);
      //   this.$router.push("/listele")
      //  })
      //   .catch((err)=> {
      //     console.log(err);
      //   this.$router.push("/listele")
      //  })

      //   this.$router.push({name:"/listle"})
      //   .then(
      //  (success)=> {
      //     console.log(success);
      //     this.$router.push({name:"/listle"})
      //  })
      //   .catch((err)=> {
      //     console.log(err);
      //     this.$router.push({name:"/listle"})
      //  })
    },
  },
};
</script>

