import React, {Component} from 'react';

class MenuOperations extends Component {
    render() {
        return (
            <div className="horizontal-content menu-operations">
                <button id='turn-left-element-button' />
                <button id='turn-right-element-button' />
                <button id='delete-element-button' onClick={() => this.props.removeElement()} />
            </div>
        );
    }
}

export default MenuOperations;