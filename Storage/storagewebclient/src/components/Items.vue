<template>
    <div v-for="item in items" :key="item.description">
        <Item 
         @use-item="$emit('use-item', item.id)"
         :item="item"/>
    </div>
</template>

<script>
import Item from './Item'

export default {
    name: 'Items',
    props: {
        items: Array
    },
    components: {
        Item
    }
}
</script>