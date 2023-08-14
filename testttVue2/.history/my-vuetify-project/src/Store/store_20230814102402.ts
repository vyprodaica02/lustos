// Import Vue và Vuex
import Vue from "vue";
import Vuex, { StoreOptions } from "vuex";
// Import module userModule đã tạo (được import từ file userModule.ts)
import userModule from "../Module/userModule";
import projectModule from "../Module/projectModule";
import attendancesModule from "../Module/attendancesModule";

// Sử dụng Vuex
Vue.use(Vuex);

// Define Vuex state types
interface State {
  users: any[];
  project: any[];
  attendances: any[];
}

// Tạo Vuex store
const store: StoreOptions<State> = {
  // State: Định nghĩa trạng thái (state) của ứng dụng
  state: {
    users: [], // Một mảng chứa thông tin người dùng, ban đầu là rỗng
    project: [], // Một mảng chứa thông tin dự án, ban đầu là rỗng
    attendances: [], // Một mảng chứa thông tin điểm danh, ban đầu là rỗng
  },

  // Mutations: Định nghĩa các mutations để thay đổi state
  mutations: {
    // Mutation để cập nhật state.users khi nhận được danh sách người dùng từ action
    SET_USERS(state, users) {
      state.users = users;
    },
    DELETE_USER(state, userId) {
      // Xóa người dùng khỏi danh sách
      state.users = state.users.filter((user) => user.id !== userId);
    },
    UPDATE_USER(state, updatedUser) {
      const index = state.users.findIndex((user) => user.id === updatedUser.id);
      if (index !== -1) {
        // Sử dụng Vue.set để thay đổi phần tử trong mảng một cách reactive
        Vue.set(state.users, index, updatedUser);
      }
    },
    ADD_USER(state, newUser) {
      // Thêm người dùng mới vào danh sách
      state.users.push(newUser);
    },
    ///
    //project
    SET_PROJECT(state, project) {
      state.project = project;
    },
    DELETE_PROJECT(state, projectId) {
      // Xóa dự án khỏi danh sách
      state.project = state.project.filter((p) => p.id !== projectId);
    },
    UPDATE_PROJECT(state, updatedProject) {
      const index = state.project.findIndex((p) => p.id === updatedProject.id);
      if (index !== -1) {
        // Sử dụng Vue.set để thay đổi phần tử trong mảng một cách reactive
        Vue.set(state.project, index, updatedProject);
      }
    },
    ADD_PROJECT(state, newProject) {
      // Thêm dự án mới vào danh sách
      state.project.push(newProject);
    },

    ///
    //attendances
    SET_ATTENDANCES(state, attendances) {
      state.attendances = attendances;
    },
    DELETE_ATTENDANCES(state, attendanceId) {
      // Xóa điểm danh khỏi danh sách
      state.attendances = state.attendances.filter(
        (a) => a.id !== attendanceId
      );
    },
    UPDATE_ATTENDANCES(state, updatedAttendance) {
      const index = state.attendances.findIndex(
        (a) => a.id === updatedAttendance.id
      );
      if (index !== -1) {
        // Sử dụng Vue.set để thay đổi phần tử trong mảng một cách reactive
        Vue.set(state.attendances, index, updatedAttendance);
      }
    },
    ADD_ATTENDANCES(state, newAttendance) {
      // Thêm điểm danh mới vào danh sách
      state.attendances.push(newAttendance);
    },
  },
  // Actions: Định nghĩa các actions để gọi API hoặc thực hiện các tác vụ bất đồng bộ
  actions: {
    ...userModule.actions, // Kết hợp các actions từ module userModule đã tạo
    // Những actions khác cũng có thể được định nghĩa tại đây
    ...projectModule.actions,
    ...attendancesModule.actions,
  },
  // Getters: Định nghĩa các getters để lấy dữ liệu từ state
  getters: {
    getUsers: (state) => state.users, // Getter để lấy danh sách người dùng từ state
    // Những getters khác cũng có thể được định nghĩa tại đây
    getProject: (state) => state.project,
    getAttendances: (state) => state.attendances,
  },
};

// Xuất Vuex store để có thể sử dụng trong ứng dụng Vue
export default new Vuex.Store(store);
