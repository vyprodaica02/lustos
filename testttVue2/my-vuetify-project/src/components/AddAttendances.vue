<template>
  <div
    class="overlay d-flex align-center justify-center"
    v-if="openAdd"
    @click="offModal()"
  >
    <div class="modal-main rounded d-flex flex-column pa-6" @click.stop>
      <div class="text-h6 font-weight-bold">Thông Tin người dùng</div>
      <v-card>
        <div>
          <v-container>
            <v-row>
              <v-col cols="6">
                <div class="text-body-2 font-weight-bold mb-3">Attendances</div>
                <v-text-field
                  density="compact"
                  variant="solo"
                  label="Attendances"
                  v-model="userId"
                ></v-text-field>
              </v-col>

              <v-col cols="6">
                <div class="text-body-2 font-weight-bold mb-3">
                  TotalWorkMinute
                </div>
                <v-text-field
                  density="compact"
                  variant="solo"
                  label="TotalWorkMinute"
                  v-model="TotalWorkMinute"
                ></v-text-field>
              </v-col>
            </v-row>
            <div class="mt-3 text-center">
              <v-btn @click.prevent="Add">Add</v-btn>
              <!--  -->
            </div>
          </v-container>
        </div>
      </v-card>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex"; // Import mapGetters and mapActions

export default {
  props: {
    openAdd: {
      type: Boolean,
    },
    selectedUser: Object,
  },
  data() {
    return {
      editedUser: {},
      userId: "",
      ContractId: 4,
      IsOverTime: true,
      TotalWorkMinute: 1,
      attendanceStatus: 1,
      WorkShiftId: 6,
      TypeAttendance: 2,
    };
  },
  methods: {
    offModal() {
      this.$emit("clickShowAdd");
    },

    Add() {
      if (!this.userId) {
        console.error("Vui lòng nhập đầy đủ thông tin.");
        return;
      }

      const newUser = {
        userId: this.userId,
        ContractId: this.ContractId,
        IsOverTime: this.IsOverTime,
        TotalWorkMinute: this.TotalWorkMinute,
        attendanceStatus: this.attendanceStatus,
        WorkShiftId: this.WorkShiftId,
        TypeAttendance: this.TypeAttendance,
      };

      this.$store
        .dispatch("addAttendances", newUser)
        .then(() => {
          // Xử lý sau khi thêm người dùng thành công
          // Ví dụ: làm mới danh sách người dùng
          alert("thêm thành công");
        })
        .catch((error) => {
          console.error(error);
        });
    },
    ...mapActions(["attendancesModule"]),
  },

  watch: {
    handler(newVal) {
      // Sao chép dữ liệu bằng cách parse và stringify
      this.newUser = JSON.parse(JSON.stringify(newVal));
    },
  },
  computed: {
    // Tạo computed property getUsers tương đương với getter getUsers trong Vuex store
    ...mapGetters(["getAttendances"]),
  },
  created() {},
};
</script>

<style>
.avata-user {
  width: 150px;
  height: 150px;
}
.btn-select_file {
  border: 1px solid #ccc;
  padding: 10px;
  max-width: 100px;
  background: #78c1f3;
  border-radius: 5px;
}
</style>
