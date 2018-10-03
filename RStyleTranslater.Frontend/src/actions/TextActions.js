import { SET_SOURCE_TEXT } from './../constants/constants'

export const setSourceText = (newSourceText) => ({
  type: SET_SOURCE_TEXT,
  payload: newSourceText
})

