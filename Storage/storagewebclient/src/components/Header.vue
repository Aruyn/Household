<template>
    <header>
        <h1>
            Husholdningsartikler
        </h1>
        <Button                 
            @clicked="$emit('toggle-add-item')"
            :title="showAddItem ? 'Avbryt' : 'Legg til'" />
    </header>
</template>

<script>
import Button from './Button'

export default{
       name: 'Header',
       props: {
           title: String,
           showAddItem: Boolean
       },
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