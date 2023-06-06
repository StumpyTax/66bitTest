<template>
  <div class="cart">
    <div class="cart__resume">
      <h1 class="cart__sum">{{ getSum().toFixed(2) }}</h1>
      <button class="cart__buy btn">Купить</button>
      <div @click='toggle=!toggle' class="cart__icon">
        <CartSvg />
      </div>
    </div>
    <div class="cart__products" :class="{ cart_visible: toggle }">
      <div v-if="chosenProducts.size" class="cart__info">
        <div v-for="prod in getProducts()" :key="prod.id" class="cart__product">
          <div>
            <img v-bind:src="prod.image" class="cart__image">
          </div>
          <div class="cart__text">{{ prod.title }}</div>
          <div>
            <input class="cart__input" min="1" type="number" name="count" :id="'count' + prod.id"
              @input="$event => setCount(prod.id, $event.target.value)" :value="chosenProducts.get(prod.id)">
          </div>
          <div>{{ prod.price }}</div>
          <div>
            <img src="@/assets/cross.svg" @click="removeFromCart(prod)" class="product__btn">
          </div>
        </div>
      </div>
      <div v-else>
        <p class="cart_empty">Корзина пуста</p>
      </div>
    </div>
    
  </div>
</template>

<script lang="ts">
import { IProduct } from '@/interfaces/IProduct';
import { PropType, defineComponent } from 'vue';
import CartSvg from './CartSvg.vue';

export default defineComponent({
    data() {
        return {
            toggle: false
        };
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
                var temp: undefined | number = this.chosenProducts.get(x.id);
                if (temp)
                    res += x.price * temp;
            });
            return res;
        },
        removeFromCart(item: IProduct): void {
            this.chosenProducts.delete(item.id);
            document.cookie = "chosenProducts=" + JSON.stringify(Array.from(this.chosenProducts.entries()));
        },
        setCount(id: number, newCount: number): void {
            if (newCount) {
                this.chosenProducts.set(id, newCount);
            }
            else {
                this.chosenProducts.delete(id);
            }
            document.cookie = "chosenProducts=" + JSON.stringify(Array.from(this.chosenProducts.entries()));
        }
    },
    components: { CartSvg }
});
</script>

<style scoped>
.cart__image {
  max-width: 50px;
}
.cart__info{
  width: 100%;
}
.cart__icon {
  max-width: 50px;
  cursor: pointer;
  width: 100%;
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

.cart_empty {
  font-size: 16px;
}

.cart__buy:hover {
  background: #363535;
}

.cart {
  padding: 10px 20px;
  font-size: 11px;
  top: 105px;
  right: 5px;
  position: fixed;
  background-image: linear-gradient(90deg, rgb(250, 164, 4), rgb(240, 179, 65) 33.3%, rgb(240, 147, 61) 66.6%, rgb(255, 146, 4) 100%);
  border-radius: 16px;
  width: 300px;
  max-height: 600px;
  z-index: 2;
  overflow-y: auto;
}



.product__btn {
  width: 15px;
  cursor: pointer;
  fill: black;
  transition: transform 0.4s ease-in-out;
}

.product__btn:hover {
  transform: rotate(180deg);
}

.cart__products {
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