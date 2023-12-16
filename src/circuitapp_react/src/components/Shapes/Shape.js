import React, {Component} from 'react';
import {DraggableColor, StaticColor} from "../../Resources/Colors";
import MultiRotate from "../../Services/ShapeMathService";
import {rightAngle, SelectedStrokeDashArray, SelectedStrokeWidth} from "../../Resources/ApplicationConstants";

class Shape extends Component {
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
        if (x && y) {
            let coord = MultiRotate(
                x,
                y,
                this.state.X,
                this.state.Y,
                this.state.width,
                this.state.height);
            this.setCoordinate(coord.x, coord.y);
        }
        let newRotate = (this.state.rotate + rightAngle) % 360;
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
            <svg
                x={this.state.X}
                y={this.state.Y}
                href={this.props.href}
                className='draggable'
                style={{ cursor: this.props.canNotDraggable ? 'default' : 'move' }}
                stroke={this.state.strokeColor}
                strokeWidth={this.state.strokeWidth}
                strokeDasharray={this.state.strokeDashArray}
                id={this.props.id}
                viewBox={[0, 0, this.state.width, this.state.height - 50].join(' ')}
                
                /*width={this.state.WidthElement}
                height={this.state.HeightElement}*/
                
                transform=
                    {`rotate(${this.state.rotate} ${this.state.X+this.state.width/2} ${this.state.Y+this.state.height/2})`}
                dangerouslySetInnerHTML={{__html: this.props.html}}>
            </svg>
        );
    }
}

export default Shape;