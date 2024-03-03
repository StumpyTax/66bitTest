<template>
<form action="#"  class="form text">
  <label for="name">Имя</label>
    <input type="text" name="name" id="name" required>
  <label for="surname">Фамилия</label>
    <input type="text" name="surname" id="surname" required>
  <label for="gender">Пол</label>
    <select name="gender" id="gender" >
      <option value=0>Мужчина</option>
      <option value=1>Женщина</option>
    </select>
  <label for="birthday">День рождения</label>
    <input type="date" name="birthday" id="birthday" value="" required>
  <label for="team">Выберите название команды из списка или введите сами:</label>
  <input list="team" name="teamName" id="teamName" required>
  <datalist id="team" >
    <option  v-for="team in teams" :key="team" v-bind:value=team></option>
  </datalist>
  <label for="country">Страна:</label>
    <select name="country" id="country" required>
      <option value=0>Россия</option>
      <option value=1>США</option>
      <option value=2>Италия</option>
    </select>
  <button @click="$emit('reqMethod')" class="btn">Отправить</button>
</form>
</template>
<script lang="ts">
import axios from "axios";
import { defineComponent } from "vue";

export default defineComponent(
  {
    components:{},
    
  data() {
      return {
        teams: [] as string[],
      }
    },
    methods: {
      async getTeams(): Promise<void> {
        try {
          const response = await axios.get<string[]>("http://localhost:5219/Player/GetTeamsNames");
          if (response.status == 200) {
            this.teams = response.data;
          }
        }
        catch (e: unknown) {
          console.log(e);
        }
      },
    },
    async mounted() {
      this.getTeams();
      const form=document.querySelector('form');
      
      form?.addEventListener('submit',async (e)=>{
        e.preventDefault();
      });
    }
  });
</script>

<style scoped>

.loader{
  margin: 0 auto;
  width: fit-content;
}

.form{
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  min-height: 50%;
}
.btn{
  width: fit-content;
}

</style>