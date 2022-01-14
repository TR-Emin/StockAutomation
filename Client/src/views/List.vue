<template>
  <div class="container py-5">
    <h1 class="text-center">Axios Get</h1>
    <div class="row">
      <div class="col-nd-6 offset-md3">
        <div class="card">
          <div class="card-header">Products</div>
          <div class="card-body" style="overflow: auto; height: 600px">
            <ul class="list-group">
              <button @click="Filter(Filter)">Filter</button>
              <input type="text" id="5" name="filterCategoryId" placeholder="FilterCategoryId">
              <input type="text" id="6" name="filterName" placeholder="FilterName">
              <input type="text" id="7" name="filterMinPrice" placeholder="FilterMinPrice">
              <input type="text" id="8" name="filterMaxPrice" placeholder="FilterMaxPrice">
              <input type="text" id="9" name="filterMinStock" placeholder="FilterMinStock">
              <li
                style="overflow: auto; text-align: left"
                v-for="(item, index) in dizi"
                :key="index"
                class="list-group-item"
              >
                Product Id: {{ item.id }} <br />
                Product Category Id: {{ item.categoryId }} <br />
                Product Name: {{ item.productName }} <br />
                Product Description: {{ item.productDescription }} <br />
                Product Price {{ item.productPrice }} <br />
                Product Stock: {{ item.productStock }} <br />
                <buttonSell @click="Sell(item)">Product Sell</buttonSell>
                <button @click="Update(item)">Update</button> <br />
                <input
                  type="text"
                  id="1"
                  name="updatedName"
                  placeholder="New Name"
                />
                <br />
                <input
                  type="text"
                  id="2"
                  name="updatedDescription"
                  placeholder="New Description"
                />
                <br />
                <input
                  type="text"
                  id="3"
                  name="updatedPrice"
                  placeholder="New Price"
                />
                <br />
                <input
                  type="text"
                  id="4"
                  name="updatedStock"
                  placeholder="New Stock"
                />
                <br />                              
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import axios from "axios";
import { defineComponent } from "vue";

class Product {
  Id:string;
  CategoryId: string;
  ProductName: string;
  ProductDescription: string;
  ProductPrice: string;
  ProductStock: string;
  constructor(product: Product) {
    this.Id=product.Id,
    this.CategoryId = product.CategoryId,
    this.ProductName = product.ProductName,
    this.ProductDescription = product.ProductDescription,
    this.ProductPrice = product.ProductPrice,
    this.ProductStock = product.ProductStock;
  }
}

class Filter{
  ProductName?:string;
  CategoryId?:number;
  ProductMinPrice?:number;
  ProductMaxPrice?:number;
  ProductMinStock?:number;

  // constructor(filter:Filter){
  //   this.ProductName=filter.ProductName;
  //   this.CategoryId=filter.CategoryId;
  //   this.ProductMinPrice=filter.ProductMinPrice;
  //   this.ProductMaxPrice=filter.ProductMaxPrice;
  //   this.ProductMinStock=filter.ProductMinStock
  // }

}

export default defineComponent({
// export default{
  name: "List",
  data() {
    return {
      url: "http://localhost:5000/Product/Get",
      urlDelete: "http://localhost:5000/Product/Delete",
      urlUpdate: "http://localhost:5000/Product/Update",
      urlGetFilterByName: "http://localhost:5000/Product/GetFilterByName",
      urlGetFilter: "http://localhost:5000/Product/GetFilter",
      filterName:"",
      dizi:[],
      //dizi: [] as Array<Product>,
    };
  },

  methods: {
    Sell(product: Product) {
      axios.post(this.urlDelete, product);
     
    },

    Update(product: Product) {
    
      if ((<HTMLInputElement>document.getElementById("1")).value != "") {
        product.ProductName = (<HTMLInputElement>document.getElementById("1")).value;
        
      }
       
      if ((<HTMLInputElement>document.getElementById("2")).value != "") {
        product.ProductDescription = (<HTMLInputElement>document.getElementById("2")).value;
        
      }

      if((<HTMLInputElement>document.getElementById("3")).value!=""){
        product.ProductPrice=(<HTMLInputElement>document.getElementById("3")).value

      }

      if((<HTMLInputElement>document.getElementById("4")).value!=""){
        product.ProductStock=(<HTMLInputElement>document.getElementById("4")).value

      }

      axios.post(this.urlUpdate, product);
    },


    Filter(){      
      //this.filterName=(<HTMLInputElement>document.getElementById("5")).value;

//       var axios = require('axios');
// var data = JSON.stringify({
//   "name": "up"
// });

// var config = {
//   method: 'post',
//   url: 'http://localhost:5000/Product/GetFilterByName',
//   headers: { 
//     'Content-Type': 'application/json'
//   },
//   data : data
// };

// axios(config)
// .then(function (response: { data: any; }) {
//   console.log(JSON.stringify(response.data));
// })
// .catch(function (error: any) {
//   console.log(error);
// });

     
       let filter=new Filter();
      const headers = {
        'Content-Type': 'application/json'
      }
      
      // İlk filtre null olursa hepsi null gidiyor, ilk filtre dolu olunca diğerlerinde sıkıntı yok.
      filter.CategoryId=parseInt((<HTMLInputElement>document.getElementById("5")).value);      
      filter.ProductName=(<HTMLInputElement>document.getElementById("6")).value;
      filter.ProductMinPrice=parseInt((<HTMLInputElement>document.getElementById("7")).value);
      filter.ProductMaxPrice=parseInt((<HTMLInputElement>document.getElementById("8")).value);
      filter.ProductMinStock=parseInt((<HTMLInputElement>document.getElementById("9")).value);
      //axios.post(this.urlGetFilter,filter).then(response=>this.dizi=response.data);
      

      axios.post(this.urlGetFilter,JSON.stringify(filter),{headers:headers}).then(response => this.dizi = response.data);

    }

  },

  created() {
    console.log("Sayfa created tarafından render edildi.", this.url);
    axios.get(this.url).then((response) => (this.dizi = response.data));
  },
});
</script>

<style>
buttonSell {
  background-color: darkgray;
  position: absolute;
  right: 80px;
  top: 25px;
  height: 50px;
  border-radius: 2px;
}
/* button {
  background-color:darkgray;
  position: absolute;
  right:80px;
  top:80px;
  height: 50px;  
  border-radius: 2px;
  size: auto;
  
} */

updateBox {
  position: absolute;
  right: 80px;
  top: 70px;
}
</style>