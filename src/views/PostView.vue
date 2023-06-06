<template>
  <div v-if="post.id!= -1" class="post">
    <Cart :products="products" :chosenProducts="chosenProducts" />
    <div>
      <img class="post__img" :src="post.image">
    </div>
    <div class="post__wrapper">
      <div class="post__text">
        <div class="post__title">
          {{ post.title }}
        </div>
        <div class="post__desc">
          <p>{{ post.description }}</p>
        </div>
        <div class="post__fav">
          <FavButtons :item="post" :favoriteProducts="favoriteProducts" />
        </div>
        <div class="post__price">
          <p>{{ post.price }}$</p>
          <button @click="addToCart(post)" class="post__btn">В корзину</button>
        </div>
      </div>
    </div>
  </div>
  <div v-else class="loader">
    <Loader/>
  </div>
</template>

<script lang="ts">
import { IProduct } from "@/interfaces/IProduct";
import axios from "axios";
import Cart from "@/components/Cart.vue";
import { defineComponent } from "vue";
import FavButtons from "@/components/FavButtons.vue";
import Loader from "@/components/Loader.vue";

export default defineComponent(
  {
    components: {
      Cart,
      FavButtons,
      Loader
    },
    data() {
      return {
        favoriteProducts: [] as number[],
        chosenProducts: new Map<number, number>(),
        post: { id: -1 } as IProduct,
        products: [] as IProduct[],
      }
    },
    methods: {
      async getProducts(): Promise<void> {
        try {
          const response = await axios.get<IProduct[]>("https://fakestoreapi.com/products");
          if (response.status == 200) {
            this.products = response.data;
            if (this.favoriteProducts.includes(this.post.id)) {
              this.post.favorite = true;
            }
          }
        }
        catch (e: unknown) {
          console.log(e);
        }
      },
      addToCart(item: IProduct): void {
        var temp: number | undefined = this.chosenProducts.get(item.id)
        if (typeof temp != 'undefined') {
          this.chosenProducts.set(item.id, temp + 1);
        }
        else {
          this.chosenProducts.set(item.id, 1);
        }
        this.setCookies();
      },
      saveFav(): void {
        const parsed = JSON.stringify(this.favoriteProducts);
        localStorage.setItem('favoriteProducts', parsed);
      },

      setCookies(): void {
        document.cookie = 'chosenProducts=' + JSON.stringify(Array.from(this.chosenProducts.entries()));
      },
      addFavorite(item: IProduct): void {
        item.favorite = true;
        this.favoriteProducts.push(item.id);
        this.saveFav();
      },
      removeFav(item: IProduct): void {

        this.favoriteProducts.splice(this.favoriteProducts.findIndex(x => x == item.id), 1);
        item.favorite = false;
        this.saveFav();
      },
    },
    async mounted() {
      this.getProducts();
      if (localStorage.getItem('favoriteProducts')) {
        try {
          this.favoriteProducts = JSON.parse(localStorage.getItem('favoriteProducts') as string);
        } catch (e) {
          localStorage.removeItem('favoriteProducts');
        }
      }
      try {
        const response = await axios.get<IProduct>(`https://fakestoreapi.com/products/${this.$route.params.id}`);
        if (response.status == 200) {
          this.post = response.data;
        }
        if (document.cookie.includes("chosenProducts=")) {
          this.chosenProducts = new Map<number, number>(JSON.parse(document.cookie.split("chosenProducts=")[1]));
        }
      }
      catch (e) {
        console.log(e);
      }
    }
  });
</script>

<style scoped>
.post {
  display: flex;
}
.loader{
  margin: 0 auto;
  width: fit-content;
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

.post__wrapper {
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

.post__btn:hover {
  background: #3d3c3c;
}

.post__desc {
  padding: 0 10px;
}

.post__price {
  display: flex;
  align-items: center;
}

.post__price>p {
  margin-right: 10px;
}

.post__title {
  font-weight: 800;
}

.product__fav-add {
  fill: rgb(247, 189, 82);
  stroke: rgb(247, 189, 82);
  transition: fill 0.4s ease-in;
}

@media (max-width:490px) {
  .post__img {
    max-width: 300px;
    width: 100%;
  }

  .post {
    flex-direction: column;
    height: 100%;
  }

  .post__title {
    font-size: 18px;
  }

  .post__text {
    align-items: space-around;
    font-size: 16px;
  }

  .post__desc>p {
    height: 100%;
  }

  .post__desc {
    height: 100%;
  }

  .psot__price {}

  .product__fav {
    width: 40px;
    height: 50px;
    margin-left: auto;
    margin-right: 0;
    cursor: pointer;
  }

  .product__fav-add:hover {
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

  .product__btn:hover {
    background: #3d3c3c;
  }

  .cart {
    top: 105px;
    bottom: unset;
  }
}
</style>