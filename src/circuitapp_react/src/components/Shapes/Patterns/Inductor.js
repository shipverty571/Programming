import React, {Component} from 'react';
import PropTypes from "prop-types";
import {InductorSize} from "../../../Resources/ShapesSizes";

/**
 * Компонент катушки индуктивности.
 */
class Inductor extends Component {
    render() {
        return (
            <symbol width={InductorSize.width} height={InductorSize.height} id={this.props.id}>
                <rect 
                    x='0' 
                    y='0' 
                    fillOpacity='0' 
                    width={InductorSize.width} 
                    height={InductorSize.height - 25} 
                    id='SelectingRect' 
                    stroke='#0078D7'
                />
                <g>
                    <line x1='0' x2='50' y1='50' y2='50' strokeWidth='3' strokeDasharray='none' />
                    <line x1='250' x2='300' y1='50' y2='50' strokeWidth='3' strokeDasharray='none' />
                    <circle 
                        cx='75' 
                        cy='50' 
                        r='25' 
                        strokeWidth='3' 
                        strokeDasharray='78.53981633974483 78.53981633974483' 
                        strokeDashoffset='-78.53981633974483' 
                        fill='none' 
                    />
                    <circle 
                        cx='125' 
                        cy='50' 
                        r='25' 
                        strokeWidth='3' 
                        strokeDasharray='78.53981633974483 78.53981633974483' 
                        strokeDashoffset='-78.53981633974483' 
                        fill='none' 
                    />
                    <circle 
                        cx='175' 
                        cy='50' 
                        r='25' 
                        strokeWidth='3' 
                        strokeDasharray='78.53981633974483 78.53981633974483' 
                        strokeDashoffset='-78.53981633974483' 
                        fill='none' 
                    />
                    <circle 
                        cx='225' 
                        cy='50' 
                        r='25' 
                        strokeWidth='3' 
                        strokeDasharray='78.53981633974483 78.53981633974483' 
                        strokeDashoffset='-78.53981633974483' 
                        fill='none' 
                    />
                </g>
            </symbol>
        );
    }
}
Inductor.propTypes = {
    id: PropTypes.string.isRequired
}

export default Inductor;