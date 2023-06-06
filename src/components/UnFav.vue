<template>
  <svg @click="removeFav(item)" class=" product__fav product__fav-rem" width="77" height="73" viewBox="0 0 77 73"
    fill="none" xmlns="http://www.w3.org/2000/svg">
    <path
      d="M55.8532 0.19397C47.8292 0.19397 40.9292 5.10297 38.0012 12.076C35.0712 5.10297 28.1682 0.19397 20.1402 0.19397C9.4672 0.19397 0.783203 8.87497 0.783203 19.546C0.783203 23.664 2.1132 27.634 4.6632 31.071L21.562 52.1752L22.453 53.2879L36.8302 71.243C37.1152 71.598 37.5452 71.805 38.0012 71.805C38.4572 71.805 38.8892 71.597 39.1732 71.241L72.0362 30.057C72.0672 30.017 72.0982 29.975 72.1262 29.932C74.1492 26.78 75.2192 23.188 75.2192 19.546C75.2196 15.0299 73.6636 10.8703 71.0592 7.57428C70.5608 6.94358 70.024 6.34451 69.4525 5.7806C65.9528 2.32803 61.1475 0.19397 55.8532 0.19397ZM69.6432 28.248L37.9992 67.904L24.6392 51.2201L23.7256 50.0792L7.0382 29.24C4.9082 26.367 3.7822 23.015 3.7822 19.546C3.7822 10.529 11.1202 3.19397 20.1392 3.19397C29.1612 3.19397 36.5012 10.529 36.5012 19.546C36.5012 20.375 37.1722 21.046 38.0012 21.046C38.8302 21.046 39.5012 20.375 39.5012 19.546C39.5012 10.529 46.8362 3.19397 55.8532 3.19397C60.3034 3.19397 64.3447 4.97781 67.2982 7.86752C67.8609 8.41805 68.3841 9.00871 68.8631 9.63482C70.9683 12.3865 72.2202 15.8229 72.2202 19.546C72.2202 22.589 71.3292 25.596 69.6432 28.248Z"
      fill="black" />
    <path
      d="M23.7256 50.0792L24.6392 51.2201L36.5012 40L68.8631 9.63482C68.3841 9.00871 67.8609 8.41805 67.2982 7.86752L38.0012 36.2495L23.7256 50.0792Z"
      fill="black" />
    <path d="M22.453 53.2879L21.562 52.1752L0.783203 72.305H2.64167L10 65.5L18 57.5L22.453 53.2879Z" fill="black" />
    <path d="M69.4525 5.7806C70.024 6.34451 70.5608 6.94358 71.0592 7.57428L77 2L75.2192 0.19397L69.4525 5.7806Z"
      fill="black" />
  </svg>
</template>

<script lang="ts">
import { IProduct } from '@/interfaces/IProduct';
import { PropType } from 'vue';
import { defineComponent } from 'vue'

export default defineComponent({
  props: {
    item: { required: true, type: Object as PropType<IProduct> },
    favoriteProducts: { required: true, type: Object as PropType<number[]> },
  },
  methods: {
    removeFav(item: IProduct) {

      this.favoriteProducts.splice(this.favoriteProducts.findIndex(x => x == item.id), 1);
      item.favorite = false;
      this.saveFav();
    },
    saveFav() {
      const parsed = JSON.stringify(this.favoriteProducts);
      localStorage.setItem('favoriteProducts', parsed);
    },
  }
});
</script>

<style scoped></style>