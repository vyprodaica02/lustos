import axios from "axios";
import { ActionTree, Commit } from "vuex";

interface User {
  id: number;
  // Các thuộc tính khác của người dùng
}

interface State {
  users: User[];
}

const userModule: {
  actions: ActionTree<State, any>;
} = {
  actions: {
    async fetchUsers({ commit }, inputValues) {
      try {
        let apiUrl = "https://localhost:44384/api/User/getFilter";

        // Kiểm tra xem có giá trị tìm kiếm hay không
        if (Object.keys(inputValues).length > 0) {
          apiUrl += "?"; // Thêm dấu "?" nếu có thông tin tìm kiếm

          // Xử lý và thêm thông tin tìm kiếm vào URL
          const queryParams = Object.keys(inputValues)
            .filter((key) => inputValues[key]) // Lọc ra các thuộc tính có giá trị
            .map(
              (key) =>
                encodeURIComponent(key) +
                "=" +
                encodeURIComponent(inputValues[key])
            )
            .join("&");

          apiUrl += queryParams;
        }

        const response = await axios.get(apiUrl);
        commit("SET_USERS", response.data);
      } catch (error) {
        console.error(error);
      }
    },

    async deleteUser({ commit }, userId) {
      try {
        await axios.delete(
          `https://localhost:44384/api/User/Delete/id?id=${userId}`
        );
        commit("DELETE_USER", userId);
      } catch (error) {
        console.error(error);
      }
    },

    async saveChangesAction({ commit }, editedData) {
      try {
        const response = await axios.put(
          "https://localhost:44384/api/User/UpdateAsync",
          editedData
        );
        commit("UPDATE_USER", response.data);
      } catch (error) {
        console.error(error);
      }
    },

    async addUser({ commit }, newUser) {
      try {
        const response = await axios.post(
          "https://localhost:44384/api/User/AddAsync",
          newUser
        );
        commit("ADD_USER", response.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
};

export default userModule;
