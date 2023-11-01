import React, {Component} from 'react';
import RotateImage from './reload_90x90_black.png'

class RotateButton extends Component {
    render() {
        return (
            <g>
                <image x={this.props.startX} y={this.props.startY} width='16' height='16' href={RotateImage} />
            </g>
        );
    }
}

export default RotateButton;