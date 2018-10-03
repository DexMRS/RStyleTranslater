import React, { Component } from 'react'

export default class LanguageSelector extends Component {
  render() {  
    return (
      <div>
        <span>{this.props.sourceLabel}</span>
        <select onChange={(e) => this.props.changeSourceLanguageEvent(e)} defaultValue={this.props.selectedSource.code}>
          {this.props.sourceItems.map((item,index) => {
            return <option key={index} 
                          value={item.code}>
                          {item.languageName}
                  </option>
            })}
        </select>
        <button onClick={(e) => {this.props.switchLanguage(e)}}>switch</button>
        <span>{this.props.destLabel}</span>
        <select onChange={(e) => this.props.changeDestLanguageEvent(e)} defaultValue={this.props.selectedDest.code}>
          {this.props.destItems.map((item,index) => {
            return <option key={index} 
                          value={item.code}>
                          {item.languageName}
                  </option>
            })}
        </select>
      </div>
    )
  }
}