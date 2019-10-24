import Main from '@/components/main'

/**
 * iview-admin中meta除了原生參數外可配置的參數:
 * meta: {
 *  title: { String|Number|Function }
 *         顯示在側邊欄、麵包屑和標籤欄的文字
 *         使用'{{ 多語言字段 }}'形式結合多語言使用，例子看多語言的路由配置;
 *         可以傳入一個回調函數，參數是當前路由對象，例子看動態路由和帶參路由
 *  hideInBread: (false) 設為true後此級路由將不會出現在麵包屑中，示例看QQ群路由配置
 *  hideInMenu: (false) 設為true後在左側菜單不會顯示該頁面選項
 *  notCache: (false) 設為true後頁面在切換標籤後不會緩存，如果需要緩存，無需設置這個字段，而且需要設置頁面組件name屬性和路由配置的name一致
 *  access: (null) 可訪問該頁面的權限數組，當前路由設置的權限會影響子路由
 *  icon: (-) 該頁面在左側菜單、麵包屑和標籤導航處顯示的圖標，如果是自定義圖標，需要在圖標名稱前加下劃線'_'
 *  beforeCloseName: (-) 設置該字段，則在關閉當前tab頁時會去'@/router/before-close.js'裡尋找該字段名對應的方法，作為關閉前的鉤子函數
 * }
 */

export const mainRouter = [{
    path: '/login',
    name: 'login',
    meta: {
      title: 'Login - 登錄',
      hideInMenu: true
    },
    component: () => import('@/view/login/login.vue')
  },
  {
    path: '/',
    name: '_home',
    redirect: '/home',
    component: Main,
    meta: {
      hideInMenu: true,
      notCache: true
    },
    children: [{
      path: '/home',
      name: 'home',
      meta: {
        hideInMenu: true,
        title: '首頁',
        notCache: true,
        icon: 'md-home'
      },
      component: () => import('@/view/single-page/home')
    }]
  },
  {
    path: '/message',
    name: 'message',
    component: Main,
    meta: {
      hideInBread: true,
      hideInMenu: true
    },
    children: [{
      path: 'message_page',
      name: 'message_page',
      meta: {
        icon: 'md-notifications',
        title: '消息中心'
      },
      component: () => import('@/view/single-page/message/index.vue')
    }]
  },
  {
    path: '/error_store',
    name: 'error_store',
    meta: {
      hideInBread: true
    },
    component: Main,
    children: [{
      path: 'error_store_page',
      name: 'error_store_page',
      meta: {
        icon: 'ios-bug',
        title: '錯誤收集'
      },
      component: () => import('@/view/error-store/error-store.vue')
    }]
  },
  {
    path: '/error_logger',
    name: 'error_logger',
    meta: {
      hideInBread: true,
      hideInMenu: true
    },
    component: Main,
    children: [{
      path: 'error_logger_page',
      name: 'error_logger_page',
      meta: {
        icon: 'ios-bug',
        title: '錯誤收集'
      },
      component: () => import('@/view/single-page/error-logger.vue')
    }]
  },
  {
    path: '/argu',
    name: 'argu',
    meta: {
      hideInMenu: true
    },
    component: Main,
    children: [{
        path: 'params/:id',
        name: 'params',
        meta: {
          icon: 'md-flower',
          title: route => `動態參數-${route.params.id}`,
          notCache: true,
          beforeCloseName: 'before_close_normal'
        },
        component: () => import('@/view/argu-page/params.vue')
      },
      {
        path: 'query',
        name: 'query',
        meta: {
          icon: 'md-flower',
          title: route => `查詢參數-${route.query.id}`,
          notCache: true
        },
        component: () => import('@/view/argu-page/query.vue')
      }
    ]
  },
  {
    path: '/401',
    name: 'error_401',
    meta: {
      hideInMenu: true
    },
    component: () => import('@/view/error-page/401.vue')
  },
  {
    path: '/500',
    name: 'error_500',
    meta: {
      hideInMenu: true
    },
    component: () => import('@/view/error-page/500.vue')
  },
  {
    path: '/404',
    name: 'error_404',
    meta: {
      hideInMenu: true
    },
    component: () => import('@/view/error-page/404.vue')
  }
]

export const appRouter = []

export default [
  ...mainRouter,
  ...appRouter
]
