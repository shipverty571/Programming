import React, {Component} from 'react';
import CanvasPages from './CanvasPages';
import Canvas from './Canvas'
import PropTypes from "prop-types";
import MenuOperations from "./MenuOperations";

/**
 * Компонент правой колонки для работы с канвасом.
 */
class CanvasBar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            element: null
        }
        
        this.setSelectedElementInState = this.setSelectedElementInState.bind(this);
        this.removeElement = this.removeElement.bind(this);
    }
    
    setSelectedElementInState(elem) {
        this.setState({ element: elem });
    }

    removeElement() {
        console.log("ASDA")
        if (!this.state.element) return;

        this.state.element.remove();
        this.setSelectedElementInState(null);
    }
    
    render() {
        return (
            <div style={{ display: 'flex', flexGrow: 1, flexDirection: 'column' }}>
                {this.state.element && (
                    <MenuOperations removeElement={this.removeElement} />
                )}
                <Canvas 
                    patterns={this.props.patterns} 
                    shapes={this.props.shapes} 
                    widthRect={this.props.widthRect} 
                    heightRect={this.props.heightRect}
                    setSelectedElementInState={this.setSelectedElementInState}
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