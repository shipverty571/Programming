import React, {Component} from 'react';
import PropTypes from "prop-types";
import {DraggableColor, NoDraggableColor} from "../../../Resources/Colors";
import {SelectedStrokeDashArray, SelectedStrokeWidth} from "../../../Resources/Values";

/**
 * Компонент для использования шаблона конденсатора.
 */
class UseCapacitor extends Component {
    constructor(props) {
        super(props);
        this.state = {
            X: this.props.x,
            Y: this.props.y,
            width: this.props.width,
            height: this.props.height,
            rotate: 0,
            strokeColor: NoDraggableColor,
            strokeWidth: 0,
            strokeDashArray: null
        }
        this.setCoordinate = this.setCoordinate.bind(this);
        this.changeRotate = this.changeRotate.bind(this);
        this.isDragging = this.isDragging.bind(this);
    }

    /**
     * Устанавливает координаты.
     * @param x Координата X.
     * @param y Координата Y.
     */
    setCoordinate(x, y) {
        this.setState({ X: x, Y: y });
    }

    /**
     * Поворачивает элемент.
     */
    changeRotate(){
        let oldRotate = this.state.rotate;
        this.setState({ rotate: (oldRotate + 90) % 360})
    }

    /**
     * Изменяет цвет элемента в зависимости от того, перемещается он или нет.
     * @param flag Если true, то элемент находится в состоянии перемещения, иначе не находится.
     */
    isDragging(flag) {
        if (flag) {
            this.setState({ strokeColor: DraggableColor })
        } else {
            this.setState({ strokeColor: NoDraggableColor })
        }
    }

    /**
     * Изменяет цвет границ элемента в зависимости от того, находится он в фокусе или нет.
     * @param flag Если true, то элемент находится в фокусе, иначе не находится.
     */
    isFocus(flag) {
        if (flag) {
            this.setState({ strokeWidth: SelectedStrokeWidth, strokeDashArray: SelectedStrokeDashArray })
        } else {
            this.setState({ strokeWidth: 0, strokeDashArray: null })
        }
    }
    
    render() {
        return (
            <use
                x={this.state.X}
                y={this.state.Y}
                href={this.props.href}
                className='draggable'
                style={{ cursor: this.props.canNotDraggable ? 'default' : 'move' }}
                stroke={this.state.strokeColor}
                strokeWidth={this.state.strokeWidth}
                strokeDasharray={this.state.strokeDashArray}
                id={this.props.id}
                transform=
                    {`rotate(${this.state.rotate} ${this.state.X+this.state.width/2} ${this.state.Y+this.state.height/2})`} 
            />
        );
    }
}
UseCapacitor.propTypes = {
    x: PropTypes.number,
    y: PropTypes.number,
    rotate: PropTypes.number,
    strokeColor: PropTypes.string,
    strokeWidth: PropTypes.number,
    strokeDashArray: PropTypes.number,
    canNotDraggable: PropTypes.bool,
    width: PropTypes.number.isRequired,
    height: PropTypes.number.isRequired,
    href: PropTypes.string.isRequired
}
UseCapacitor.defaultProps = {
    x: 0,
    y: 0,
    canNotDraggable: false,
    rotate: 0,
    strokeColor: NoDraggableColor,
    strokeWidth: 0,
    strokeDasharray: 0
}

export default UseCapacitor;