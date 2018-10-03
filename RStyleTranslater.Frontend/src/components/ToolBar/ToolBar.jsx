import React, { Component } from 'react'
import style from './styles/toolBar.less'
import LanguageSelector from '../LanguageSelect/LanguageSelector'
import * as LanguagesSettingsActions from './../../actions/LanguagesSettingsActions'
import * as TranslateAction from './../../actions/TranslateAction'
import { connect } from 'react-redux'
import axios from 'axios'

export class ToolBar extends Component {
  componentDidMount() {
    this.props.dispatch(LanguagesSettingsActions.getDestLanguages(this.props.sourceLanguage))
    this.props.dispatch(LanguagesSettingsActions.getSourceLanguages(this.props.destinationLanguage))
  }

  changeSourceLanguage(event) {
      let newSourceLanguage = this.props.sourceLanguagesList.filter(x => x.code == event.target.value).length != 0
        ? this.props.sourceLanguagesList.filter(x => x.code == event.target.value)[0]
        : null
      
      this.props.dispatch(LanguagesSettingsActions.setSourceLanguage(
        newSourceLanguage,
        this.props.sourceLanguage,
      ))
  }

  changeDestLanguage(event) {
    let newDestinationLanguage = this.props.destinationLanguagesList.filter(x => x.code == event.target.value).length != 0 
      ? this.props.destinationLanguagesList.filter(x => x.code == event.target.value)[0]
      : null
    this.props.dispatch(LanguagesSettingsActions.setDestLanguage(
      newDestinationLanguage,
      this.props.destinationLanguage,
    ))
  }

  switchLanguage(event) {
    this.props.dispatch(LanguagesSettingsActions.switchLanguage( this.props.sourceLanguage, this.props.destinationLanguage ))
  }

  translate() {
    const translateRequest = {
      Lang: `${this.props.sourceLanguage.code}-${this.props.destinationLanguage.code}`,
      Text: `${this.props.sourceText}`
    }
    this.props.dispatch(TranslateAction.translate(translateRequest))
  }

  download({sourceLanguage, sourceText, destinationLanguage, destText} = this.props) {
    const downloadRequest = {
      SourceText: {
        Language: sourceLanguage,
        Content: sourceText
      },
      DestinationText: {
        Language: destinationLanguage,
        Content: destText
      }
    }
  
    axios({
      url: "/formatTo/xml", 
      method : 'POST',
      data:  downloadRequest,
      responseType: 'blob'
    }).then((response)=>{
      const url = window.URL.createObjectURL(new Blob([response.data]))
      const link = document.createElement('a')
      link.href = url
      link.setAttribute('download', `translate-${new Date().getTime()}.xml`)
      document.body.appendChild(link)
      link.click()
    })
  }

  render() {
    if (this.props.isLoading)
      return null
    if(!this.props.isLoading && this.props.error_message)
      return <h1>Что то пошло не так: {this.props.error_message}</h1>

    return (
      <div className={style.topBar}>
        <h1>Rstyle translater</h1>
        <LanguageSelector sourceLabel="From" sourceItems={this.props.sourceLanguagesList}
                           changeSourceLanguageEvent={(e) => {this.changeSourceLanguage(e)}}
                           selectedSource={this.props.sourceLanguage}

                           switchLanguage={ (e) => this.switchLanguage(e)}

                           destLabel="To" destItems={this.props.destinationLanguagesList}
                           changeDestLanguageEvent={(e) => {this.changeDestLanguage(e)}} 
                           selectedDest={this.props.destinationLanguage}/>
        <button onClick={()=>this.translate()} disabled={!this.props.serviceIsLive}>
          Перевести 
        </button>
        <button onClick={()=>this.download()} disabled={this.props.isDownloadButtonDisabled}>
          Скачать
        </button>
      </div>
    )
  }
}

const mapStateToProps = (store) => ({
  sourceLanguagesList: store.languagesSettingsStore.sourceLanguagesList,
  destinationLanguagesList: store.languagesSettingsStore.destinationLanguagesList,
  sourceLanguage: store.languagesSettingsStore.sourceLanguage,
  destinationLanguage: store.languagesSettingsStore.destinationLanguage,

  sourceText: store.textStore.sourceText,
  destText: store.textStore.destText,
  isDownloadButtonDisabled: store.textStore.isDownloadButtonDisabled,
  serviceIsLive: store.textStore.serviceIsLive,

  isLoading: store.languagesSettingsStore.isLoading,
  error_message: store.languagesSettingsStore.error_message
})

export default connect(mapStateToProps)(ToolBar)