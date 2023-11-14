import React, {Component} from 'react';
import Resistor from '../Shapes/Patterns/Resistor';
import Capacitor from '../Shapes/Patterns/Capacitor';
import Inductor from '../Shapes/Patterns/Inductor';
import UseResistor from '../Shapes/UseShapes/UseResistor';
import UseCapacitor from '../Shapes/UseShapes/UseResistor';
import UseInductor from '../Shapes/UseShapes/UseResistor';
import PropTypes from "prop-types";

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
     * Рендерит изображение элемента.
     * @param param Имя элемента.
     * @returns {JSX.Element|string} Возвращает svg-элемент.
     */
    renderElements(param) {
        switch(param) {
            case 'Resistor':
                return (
                    <svg 
                         className='shape-image' 
                         viewBox={[0, 0, 250, 100].join(' ')}
                         width={this.WidthElement} 
                         height={this.HeightElement}>
                        <Resistor id="ResistorSymbolPicture" />
                        <UseResistor 
                            href="#ResistorSymbolPicture" 
                            canNotDraggable={true}
                            width={250}
                            height={100}
                        />
                    </svg>
                );
            case 'Capacitor':
                return (
                    <svg 
                        className='shape-image' 
                        viewBox={[0, 0, 150, 100].join(' ')}
                        width={this.WidthElement}
                        height={this.HeightElement} >
                        <Capacitor id="CapacitorSymbolPicture" />
                        <UseCapacitor 
                            href="#CapacitorSymbolPicture" 
                            canNotDraggable={true} 
                            width={125} 
                            height={150}
                        />
                    </svg>
                );
            case 'Inductor':
                return (
                    <svg 
                        className='shape-image'
                         viewBox={[0, 0, 300, 75].join(' ')}
                        width={this.WidthElement}
                        height={this.HeightElement} >
                        <Inductor id="InductorSymbolPicture" />
                        <UseInductor 
                            href="#InductorSymbolPicture" 
                            canNotDraggable={true}
                            width={300}
                            height={75}
                        />
                    </svg>
                );
            default:
                return 'Element not found';
        }
    }
    
    render() {
        return (
            <button className='horizontal-content shape-button' onClick={() => this.props.onAddShape(this.props.name)}>
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