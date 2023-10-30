import React, {Component} from 'react';
import CanvasPages from "./CanvasPages";
import Canvas from "./Canvas"

class CanvasBar extends Component {
    render() {
        return (
            <div style={{display: "flex", flexGrow: 1, flexDirection: "column"}}>
                <Canvas 
                    patterns={this.props.patterns} 
                    shapes={this.props.shapes} 
                    widthRect={this.props.widthRect} 
                    heightRect={this.props.heightRect}/>
                <CanvasPages />
            </div>
        );
    }
}

export default CanvasBar;