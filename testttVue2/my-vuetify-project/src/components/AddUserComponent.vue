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
                <div class="text-body-2 font-weight-bold mb-3">FisrtName</div>
                <v-text-field
                  density="compact"
                  variant="solo"
                  label="Họ tên"
                  v-model="fisrtName"
                ></v-text-field>
              </v-col>

              <v-col cols="6">
                <div class="text-body-2 font-weight-bold mb-3">code</div>
                <v-text-field
                  density="compact"
                  variant="solo"
                  label="Pháp danh"
                  v-model="code"
                ></v-text-field>
              </v-col>

              <v-col cols="6">
                <div class="text-body-2 font-weight-bold mb-3">Email</div>
                <v-text-field
                  density="compact"
                  variant="solo"
                  label="Email"
                  v-model="email"
                >
                </v-text-field>
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
      email: "",
      code: "",
      inputValues: {},
      fisrtName: "",
      userAvatar: "đâsdas",
      userWallImage: "xxxxxxxxzz",
      password: "123490",
      contactCode: "285999",
      lastname: "Night",
      payLeave: 0,
      paidLeave: 0,
      unPaidLeave: 0,
      userStatus: 1,
      typeUser: 1,
      createTime: "2023-08-03T16:26:22.354Z",
      updateTime: "2023-08-03T16:26:22.354Z",
    };
  },
  methods: {
    offModal() {
      this.$emit("clickShowAdd");
    },

    Add() {
      if (!this.fisrtName || !this.code || !this.email) {
        console.error("Vui lòng nhập đầy đủ thông tin người dùng.");
        return;
      }

      const newUser = {
        email: this.email,
        code: this.code,
        fisrtName: this.fisrtName,
        userAvatar: this.userAvatar,
        userWallImage: this.userWallImage,
        password: this.password,
        contactCode: this.contactCode,
        lastname: this.lastname,
        payLeave: parseInt(this.payLeave),
        paidLeave: parseInt(this.paidLeave),
        unPaidLeave: parseInt(this.unPaidLeave),
        userStatus: parseInt(this.userStatus),
        typeUser: parseInt(this.typeUser),
        createTime: new Date(this.createTime),
        updateTime: new Date(this.updateTime),
      };

      this.$store
        .dispatch("addUser", newUser)
        .then(() => {
          // Xử lý sau khi thêm người dùng thành công
          // Ví dụ: làm mới danh sách người dùng
          alert("thêm thành công");
          this.$store.dispatch("fetchUsers", this.inputValues);
        })
        .catch((error) => {
          console.error(error);
        });
    },
    ...mapActions(["userModule"]),
  },

  watch: {
    handler(newVal) {
      // Sao chép dữ liệu bằng cách parse và stringify
      this.newUser = JSON.parse(JSON.stringify(newVal));
    },
  },
  computed: {
    // Tạo computed property getUsers tương đương với getter getUsers trong Vuex store
    ...mapGetters(["getUsers"]),
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
