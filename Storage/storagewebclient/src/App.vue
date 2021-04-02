<template>
<div class="container">
  <Header/>
  <AddItem @add-item="addItem"/>
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
      items: []
    }
  },
  methods: {
    addItem(item) {
      this.items = [...this.items, item]
    },
    useItem(id){
      console.log(id)
      this.items = this.items.map((item) => 
      item.id === id 
      ? {...item, used: true} 
      : item
      )
    }
  },
  created() {
    this.items = [
      {
        id: 1,
        description: "Havregryn",
        expirydate: "01.01.2022",
        used: false
      },
      {
        id: 2,
        description: "Melk",
        expirydate: "13.04.2021",
        used: false
      } 
    ]
  }
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
  max-width: 500px;
  margin: 30px auto;
  overflow: auto;
  min-height: 300px;
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