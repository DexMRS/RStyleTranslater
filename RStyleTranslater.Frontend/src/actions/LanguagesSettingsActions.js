import { GET_SOURCE_LANGUAGES,
         CHANGE_SOURCE_LANGUAGE,
         CHANGE_DEST_LANGUAGE,
         GET_DEST_LANGUAGES,
         SWITCH_LANGUAGES } from './../constants/constants'
import axios from 'axios'

export const getSourceLanguages = (destLanguage) => ({
  type: GET_SOURCE_LANGUAGES,
  payload: axios.post("/Languages/getsourcelanguages", destLanguage)
 })

export const setSourceLanguage = (sourceLanguage, oldSourceLanguage) => ({
  type: CHANGE_SOURCE_LANGUAGE,
  payload: {sourceLanguage: sourceLanguage === null ? oldSourceLanguage : sourceLanguage }
})

export const setDestLanguage = (destinationLanguage, oldDestinationLanguage) => ({
  type: CHANGE_DEST_LANGUAGE,
  payload: {destinationLanguage: destinationLanguage === null ? oldDestinationLanguage : destinationLanguage }
})

export const getDestLanguages = (sourceLanguage) => ({
    type: GET_DEST_LANGUAGES,
    payload: axios.post("/Languages/getdestlanguages", sourceLanguage)
})

export const switchLanguage = (source, dest) => ({
  type: SWITCH_LANGUAGES,
  payload: axios.all([axios.post("/Languages/getdestlanguages", dest),
                      axios.post("/Languages/getsourcelanguages", source),
                      dest,
                      source])
})