<template>
  <div class="home">
    <Cart :products="products" :chosenProducts="chosenProducts"/>
    <div class="home__filters">
  
    <Categories  v-model="chosenCategory" />
    <div>
    <input id="fav" type="checkbox" @click="$event=>showFavorite=!showFavorite">
      <label for="fav" > Показать избранное</label>
  </div>
  <input type="text" v-model="filter" class="input" placeholder="Что ищем?"/>
  </div>
    <div style="width: 100%;" v-if="products.length != 0">
      <Products :chosenProducts="chosenProducts" :favoriteProducts="favoriteProducts" :products="filtredProducts.slice((activePage-1)*limit, (activePage-1)*limit+limit)" class="products" />
      <div class="pagination">
        <button class="pagination__btn" :class="{active:activePage===page}" v-for="page in pagesCount" :key="page" @click="activePage=page">{{page}}</button>
    </div>
    </div>
    <div v-else>
      <h1>Наливаем</h1>
    </div>
  </div>
</template>

<script lang="ts">
import { IProduct } from "@/interfaces/IProduct";
import { defineComponent } from 'vue';
import axios from 'axios';
import Categories from '@/components/Categories.vue';
import Products from '@/components/Products.vue';
import Cart from '@/components/Cart.vue'; 

export default defineComponent({
  components: {
    Products,
    Categories,
    Cart,
  },
  data() {
    return {
      products: [] as IProduct[],
      chosenCategory: "All",
      filter: "",
      favoriteProducts:[] as number[],
      showFavorite:false,
      chosenProducts:new Map<number,number>(),
      activePage:1,
      limit:10
    }
  },
  methods: {
    
    async getProducts():Promise<void> {
      try {
        const response = await axios.get<IProduct[]>("https://fakestoreapi.com/products");
        if (response.status == 200) {
          this.products = response.data;
          this.products.forEach(x=>{
            if(this.favoriteProducts.includes(x.id-1))
              x.favorite=true;
          })
        }
      }
      catch (e:unknown) {
        console.log(e);
      }
    },
  },
  mounted() {
    this.getProducts();
    if (localStorage.getItem('favoriteProducts')) {
      try {
        this.favoriteProducts = JSON.parse(localStorage.getItem('favoriteProducts') as string);
      } catch(e) {
        localStorage.removeItem('favoriteProducts');
      }
    }
    if(document.cookie.includes("chosenProducts=")){
      this.chosenProducts=new Map<number,number>(JSON.parse(document.cookie.split("chosenProducts=")[1]));
      console.log(document.cookie);
    }
  },
  computed:{
    filtredProducts(): IProduct[] {
      return this.products.filter(x => {
        return (x.title.toLowerCase().includes(this.filter.toLowerCase()) ||
          x.description.toLowerCase().includes(this.filter.toLowerCase())) && (x.category==this.chosenCategory || this.chosenCategory=="All") 
          && ((this.showFavorite && x.favorite) || !this.showFavorite)
      });
    },
    pagesCount():number{
      return Math.ceil(this.filtredProducts.length/10);
    }
  }
  });
</script>
<style>
.pagination{
  display: flex;
}
.pagination__btn{
  font-size: 22px;
  width: 30px;
  height: 30px;
  cursor: pointer;
  margin-top: 10px;
  margin-right: 10px;
  border: none;
  border-radius: 50%;
}
.pagination__btn:hover{
  background: #fff
}
.active{
  background: blue;
  color: #fff;
}

.input{
  border-radius: 5px;

}
.cart{
  top:105px;
  bottom: unset !important;
}
</style>