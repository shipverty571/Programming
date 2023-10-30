import React, {Component} from 'react';

class Inductor extends Component {
    render() {
        return (
            <symbol width={this.props.width} height={this.props.height} id={this.props.id}>
                <rect x="0" y="0" fillOpacity="0" width="300" height="75" id="SelectingRect" stroke="black"  />
                <g>
                    <line x1="0" x2="50" y1="50" y2="50" stroke="black" strokeWidth="3" strokeDasharray="none" />
                    <line x1="250" x2="300" y1="50" y2="50" stroke="black" strokeWidth="3" strokeDasharray="none" />
                    <circle cx="75" cy="50" r="25" stroke="black" strokeWidth="3" strokeDasharray="78.53981633974483 78.53981633974483" strokeDashoffset="-78.53981633974483" fill="none" />
                    <circle cx="125" cy="50" r="25" stroke="black" strokeWidth="3" strokeDasharray="78.53981633974483 78.53981633974483" strokeDashoffset="-78.53981633974483" fill="none" />
                    <circle cx="175" cy="50" r="25" stroke="black" strokeWidth="3" strokeDasharray="78.53981633974483 78.53981633974483" strokeDashoffset="-78.53981633974483" fill="none" />
                    <circle cx="225" cy="50" r="25" stroke="black" strokeWidth="3" strokeDasharray="78.53981633974483 78.53981633974483" strokeDashoffset="-78.53981633974483" fill="none" />
                </g>
            </symbol>
        );
    }
}

export default Inductor;