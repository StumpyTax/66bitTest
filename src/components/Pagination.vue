<template>
    <div class="pagination">
        <button class="pagination__btn" :class="{ active: activePage === page }" v-for="page in pagesCount" :key="page"
          @click="$emit('ChangeActive',page)">{{ page }}</button>
      </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  props:{
    pagesCount:Number,
    activePage:Number,
  }
})
</script>

<style scoped>
.pagination {
  display: flex;
}

.pagination__btn {
  font-size: 22px;
  width: 30px;
  height: 30px;
  cursor: pointer;
  margin-top: 10px;
  margin-right: 10px;
  border: none;
  border-radius: 50%;
}

.pagination__btn:hover {
  background: #fff
}

.active {
  background: blue;
  color: #fff;
}
.active:hover{
  color: #fff;
  background: rgb(4, 4, 175);
}
</style>