<template>
  <form @submit="onSubmit" class="add-form">
    <div class="form-control">
      <label>Beskrivelse</label>   
      <ItemInputAutoComplete :items="itemTypes" v-model="description"/>
    </div>
    <div class="form-control">
      <label>Best før</label>
      <input
        type="date"
        v-model="expirydate"
        name="expirydate"
        placeholder="Legg til best før dato"
      />
    </div>
    <input type="submit" value="Lagre" class="btn btn-block" />
  </form>
</template>

<script>
import ItemInputAutoComplete from './ItemInputAutocomplete'

export default {
  name: 'AddItem',
  props: {
    itemTypes : Array
  },
  data() {
    return {
      description: '',
      expirydate: '',
    }
  },
  components:{
    ItemInputAutoComplete
  },
  methods: {
    onSubmit(e) {
      e.preventDefault()
      if (!this.description) {
        alert('Legg til en beskrivelse av artikkel')
        return
      }
            if (!this.expirydate) {
        alert('Legg til en best før dato')
        return
      }
      const newItem = {
        id: Math.floor(Math.random() * 100000),
        description: this.description,
        expirydate: this.expirydate
      }
      this.$emit('add-item', newItem)
      this.description = ''
      this.expirydate = ''
    },
  },
}
</script>

<style scoped>
.add-form {
  margin-top: 20px;
  margin-bottom: 40px;
}
.form-control {
  margin: 20px 0;
}
.form-control label {
  display: block;
}
.form-control input {
  width: 100%;
  height: 40px;
  margin: 5px;
  padding: 3px 7px;
  font-size: 17px;
}
.form-control-check {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.form-control-check label {
  flex: 1;
}
.form-control-check input {
  flex: 2;
  height: 20px;
}
</style>