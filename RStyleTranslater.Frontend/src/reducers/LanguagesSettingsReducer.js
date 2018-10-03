import * as constants from './../constants/constants'

const initialState = {
    sourceLanguage: {
        code: "ru",
        languageName: "русский"
    },
    sourceLanguagesList: [],
    destinationLanguage: {
        code: "en",
        languageName: "английский"
    },
    destinationLanguagesList: [],
    isLoading: false
}

export default(state = initialState, action) => {
  switch (action.type) {
    case constants.GET_SOURCE_LANGUAGES_PENDING:
    case constants.GET_DEST_LANGUAGES_PENDING:
    case constants.SWITCH_LANGUAGES_PENDING:
      return { ...state, isLoading: true}

    case constants.GET_SOURCE_LANGUAGES_REJECTED:
    case constants.GET_DEST_LANGUAGES_REJECTED:
    case constants.SWITCH_LANGUAGES_REJECTED:
      return { ...state, isLoading: false, error_message: action.payload.message}

    case constants.GET_SOURCE_LANGUAGES_FULFILLED:
      return { 
        ...state,
        isLoading: false,
        sourceLanguagesList: action.payload.data
      }
    case constants.GET_DEST_LANGUAGES_FULFILLED:
      return {
        ...state,
        isLoading: false,
        destinationLanguagesList: action.payload.data
      }
    case constants.CHANGE_SOURCE_LANGUAGE: 
      return {
        ...state,
        sourceLanguage: action.payload.sourceLanguage
      }
    case constants.CHANGE_DEST_LANGUAGE:
      return {
        ...state,
        destinationLanguage: action.payload.destinationLanguage
      }

    case constants.SWITCH_LANGUAGES_FULFILLED:
      return {
        ...state,
        destinationLanguage: action.payload[3],
        sourceLanguage: action.payload[2],
        sourceLanguagesList: action.payload[1].data,
        destinationLanguagesList: action.payload[0].data,
        isLoading: false
      }

    default:  return state
  }
}