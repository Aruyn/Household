<template>    
    <div class="autoCompleteContainer">     
        <input type="text" class="inputField" autocomplete="off" v-model="inputText" @focus="modal = true" @blur="modal = false"/>
        <div v-if="filteredItems && modal" class="filteredItems">
        <div v-for="item in filteredItems.slice(0,5)" :key="item.description" class="filteredItem">
            <li class="itemSuggestion" @mousedown="setItem(item)">{{item.description}}</li>
        </div>
        </div>
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
        this.filterItems();
    },
    methods: {
        filterItems() {
            if(this.inputText.length == 0){
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
    },
    watch: {
        inputText() {
            this.filterItems();
        }
    }
}
</script>

<style>
.autoCompleteContainer{
    display: flex;
    flex-direction: column;
    align-items: center;
}
.filteredItems{
    z-index: 10;
    list-style-type: none;
    border: 103,71,54;
    border: 1px solid rgb(103,71,54);
    width: 100%;
}
.filteredItem{
    cursor: pointer;
    width: 100%;
}
.inputField{
    width: 100%;
    border: 1px solid black;
    padding: 5px;
}
.itemSuggestion{
    width: 100%;
    padding: 5px;
    border: 1px solid black;
    background: rgb(51, 50, 50);
    text-align: center;
    color: white;
}

</style>