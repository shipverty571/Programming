import React, {Component} from 'react';
import PropTypes from "prop-types";

/**
 * Компонент прямоугольника для фокуса множества элементов.
 */
class SelectingRect extends Component {
    constructor(props) {
        super(props);
        this.state = {
            width: 0,
            height: 0,
            x: 0,
            y: 0
        }
        
        this.setSize = this.setSize.bind(this);
    }
    
    setSize(x, y, width, height) {
        this.setState({ x: x, y: y, width: width, height: height });
    }
    
    render() {
        return (
            <rect 
                stroke='black' 
                id='SelectingRect' 
                strokeWidth='1'
                fill='#0078D7'
                fillOpacity='0.3'
                width={this.state.width} 
                height={this.state.height} 
                x={this.state.x} 
                y={this.state.y} 
            />
        );
    }
}

export default SelectingRect;