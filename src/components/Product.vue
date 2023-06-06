<template>
  <div>
    <div class="product-item">
      <div class="product__img">
        <router-link :to="`/product/${item.id}`">
          <img :src="item.image" alt="" class="product__image">
        </router-link>
      </div>
      <div class="product__title"><strong>{{ item.title }}</strong></div>
      <div class="product__price">{{ item.price }}$</div>
      <div class="product__btns">
        <FavButtons :item="item" :favoriteProducts="favoriteProducts" />
        <div>
          <button @click="$emit('addToCart', item)" class="product__btn">В корзину</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { IProduct } from '@/interfaces/IProduct';
import { PropType, defineComponent } from 'vue'
import FavButtons from './FavButtons.vue';

export default defineComponent({
  props: {
    item: { required: true, type: Object as PropType<IProduct> },
    favoriteProducts: { required: true, type: Object as PropType<number[]> },
  },
  components: {
    FavButtons
  }
});
</script>

<style scoped>
.product-item {
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  justify-content: space-between;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  -ms-flex-direction: column;
  flex-direction: column;
  -webkit-box-flex: 0;
  -ms-flex: 0 0 100%;
  height: 100%;
}

.btn-wrapper {
  display: flex;
  align-items: right;
}

.products {
  display: flex;
  flex-wrap: wrap;
  width: 100%;
}


.product__image {
  max-width: 100px;
  width: 100%;
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

@media(max-width: 990px) {
  .product-item {
    max-width: 33.3%;
    flex: 0 0 33.3%
  }

  .product {
    font-size: 10px;
  }

  .product__fav {
    width: 20px;
  }

  .product__btn {
    font-size: 11px;
  }
}

@media(max-width: 578px) {
  .product-item {
    width: 100%;
    max-width: 50%;
    flex: 0 0 50%;
  }
}

@media(max-width: 415px) {
  .product-item {
    width: 100%;
    max-width: 100%;
    flex: 0 0 100%;
  }

}</style>