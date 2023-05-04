<template>
  <!-- Main -->
  <h5 class="title">Title</h5>
  <el-table :data="filterTableData"  style="width: 100%">
    <el-table-column label="Date" prop="date" />
    <el-table-column label="Name" prop="name" />
    <el-table-column align="right">
      <template #header>
        <el-input v-model="search" size="small" placeholder="Type to search" />
      </template>
      <template #default="scope">
        <el-button size="small" @click="handleEdit(scope.$index, scope.row)"
          >Edit</el-button
        >
        <el-button
          size="small"
          type="danger"
          @click="handleDelete(scope.$index, scope.row)"
          >Delete</el-button
        >
      </template>
    </el-table-column>
  </el-table>
</template>
<script>
import { computed, ref } from 'vue'
import { ArrowRight } from '@element-plus/icons-vue'
import { defineComponent } from 'vue'
import {useMenu} from '../../stores/use-menu-admin'
export default defineComponent({
  components: {
    ArrowRight
  },
  setup() {
    const search = ref('')
    const filterTableData = computed(() =>
      tableData.filter(
        (data) =>
          !search.value ||
          data.name.toLowerCase().includes(search.value.toLowerCase())
      )
    )
    const handleEdit = (index, row) => {
      console.log(index, row)
    }
    const handleDelete = (index, row) => {
      console.log(index, row)
    }

    const tableData = [
      {
        date: '2016-05-03',
        name: 'Tom',
        address: 'No. 189, Grove St, Los Angeles'
      },
      {
        date: '2016-05-02',
        name: 'John',
        address: 'No. 189, Grove St, Los Angeles'
      },
      {
        date: '2016-05-04',
        name: 'Morgan',
        address: 'No. 189, Grove St, Los Angeles'
      },
      {
        date: '2016-05-01',
        name: 'Jessy',
        address: 'No. 189, Grove St, Los Angeles'
      }
    ]
    return {filterTableData,search, handleDelete, handleEdit }
  }
})
</script>
<style scoped>
.title {
  padding: 12px;
}
</style>
