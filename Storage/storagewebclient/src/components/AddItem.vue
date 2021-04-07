<template>
  <form @submit="onSubmit" class="add-form">
    <div class="form-control">
      <label>Beskrivelse</label>
      <ItemInputAutoComplete
        ref="itemInputField"
        :items="itemTypes"
        @input-updated="updateDescription"
      />
    </div>
    <div class="form-control">
      <label>Best før</label>
      <input
        type="date"
        v-model="expiredDate"
        name="expiredDate"
        placeholder="Legg til best før dato"
      />
    </div>
    <input type="submit" value="Lagre" class="btn btn-block" />
  </form>
</template>

<script>
import ItemInputAutoComplete from "./ItemInputAutocomplete";

export default {
  name: "AddItem",
  props: {
    itemTypes: Array,
  },
  data() {
    return {
      description: "",
      expiredDate: "",
    };
  },
  components: {
    ItemInputAutoComplete,
  },
  methods: {
    updateDescription(description) {
      this.description = description;
    },
    onSubmit(e) {
      e.preventDefault();
      if (!this.description) {
        alert("Legg til en beskrivelse av artikkel");
        return;
      }
      if (!this.expiredDate) {
        alert("Legg til en best før dato");
        return;
      }

      var itemType = this.itemTypes.find(
        (i) => i.description == this.description
      );
      var itemTypeId = "00000000-0000-0000-0000-000000000000";

      if(itemType !== undefined){
        itemTypeId = itemType.id;
      }

      const newItem = {
        itemTypeId: itemTypeId,
        description: this.description,
        expiredDate: this.expiredDate,
        addedDate: new Date(),
        location: 0,
      };

      this.$emit("add-item", newItem);
      this.$refs.itemInputField.inputText = "";
      this.description = "";
      this.expiredDate = "";
    },
  },
};
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