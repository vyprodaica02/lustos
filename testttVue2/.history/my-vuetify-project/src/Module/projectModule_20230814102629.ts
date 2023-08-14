import axios from "axios";
import { ActionTree, Commit } from "vuex";

interface Project {
  id: number;
  // Các thuộc tính khác của dự án
}

interface State {
  project: Project[];
}

const projectModule: {
  actions: ActionTree<State, any>;
} = {
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

    async deleteProject({ commit }, projectId) {
      try {
        await axios.delete(
          `https://localhost:44384/api/Project/Delete/id?id=${projectId}`
        );
        commit("DELETE_PROJECT", projectId);
      } catch (error) {
        console.error(error);
      }
    },

    async saveChangesActionProject({ commit }, editedData) {
      try {
        const response = await axios.put(
          "https://localhost:44384/api/Project/UpdateAsync",
          editedData
        );
        commit("UPDATE_PROJECT", response.data);
      } catch (error) {
        console.error(error);
      }
    },

    async addProject({ commit }, newProject) {
      try {
        const response = await axios.post(
          "https://localhost:44384/api/Project/AddAsync",
          newProject
        );
        commit("ADD_PROJECT", response.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
};

export default projectModule;
