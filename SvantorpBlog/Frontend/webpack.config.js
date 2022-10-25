const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");


module.exports = {
  entry: './src/index.js',
  entry: {
    app: './src/index.js',
    styles: './src/style.scss'
  },
  output: {
    filename: '[name].js',
    path: path.resolve(__dirname, '../wwwroot'),
  },
  plugins: [new MiniCssExtractPlugin()],
  module: {
    rules: [
      {
        test: /\.scss$/i,
        use: [
          MiniCssExtractPlugin.loader,
          "css-loader",
          "sass-loader",
        ],
      },
    ],
  },
  devServer: {
    proxy: {
      '/': 'https://localhost:5001',
    },
  },
};