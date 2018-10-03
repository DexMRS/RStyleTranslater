import React, { Component } from 'react'
import InputText from './../components/InputText/InputText'
import TranslatedText from './../components/TranslatedText/TranslatedText'
import style from './styles/textSectionLayout.less'
import {connect} from 'react-redux'
import * as TranslateAction from './../actions/TranslateAction'

export class TextSectionLayout extends Component {
  componentDidMount() {
    this.props.dispatch(TranslateAction.checkTranslaterService())
  }

  render() {
    if (!this.props.serviceIsLive) 
      return <h1>Яндекс не доступен</h1>

    return (
        <div className={style.textSection}>
          <InputText text={this.props.sourceText} /> 
          {this.props.isLoading ? <h1 className={style.loadingMessage}>Загрузка...</h1> 
                                : <TranslatedText text={this.props.destText}/>}
        </div> 
    )
  }
}

function mapStateToProps(store){
  return {
    sourceText: store.textStore.sourceText,
    destText: store.textStore.destText,
    isLoading: store.textStore.isLoading,
    serviceIsLive: store.textStore.serviceIsLive
  }
}

export default connect(mapStateToProps)(TextSectionLayout)