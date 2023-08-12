<template>
  <div
    class="overlay d-flex align-center justify-center"
    v-if="isOpen"
    @click="offModal()"
  >
    <div class="modal-main rounded d-flex flex-column pa-6" @click.stop>
      <div class="text-h6 font-weight-bold">Thông Tin người dùng</div>
      <v-card>
        <div>
          <v-container>
            <v-row>
              <v-col cols="6">
                <div class="text-body-2 font-weight-bold mb-3">UserId</div>
                <v-text-field
                  density="compact"
                  variant="solo"
                  label="user ID"
                  v-model="editedUser.userId"
                ></v-text-field>
              </v-col>

              <v-col cols="4">
                <div class="text-body-2 font-weight-bold mb-3">isLate</div>
                <label>
                  <input
                    type="radio"
                    v-model="editedUser.isOverTime"
                    :value="false"
                  />
                  No late
                </label>
                <label>
                  <input
                    type="radio"
                    v-model="editedUser.isOverTime"
                    :value="true"
                  />
                  Late
                </label>
                <p>đã chọn: {{ editedUser.isOverTime }}</p>
              </v-col>
            </v-row>
            <div class="mt-3 text-center">
              <v-btn @click="saveChanges">Save</v-btn>
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
    isOpen: {},
    value: Boolean,
    selectedUser: Object,
  },
  data() {
    return {
      editedUser: {
        isLate: false,
      },
      isFetchingUsers: false,
      inputValues: {},
    };
  },
  methods: {
    offModal() {
      this.$emit("clickOverlay");
    },
    ...mapActions(["attendancesModule"]), // Tạo method userModule tương đương với action userModule trong Vuex store
    async saveChanges() {
      // Kiểm tra xem this.editedData có chứa trường id không
      if (
        !Object.prototype.hasOwnProperty.call(this.editedUser, "id") ||
        this.editedUser.id === null ||
        this.editedUser.id === ""
      ) {
        alert("Lỗi: Vui lòng chọn một bản ghi để sửa đổi.");
        return;
      }
      await this.$store.dispatch(
        "saveChangesActionAttendances",
        this.editedUser
      ); // Sử dụng await để đảm bảo saveChangesAction hoàn thành trước khi gọi fetchUsers
      await this.$store.dispatch("fetchAttendances", this.inputValues);
      this.offModal();
    },
  },

  computed: {
    // Tạo computed property getUsers tương đương với getter getUsers trong Vuex store
    ...mapGetters(["getAttendances"]),
  },
  created() {},
  watch: {
    selectedUser: {
      handler(newVal) {
        // Sao chép dữ liệu bằng cách parse và stringify
        this.editedUser = JSON.parse(JSON.stringify(newVal));
      },
    },
  },
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
