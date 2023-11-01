import React, {Component} from 'react';
import Shape from './Shape';
import PropTypes from "prop-types";

class ShapesGroup extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isHidden: false
        }
        
        this.showGroup = this.showGroup.bind(this);
    }

    showGroup() {
        this.setState( {isHidden : !this.state.isHidden} )
    }
    
    renderGroup(name) {
        switch (name) {
            case 'Fundamental Items':
                return (
                    <div className='shapes_container' hidden={this.state.isHidden}>
                        <Shape name="Resistor" onAddShape={this.props.onAddShape} />
                        <Shape name="Capacitor" onAddShape={this.props.onAddShape} />
                        <Shape name="Inductor" onAddShape={this.props.onAddShape} /> 
                    </div>);
            case 'Custom Items':
                return (<div className='shapes_container' hidden={this.state.isHidden} />);
            default:
                return 'Not found group';
        }
    }

    SetNoFocusAllElements() {
        var elements = document
            .getElementById('ShapesGroup')
            .getElementsByTagName('use');
        for (var element of elements) {
            element.setAttributeNS(null, 'stroke-width', '0');
            element.setAttributeNS(null, 'stroke-dasharray', 'none');
        }
    }
    
    componentDidUpdate(prevProps, prevState, snapshot) {
        this.SetNoFocusAllElements();
    }

    render() {
        return (
            <div id='ShapesGroup'>
                <div style={{ display: 'flex' }}>
                    <button 
                        id='ShapesGroupButton' 
                        onClick={this.showGroup}>
                        <h3>{this.props.groupName}</h3>
                    </button>
                </div>
                {this.state.isHidden && (
                    this.renderGroup(this.props.groupName)
                )}
            </div> 
        );
    }
}
ShapesGroup.propTypes = {
    groupName: PropTypes.string.isRequired,
    onAddShape: PropTypes.func
}
ShapesGroup.defaultProps = {
    onAddShape: (() => ({}))
}

export default ShapesGroup;