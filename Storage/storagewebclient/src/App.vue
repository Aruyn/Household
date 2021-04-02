<template>
<div class="container">
  <Header @toggle-add-item="toggleAddItem" :showAddItem="showAddItem"/>
  <div v-show="showAddItem">
    <AddItem @add-item="addItem"/>
  </div>  
  <Items 
    @use-item="useItem"
    :items="items"/>
</div>
</template>

<script>
import Header from './components/Header'
import Items from './components/Items'
import AddItem from './components/AddItem'

export default {
  name: 'App',
  components: {  
    Header,
    Items,
    AddItem
  },
  data() {
    return {
      items: [],
      showAddItem: false
    }
  },
  methods: {
    toggleAddItem() {
      this.showAddItem = !this.showAddItem
    },
    addItem(item) {
      this.items = [...this.items, item]
      //Send add item to StorageWebapi
    },
    useItem(id){
      this.items = this.items.map((item) => 
      item.id === id 
      ? {...item, used: true} 
      : item
      )
      //Send item used request to StorageWebApi
    },
    async fetchItems() {
      const res =  await fetch('http://desktop-aaroeen:80/storage', {
            method: "GET",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            }
        })
      const data = await res.json()

      return data
    }
  },
  async created() {
    this.items = await this.fetchItems()
  },
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@300;400&display=swap');
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
body {
  font-family: 'Poppins', sans-serif;
}
.container {
  margin: 10px auto;
  overflow: auto;
  border: 1px solid steelblue;
  padding: 30px;
  border-radius: 5px;
}
.btn {
  display: inline-block;
  background: #000;
  color: #fff;
  border: none;
  padding: 10px 20px;
  margin: 5px;
  border-radius: 5px;
  cursor: pointer;
  text-decoration: none;
  font-size: 15px;
  font-family: inherit;
}
.btn:focus {
  outline: none;
}
.btn:active {
  transform: scale(0.98);
}
.btn-block {
  display: block;
  width: 100%;
}
</style>