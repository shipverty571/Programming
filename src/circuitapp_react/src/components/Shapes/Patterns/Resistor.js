import React, {Component} from 'react';

class Resistor extends Component {
    render() {
        return (
            <symbol width="250" height="100" id={this.props.id}>
                <rect x="0" y="0" fillOpacity="0" width="250" height="100" id="SelectingRect" stroke="#0078D7"  />
                <g>
                    <rect x="50" y="25" width="150" height="50" fill="none" stroke="black" strokeWidth="3" strokeDasharray="none" />
                    <line x1="0" x2="50" y1="50" y2="50" stroke="black" strokeWidth="3" strokeDasharray="none"  />
                    <line x1="200" x2="250" y1="50" y2="50" stroke="black" strokeWidth="3" strokeDasharray="none"  />
                </g>
            </symbol>
        );
    }
}

export default Resistor;