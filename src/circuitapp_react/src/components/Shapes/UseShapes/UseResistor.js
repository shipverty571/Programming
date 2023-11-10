import React, {Component} from 'react';
import PropTypes from "prop-types";

/**
 * Компонент для использования шаблона резистора.
 */
class UseResistor extends Component {
    constructor(props) {
        super(props);
        this.state = {
            X: this.props.x,
            Y: this.props.y
        }
        this.setCoordinate = this.setCoordinate.bind(this);
    }
    
    setCoordinate(x, y) {
        this.setState({ X: x, Y: y });
    }
    
    render() {
        return (
            <use
                x={this.state.X} 
                y={this.state.Y} 
                href={this.props.href} 
                className='draggable' 
                style={{ cursor: this.props.canNotDraggable ? 'default' : 'move' }}
                stroke="black"
                id={this.props.id}
            />
        );
    }
}
UseResistor.propTypes = {
    x: PropTypes.number,
    y: PropTypes.number,
    href: PropTypes.string.isRequired,
    canNotDraggable: PropTypes.bool
}
UseResistor.defaultProps = {
    x: 0,
    y: 0,
    canNotDraggable: false
}

export default UseResistor;