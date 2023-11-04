import React, {Component} from 'react';
import PropTypes from "prop-types";

/**
 * Компонент конденсатора.
 */
class Capacitor extends Component {
    render() {
        return (
            <symbol width='150' height='100' id={this.props.id}>
                <rect x='0' y='0' fillOpacity='0' width='150' height='100' id='SelectingRect' stroke='#0078D7' />
                <g>
                    <line x1='67.5' x2='67.5' y1='0' y2='100' strokeWidth='3' strokeDasharray='none' />
                    <line x1='92.5' x2='92.5' y1='0' y2='100' strokeWidth='3' strokeDasharray='none' />
                    <line x1='0' x2='67.5' y1='50' y2='50' strokeWidth='3' strokeDasharray='none' />
                    <line x1='92.5' x2='165' y1='50' y2='50' strokeWidth='3' strokeDasharray='none' />
                </g>
            </symbol>
        );
    }
}
Capacitor.propTypes = {
    id: PropTypes.string.isRequired
}

export default Capacitor;