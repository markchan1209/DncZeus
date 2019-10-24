const path = require('path')

const resolve = dir => {
  return path.join(__dirname, dir)
}

// 項目部署基礎
// 默認情況下，我們假設你的應用將被部署在域的根目錄下,
// 例如：https://www.my-app.com/
// 默認：'/'
// 如果您的應用程序部署在子路徑中，則需要在這指定子路徑
// 例如：https://www.foobar.com/my-app/
// 需要將它改為'/my-app/'
const BASE_URL = process.env.NODE_ENV === 'production'
  ? '/'
  : '/'

module.exports = {
  // Project deployment base
  // By default we assume your app will be deployed at the root of a domain,
  // e.g. https://www.my-app.com/
  // If your app is deployed at a sub-path, you will need to specify that
  // sub-path here. For example, if your app is deployed at
  // https://www.foobar.com/my-app/
  // then change this to '/my-app/'
  baseUrl: BASE_URL,
  // tweak internal webpack configuration.
  // see https://github.com/vuejs/vue-cli/blob/dev/docs/webpack.md
  chainWebpack: config => {
    config.resolve.alias
      .set('@', resolve('src')) // key,value自行定義，比如.set('@@', resolve('src/components'))
      .set('_c', resolve('src/components'))
      .set('_conf', resolve('config'))
  },
  // 打包時不生成.map文件
  productionSourceMap: false,
  // 這裡寫你調用接口的基礎路徑，來解決跨域，如果設置了代理，那你本地開發環境的axios的baseUrl要寫為 '' ，即空字符串
  devServer: {
    // proxy: 'localhost:3000'
    port: 9000,
    //禁用host檢查,不然在部分流利器中會報[WDS disconnected]的錯誤
    // 參考:https://github.com/webpack/webpack-dev-server/issues/851
    disableHostCheck: true
  }
}
