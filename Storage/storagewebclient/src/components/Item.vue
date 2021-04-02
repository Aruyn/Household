<template>
<div :class="[item.used ? 'used' : '', 'item']">
    <h3>{{item.description}}
        <Button title="Bruk" @click="$emit('use-item', this.id)" />
    </h3>
    <p>{{item.expirydate}}</p>
</div>
</template>

<script>
import Button from './Button'

export default {
    name: 'Item',
    props: {
        item: Object
    },
    components: {
        Button
    }
}
</script>

<style scope>
.item {
  background: #f4f4f4;
  margin: 5px;
  padding: 10px 20px;
  cursor: pointer;
}
.item.used {
  background: #76c581
}
.item h3 {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
</style>