import React, { Component } from 'react'
import style from './styles/layout.less'
import ToolBar from './../components/ToolBar/ToolBar'
import TextSectionLayout from './TextSectionLayout'

export default class Layout extends Component {
  render() {
    return (
      <div className={style.main}>
        <ToolBar />
        <TextSectionLayout />
      </div>
    )
  }
}
