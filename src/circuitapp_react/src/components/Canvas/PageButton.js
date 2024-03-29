﻿import React, {Component} from 'react';

class PageButton extends Component {
    constructor(props) {
        super(props);
        
        this.onChange = this.onChange.bind(this);
    }

    /**
     * Обработчик события изменения свойств у переключателя.
     */
    onChange() {
        this.props.setActivePage(this.props.id);
    }
    
    render() {
        return (
            <div id='page-block'>
                <input 
                    type='radio' 
                    value={this.props.id} 
                    name='pages-group' i
                    id={this.props.id} 
                    checked={this.props.activePageId === this.props.id} 
                    onChange={this.onChange}
                />
                <label htmlFor={this.props.id}>{this.props.name}</label>
            </div>
        );
    }
}

export default PageButton;