<template>
  <div v-if="post.id!=-1" class="post">
    <Cart :products="products" :chosenProducts="chosenProducts"/>
    <div>
      <img class="post__img" :src="post.image">
    </div>
    <div class="post__wrapper">
    <div class="post__text">
      <div class="post__title">
      {{post.title}}
    </div>
    <div class="post__desc">
      <p>{{post.description}}</p>
    </div>
    <div class="post__fav">
      <div v-if="!post.favorite"  class="btn-wrapper">
            <svg @click="addFavorite(post)" class="product__fav product__fav-add" width="76" height="72" viewBox="0 0 76 72" fill="none" xmlns="http://www.w3.org/2000/svg">
<path d="M55.8532 0.19397C47.8292 0.19397 40.9292 5.10297 38.0012 12.076C35.0712 5.10297 28.1682 0.19397 20.1402 0.19397C9.4672 0.19397 0.783203 8.87497 0.783203 19.546C0.783203 23.664 2.1132 27.634 4.6632 31.071L21.562 52.1752L22.453 53.2879L36.8302 71.243C37.1152 71.598 37.5452 71.805 38.0012 71.805C38.4572 71.805 38.8892 71.597 39.1732 71.241L72.0362 30.057C72.0672 30.017 72.0982 29.975 72.1262 29.932C74.1492 26.78 75.2192 23.188 75.2192 19.546C75.2196 15.0299 73.6636 10.8703 71.0592 7.57428C70.5608 6.94358 70.024 6.34451 69.4525 5.7806C65.9528 2.32803 61.1475 0.19397 55.8532 0.19397ZM69.6432 28.248L37.9992 67.904L24.6392 51.2201L23.7256 50.0792L7.0382 29.24C4.9082 26.367 3.7822 23.015 3.7822 19.546C3.7822 10.529 11.1202 3.19397 20.1392 3.19397C29.1612 3.19397 36.5012 10.529 36.5012 19.546C36.5012 20.375 37.1722 21.046 38.0012 21.046C38.8302 21.046 39.5012 20.375 39.5012 19.546C39.5012 10.529 46.8362 3.19397 55.8532 3.19397C60.3034 3.19397 64.3447 4.97781 67.2982 7.86752C67.8609 8.41805 68.3841 9.00871 68.8631 9.63482C70.9683 12.3865 72.2202 15.8229 72.2202 19.546C72.2202 22.589 71.3292 25.596 69.6432 28.248Z" />
<path d="M37.9992 67.904L69.6432 28.248C71.3292 25.596 72.2202 22.589 72.2202 19.546C72.2202 15.8229 70.9683 12.3865 68.8631 9.63482C68.3841 9.00871 67.8609 8.41805 67.2982 7.86752C64.3447 4.97781 60.3034 3.19397 55.8532 3.19397C46.8362 3.19397 39.5012 10.529 39.5012 19.546C39.5012 20.375 38.8302 21.046 38.0012 21.046C37.1722 21.046 36.5012 20.375 36.5012 19.546C36.5012 10.529 29.1612 3.19397 20.1392 3.19397C11.1202 3.19397 3.7822 10.529 3.7822 19.546C3.7822 23.015 4.9082 26.367 7.0382 29.24L23.7256 50.0792L24.6392 51.2201L37.9992 67.904Z" />
</svg>
          </div>
          <div class="btn-wrapper" v-else>
            <svg @click="removeFav(post)" class=" product__fav product__fav-rem" width="77" height="73"
              viewBox="0 0 77 73" fill="none" xmlns="http://www.w3.org/2000/svg">
              <path
                d="M55.8532 0.19397C47.8292 0.19397 40.9292 5.10297 38.0012 12.076C35.0712 5.10297 28.1682 0.19397 20.1402 0.19397C9.4672 0.19397 0.783203 8.87497 0.783203 19.546C0.783203 23.664 2.1132 27.634 4.6632 31.071L21.562 52.1752L22.453 53.2879L36.8302 71.243C37.1152 71.598 37.5452 71.805 38.0012 71.805C38.4572 71.805 38.8892 71.597 39.1732 71.241L72.0362 30.057C72.0672 30.017 72.0982 29.975 72.1262 29.932C74.1492 26.78 75.2192 23.188 75.2192 19.546C75.2196 15.0299 73.6636 10.8703 71.0592 7.57428C70.5608 6.94358 70.024 6.34451 69.4525 5.7806C65.9528 2.32803 61.1475 0.19397 55.8532 0.19397ZM69.6432 28.248L37.9992 67.904L24.6392 51.2201L23.7256 50.0792L7.0382 29.24C4.9082 26.367 3.7822 23.015 3.7822 19.546C3.7822 10.529 11.1202 3.19397 20.1392 3.19397C29.1612 3.19397 36.5012 10.529 36.5012 19.546C36.5012 20.375 37.1722 21.046 38.0012 21.046C38.8302 21.046 39.5012 20.375 39.5012 19.546C39.5012 10.529 46.8362 3.19397 55.8532 3.19397C60.3034 3.19397 64.3447 4.97781 67.2982 7.86752C67.8609 8.41805 68.3841 9.00871 68.8631 9.63482C70.9683 12.3865 72.2202 15.8229 72.2202 19.546C72.2202 22.589 71.3292 25.596 69.6432 28.248Z"
                fill="black" />
              <path
                d="M23.7256 50.0792L24.6392 51.2201L36.5012 40L68.8631 9.63482C68.3841 9.00871 67.8609 8.41805 67.2982 7.86752L38.0012 36.2495L23.7256 50.0792Z"
                fill="black" />
              <path d="M22.453 53.2879L21.562 52.1752L0.783203 72.305H2.64167L10 65.5L18 57.5L22.453 53.2879Z"
                fill="black" />
              <path
                d="M69.4525 5.7806C70.024 6.34451 70.5608 6.94358 71.0592 7.57428L77 2L75.2192 0.19397L69.4525 5.7806Z"
                fill="black" />
            </svg>
          </div>
    </div>
    <div class="post__price">
      <p>{{ post.price }}$</p>
      <button @click="addToCart(post)" class="post__btn">В корзину</button>
    </div>
  </div>
  </div>
  </div>
  <div v-else>
    Наливаем
  </div>
</template>

<script lang="ts">
import { IProduct } from "@/interfaces/IProduct";
import axios from "axios";
import Cart from "@/components/Cart.vue";
import { defineComponent } from "vue";

  export default defineComponent(
  {
    components:{
      Cart,
    },
  data(){
    return{
      favoriteProducts:[] as number[],
      chosenProducts:new Map<number,number>(),
      post:{} as IProduct,
      products:[] as IProduct[],
    }
  },
  methods:{
    async getProducts() {
      try {
        const response = await axios.get<IProduct[]>("https://fakestoreapi.com/products");
        if (response.status == 200) {
          this.products = response.data;
          if(this.favoriteProducts.includes(this.post.id)){
            this.post.favorite=true;
          }
        }
      }
      catch (e:unknown) {
        console.log(e);
      }
    },
    addToCart(item: IProduct) {
      var temp: number | undefined = this.chosenProducts.get(item.id)
      if (typeof temp != 'undefined') {
        this.chosenProducts.set(item.id, temp + 1);
      }
      else {
        this.chosenProducts.set(item.id, 1);
      }
      this.setCookies();
    },
    saveFav() {
      const parsed = JSON.stringify(this.favoriteProducts);
      localStorage.setItem('favoriteProducts', parsed);
    },

    setCookies() {
      document.cookie = 'chosenProducts=' + JSON.stringify(Array.from(this.chosenProducts.entries()));
      console.log(document.cookie)
    },
    addFavorite(item: IProduct) {
      item.favorite = true;
      this.favoriteProducts.push(item.id);
      this.saveFav();
    },
    removeFav(item: IProduct) {

      this.favoriteProducts.splice(this.favoriteProducts.findIndex(x => x == item.id), 1);
      item.favorite = false;
      this.saveFav();
    },
  },
  async mounted(){
    this.getProducts();
    if (localStorage.getItem('favoriteProducts')) {
      try {
        this.favoriteProducts = JSON.parse(localStorage.getItem('favoriteProducts') as string);
      } catch(e) {
        localStorage.removeItem('favoriteProducts');
      }
    }
    try{
      const response=await axios.get<IProduct>(`https://fakestoreapi.com/products/${this.$route.params.id}`);
      if(response.status==200){
        this.post=response.data;
      }
      if(document.cookie.includes("chosenProducts=")){
        this.chosenProducts=new Map<number,number>(JSON.parse(document.cookie.split("chosenProducts=")[1]));
      }
    }
    catch(e){
      console.log(e);
    } 
  } 
  });
</script>

<style scoped>
.post {
  display: flex;
}
.post__img {
  max-width: 500px;
  width: 100%;
}
.post__text {
  max-height: 50%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
}
.post__wrapper{
  display: flex;
  align-items: center;
}
.post__btn {
  cursor: pointer;
  
  color: #fff;
  height: 30px;
  width: 100%;
  background: #0a0808;
  border: none;
  border-radius: 6px;
  transition: background 0.4s ease-in;
}
.post__btn:hover{
  background: #3d3c3c;
}
.post__desc {
  padding: 0 10px;
}
.post__price {
  display: flex;
  align-items: center;
}
.post__price>p{
  margin-right: 10px;
}
.post__title {
  font-weight: 800;
}
@media (max-width:490px) {
.post__img {
  max-width: 300px;
  width: 100%;
}
  .post{
    flex-direction: column;
    height: 100%;
  }
  .post__title{
    font-size: 18px;
  }
  .post__text{
    align-items: space-around;
    font-size: 16px;
  }
  .post__desc>p{
    height: 100%;
  }
  .post__desc{
    height: 100%;
  }
  .psot__price{

  }
  .product__fav {
  width: 40px;
  height: 50px;
  margin-left: auto;
  margin-right: 0;
  cursor: pointer;
}
.product__fav-add{
  fill: rgb(247, 189, 82);
  stroke: rgb(247, 189, 82);
  transition: fill 0.4s ease-in;

  
}
.product__fav-add:hover{
  fill: rgb(255, 142, 50);
  stroke: rgb(255, 142, 50);
}
.product__btn {
  cursor: pointer;
  margin-top: auto;
  margin-bottom: 0;
  color: #fff;
  height: 30px;
  width: 100%;
  background: #0a0808;
  border: none;
  border-radius: 6px;
  transition: background 0.4s ease-in;
}
.product__btn:hover{
  background: #3d3c3c;
}
  .cart{
    top:105px;
    bottom: unset;
  }
}
</style>