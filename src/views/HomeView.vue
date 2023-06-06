<template>
  <div class="home">
    <Cart :products="products" :chosenProducts="chosenProducts" />
    <div class="home__filters">

      <Categories v-model="chosenCategory" />
      <div>
        <input id="fav" type="checkbox" @click="showFavorite = !showFavorite">
        <label for="fav"> Показать избранное</label>
      </div>
      <input type="text" v-model="filter" class="input" placeholder="Что ищем?" />
    </div>
    <div v-if="products.length != 0">
      <Products :chosenProducts="chosenProducts" :favoriteProducts="favoriteProducts"
        :products="filtredProducts.slice((activePage - 1) * limit, (activePage - 1) * limit + limit)" class="products" />
      <Pagination @ChangeActive="ChangeActiveHandler" :activePage="activePage" :pagesCount="pagesCount"/>

    </div>
    <div v-else class="loader">
      <Loader/>
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
import Pagination from "@/components/Pagination.vue";
import Loader from "@/components/Loader.vue";

export default defineComponent({
  components: {
    Products,
    Categories,
    Cart,
    Pagination,
    Loader
},
  data() {
    return {
      products: [] as IProduct[],
      chosenCategory: "All",
      filter: "",
      favoriteProducts: [] as number[],
      showFavorite: false,
      chosenProducts: new Map<number, number>(),
      activePage: 1,
      limit: 10
    }
  },
  methods: {
    ChangeActiveHandler(newActive:number){
      this.activePage=newActive;
    },
    async getProducts(): Promise<void> {
      try {
        const response = await axios.get<IProduct[]>("https://fakestoreapi.com/products");
        if (response.status == 200) {
          this.products = response.data
          this.products.map(x => {
            if (this.favoriteProducts.includes(x.id))
              x.favorite = true;
          });
        }
      }
      catch (e: unknown) {
        console.log(e);
      }
    },
  },
  mounted() {
    this.getProducts();
    if (localStorage.getItem('favoriteProducts')) {
      try {
        this.favoriteProducts = JSON.parse(localStorage.getItem('favoriteProducts') as string);
      } catch (e) {
        localStorage.removeItem('favoriteProducts');
      }
    }
    if (document.cookie.includes("chosenProducts=")) {
      this.chosenProducts = new Map<number, number>(JSON.parse(document.cookie.split("chosenProducts=")[1]));
      console.log(document.cookie);
    }
  },
  computed: {
    filtredProducts(): IProduct[] {
      return this.products.filter(x => {
        this.activePage=1;
        return (x.title.toLowerCase().includes(this.filter.toLowerCase()) ||
          x.description.toLowerCase().includes(this.filter.toLowerCase())) && (x.category == this.chosenCategory || this.chosenCategory == "All")
          && ((this.showFavorite && x.favorite) || !this.showFavorite)
      });
    },
    pagesCount(): number {
      return Math.ceil(this.filtredProducts.length / 10);
    }
  }
});
</script>
<style>


.input {
  border-radius: 5px;

}
.loader{
  margin: 0 auto;
}

</style>