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

        const id = this.state.element.props.id;
        this.props.onRemoveShape(id);
        this.setSelectedElementInState(null);
    }

    /**
     * Поворачивает элемент.
     */
    rotateElement() {
        if (!this.state.element) return;
        
        this.state.element.changeRotate();
        
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
                <CanvasPages pages={this.props.pages} />
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