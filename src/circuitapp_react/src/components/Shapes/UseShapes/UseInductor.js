import React, {Component} from 'react';
import PropTypes from "prop-types";

class UseInductor extends Component {
    render() {
        return (
            <use 
                x={this.props.x} 
                y={this.props.y} 
                href={this.props.href} 
                className='draggable' 
                style={{ cursor: this.props.canNotDraggable && 'default' }} />
        );
    }
}
UseInductor.propTypes = {
    x: PropTypes.number.isRequired,
    y: PropTypes.number.isRequired,
    href: PropTypes.string.isRequired,
    canNotDraggable: PropTypes.bool
}
UseInductor.defaultProps = {
    canNotDraggable: false
}

export default UseInductor;