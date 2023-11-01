import React, {Component} from 'react';

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
                y={this.props.y} />
        );
    }
}

export default SelectingRect;