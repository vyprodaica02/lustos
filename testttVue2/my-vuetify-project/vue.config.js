// const { defineConfig } = require("@vue/cli-service");
module.exports = {
  transpileDependencies: ["vuetify"], // Thêm transpileDependencies nếu cần

  pluginOptions: {
    vuetify: {
      // https://github.com/vuetifyjs/vuetify-loader/tree/next/packages/vuetify-loader
    },
  },

  devServer: {
    proxy: {
      "/api": {
        target: "https://localhost:7024",
        changeOrigin: true,
      },
    },
  },
};
