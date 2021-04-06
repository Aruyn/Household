<template>
    <div class="backgroundCarpet" @click="modal = false"/>
    <input type="text" class="inputField" autocomplete="off" v-model="inputText"/>
    <div v-if="filteredItems && modal" class="filteredItems">
        <ul>
            <li v-for="item in filteredItems" :key="item.description" class="filteredItem"/>
    </div>
</template>

<script>
export default {
    props:{
        items: Array
    },
    data: function() {
        return {
            inputText: '',
            modal: false,
            filteredItems: [],
        }
    },
    mounted() {
        this.fil
    },
    methods: {
        filterItems() {
            if(this.inputText.length = 0){
                this.filteredItems = this.items;
            }
            
            this.filteredItems = this.items.filter(item => {
                return item.description.toLowerCase().startsWith(this.inputText.toLowerCase());
            });
        },
        setItem(item) {
            this.inputText = item.description;
            this.modal = false;
        }
    }
}
</script>

<style>
.backgroundCarpet{
    position: absolute;
    z-index: 0;
    inset: 0;
}
.filteredItems{
    z-index: 10;
}
.filteredItem{
    cursor: pointer;
}
</style>