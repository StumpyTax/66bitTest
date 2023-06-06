<template>
  <div class="products">
    <div v-for="item in products" :key="item.id" class="products-item">
      <Product class="product" :item="item" :favoriteProducts="favoriteProducts" @addToCart="addToCart"/>
    </div>
  </div>
</template>

<script lang="ts">
import { IProduct } from '@/interfaces/IProduct';
import { PropType, defineComponent } from 'vue';
import Product from './Product.vue';

export default defineComponent({
  components:{
    Product
},
  props: {
    products: { required: true, type: Object as PropType<IProduct[]> },
    favoriteProducts: { required: true, type: Object as PropType<number[]> },
    chosenProducts: { required: true, type: Object as PropType<Map<number, number>> }
  },
  
  methods: {
    addToCart(item: IProduct) {
      var temp: number | undefined = this.chosenProducts.get(item.id)
      if (temp) {
        this.chosenProducts.set(item.id, temp + 1);
      }
      else {
        this.chosenProducts.set(item.id, 1);
      }
      this.setCookies();
    },

    setCookies():void {
      document.cookie = 'chosenProducts=' + JSON.stringify(Array.from(this.chosenProducts.entries()));
    }
  },
});
</script>

<style scoped>
.btn-wrapper{
  display: flex;
  align-items: right;
}
.products {
  display: flex;
  flex-wrap: wrap;
  width: 100%;
}

.product {
  border: 1px solid blue;
  position: relative;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  justify-content: space-between;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  -ms-flex-direction: column;
  flex-direction: column;
  background: #fff;
  border-radius: .3125rem;
  -webkit-box-flex: 0;
  -ms-flex: 0 0 100%;
  flex: 0 0 100%;
  max-width: 100%;
  height: 100%;
  padding: 20px;
}

.products-item {
  padding-left: .9375rem;
  padding-right: .9375rem;
  margin-top: 1.875rem;
  -webkit-box-flex: 0;
  -ms-flex: 0 0 16.66667%;
  flex: 0 0 16.66667%;
  max-width: 16.66667%;
  -webkit-box-flex: 0;
  -ms-flex: 0 0 20%;
  flex: 0 0 20%;
  max-width: 20%;

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
.product__btn:hover{
  background: #3d3c3c;
}
@media(max-width: 990px){
  .products-item{
    max-width: 33.3%;
    flex:0 0 33.3%
  }
  .product{
    font-size: 10px;
  }
  .product__fav{
    width: 20px;
  }
  .product__btn{
    font-size: 11px;
  } 
}
@media(max-width: 578px){
  .products-item{
    width: 100%;
    max-width: 50%;
    flex: 0 0 50%;
  }
  .product__btn{
    font-size: 11px;
  } 
}
  @media(max-width: 415px){
  .products-item{
    width: 100%;
    max-width: 100%;
    flex: 0 0 100%;
  }

}
</style>