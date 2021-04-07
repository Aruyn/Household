<template>
  <div class="container">
    <Header />
    <Items @use-item="useItem" :items="items" />
    <Button
      class="showAddItemButton"
      @clicked="showAddItem = !showAddItem"
      :title="showAddItem ? 'Avbryt' : 'Legg til'"
    />
    <div v-show="showAddItem">
      <AddItem @add-item="addItem" :itemTypes="itemTypes" />
    </div>
  </div>
</template>

<script>
import Header from "./components/Header";
import Items from "./components/Items";
import AddItem from "./components/AddItem";
import Button from "./components/Button";

export default {
  name: "App",
  components: {
    Header,
    Items,
    AddItem,
    Button,
  },
  data() {
    return {
      items: [],
      itemTypes: [],
      showAddItem: false,
    };
  },
  methods: {
    async addItem(item) {
      await fetch(process.env.VUE_APP_API_ENDPOINT + "/storage", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(item),
      });
      this.showAddItem = false;
      await this.fetchItemsAndTypes();
    },
    async useItem(description) {
      await fetch(process.env.VUE_APP_API_ENDPOINT + "/storage", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(description),
      });
    },
    async fetchItemsAndTypes() {
      this.items = await this.fetchItems();
      this.itemTypes = await this.fetchItemTypes();
    },
    async fetchItems() {
      const res = await fetch(process.env.VUE_APP_API_ENDPOINT + "/storage", {
        method: "GET",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
      const data = await res.json();

      return data;
    },
    async fetchItemTypes() {
      const res = await fetch(process.env.VUE_APP_API_ENDPOINT + "/ItemTypes", {
        method: "GET",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
      const data = await res.json();

      return data;
    },
  },
  async created() {
    await this.fetchItemsAndTypes();
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@300;400&display=swap");
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
body {
  font-family: "Poppins", sans-serif;
}
.container {
  margin: 10px auto;
  overflow: auto;
  border: 1px solid rgb(103, 71, 54);
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
.showAddItemButton {
  float: right;
}
</style>