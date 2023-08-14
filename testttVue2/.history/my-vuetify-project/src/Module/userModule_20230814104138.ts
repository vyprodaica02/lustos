import axios from "axios"; // Nhập thư viện axios để thực hiện các yêu cầu HTTP

import { ActionTree, Commit } from "vuex"; // Nhập các kiểu và hàm liên quan đến Vuex

// Định nghĩa kiểu dữ liệu cho một đối tượng Người dùng
interface User {
  id: number;
  // Các thuộc tính khác của người dùng
}

// Định nghĩa kiểu trạng thái cho Vuex Store
interface State {
  users: User[]; // Mảng chứa các đối tượng người dùng
}

// Khai báo mô-đun người dùng, chứa các hành động liên quan đến người dùng
const userModule: {
  actions: ActionTree<State, any>; // Khai báo các hành động với kiểu dữ liệu State và bất kỳ
} = {
  actions: {
    // Hành động để lấy danh sách người dùng
    async fetchUsers({ commit }, inputValues) {
      try {
        let apiUrl = "https://localhost:44384/api/User/getFilter";

        if (Object.keys(inputValues).length > 0) {
          apiUrl += "?";

          // Xử lý và thêm thông tin tìm kiếm vào URL
          const queryParams = Object.keys(inputValues)
            .filter((key) => inputValues[key])
            .map(
              (key) =>
                encodeURIComponent(key) +
                "=" +
                encodeURIComponent(inputValues[key])
            )
            .join("&");

          apiUrl += queryParams;
        }

        const response = await axios.get(apiUrl); // Gửi yêu cầu GET đến API
        commit("SET_USERS", response.data); // Gọi commit để thay đổi trạng thái Vuex
      } catch (error) {
        console.error(error);
      }
    },

    // Hành động để xóa người dùng
    async deleteUser({ commit }, userId) {
      try {
        await axios.delete(
          `https://localhost:44384/api/User/Delete/id?id=${userId}`
        ); // Gửi yêu cầu DELETE đến API để xóa người dùng theo ID
        commit("DELETE_USER", userId); // Gọi commit để thay đổi trạng thái Vuex
      } catch (error) {
        console.error(error);
      }
    },

    // Hành động để lưu các thay đổi vào người dùng
    async saveChangesAction({ commit }, editedData) {
      try {
        const response = await axios.put(
          "https://localhost:44384/api/User/UpdateAsync",
          editedData
        ); // Gửi yêu cầu PUT đến API để cập nhật người dùng
        commit("UPDATE_USER", response.data); // Gọi commit để thay đổi trạng thái Vuex
      } catch (error) {
        console.error(error);
      }
    },

    // Hành động để thêm người dùng mới
    async addUser({ commit }, newUser) {
      try {
        const response = await axios.post(
          "https://localhost:44384/api/User/AddAsync",
          newUser
        ); // Gửi yêu cầu POST đến API để thêm người dùng mới
        commit("ADD_USER", response.data); // Gọi commit để thay đổi trạng thái Vuex
      } catch (error) {
        console.error(error);
      }
    },
  },
};

export default userModule; // Xuất mô-đun người dùng để sử dụng trong Vuex Store
