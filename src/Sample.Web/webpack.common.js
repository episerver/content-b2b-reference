const path = require("path");
const webpack = require("webpack");

module.exports = {
    entry: {
        main: path.join(__dirname, 'clientResources/scripts', 'main.ts'),
    },
    resolve: {
        modules: [path.join(__dirname, 'clientResources/scripts'), "node_modules"],
        extensions: ['.js', '.ts', '.tsx'],
    },
    output: {
        filename: "[name].min.js",
        path: path.resolve(__dirname, "wwwroot"),
    },
   
    module: {
        rules: [
            {
                test: /\.(ts|js)x?$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: "babel-loader",
                    },
                ],
            },
        ],
    },
};