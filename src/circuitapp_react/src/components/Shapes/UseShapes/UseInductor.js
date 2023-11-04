import React, {Component} from 'react';
import PropTypes from "prop-types";

/**
 * Компонент для использования шаблона катушки индуктивности.
 */
class UseInductor extends Component {
    render() {
        return (
            <use 
                x={this.props.x} 
                y={this.props.y} 
                href={this.props.href} 
                className='draggable' 
                style={{ cursor: this.props.canNotDraggable ? 'default' : 'move' }}
                stroke="black"
            />
        );
    }
}
UseInductor.propTypes = {
    x: PropTypes.number,
    y: PropTypes.number,
    href: PropTypes.string.isRequired,
    canNotDraggable: PropTypes.bool
}
UseInductor.defaultProps = {
    x: 0,
    y: 0,
    canNotDraggable: false
}

export default UseInductor;