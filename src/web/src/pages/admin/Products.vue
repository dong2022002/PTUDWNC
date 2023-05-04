<template>
  <!-- Main -->
  <div class="d-flex justify-content-between">
    <h5 class="title">Danh sách sản phẩm</h5>
    <EditProduct @updateTable="updateTable" />
  </div>
  <el-table :data="filterTableData" style="width: 100%">
    <el-table-column label="Tên sản phẩm" prop="name" width="250" />
    <el-table-column label="Mô tả" prop="description" width="250" />
    <el-table-column label="Giá" prop="price" width="100" />
    <el-table-column label="Số lượng" prop="quantity" width="90" />
    <el-table-column
      label="Giảm giá"
      prop="discount.discountPercent"
      width="90"
    />
    <el-table-column label="Loại" prop="productCategory.name" width="80" />
    <el-table-column fixed="right" width="150">
      <template #header>
        <el-input v-model="search" size="small" placeholder="Type to search" />
      </template>
      <template #default="scope">
        <el-button size="small" @click="handleEdit(scope.$index, scope.row)"
          >Sửa</el-button
        >
        <el-popconfirm
          width="220"
          confirm-button-text="OK"
          cancel-button-text="Hủy"
          :icon="InfoFilled"
          icon-color="#626AEF"
          title="bạn có thực sự muốn xóa"
          @confirm="handleDelete(scope.$index, scope.row)"
          @cancel="cancelEvent"
        >
          <template #reference>
            <el-button size="small" type="danger">Xóa</el-button>
          </template>
        </el-popconfirm>
      </template>
    </el-table-column>
  </el-table>
  <div class="d-flex justify-content-center mt-4">
    <el-pagination
      layout="prev, pager, next"
      :total="pageCount"
      :page-size="pageSize"
      @current-change="handleCurrentChange"
    />
  </div>
</template>
<script>
import { ArrowRight, InfoFilled } from "@element-plus/icons-vue";
import { computed, ref } from "vue";
import EditProduct from "../../components/admin/EditProduct.vue";
import {
  deleteProduct,
  getProductsFilter,
} from "../../services/ProductRepository";
export default {
  components: {
    ArrowRight,
    EditProduct,
    InfoFilled,
  },
  setup() {
    const search = ref("");
    const filterTableData = computed(() =>
      tableData.value.filter(
        (data) =>
          !search.value ||
          data.name.toLowerCase().includes(search.value.toLowerCase())
      )
    );

    const pageSize = ref(5);
    const pageNumber = ref(1);
    const tableData = ref([]);
    const pageCount = ref(0);
    const getData = () => {
      getProductsFilter("", "", pageSize.value, pageNumber.value, "", "").then(
        (data) => {
          tableData.value = data.items;
          pageCount.value = data.metadata.pageCount * pageSize.value;
          console.log(tableData.value);
        }
      );
    };
    getData();

    const handleEdit = (index, row) => {
      console.log(index, row);
    };
    const handleDelete = (index, row) => {
      deleteProduct(row.id).then(() => {
        getData();
      });
    };
    const cancelEvent = () => {
      return;
    };
    const handleCurrentChange = (val) => {
      pageNumber.value = val;
      getData();
    };
    const updateTable = () => {
      getData();
    };

    return {
      cancelEvent,
      updateTable,
      handleCurrentChange,
      filterTableData,
      search,
      handleDelete,
      handleEdit,
      pageCount,
      pageSize,
    };
  },
};
</script>
<style scoped>
.title {
  padding: 12px;
}
</style>
