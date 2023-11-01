import React, {Component} from 'react';
import Resistor from '../Shapes/Patterns/Resistor';
import Capacitor from '../Shapes/Patterns/Capacitor';
import Inductor from '../Shapes/Patterns/Inductor';
import UseResistor from '../Shapes/UseShapes/UseResistor';
import UseCapacitor from '../Shapes/UseShapes/UseResistor';
import UseInductor from '../Shapes/UseShapes/UseResistor';

class Shape extends Component {
    WidthElement = 50;
    HeightElement = 50;
    
    renderElements(param) {
        switch(param) {
            case 'Resistor':
                return (
                    <svg 
                         className='shape_image' 
                         viewBox={[0, 0, 250, 100].join(' ')}
                         width={this.WidthElement} 
                         height={this.HeightElement}>
                        <Resistor id="ResistorSymbolPicture" />
                        <UseResistor href="#ResistorSymbolPicture" x="0" y="0" canNotDraggable="true" />
                    </svg>
                );
            case 'Capacitor':
                return (
                    <svg 
                        className='shape_image' 
                        viewBox={[0, 0, 125, 150].join(' ')}
                        width='125'
                        height='150'>
                        <Capacitor id="CapacitorSymbolPicture" />
                        <UseCapacitor href="#CapacitorSymbolPicture" x="0" y="0" canNotDraggable="true" />
                    </svg>
                );
            case 'Inductor':
                return (
                    <svg 
                        className='shape_image'
                         viewBox={[0, 0, 300, 75].join(' ')}
                         width='300'
                         height='75'>
                        <Inductor id="InductorSymbolPicture" />
                        <UseInductor href="#InductorSymbolPicture" x="0" y="0" canNotDraggable="true" />
                    </svg>
                );
            default:
                return 'Element not found';
        }
    }
    
    render() {
        return (
            <button className='horizontal_content shape_button' onClick={() => this.props.onAddShape(this.props.name)}>
                {this.renderElements(this.props.name)}
                <p className='shape_name'>{this.props.name}</p>
            </button>
        );
    }
}

export default Shape;