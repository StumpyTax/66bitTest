<template>
  <FormComp @reqMethod="post"></FormComp>
</template>

<script lang="ts">
import axios from "axios";
import { defineComponent } from "vue";
import Loader from "@/components/Loader.vue";
import FormComp from "@/components/FormComp.vue";

export default defineComponent(
  {
    components: {
      Loader,
      FormComp
    },
  methods:{
    async post(){
      const form=document.querySelector('form');
      if(form==null)
        return;
      const formData=new FormData(form);
        let player:any={};
        formData.forEach(function (value, key) {
          if(key=="gender" || key=="country")
            player[key]=Number(value);
          else player[key] = value;
        });
        console.log(player);
        try{
        const resp=await axios.post("http://localhost:5219/Player/Add",player);
        if(resp.status==200){
          alert("Игрок создан!");
        form.reset();
        }  
      }
        catch(e:unknown){
          console.log(e);
        }
    }
  }});
  </script>
<style>
</style>