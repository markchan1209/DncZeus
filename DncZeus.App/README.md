<p align="center">
    <a href="https://www.iviewui.com">
        <img width="200" src="https://file.iviewui.com/logo-new.svg">
    </a>
</p>

# iView Admin
[![](https://img.shields.io/travis/iview/iview-admin.svg?style=flat-square)](https://travis-ci.org/iview/iview-admin)
[![vue](https://img.shields.io/badge/vue-2.5.10-brightgreen.svg?style=flat-square)](https://github.com/vuejs/vue)
[![iview ui](https://img.shields.io/badge/iview-3.0.0-brightgreen.svg?style=flat-square)](https://github.com/iview/iview)
[![npm](https://img.shields.io/npm/l/express.svg)]()


## 當前版本：v2.0-beta.3
[更新日誌](https://github.com/iview/iview-admin/releases)

[使用文檔](https://lison16.github.io/iview-admin-doc/#/)

[在線訪問](https://admin.iviewui.com/)

[簡化版模板](https://github.com/iview/iview-admin/tree/template)

`註：在線版本會在開發版本新小版本發佈後更新到相應版本，所以如果想體驗最新版本iview-admin，請clone完整項目代碼到本地運行。`

## Install
```bush
// install dependencies
npm install
```
## Run
### Development
```bush
npm run dev
```
### Production(Build)
```bush
npm run build
```

## 簡介
&emsp;&emsp;iView admin是基於Vue.js，搭配使用[iView](https://www.iviewui.com) UI組件庫形成的一套後台集成解決方案，由TalkingData前端可視化團隊部分成員開發維護。iView admin遵守iView設計和開發約定，風格統一，設計考究，並且更多功能在不停開發中。
如果您想查看iview-admin的更新動態，您可以到[更新日誌](https://github.com/iview/iview-admin/releases)查看瞭解最新更新；如果您是新手，想快速入手iview-admin，您可以到[使用教程](https://github.com/iview/iview-admin/wiki)查看講解；如果您想在線體驗iview-admin，您可以到[在線訪問](https://admin.iviewui.com/)體驗。如果你只是想要一個清醒爽朗的界面，那你可以下載[簡化版模板](https://github.com/iview/iview-admin/tree/template)來做開發。

## 功能

- 登錄/登出
- 權限管理
    - 列表過濾
    - 權限切換
- 多語言切換
- 組件
    - 富文本編輯器
    - Markdown編輯器
    - 城市級聯
    - 圖片預覽編輯
    - 可拖拽列表
    - 文件上傳
    - 數字漸變
    - split-pane
- 表單編輯
    - 文章發佈
    - 工作流
- 表格
    - 可拖拽排序
    - 可編輯表格
        - 行內編輯
        - 單元格編輯
    - 可搜索表格
    - 表格導出數據
        - 導出為Csv文件
        - 導出為Xls文件
    - 表格轉圖片
- 錯誤頁面
    - 403頁面
    - 404頁面
    - 500頁面
- 高級路由
    - 動態路由
    - 帶參頁面
- 換膚
- 收縮側邊欄
- tag標籤導航
- 麵包屑導航
- 全屏/退出全屏
- 鎖屏
- 消息中心
- 個人中心

## 文件結構
```shell
.
├── build  項目構建配置
├── config  開發相關配置
├── public  打包所需靜態資源
└── src
    ├── api  AJAX請求
    └── assets  項目靜態資源
        ├── icons  自定義圖標資源
        └── images  圖片資源
    ├── components  業務組件
    ├── config  項目運行配置
    ├── directive  自定義指令
    ├── libs  封裝工具函數
    ├── locale  多語言文件
    ├── mock  mock模擬數據
    ├── router  路由配置
    ├── store  Vuex配置
    ├── view  頁面文件
    └── tests  測試相關
```

## Links

- [TalkingData](https://github.com/TalkingData)
- [iView](https://github.com/iview/iview)
- [Vue](https://github.com/vuejs/vue)
- [Webpack](https://github.com/webpack/webpack)

## 效果展示

- 響應式佈局首頁
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/home.gif)

- 標籤導航
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/page-tags.gif)

- 權限管理
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/access.gif)

- 可拖拽列表
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/dragable-list.gif)

- 圖片預覽編輯
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/image-editor.gif)

- 文件上傳
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/upload.gif)

- 數字漸變
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/count-to.gif)

- split-pane
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/split-pane.gif)

- 文章發佈
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/article-publish.gif)

- 工作流
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/workflow.gif)

- 可拖拽表格
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/dragable-table.gif)

- 可編輯表格
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/editable-table.gif)

- 表格導出數據
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/exportable-table.gif)

- 表格轉圖片
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/table2image.gif)

- 錯誤頁面
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/error-page.gif)

- 鎖屏
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/locking.gif)

- 可收縮側邊欄
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/sidebarmenu.gif)

- 主題切換
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/theme.gif)

- 消息中心
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/message.gif)

### ߒ氟■If you find this project helpful, maybe you can buy me a coffee. ߒ氟▍
![image](https://github.com/iview/iview-admin/raw/dev/github-gif/code.png)


## License
[MIT](http://opensource.org/licenses/MIT)

Copyright (c) 2016-present, iView
