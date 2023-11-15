import React, {Component} from 'react';

class PageButton extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <div>
                <input type='radio' value={this.props.id} name='pages-group' id={this.props.id} />
                <label htmlFor={this.props.id}>{this.props.name}</label>
            </div>
        );
    }
}

export default PageButton;