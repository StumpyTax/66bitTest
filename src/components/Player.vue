<template>
  <div>
    <div class="product-item">
      <div class="product__title"><strong> Фамилия: {{item.surname}} </strong></div>
      <div class="product__title"><strong>Имя: {{ item.name }} </strong></div>
      <div class="product__title"><strong>Команда: {{ item.teamName }}</strong></div>
      <div class="product__price">Пол: {{  gend[item.gend] }}</div>
      <div class="product__price">Страна: {{  country[item.country] }}</div>
      <div class="product__price">День рождения: {{  item.birthday }}</div>
      <div class="btn" @click="toggleForm(item)">Редактировать</div>
    </div>
  </div>
</template>

<script lang="ts">
import {gend,country} from "@/Dict";
import { IPlayer } from '@/interfaces/IPlayer';
import { PropType, defineComponent } from 'vue'

export default defineComponent({
  props: {
    item: { required: true, type: Object as PropType<IPlayer> },
    
  },
  components: {
  },
  methods:{
    toggleForm(item:IPlayer){
      const upd=document.querySelector("#upd");
      upd?.parentElement?.classList.replace("off","on");
      const form:HTMLFormElement|null=document.forms.namedItem("upd");
      Object.getOwnPropertyNames(item).forEach((key:string,enumerate:number)=>{
        let tmp:string=key;
        if(key=="gend")
          tmp="gender";
        form?.children.namedItem(tmp)?.setAttribute("value",Object.values(item)[enumerate]);
      });
      document.cookie="id="+item.id;
     }
   },
  data(){
    return{country,gend}
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

.btn{
  background:black;
  color:white;
  cursor: pointer;
  border-radius: 5px;
  text-align: center;
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