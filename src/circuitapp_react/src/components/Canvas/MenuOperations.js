import React, {Component} from 'react';

/**
 * Компонент с операциями над элементами.
 */
class MenuOperations extends Component {
    render() {
        return (
            <div className="horizontal-content menu-operations">
                <button id='rotate-element-button' onClick={() => this.props.rotateElement()} />
                <button id='delete-element-button' onClick={() => this.props.removeElement()} />
            </div>
        );
    }
}

export default MenuOperations;