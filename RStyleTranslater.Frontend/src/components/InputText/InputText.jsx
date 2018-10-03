import React, { Component } from 'react'
import style from './styles/inputText.less'
import * as TranslateAction from './../../actions/TranslateAction'
import { setSourceText } from './../../actions/TextActions'
import {connect} from 'react-redux'

export  class InputText extends Component {
  getText(e) {
    const translateRequest = {
      Lang: `${this.props.sourceLanguage.code}-${this.props.destinationLanguage.code}`,
      Text: e.target.value
    }
    
    this.props.dispatch(setSourceText(e.target.value))
    this.props.dispatch(TranslateAction.translate(translateRequest))
  }

  render() {
    return (
      <div>
        <textarea onBlur={e => this.getText(e)} className={style.textAreaClass} defaultValue={this.props.sourceText}>
        </textarea>
      </div>  
    )
  }
}

function mapStateToProps(store) {
  return {
    sourceLanguage: store.languagesSettingsStore.sourceLanguage,
    destinationLanguage: store.languagesSettingsStore.destinationLanguage,
    isLoading: false,
    sourceText: store.textStore.sourceText,
    destText: store.textStore.destText
  }
}

export default connect(mapStateToProps)(InputText)