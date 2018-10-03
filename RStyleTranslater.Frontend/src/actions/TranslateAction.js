import {TRANSLATE, CHECK_TRANSLATER_SERVICE} from './../constants/constants'
import axios from 'axios'

export const translate = (translateRequest) => ({
  type: TRANSLATE,
  payload: axios.post("/translate/", translateRequest)
})

export const checkTranslaterService = () => ({
  type: CHECK_TRANSLATER_SERVICE,
  payload: axios.get("/translate/check")
})