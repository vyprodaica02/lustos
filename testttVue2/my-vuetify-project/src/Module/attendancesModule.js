import axios from "axios";

export default {
  actions: {
    async fetchAttendances({ commit }, inputValues) {
      try {
        let apiUrl = "https://localhost:44384/api/AttenDances/getFilter";

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
        commit("SET_Attendances", response.data);
      } catch (error) {
        console.error(error);
      }
    },

    deleteAttendances({ commit }, userId) {
      axios
        .delete(
          `https://localhost:44384/api/AttenDances/Delete/id?id=${userId}`
        )
        .then(() => {
          // Xóa thành công, cập nhật state
          commit("DELETE_Attendances", userId);
          console.log(userId);
        })
        .catch((error) => {
          console.error(error);
        });
    },
    saveChangesActionAttendances({ commit }, editedData) {
      // Gửi dữ liệu đã chỉnh sửa lên API
      return axios
        .put("https://localhost:44384/api/AttenDances/UpdateAsync", editedData)
        .then((response) => {
          // Gọi mutation để cập nhật dữ liệu trong Vuex store
          commit("UPDATE_Attendances", response.data);
        })
        .catch((error) => {
          console.error(error);
        });
    },
    addAttendances({ commit }, newUser) {
      return axios
        .post("https://localhost:44384/api/AttenDances/AddAsync", newUser)
        .then((response) => {
          // Gọi mutation để thêm người dùng mới vào Vuex store
          commit("ADD_Attendances", response.data);
          console.log(newUser);
        })
        .catch((error) => {
          console.error(error);
        });
    },
  },
};
