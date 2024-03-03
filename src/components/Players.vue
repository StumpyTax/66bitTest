<template>
  <div class="players">
    <div v-for="item in players" :key="item.id" class="players-item">
      <Player class="player" :item="item"/>
    </div>
  </div>
</template>

<script lang="ts">
import { IPlayer } from '@/interfaces/IPlayer';
import { PropType, defineComponent } from 'vue';
import Player from './Player.vue';

export default defineComponent({
  components:{
    Player
},
  props: {
    players: { required: true, type: Object as PropType<IPlayer[]> },
  },
  
  methods: {
    
  },
  mounted(){
    console.log(this.players);
  }
});
</script>

<style scoped>
.btn-wrapper{
  display: flex;
  align-items: right;
}
.players {
  display: flex;
  flex-wrap: wrap;
  width: 100%;
}

.player {
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
  min-width: 100px;
  padding: 20px;
}

.players-item {
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

.player__image {
  max-width: 100px;
  width: 100%;
}
.player__btn {
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
.player__btn:hover{
  background: #3d3c3c;
}
@media(max-width: 990px){
  .players-item{
    max-width: 33.3%;
    flex:0 0 33.3%
  }
  .player{
    font-size: 10px;
  }
  .player__btn{
    font-size: 11px;
  } 
}
@media(max-width: 578px){
  .players-item{
    width: 100%;
    max-width: 50%;
    flex: 0 0 50%;
  }
  .player__btn{
    font-size: 11px;
  } 
}
  @media(max-width: 415px){
  .players-item{
    width: 100%;
    max-width: 100%;
    flex: 0 0 100%;
  }

}
</style>