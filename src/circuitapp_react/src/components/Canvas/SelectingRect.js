import React, {Component} from 'react';
import PropTypes from "prop-types";

/**
 * Компонент прямоугольника для фокуса множества элементов.
 */
class SelectingRect extends Component {
    render() {
        return (
            <rect 
                stroke='black' 
                id='SelectingRect' 
                strokeWidth='1'
                fill='#0078D7'
                fillOpacity='0.3'
                width={this.props.width} 
                height={this.props.height} 
                x={this.props.x} 
                y={this.props.y} 
            />
        );
    }
}
SelectingRect.propTypes = {
    width: PropTypes.number.isRequired,
    height: PropTypes.number.isRequired,
    x: PropTypes.number.isRequired,
    y: PropTypes.number.isRequired
}

export default SelectingRect;