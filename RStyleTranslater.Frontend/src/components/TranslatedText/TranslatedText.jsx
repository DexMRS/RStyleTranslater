import React, { Component } from 'react'
import style from './styles/translatedText.less'

export default class TranslatedText extends Component {
  render() {
    return (
      <div className={style.translatedText}>
        <p>{this.props.text}</p>
        {
          this.props.text === "" 
          ? null 
          : <p>Переведено сервисом <a href="http://translate.yandex.ru/" target="blank">«Яндекс.Переводчик»</a></p> 
        }
      </div>
    )
  }
}
