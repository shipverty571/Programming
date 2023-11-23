import React, {Component} from 'react';
import PropTypes from "prop-types";
import {CapacitorSize} from "../../../Resources/ShapesSizes";

/**
 * Компонент конденсатора.
 */
class Capacitor extends Component {
    render() {
        return (
            <symbol width={CapacitorSize.width} height={CapacitorSize.height} id={this.props.id}>
                <rect 
                    x='0' 
                    y='0' 
                    fillOpacity='0' 
                    width={CapacitorSize.width} 
                    height={CapacitorSize.height - 50} 
                    id='SelectingRect' 
                    stroke='#0078D7'
                />
                <g>
                    <line x1='62.5' x2='62.5' y1='0' y2='100' strokeWidth='3' strokeDasharray='none' />
                    <line x1='87.5' x2='87.5' y1='0' y2='100' strokeWidth='3' strokeDasharray='none' />
                    <line x1='0' x2='62.5' y1='50' y2='50' strokeWidth='3' strokeDasharray='none' />
                    <line x1='87.5' x2='150' y1='50' y2='50' strokeWidth='3' strokeDasharray='none' />
                </g>
            </symbol>
        );
    }
}
Capacitor.propTypes = {
    id: PropTypes.string.isRequired
}

export default Capacitor;