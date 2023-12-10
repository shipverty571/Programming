import React, {Component} from 'react';
import CanvasPages from './CanvasPages';
import Canvas from './Canvas'
import PropTypes from "prop-types";
import MenuOperations from "./MenuOperations";
import {type} from "@testing-library/user-event/dist/type";

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
            element: null,
            centerX: null,
            centerY: null
        }
        
        this.setSelectedElementInState = this.setSelectedElementInState.bind(this);
        this.removeElement = this.removeElement.bind(this);
        this.rotateElement = this.rotateElement.bind(this);
        this.setCenterRotate = this.setCenterRotate.bind(this);
    }

    /**
     * Изменяет состояние текущего класса.
     * @param elem Элемент, на который необходимо заменить.
     */
    setSelectedElementInState(elem) {
        this.setState({ element: elem });
    }

    setCenterRotate(x, y) {
        this.setState({ centerX: x, centerY: y });
    }

    /**
     * Удаляет элемент из канваса.
     */
    removeElement() {
        if (!this.state.element) return;

        let length = this.state.element.length;
        if (!length) {
            const id = this.state.element.props.id;
            this.props.onRemoveShape(id);
        } else {
            for (let element of this.state.element) {
                const id = element.props.id;
                this.props.onRemoveShape(id);
            }
        }
        this.setSelectedElementInState(null);
        
    }

    /**
     * Поворачивает элемент.
     */
    rotateElement() {
        if (!this.state.element) return;
        
        let length = this.state.element.length;
        if (!length) {
            this.state.element.rotate();
        } else {
            for (let element of this.state.element) {
                element.rotate(this.state.centerX, this.state.centerY);
            }
        }
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
                    setNewPropsShape={this.props.setNewPropsShape}
                    activePageId={this.props.activePageId}
                    setCenterRotate={this.setCenterRotate}
                    newShapeDrag={this.props.newShapeDrag}
                    newShapeDragName={this.props.newShapeDragName}
                    onAddShape={this.props.onAddShape}
                />
                <CanvasPages 
                    pages={this.props.pages} 
                    onAddPage={this.props.onAddPage} 
                    onRemovePage={this.props.onRemovePage}
                    setActivePage={this.props.setActivePage}
                    activePageId={this.props.activePageId}
                    canNotRemovePage={this.props.canNotRemovePage}
                />
            </div>
        );
    }
}
CanvasBar.propTypes = {
    patterns: PropTypes.array.isRequired,
    shapes: PropTypes.array.isRequired
}

export default CanvasBar;