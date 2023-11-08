import React, {Component} from 'react';

class MenuOperations extends Component {
    
    deleteElement() {
        
    }
    
    render() {
        return (
            <div className="horizontal-content menu-operations">
                <button id='turn-left-element-button' />
                <button id='turn-right-element-button' />
                {this.props.element && (
                    <button id='delete-element-button' />
                )}
            </div>
        );
    }
}

export default MenuOperations;