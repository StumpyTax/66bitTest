<template>
  <div class="categories" d>
    <div v-for="(cat,index) in categories" :key="index"  class="category">
      <input v-bind:id="'category'+index"  name="category"  
      @click='$event=>$emit("update:modelValue",$event.target.value)' 
      type="radio" 
      v-bind:value="cat[0]" 
      class="category__button"/>
      <label v-bind:for="cat[0]">{{cat[1]}}</label>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  data(){
    return{
      categories:[
        ["All","Все категории"],
        ["electronics","Электроника"],
        ["jewelery","Драгоценности"],
        ["men's clothing","Мужская одежда"],
        ["women's clothing","Женская одежда"]
    ],
    };
  },
  props:{
    modelValue:String
  },
  methods: {

  },
});
</script>

<style scoped>

</style>