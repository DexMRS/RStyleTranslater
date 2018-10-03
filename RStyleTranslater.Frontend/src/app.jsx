import React from 'react'
import {render} from 'react-dom'
import Layout from './layouts/Layout'
import {Provider} from 'react-redux'
import store from './store/store'
import axiosConfig from './axiosConfig'

let app = document.getElementById('app')
axiosConfig()

render(
  <Provider store={store}>
    <Layout />
  </Provider>
  , app)
