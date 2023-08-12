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
                <div class="text-body-2 font-weight-bold mb-3">ProjectName</div>
                <v-text-field
                  density="compact"
                  variant="solo"
                  label="projectName"
                  v-model="projectName"
                ></v-text-field>
              </v-col>

              <v-col cols="6">
                <div class="text-body-2 font-weight-bold mb-3">PoId</div>
                <v-text-field
                  density="compact"
                  variant="solo"
                  label="PoId"
                  v-model="PoId"
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
      inputValues: {},
      projectName: "",
      EstimateDay: 1,
      IsLate: true,
      PmId: 5,
      PoId: "",
      StatusId: 1,
    };
  },
  methods: {
    offModal() {
      this.$emit("clickShowAdd");
    },
    Add() {
      if (!this.projectName || !this.PoId) {
        console.error("Vui lòng nhập đầy đủ thông tin.");
        return;
      }

      // Chuyển đổi dữ liệu sang dạng số nếu cần
      const newUser = {
        projectName: this.projectName,
        EstimateDay: parseInt(this.EstimateDay),
        IsLate: Boolean(this.IsLate), // Chuyển đổi sang kiểu boolean nếu cần
        PmId: parseInt(this.PmId),
        PoId: parseInt(this.PoId),
        StatusId: parseInt(this.StatusId),
      };

      this.$store
        .dispatch("addProject", newUser)
        .then(() => {
          this.$store.dispatch("fetchProject", this.inputValues);
          this.offModal();
        })
        .catch((error) => {
          console.error(error);
        });
    },
    ...mapActions(["projectModule"]),
  },

  watch: {
    newUser: {
      deep: true,
      handler(newVal) {
        // Sao chép dữ liệu bằng cách parse và stringify
        this.newUserCopy = JSON.parse(JSON.stringify(newVal));
      },
    },
  },
  computed: {
    // Tạo computed property getUsers tương đương với getter getUsers trong Vuex store
    ...mapGetters(["getProject"]),
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
