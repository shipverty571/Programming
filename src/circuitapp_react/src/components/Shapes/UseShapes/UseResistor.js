import React, {Component} from 'react';
import PropTypes from "prop-types";
import {DraggableColor, StaticColor} from "../../../Resources/Colors";
import {SelectedStrokeDashArray, SelectedStrokeWidth} from "../../../Resources/ApplicationConstants";

/**
 * Компонент для использования шаблона резистора.
 */
class UseResistor extends Component {
    Angle = 90;
    
    constructor(props) {
        super(props);
        this.state = {
            X: this.props.x,
            Y: this.props.y,
            width: this.props.width,
            height: this.props.height,
            rotate: this.props.rotate,
            strokeColor: StaticColor,
            strokeWidth: 0,
            strokeDashArray: 0
        }
        this.setCoordinate = this.setCoordinate.bind(this);
        this.rotate = this.rotate.bind(this);
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
     * Поворачивает элемент на 90 градусов по часовой.
     * @param x Координата X центра вращения.
     * @param y Координата Y центра вращения.
     */
    rotate(x, y){
        let newRotate = (this.state.rotate + 90) % 360;
        if (x && y) {
            let centerX = this.state.X + this.state.width / 2;
            let centerY = (this.state.Y + this.state.height / 2);
            let radians = this.Angle * Math.PI / 180;
            let newX =
                (x - centerX) * Math.cos(radians) +
                (y - centerY) * Math.sin(radians) +
                x;
            let newY =
                (-1) *
                (x - centerX) * Math.sin(radians) +
                (y - centerY) * Math.cos(radians) +
                y;
            newX = newX - this.state.width / 2;
            newY = newY - this.state.height / 2;
            this.setCoordinate(newX, newY);
        }
        this.setState(
            { rotate: newRotate},
            () => this.props.setNewPropsShape(this.props.id, this.state));
    }

    /**
     * Изменяет цвет элемента в зависимости от того, перемещается он или нет.
     * @param flag Если true, то элемент находится в состоянии перемещения, иначе не находится.
     */
    isDragging(flag) {
        if (flag) {
            this.setState({ strokeColor: DraggableColor })
        } else {
            this.setState({ strokeColor: StaticColor })
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
UseResistor.propTypes = {
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
UseResistor.defaultProps = {
    x: 0,
    y: 0,
    canNotDraggable: false,
    rotate: 0,
    strokeColor: StaticColor,
    strokeWidth: 0,
    strokeDasharray: 0
}

export default UseResistor;