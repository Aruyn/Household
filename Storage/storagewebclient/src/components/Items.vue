<template>
<table class="items" style="width:100%">
    <thead>
      <tr>
        <th>Beskrivelse</th>
        <th>Mengde</th>
        <th>Første best-før-dato</th>
        <th>Handling</th>
    </tr>
    </thead>
    <tbody>
    <template v-for="item in items" :key="item.description">
        <tr>
    <td>{{item.description}}</td>
    <td>{{item.amount}}</td> 
    <td>{{formatDate(item.expiredDates[0])}}</td>    
    <td><Button title="Bruk" @click="$emit('use-item', this.id)"/> </td>
</tr>
    </template>
    </tbody>
</table>
</template>

<script>
import Button from './Button'
import moment from 'moment'

export default {
    name: 'Items',
    props: {
        items: Array
    },
    components: {
        Button
    },
    methods: {
      formatDate: function (date) {
        return moment(date).locale('nn').format('LL');
        }
    }
}
</script>
<style>
.items {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

.items td, .items th {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: center;
}

.items tr:nth-child(even){background-color: #f2f2f2;}

.items tr:hover {background-color: #ddd;}

.items th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: center;
  background-color: rgb(103,71,54);
  color: white;
}
</style>