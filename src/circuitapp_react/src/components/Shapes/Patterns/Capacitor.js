import React, {Component} from 'react';

class Capacitor extends Component {
    render() {
        return (
            <symbol width="125" height="150" id={this.props.id}>
                <rect x="0" y="0" fillOpacity="0" width="125" height="150" id="SelectingRect" stroke="black"  />
                <g>
                    <line x1="50" x2="50" y1="25" y2="125" stroke="black" strokeWidth="3" strokeDasharray="none" />
                    <line x1="75" x2="75" y1="25" y2="125" stroke="black" strokeWidth="3" strokeDasharray="none" />
                    <line x1="0" x2="50" y1="75" y2="75" stroke="black" strokeWidth="3" strokeDasharray="none" />
                    <line x1="75" x2="125" y1="75" y2="75" stroke="black" strokeWidth="3" strokeDasharray="none" />
                </g>
            </symbol>
        );
    }
}

export default Capacitor;