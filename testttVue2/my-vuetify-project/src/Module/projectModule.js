import axios from "axios";

export default {
  actions: {
    async fetchProject({ commit }, inputValues) {
      try {
        let apiUrl = "https://localhost:44384/api/Project/getFilter";

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
        commit("SET_PROJECT", response.data);
      } catch (error) {
        console.error(error);
      }
    },

    deleteProject({ commit }, userId) {
      axios
        .delete(`https://localhost:44384/api/Project/Delete/id?id=${userId}`)
        .then(() => {
          // Xóa thành công, cập nhật state
          commit("DELETE_USER", userId);
        })
        .catch((error) => {
          console.error(error);
        });
    },
    saveChangesActionProject({ commit }, editedData) {
      // Gửi dữ liệu đã chỉnh sửa lên API
      return axios
        .put("https://localhost:44384/api/Project/UpdateAsync", editedData)
        .then((response) => {
          // Gọi mutation để cập nhật dữ liệu trong Vuex store
          commit("UPDATE_USER", response.data);
        })
        .catch((error) => {
          console.error(error);
        });
    },
    addProject({ commit }, newUser) {
      return axios
        .post("https://localhost:44384/api/Project/AddAsync", newUser)
        .then((response) => {
          // Gọi mutation để thêm người dùng mới vào Vuex store
          commit("ADD_PROJECT", response.data);
          console.log(newUser);
        })
        .catch((error) => {
          console.error(error);
        });
    },
  },
};
