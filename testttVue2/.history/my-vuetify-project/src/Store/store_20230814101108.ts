// Import Vue và Vuex
import Vue from "vue";
import Vuex from "vuex";
// Import module userModule đã tạo (được import từ file userModule.js)
import userModule from "../Module/userModule";
import projectModule from "../Module/projectModule";
import attendancesModule from "../Module/attendancesModule";
// Sử dụng Vuex
Vue.use(Vuex);
// Tạo Vuex store
const store = new Vuex.Store({
  // State: Định nghĩa trạng thái (state) của ứng dụng
  state: {
    users: [], // Một mảng chứa thông tin người dùng, ban đầu là rỗng
    project: [], // Một mảng chứa thông tin người dùng, ban đầu là rỗng
    attendances: [],
  },

  // Mutations: Định nghĩa các mutations để thay đổi state
  mutations: {
    // Mutation để cập nhật state.users khi nhận được danh sách người dùng từ action
    //USER
    SET_USERS(state, users) {
      state.users = users;
    },
    DELETE_USER(state, userId) {
      // Xóa người dùng khỏi danh sách
      state.project = state.project.filter((user) => user.id !== userId);
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
    DELETE_PROJECT(state, project) {
      // Xóa người dùng khỏi danh sách
      state.users = state.users.filter((projects) => projects.id !== project);
    },
    UPDATE_PROJECT(state, project) {
      const index = state.users.findIndex(
        (projects) => projects.id === project.id
      );
      if (index !== -1) {
        // Sử dụng Vue.set để thay đổi phần tử trong mảng một cách reactive
        Vue.set(state.project, index, project);
      }
    },
    ADD_PROJECT(state, newUser) {
      // Thêm người dùng mới vào danh sách
      state.project.push(newUser);
    },

    ///
    //att
    SET_Attendances(state, attendance) {
      state.attendances = attendance;
    },
    DELETE_Attendances(state, attendances) {
      // Xóa người dùng khỏi danh sách
      state.attendances = state.attendances.filter(
        (attendance) => attendance.id !== attendances
      );
    },
    UPDATE_Attendances(state, attendances) {
      const index = state.attendances.findIndex(
        (attendances) => attendances.id === attendances.id
      );
      if (index !== -1) {
        // Sử dụng Vue.set để thay đổi phần tử trong mảng một cách reactive
        Vue.set(state.attendances, index, attendances);
      }
    },
    ADD_Attendances(state, newUser) {
      // Thêm người dùng mới vào danh sách
      state.project.push(newUser);
    },
    ///
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
});
// Xuất Vuex store để có thể sử dụng trong ứng dụng Vue
export default store;
