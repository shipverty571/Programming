import React, {Component} from 'react';
import PropTypes from "prop-types";
import {ResistorSize} from "../../../Resources/ShapesSizes";

/**
 * Компонент резистора.
 */
class Resistor extends Component {
    render() {
        return (
            <symbol width={ResistorSize.width} height={ResistorSize.height} id={this.props.id}>
                <rect 
                    x='0' 
                    y='0' 
                    fillOpacity='0' 
                    width={ResistorSize.width} 
                    height={ResistorSize.height - 50} 
                    id='SelectingRect' 
                    stroke='#0078D7'
                />
                <g>
                    <rect 
                        x='50' 
                        y='25' 
                        width='150' 
                        height='50' 
                        fill='none' 
                        strokeWidth='3' 
                        strokeDasharray='none'
                    />
                    <line x1='0' x2='50' y1='50' y2='50' strokeWidth='3' strokeDasharray='none' />
                    <line x1='200' x2='250' y1='50' y2='50' strokeWidth='3' strokeDasharray='none' />
                </g>
            </symbol>
        );
    }
}
Resistor.propTypes = {
    id: PropTypes.string.isRequired
}

export default Resistor;