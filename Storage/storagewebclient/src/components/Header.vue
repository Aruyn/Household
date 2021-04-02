<template>
    <header>
        <h1>
            Husholdningsartikler
        </h1>
        <Button title="Legg til"/>
    </header>
</template>

<script>
import Button from './Button'

export default{
       name: 'Header',
       components:{
           Button
       }
}
</script>

<style scoped>
    header{
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 20px;
    }
</style>