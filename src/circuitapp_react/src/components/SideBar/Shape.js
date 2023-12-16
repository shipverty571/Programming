import React, {Component} from 'react';
import Resistor from '../Shapes/Patterns/Resistor';
import Capacitor from '../Shapes/Patterns/Capacitor';
import Inductor from '../Shapes/Patterns/Inductor';
import UseResistor from '../Shapes/UseShapes/UseResistor';
import UseCapacitor from '../Shapes/UseShapes/UseResistor';
import UseInductor from '../Shapes/UseShapes/UseResistor';
import PropTypes from "prop-types";
import {CapacitorSize, InductorSize, ResistorSize} from "../../Resources/ShapesSizes";

/**
 * Компонент кнопки для создания элемента.
 */
class Shape extends Component {
    /**
     * Ширина элемента.
     * @type {number}
     * @private
     * @const
     */
    WidthElement = 50;
    
    /**
     * Высота элемента.
     * @type {number}
     * @private
     * @const
     */
    HeightElement = 50;

    /**
     * Хранит True, если на элемент нажали, инача False.
     * @type {boolean}
     */
    isDown = false;

    /**
     * Рендерит изображение элемента.
     * @param param Имя элемента.
     * @returns {JSX.Element|string} Возвращает svg-элемент.
     */
    // TODO Переделать с использованием УГО
    renderElements(param) {
        switch(param) {
            case 'Resistor':
                return (
                    <svg 
                         className='shape-image' 
                         viewBox={[0, 0, ResistorSize.width, ResistorSize.height - 50].join(' ')}
                         width={this.WidthElement} 
                         height={this.HeightElement}>
                        <Resistor id="ResistorSymbolPicture" />
                        <UseResistor 
                            href="#ResistorSymbolPicture" 
                            canNotDraggable={true}
                            width={ResistorSize.width}
                            height={ResistorSize.height}
                        />
                    </svg>
                );
            case 'Capacitor':
                return (
                    <svg 
                        className='shape-image' 
                        viewBox={[0, 0, CapacitorSize.width, CapacitorSize.height - 50].join(' ')}
                        width={this.WidthElement}
                        height={this.HeightElement} >
                        <Capacitor id="CapacitorSymbolPicture" />
                        <UseCapacitor 
                            href="#CapacitorSymbolPicture" 
                            canNotDraggable={true} 
                            width={CapacitorSize.width} 
                            height={CapacitorSize.height}
                        />
                    </svg>
                );
            case 'Inductor':
                return (
                    <svg 
                        className='shape-image'
                         viewBox={[0, 0, InductorSize.width, InductorSize.height - 25].join(' ')}
                        width={this.WidthElement}
                        height={this.HeightElement} >
                        <Inductor id="InductorSymbolPicture" />
                        <UseInductor 
                            href="#InductorSymbolPicture" 
                            canNotDraggable={true}
                            width={InductorSize.width}
                            height={InductorSize.height}
                        />
                    </svg>
                );
            default:
                return 'Element not found';
        }
    }

    /**
     * Срабатывает при нажатии на элемент.
     */
    onMouseDownShape() {
        this.isDown = true;
    }

    /**
     * Срабатывает при выходе мыши из области элемента.
     */
    onMouseLeaveShape() {
        if (!this.isDown) {
            return;
        }
        this.isDown = false;
        this.props.setIsMove(true);
        this.props.setAddShapeName(this.props.name);
    }
    
    render() {
        return (
            <button 
                className='horizontal-content shape-button' 
                onClick={() => {
                    this.isDown = false;
                    this.props.onAddShape(this.props.name);
                }} 
                onMouseDown={() => this.onMouseDownShape()}
                onMouseLeave={() => this.onMouseLeaveShape()}>
                {this.renderElements(this.props.name)}
                <p className='shape-name'>{this.props.name}</p>
            </button>
        );
    }
}
Shape.propTypes = {
    onAddShape: PropTypes.func.isRequired,
    name: PropTypes.string.isRequired,
}

export default Shape;