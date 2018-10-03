import * as constants from '../constants/constants'

const initialState = {
  sourceText: "",
  destText: "",
  isDownloadButtonDisabled: true,
  serviceIsLive: true
}

export const textReducer = (state = initialState, action) => {
  switch(action.type) {
    case constants.TRANSLATE_FULFILLED: 
      return { 
        ...state,
        isLoading: false,
        destText: action.payload.data.text[0],
        isDownloadButtonDisabled: action.payload.data.text[0] === "" || state.sourceText === ""
      }

    case constants.CHECK_TRANSLATER_SERVICE_FULFILLED: 
      return {
        ...state,
        isLoading: false,
        serviceIsLive: action.payload.data
      }

    case constants.TRANSLATE_PENDING: 
    case constants.CHECK_TRANSLATER_SERVICE_PENDING:
      return {
        ...state,
        isLoading: true,
        isDownloadButtonDisabled: true
      }

    case constants.CHECK_TRANSLATER_SERVICE_REJECTED: 
      return {
        ...state,
        serviceIsLive: false
      }

    case constants.TRANSLATE_REJECTED: 
      return { 
        ...state,
        isLoading: false,
        error_message: action.payload.message,
        isDownloadButtonDisabled: true,
      }

    case constants.SET_SOURCE_TEXT:
      return {
        ...state,
        sourceText: action.payload
      }

    default: return state
  }
}