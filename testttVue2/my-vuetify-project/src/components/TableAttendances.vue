<template>
  <v-container>
    <v-row class="d-flex align-center justify-center">
      <v-col :cols="currentCols" class="transform">
        <div class="location-lotus pb-4">
          <p class="text-color-gray text-h6 font-weight-bold">
            Home > {{ DataLotus }}
          </p>
          <p class="main-title text-color-gray text-subtitle-2"></p>
        </div>
        <v-card class="d-flex bg-white pa-6 mb-5 d-flex flex-column">
          <v-row>
            <v-col class="d-flex justify-end">
              <v-btn @click.prevent="searchUser">
                <v-icon class="icon-border-grean pa-4">mdi-magnify</v-icon>
              </v-btn>
            </v-col>
          </v-row>
          <v-row>
            <v-col v-for="(item, index) in DataInput" :key="index" cols="4">
              <div class="text-body-2 font-weight-bold mb-3">
                {{ item }}
              </div>
              <v-text-field
                class="mt-3"
                density="compact"
                v-model="inputValues[item]"
                :label="item"
                solo
                dense
              ></v-text-field>
            </v-col>
          </v-row>
        </v-card>
        <!-- :items="desserts" -->

        <template>
          <v-data-table
            :headers="headers"
            :items="getAttendances"
            :single-select="singleSelect"
            sort-by="calories"
            class="elevation-1 table"
          >
            <!-- show-select -->
            <template v-slot:top>
              <div class="d-flex">
                <v-spacer></v-spacer>
                <v-btn
                  color="primary"
                  dark
                  class="d-flex justify-end mb-2"
                  @click="clickShowAdds"
                >
                  New Item
                </v-btn>
              </div>
            </template>
            <template v-slot:[`item.actions`]="{ item }">
              <v-icon
                small
                class="mr-2 icon_table-pen"
                @click="clickOpenUpdate(item)"
              >
                mdi-pencil
              </v-icon>
              <v-icon
                small
                class="icon_table-delete"
                @click="showConfirmation(item.id)"
              >
                mdi-delete
              </v-icon>
            </template>
          </v-data-table>
        </template>
      </v-col>
    </v-row>
    <UpdateAteendances
      :isOpen="open"
      :selectedUser="selected"
      @clickOverlay="clickOpenUpdate"
    />
    <AddAttendances :openAdd="showAdd" @clickShowAdd="clickShowAdds" />
  </v-container>
</template>
<script>
import { mapGetters, mapActions } from "vuex"; // Import mapGetters and mapActions
import { debounce } from "lodash";
import Swal from "sweetalert2";
import UpdateAteendances from "./UpdateAteendances.vue";
import AddAttendances from "./AddAttendances.vue";
export default {
  components: {
    UpdateAteendances,
    AddAttendances,
  },
  data() {
    return {
      open: false,
      singleSelect: false,
      DataLotus: "Attendances",
      DataInput: ["UserId", "contractId", "WorkShiftId"],
      inputValues: {
        userId: "",
        contractId: "",
        WorkShiftId: "",
      },
      selected: {},
      showAdd: false,
      currentCols: 12,
      headers: [
        // Định nghĩa headers cho bảng (columns)
        // Ví dụ:
        { text: "ID", value: "id" },
        { text: "UserId", value: "userId" },
        { text: "contractId", value: "contractId" },
        { text: "IsOverTime", value: "isOverTime" },
        { text: "WorkShiftId", value: "workShiftId" },
        { text: "Actions", value: "actions", sortable: false },
        // ...
      ],
    };
  },
  // Sử dụng các helper để tạo methods và computed properties từ Vuex store
  methods: {
    ...mapActions(["attendancesModule"]), // Tạo method userModule tương đương với action userModule trong Vuex store

    showConfirmation(id) {
      Swal.fire({
        title: "Are you sure you want to delete this user?",
        showCancelButton: true,
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        showLoaderOnConfirm: true,
        preConfirm: () => {
          return this.$store
            .dispatch("deleteAttendances", id)
            .then(() => {
              Swal.fire("Deleted successfully!", "", "success");
            })
            .catch((error) => {
              Swal.fire("Failed to delete", "", "error");
              console.error(error);
            });
        },
      });
    },

    clickOpenUpdate(item) {
      this.open = !this.open;
      this.selected = { ...item };
    },

    clickShowAdds() {
      this.showAdd = !this.showAdd;
    },
    //col
    handleResize: debounce(function () {
      this.updateCols(); // Gọi hàm updateCols khi kích thước màn hình thay đổi
    }, 300),
    updateCols() {
      const screenWidth = window.innerWidth;
      if (screenWidth >= 1600) {
        this.currentCols = 12;
      } else if (screenWidth >= 1000) {
        this.currentCols = 10;
      } else if (screenWidth >= 768) {
        this.currentCols = 8;
      } else {
        this.currentCols = 6;
      }
    },
    //
    //add
    searchUser() {
      this.$store.dispatch("fetchAttendances", this.inputValues);
    },
  },
  computed: {
    // Tạo computed property getUsers tương đương với getter getUsers trong Vuex store
    ...mapGetters(["getAttendances"]),
  },
  created() {
    // Gọi action fetchUsers trong Vuex store thông qua method userModule đã tạo bằng mapActions
    this.$store.dispatch("fetchAttendances", this.inputValues);
  },
  mounted() {
    this.updateCols(); // Gọi hàm updateCols khi component được mount lần đầu tiên
    window.addEventListener("resize", this.handleResize);
  },
  beforeDestroy() {
    window.removeEventListener("resize", this.handleResize);
  },
};
</script>
<style scoped>
th .text-start .sortable {
  text-align: center !important;
}
td.text-start {
  text-align: center !important;
}
.icon_table-pen {
  background: #5ab55e;
  color: white;
  padding: 10px;
  border-radius: 50%;
}
.icon_table-delete {
  background: #f55246;
  color: white;
  padding: 10px;
  border-radius: 50%;
}
</style>
