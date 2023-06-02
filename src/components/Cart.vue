<template>
  <div class="cart">
    <div class="cart__products" :class="{cart_visible:toggle}">
      <div style="width: 100%;" v-if="chosenProducts!=undefined">
        <div v-for="prod in getProducts()" :key="prod.id" class="cart__product">
          <div>
            <img v-bind:src="prod.image" class="cart__image">
          </div>
          <div class="cart__text">{{ prod.title }}</div>
          <div>
            <input class="cart__input" min="0" type="number" name="count" :id="'count' + prod.id"
              @input="$event => setCount(prod.id, $event.target.value)" :value="chosenProducts.get(prod.id)">
          </div>
          <div>{{ prod.price }}</div>
          <div>
            <img src="@/assets/cross.svg" @click="removeFromCart(prod)" class="product__btn" >
          </div>
        </div>
      </div>
      <div v-else>
        <p class="cart_empty">Корзина пуста</p>
      </div>
    </div>
    <div class="cart__resume">
      <h1 class="cart__sum">{{ getSum().toFixed(2) }}</h1>

      <button class="cart__buy btn">Купить</button>

      <svg  @click="toggle=!toggle" class="cart__icon" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg"
        xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 100.353 100.353"
        style="enable-background:new 0 0 100.353 100.353;" xml:space="preserve">
        <path d="M94.224,18.366c-0.284-0.332-0.7-0.523-1.138-0.523H22.308l-2.886-9.672C19.231,7.535,18.647,7.1,17.984,7.1H6.915
  	c-0.829,0-1.5,0.671-1.5,1.5s0.671,1.5,1.5,1.5h9.951l18.234,61.104c0.002,0.007,0.008,0.013,0.01,0.02l2.265,7.704
  	c-1.43,1.421-2.316,3.388-2.316,5.557c0,4.33,3.521,7.853,7.848,7.853c4.188,0,7.609-3.308,7.82-7.451h19.659
  	c-0.001,0.055-0.008,0.109-0.008,0.165c0,4.326,3.519,7.846,7.844,7.846s7.845-3.52,7.845-7.846s-3.52-7.846-7.845-7.846
  	c-3.199,0-5.952,1.928-7.171,4.681H50.299c-0.384-1.095-1.003-2.102-1.848-2.947c-1.481-1.481-3.449-2.298-5.541-2.298
  	c-0.001,0-0.002,0-0.002,0c-1.029,0-2.01,0.204-2.911,0.566l-1.45-4.933h46.673c0.741,0,1.371-0.541,1.482-1.273l7.867-51.433
  	C94.635,19.137,94.509,18.698,94.224,18.366z M78.222,80.207c2.671,0,4.845,2.174,4.845,4.846s-2.174,4.846-4.845,4.846
  	s-4.844-2.174-4.844-4.846S75.551,80.207,78.222,80.207z M42.908,79.643c0,0,0.001,0,0.001,0c1.291,0,2.505,0.504,3.419,1.419
  	c0.915,0.915,1.418,2.132,1.418,3.425c0,2.676-2.171,4.853-4.84,4.853c-2.673,0-4.848-2.177-4.848-4.853
  	C38.059,81.816,40.234,79.643,42.908,79.643z M83.931,69.276H37.664l-2.836-9.648c-0.036-0.122-0.09-0.233-0.152-0.338
  	L23.203,20.843h68.136L83.931,69.276z" />
      </svg>
    </div>
  </div>
</template>

<script lang="ts">
import { IProduct } from '@/interfaces/IProduct';
import { PropType, defineComponent } from 'vue';

export default defineComponent({
  data() {
    return {
      toggle: false
    }
  },
  props: {
    chosenProducts: { required: true, type: Object as PropType<Map<number, number>> },
    products: { required: true, type: Object as PropType<IProduct[]> }
  },
  methods: {
    getProducts(): IProduct[] {
      return this.products.filter(x => this.chosenProducts.has(x.id));
    },
    getSum(): number {
      var res: number = 0;
      this.getProducts().forEach(x => {
        var temp:undefined|number=this.chosenProducts.get(x.id); 
        if(temp!=undefined)
          res += x.price*temp; 
      });
      return res;
    },
    removeFromCart(item: IProduct):void{
      this.chosenProducts.delete(item.id);
      document.cookie = 'chosenProducts=' + JSON.stringify(Array.from(this.chosenProducts.entries()));
    },
    setCount(id: number, newCount: number):void {
      if (newCount > 0) {
        this.chosenProducts.set(id, newCount);
      }
      else {
        this.chosenProducts.delete(id);
      }
      document.cookie = 'chosenProducts=' + JSON.stringify(Array.from(this.chosenProducts.entries()));
    }
  },
});
</script>

<style scoped>
.cart__image {
  max-width: 50px;
}

.cart__resume {
  display: flex;
  justify-content: space-between;
}

.cart__text {
  max-width: 70px;
}

.btn {
  display: inline-block;
}

.cart__buy {
  cursor: pointer;
  display: inline-block;
  height: 40px;
  width: 100px;
  border: none;
  border-radius: 15px;
  color: #fff;
  background: #000;
  transition: background 0.4s ease-in;
}
.cart_empty{
  font-size: 16px;
}
.cart__buy:hover{
  background: #363535;
}
.cart {
  padding: 10px 20px;
  font-size: 11px;
  right: 10px;
  bottom: 10px;
  position: fixed;
  background-image: linear-gradient(90deg, rgb(250, 164, 4), rgb(240, 179, 65) 33.3%, rgb(240, 147, 61) 66.6%, rgb(255, 146, 4) 100%);
  border-radius: 16px;
  width: 300px;
  max-height: 600px;
  z-index: 2;
}

.cart__icon {
  max-width: 50px;
  cursor: pointer;
}

.product__btn{
  width: 15px;
  cursor: pointer;
  fill: black;
  transition: transform 0.4s ease-in-out;
}
.product__btn:hover{
  transform: rotate(180deg);
}
.cart__products{
  display: none;
  width: 100%;
  height: 0;
}
.cart__product {
  padding: 5px;
  display: flex;
  align-items: center;
  width: 100%;
  margin-bottom: 10px;
  justify-content: space-between;
  background: #dfdddd;
  border-top: 2px solid rgb(146, 145, 145);
  border-bottom: 2px solid rgb(146, 145, 145);
}

.cart_visible {
  display: flex;
  max-height: 400px;
  height: 100%;
  overflow-y: scroll;
}

.cart__input {
  width: 40px;
}
</style>