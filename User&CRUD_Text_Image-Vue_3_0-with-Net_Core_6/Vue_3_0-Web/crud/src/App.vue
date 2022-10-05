<template>
    <!--Message msg="Vue 3.0 with .Net Core 6 API" /-->
    <!--路由出口、元件會渲染在此-->
    <router-view></router-view>
</template>
<!-- axios: easy-to-useAPI https://blog.logrocket.com/axios-vs-fetch-best-http-requests/ -->
<script lang="ts">
    import { defineComponent } from 'vue';
    //import DataBase from './components/WebContent.vue';
    // 引入 vue裡的 defineComponent()好讓 Typescirpt判斷 components的型別
    export default defineComponent({
        name: 'App',
    });
</script>
<!--global css style-->
<style>
</style>
