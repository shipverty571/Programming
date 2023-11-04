import React, {Component} from 'react';
import CanvasPages from './CanvasPages';
import Canvas from './Canvas'
import PropTypes from "prop-types";

/**
 * Компонент правой колонки для работы с канвасом.
 */
class CanvasBar extends Component {
    render() {
        return (
            <div style={{ display: 'flex', flexGrow: 1, flexDirection: 'column' }}>
                <Canvas 
                    patterns={this.props.patterns} 
                    shapes={this.props.shapes} 
                    widthRect={this.props.widthRect} 
                    heightRect={this.props.heightRect} 
                />
                <CanvasPages />
            </div>
        );
    }
}
CanvasBar.propTypes = {
    patterns: PropTypes.array.isRequired,
    shapes: PropTypes.array.isRequired,
    widthRect: PropTypes.number.isRequired,
    heightRect: PropTypes.number.isRequired
}

export default CanvasBar;