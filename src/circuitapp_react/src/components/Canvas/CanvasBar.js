import React, {Component} from 'react';
import CanvasPages from './CanvasPages';
import Canvas from './Canvas'
import PropTypes from "prop-types";
import MenuOperations from "./MenuOperations";

/**
 * Компонент правой колонки для работы с канвасом.
 */
class CanvasBar extends Component {
    /**
     * Создает экземпляр класса CanvasBar.
     * @param props Свойства.
     */
    constructor(props) {
        super(props);
        this.state = {
            element: null
        }
        
        this.setSelectedElementInState = this.setSelectedElementInState.bind(this);
        this.removeElement = this.removeElement.bind(this);
        this.rotateElement = this.rotateElement.bind(this);
    }

    /**
     * Изменяет состояние текущего класса.
     * @param elem Элемент, на который необходимо заменить.
     */
    setSelectedElementInState(elem) {
        this.setState({ element: elem });
    }

    /**
     * Удаляет элемент из канваса.
     */
    removeElement() {
        if (!this.state.element) return;

        this.state.element.remove();
        this.setSelectedElementInState(null);
    }

    /**
     * Поворачивает элемент.
     */
    rotateElement() {
        if (!this.state.element) return;
        
        let nameSymbol =
            this.state.element.getAttribute('href').replace('#', '');
        let symbol = document.getElementById(nameSymbol);
        let x = Math.floor(this.state.element.getAttribute('x'));
        let y = Math.floor(this.state.element.getAttribute('y'));
        let centerX = Math.floor(symbol.getAttribute('width')) / 2;
        let centerY = Math.floor(symbol.getAttribute('height')) / 2;
        let rotate = this.state.element.getAttribute('transform');
        if (rotate) {
            rotate = rotate.match(/rotate\((\d+)(.+)\)/);
            rotate = (Math.floor(rotate.slice(1)[0]) + 90) % 360;
        }
        else{
            rotate = 90;
        }
        this.state.element.setAttribute('transform', `rotate(${rotate} ${x+centerX} ${y+centerY})`);
    }
    
    render() {
        return (
            <div style={{ display: 'flex', flexGrow: 1, flexDirection: 'column' }}>
                {this.state.element && (
                    <MenuOperations removeElement={this.removeElement} rotateElement={this.rotateElement} />
                )}
                <Canvas 
                    patterns={this.props.patterns} 
                    shapes={this.props.shapes} 
                    widthRect={this.props.widthRect} 
                    heightRect={this.props.heightRect}
                    setSelectedElementInState={this.setSelectedElementInState}
                    refs={this.props.refs}
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