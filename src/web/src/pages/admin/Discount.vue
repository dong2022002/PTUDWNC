<template>
  <!-- Main -->
  <div class="d-flex justify-content-between">
    <h5 class="title">Danh sách mức giảm giá</h5>
    <router-link :to="{ name: 'edit-discount' }">
      <el-button class="mt-2 me-4" type="success">
        Thêm mức giảm giá
      </el-button>
    </router-link>
  </div>
  <el-table :data="filterTableData" style="width: 100%">
    <el-table-column label="Tên danh mục" prop="name" width="350" />
    <el-table-column label="Mô tả" prop="description" />
    <el-table-column label="Tỉ lệ" prop="discountPercent" />

    <el-table-column fixed="right" width="150">
      <template #header>
        <el-input
          v-model="search"
          size="small"
          :z-index="3000"
          placeholder="Type to search"
        />
      </template>
      <template #default="scope">
        <router-link :to="{ name: 'edit-discount' }">
          <el-button size="small" class="me-4" @click="handleEdit(scope.row)">
            sửa
          </el-button>
        </router-link>
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
import {
  deleteDiscount,
  getDiscounts,
} from "../../services/discountRepository";
import { useBreadCurmb } from "../../stores/breadcrumb.js";
import { useDiscountEdit } from "../../stores/discountEdit";

export default {
  components: {
    ArrowRight,
    InfoFilled,
  },
  setup() {
    const breadcrumb = useBreadCurmb();
    breadcrumb.updateTitle("Quản lý mức giảm giá");
    const search = ref("");
    const filterTableData = computed(() =>
      tableData.value.filter(
        (data) =>
          !search.value ||
          data.name.toLowerCase().includes(search.value.toLowerCase())
      )
    );
    const discount = useDiscountEdit();
    const pageSize = ref(5);
    const pageNumber = ref(1);
    const tableData = ref([]);
    const pageCount = ref(0);
    const getData = () => {
      getDiscounts("", pageSize.value, pageNumber.value, "", "").then(
        (data) => {
          tableData.value = data.items;
          pageCount.value = data.metadata.pageCount * pageSize.value;
        }
      );
    };
    getData();

    const handleEdit = (data) => {
      discount.updateDiscount(data);
    };
    const handleDelete = (index, row) => {
      deleteDiscount(row.id).then(() => {
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
      InfoFilled,
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
