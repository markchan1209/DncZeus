export default {
  /**
   * @description 配置顯示在瀏覽器標籤的title
   */
  title: '誠邦後台管理',
  /**
   * @description token在Cookie中存儲的天數，默認1天
   */
  cookieExpires: 7,
  /**
   * @description 是否使用國際化，默認為false
   *              如果不使用，則需要在路由中給需要在菜單中展示的路由設置meta: {title: 'xxx'}
   *              用來在菜單中顯示文字
   */
  useI18n: false,
  /**
   * @description api請求基礎路徑
   */
  baseUrl: {
    dev: 'http://localhost:54321/',
    pro: 'http://localhost:54321/',
    defaultPrefix: "api/v1/"
  },
  authUrl: {
    dev: 'http://localhost:54321/api/oauth/auth',
    pro: 'http://localhost:54321/api/oauth/auth'
  },
  /**
   * @description 默認打開的首頁的路由name值，默認為home
   */
  homeName: 'home',
  /**
   * @description 需要加載的插件
   */
  plugin: {
    'error-store': {
      showInHeader: false, // 設為false後不會在頂部顯示錯誤日誌徽標
      developmentOff: true // 設為true後在開發環境不會收集錯誤信息，方便開發中排查錯誤
    }
  }
}
