<template>
  <router-link :to="`/addPlayer`">
  <div class="addPlayer"><p>Добавить игрока</p></div>
</router-link>
</template>

<script lang="ts">
import { PropType, defineComponent } from 'vue'

export default defineComponent({
  props: {
    
  },
  components: {
  },
  data(){
    return{}
  }
});
</script>

<style scoped>
.addPlayer{
  border-radius: 10px;
  display: flex;
    height: 35px;
    width: 200px;
    background-color: black;
    color: white;
    text-decoration: none;
    text-align: center;
    justify-content: center;
    flex-direction: column;
}
.addPlayer>p{
  display: inline-block;
  align-items: center;
  padding-top: 50%;
  padding-bottom: 50%;
}
</style>