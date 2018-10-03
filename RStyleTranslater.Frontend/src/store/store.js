import {createStore, combineReducers, applyMiddleware, compose} from 'redux'
import logger from 'redux-logger'
import promiseMiddleware from 'redux-promise-middleware'

//Reducers 
import languagesSettingsReducer from '../reducers/LanguagesSettingsReducer'
import {textReducer} from '../reducers/TextReducer'

const middleware = applyMiddleware(promiseMiddleware(), logger())

const reducers = combineReducers({ 
  languagesSettingsStore : languagesSettingsReducer,
  textStore: textReducer
})

//подключение Redux-DevTools
const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose
const store = createStore(reducers, composeEnhancer(
  middleware
))

export default store