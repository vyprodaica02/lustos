import axios from "axios";
import { ActionTree, Commit } from "vuex";

interface Attendance {
  id: number;
  // Các thuộc tính khác của điểm danh
}

interface State {
  attendances: Attendance[];
}

const attendancesModule: {
  actions: ActionTree<State, any>;
} = {
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

    async deleteAttendances({ commit }, attendanceId) {
      try {
        await axios.delete(
          `https://localhost:44384/api/AttenDances/Delete/id?id=${attendanceId}`
        );
        commit("DELETE_Attendances", attendanceId);
      } catch (error) {
        console.error(error);
      }
    },

    async saveChangesActionAttendances({ commit }, editedData) {
      try {
        const response = await axios.put(
          "https://localhost:44384/api/AttenDances/UpdateAsync",
          editedData
        );
        commit("UPDATE_Attendances", response.data);
      } catch (error) {
        console.error(error);
      }
    },

    async addAttendances({ commit }, newAttendance) {
      try {
        const response = await axios.post(
          "https://localhost:44384/api/AttenDances/AddAsync",
          newAttendance
        );
        commit("ADD_Attendances", response.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
};

export default attendancesModule;
