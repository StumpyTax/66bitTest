<template>
  <div>
    <div v-if="!item.favorite" class="btn-wrapper">
      <AddFav :item="item" :favoriteProducts="favoriteProducts" />
    </div>
    <div class="btn-wrapper" v-else>
      <UnFav :item="item" :favoriteProducts="favoriteProducts" />
    </div>
  </div>
</template>

<script lang="ts">
import UnFav from '@/components/UnFav.vue'
import AddFav from './AddFav.vue'
import { IProduct } from '@/interfaces/IProduct';
import { defineComponent } from 'vue'
import { PropType } from 'vue';


export default defineComponent({
  props: {
    item: { required: true, type: Object as PropType<IProduct> },
    favoriteProducts: { required: true, type: Object as PropType<number[]> },
  },
  methods: {

    saveFav() {
      const parsed = JSON.stringify(this.favoriteProducts);
      localStorage.setItem("favoriteProducts", parsed);
    },
  },
  components: { UnFav, AddFav }
})
</script>

<style scoped>
.product__fav {
  width: 40px;
  height: 50px;
  margin-left: auto;
  margin-right: 0;
  cursor: pointer;
}

.product__fav-add {
  fill: rgb(247, 189, 82);
  stroke: rgb(247, 189, 82);
  transition: fill 0.4s ease-in;
}

.btn-wrapper {
  display: flex;
  align-items: right;
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

@media(max-width: 990px) {
  .product__fav {
    width: 20px;
  }
}
</style>