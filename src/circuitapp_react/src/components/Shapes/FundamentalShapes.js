import React from "react";
import {InductorSize} from "../../Resources/ShapesSizes";

export const shapes = [
    {
        name: 'Capacitor',
        html: `<rect 
                    x='0' 
                    y='0' 
                    fill-opacity='0' 
                    width='150'
                    height='100'
                    id='SelectingRect' 
                    stroke='#0078D7'></rect>
                <g>
                    <line x1='62.5' x2='62.5' y1='0' y2='100' stroke-width='3' stroke-dasharray='none'></line>
                    <line x1='87.5' x2='87.5' y1='0' y2='100' stroke-width='3' stroke-dasharray='none'></line>
                    <line x1='0' x2='62.5' y1='50' y2='50' stroke-width='3' stroke-dasharray='none'></line>
                    <line x1='87.5' x2='150' y1='50' y2='50' stroke-width='3' stroke-dasharray='none'></line>
                </g>`,
        width: 150,
        height: 150,
    },
    {
        name: 'Resistor',
        html: `<rect 
                    x='0' 
                    y='0' 
                    fill-opacity='0' 
                    width='250' 
                    height='100' 
                    id='SelectingRect' 
                    stroke='#0078D7'></rect>
                <g>
                    <rect 
                        x='50' 
                        y='25' 
                        width='150' 
                        height='50' 
                        fill='none' 
                        stroke-width='3' 
                        stroke-dasharray='none'></rect>
                    <line x1='0' x2='50' y1='50' y2='50' stroke-width='3' stroke-dasharray='none'></line>
                    <line x1='200' x2='250' y1='50' y2='50' stroke-width='3' stroke-dasharray='none'></line>
                </g>`,
        width: 250,
        height: 150,
    },
    {
        name: 'Inductor',
        html: `<rect 
                    x='0' 
                    y='0' 
                    fill-opacity='0' 
                    width='300'
                    height='75'
                    id='SelectingRect' 
                    stroke='#0078D7'></rect>
                <g>
                    <line x1='0' x2='50' y1='50' y2='50' stroke-width='3' stroke-dasharray='none'></line>
                    <line x1='250' x2='300' y1='50' y2='50' stroke-width='3' stroke-dasharray='none'></line>
                    <circle 
                        cx='75' 
                        cy='50' 
                        r='25' 
                        stroke-width='3' 
                        stroke-dasharray='78.53981633974483 78.53981633974483' 
                        stroke-dashoffset='-78.53981633974483' 
                        fill='none'></circle>
                    <circle 
                        cx='125' 
                        cy='50' 
                        r='25' 
                        stroke-width='3' 
                        stroke-dasharray='78.53981633974483 78.53981633974483' 
                        stroke-dashoffset='-78.53981633974483' 
                        fill='none'></circle>
                    <circle 
                        cx='175' 
                        cy='50' 
                        r='25' 
                        stroke-width='3' 
                        stroke-dasharray='78.53981633974483 78.53981633974483' 
                        stroke-dashoffset='-78.53981633974483' 
                        fill='none'></circle>
                    <circle 
                        cx='225' 
                        cy='50' 
                        r='25' 
                        stroke-width='3' 
                        stroke-dasharray='78.53981633974483 78.53981633974483' 
                        stroke-dashoffset='-78.53981633974483' 
                        fill='none'></circle>
                </g>`,
        width: 300,
        height: 100
    }
    
];