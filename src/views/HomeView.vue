<template>
  <div class="updPlayer off">
  <FormComp id="upd" @reqMethod="updPlayer" name="upd" class="updPlayer__form"></FormComp>
</div>
  <div class="home" :key="forceRenderKey">
    <AddPlayer></AddPlayer>
    <div v-if="players.length != 0" class="players-list">
      <Players 
        :players="players.slice((activePage - 1) * limit, (activePage - 1) * limit + limit)"  />
      <Pagination @ChangeActive="ChangeActiveHandler" :activePage="activePage" :pagesCount="pagesCount" />

    </div>
    <div v-else class="loader">
      <Loader/>
    </div>
  </div>
</template>

<script lang="ts">
import { IPlayer } from "@/interfaces/IPlayer";
import { defineComponent } from 'vue';
import axios from 'axios';
import Players from '@/components/Players.vue';
import Pagination from "@/components/Pagination.vue";
import Loader from "@/components/Loader.vue";
import AddPlayer from "@/components/AddPlayer.vue";
import FormComp from "@/components/FormComp.vue";

export default defineComponent({
  components: {
    Players,
    Pagination,
    AddPlayer,
    Loader,
    FormComp
},
  data() {
    return {
      players: [] as IPlayer[],
      activePage: 1,
      limit: 15,
      forceRenderKey:0
    }
  },
  methods: {
    forceReload(){
      this.forceRenderKey++;
    },
    ChangeActiveHandler(newActive:number){
      this.activePage=newActive;
    },
    async updPlayer(){
      const form=document.querySelector('form');
      if(form==null)
        return;
      const formData=new FormData(form);
        let player:any={};
        const id:Number=Number(JSON.parse(document.cookie.split("id=")[1]));
      if (document.cookie.includes("id=")) 
          player["id"]=id;
        formData.forEach((value, key)=> {
          if(key=="gender" || key=="country")
            player[key]=Number(value);
          else player[key]=value;
        });
        try{
          console.log(player);
        const resp=await axios.put("http://localhost:5219/Player/Update",player);
        if(resp.status==200){
          alert("Игрок Обновлен!");
        let index=this.players.findIndex(x=>x.id==id);
        this.players[index]=player;
        form.reset();
        this.forceReload();
      }  
      }
        catch(e:unknown){
          console.log(e);
        }
        form.parentElement?.classList.replace("on","off");
    },
    async getProducts(): Promise<void> {
      try {
        const response = await axios.get<IPlayer[]>("http://localhost:5219/Player/GetAll");
        if (response.status == 200) {
          this.players = response.data;
          console.log(this.players);
        }
      }
      catch (e: unknown) {
        console.log(e);
      }
    },
  },

  mounted() {
    this.getProducts();
    const upd=document.querySelector(".updPlayer");
    upd?.addEventListener("click",(e)=>{
      let event=<Element>e.target;
      if(upd?.classList.contains("on") && !event.closest(".updPlayer__form")){
        upd.classList.replace("on","off");
        
      }
    });

  },
  computed: {
    
    pagesCount(): number {
      return Math.ceil(this.players.length / this.limit);
    }
  }
});
</script>
<style>
.on{
  display: block;
}
.off{
  display: none;
}
.updPlayer{
  position: absolute;
  background: rgba(100, 99, 99, 0.623);
  z-index: 1;
  transform: translate(-17.5%,-16.1%);
  width: 100%;
  height: 100%;
}
.updPlayer__form{
  position: relative;
  background-color: white;
  top:25%;
  left:40%;
  width: fit-content;
  height: fit-content;
  padding: 20px;
}
.players-list{
  display: flex;
    flex-direction: column;
    justify-content: space-between;
    width: 100%;
}

.loader{
  margin: 0 auto;
}

</style>