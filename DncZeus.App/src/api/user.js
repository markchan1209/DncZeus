import _axios from 'axios'
import config from '@/config'
import axios from '@/libs/api.request'

const authUrl = process.env.NODE_ENV === 'development' ? config.authUrl.dev : config.authUrl.pro

export const login = ({
  userName,
  password
}) => {
  return _axios.get(authUrl + '?username=' + userName + '&password=' + password)
}

export const getUserInfo = (token) => {
  return axios.request({
    url: 'account/profile',
    method: 'get',
    //是否在請求資源中添加資源的前綴
    withPrefix: false,  //設置為true或者不設置此屬性，將默認添加配置文件config.baseUrl.defaultPrefix的前綴，如果設置下面這個屬性[prefix]，默認配置文件中的默認前綴將不生效
    //請求資源的前綴重寫
    prefix:"api/v1/"    //設此屬性權重最高，將覆蓋配置文件[baseUrl.defaultPrefix]中的前綴，withPrefix對此屬性不起作用(也就是說只要設置了此屬性，都將在請求中添加設置的前綴)
  })
}

export const logout = (token) => {
  return new Promise((resolve, reject) => {
    resolve()
  })
}

export const getUnreadCount = () => {
  return axios.request({
    url: 'message/count',
    hideError: false,
    method: 'get'
  })
}

export const getMessage = () => {
  return axios.request({
    url: 'message/init',
    method: 'get'
  })
}

export const getContentByMsgId = msg_id => {
  return axios.request({
    url: 'message/content/' + msg_id,
    method: 'get'
  })
}

export const hasRead = msg_id => {
  return axios.request({
    url: 'message/has_read/' + msg_id,
    method: 'get',
  })
}

export const removeReaded = msg_id => {
  return axios.request({
    url: 'message/remove_readed/' + msg_id,
    method: 'get'
  })
}

export const restoreTrash = msg_id => {
  return axios.request({
    url: 'message/restore/' + msg_id,
    method: 'get'
  })
}
