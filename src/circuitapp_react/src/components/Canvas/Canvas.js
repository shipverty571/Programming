import React, {Component} from 'react';
import SelectingRect from './SelectingRect';
import RotateButton from './RotateButton';
import PropTypes from "prop-types";

class Canvas extends Component {
    X = 25;
    Y = 25;
    SelectedStrokeWidth = 2;
    SelectedStrokeDashArray = 8;
    selectedElement;
    mouseCoordinate;
    selectedElements = [];

    selectingRectX = null;
    selectingRectY = null;
    isAllSelecting = false;
    
    down = null;
    offset = null;
    
    isPanning = false;
    startXPanning = null;
    startYPanning = null;

    scaleFactor = 0.1;
    MaxZoomWidth = 5000;
    MaxZoomHeight = 5000;
    
    CanvasSVG = null;
    CanvasRect = null;
    
    constructor(props) {
        super(props);
        this.state = {
            xSelect : 0,
            ySelect : 0,
            widthSelect : 0,
            heightSelect : 0,
            startXRotateButton : 0,
            startYRotateButton: 0,
            isShowRotateButton : false
        }
        this.canvasRef = React.createRef();
        
        this.startDrag = this.startDrag.bind(this);
        this.drag = this.drag.bind(this);
        this.endDrag = this.endDrag.bind(this);
        this.SetNoFocusElement = this.SetNoFocusElement.bind(this);
        this.getMousePosition = this.getMousePosition.bind(this);
        this.setZoom = this.setZoom.bind(this);
        this.setFocus = this.setFocus.bind(this);
    }
    
    startDrag(event) {
        if (event.button === 2){
            this.isPanning = true;
            let coord = this.getMousePosition(event);
            this.startXPanning = coord.x;
            this.startYPanning = coord.y;
        } else if (event.target.classList.contains('draggable')) {
            this.down = true;
            if (this.selectedElement)
            {
                this.SetNoFocusElement();
            }
            this.setState( {isShowRotateButton: true} );
            this.selectedElement = event.target;
            this.offset = this.getMousePosition(event);
            this.offset.x -= parseFloat(this.selectedElement.getAttributeNS(null, 'x'));
            this.offset.y -= parseFloat(this.selectedElement.getAttributeNS(null, 'y'));
            this.setFocus(this.selectedElement);
            
        } else {
            this.down = true;
            this.mouseCoordinate = this.getMousePosition(event);
            if (!this.selectingRectX && !this.selectingRectY)
            {
                this.selectingRectX = this.mouseCoordinate.x;
                this.selectingRectY = this.mouseCoordinate.y;
                this.setState({ IsSelecting : true })
                this.isAllSelecting = true;
                this.setState({ xSelect: this.selectingRectX, ySelect : this.selectingRectY})
            }
            this.SetNoFocusElement();
        }
    }

    drag(event) {
        this.mouseCoordinate = this.getMousePosition(event);
        if (this.isPanning) {
            let viewBox = this.CanvasSVG.viewBox.animVal;
            let newX = viewBox.x - (this.mouseCoordinate.x - this.startXPanning);
            let newY = viewBox.y - (this.mouseCoordinate.y - this.startYPanning);
            this.CanvasSVG.setAttribute('viewBox', `${newX} ${newY} ${viewBox.width} ${viewBox.height}`)
            this.CanvasRect.setAttribute('x', newX);
            this.CanvasRect.setAttribute('y', newY);
        } else if (this.selectedElement && this.down) {
            event.preventDefault();
            this.selectedElement.setAttributeNS(
                null, 
                'x', 
                Math.floor((this.mouseCoordinate.x - this.offset.x) / this.X) * this.X);
            this.selectedElement.setAttributeNS(
                null, 
                'y', 
                Math.floor((this.mouseCoordinate.y - this.offset.y) / this.Y) * this.Y);
        } else if (this.isAllSelecting && this.down)
        {
            let width, height;
            let x, y;
            x = this.selectingRectX;
            y = this.selectingRectY;
            width = Math.abs(this.mouseCoordinate.x - x);
            height = Math.abs(this.mouseCoordinate.y - y);
            if (this.mouseCoordinate.x < x)
            {
                x = this.mouseCoordinate.x;
            }

            if (this.mouseCoordinate.y < y)
            {
                y = this.mouseCoordinate.y;
            }
            this.setState({ xSelect: x, ySelect : y, widthSelect : width, heightSelect : height})
        }
    }

    endDrag() {
        this.down = false;
        this.isPanning = false;
        if (this.selectedElements.length > 0)
        {
            for (var element of this.selectedElements)
            {
                this.setDashArraySelectingRect(element, '0', 'none');
            }
            this.selectedElements = [];
        }
        let rectX1 = this.state.xSelect;
        let rectY1 = this.state.ySelect;
        let rectX2 = parseInt(rectX1) + parseInt(this.state.widthSelect);
        let rectY2 = parseInt(rectY1) + parseInt(this.state.heightSelect);

        let elements = this.CanvasSVG.getElementsByTagName('use');
        for (let elem of elements)
        {
            let x = parseInt(elem.getAttribute('x'));
            let y = parseInt(elem.getAttribute('y'));
            if (rectX1 <= x && rectX2 >= x && rectY1 <= y && rectY2 >= y)
            {
                this.setDashArraySelectingRect(elem, this.SelectedStrokeWidth, this.SelectedStrokeDashArray);
                this.selectedElements.push(elem);
            }
        }

        this.setState({ 
            xSelect: 0, 
            ySelect : 0, 
            widthSelect : 0, 
            heightSelect : 0});
        if (this.state.isShowRotateButton) {
            this.setState({
                startXRotateButton: this.selectedElement.getAttribute('x')-16,
                startYRotateButton: this.selectedElement.getAttribute('y')-16});
        } 
        
        this.isAllSelecting = false;
        this.selectingRectX = null;
        this.selectingRectY = null;
    }
    
    setFocus(element) {
        this.setDashArraySelectingRect(element, this.SelectedStrokeWidth, this.SelectedStrokeDashArray);
        this.setState( {
            startXRotateButton: element.getAttribute('x')-16,
            startYRotateButton: element.getAttribute('y')-16} )
    }

    setZoom(event) {
        event.preventDefault();

        let viewBox = this.CanvasSVG.viewBox.animVal;
        let newWidth = viewBox.width;
        let newHeight = viewBox.height;
        if (event.deltaY > 0) {
            newWidth = viewBox.width * (1 + this.scaleFactor);
            newHeight = viewBox.height * (1 + this.scaleFactor);
        } else {
            newWidth = viewBox.width * (1 - this.scaleFactor);
            newHeight = viewBox.height * (1 - this.scaleFactor);
        }

        if (newWidth < this.props.widthRect || newHeight < this.props.heightRect) {
            return;
        } else if (newWidth >= this.MaxZoomWidth || newHeight >= this.MaxZoomHeight) {
            return;
        }

        this.CanvasSVG.setAttribute('viewBox', `${viewBox.x} ${viewBox.y} ${newWidth} ${newHeight}`);
        this.CanvasRect.setAttribute('width', newWidth);
        this.CanvasRect.setAttribute('height', newHeight);
    }
    
    setDashArraySelectingRect(element, strokeWidth, strokeDashArray) {
        element.setAttributeNS(null, 'stroke-width', strokeWidth);
        element.setAttributeNS(null, 'stroke-dasharray', strokeDashArray);
    }

    SetNoFocusAllElements() {
        let elements = this.CanvasSVG.getElementsByTagName('use');
        for (var element of elements) {
            this.setDashArraySelectingRect(element, '0', 'none');
        }
        this.setState( {isShowRotateButton: false} );
    }

    SetNoFocusElement() {
        if (!this.selectedElement) return;

        this.setDashArraySelectingRect(this.selectedElement, '0', 'none');
        this.selectedElement = null;
        this.setState( {isShowRotateButton: false} );
    }

    getMousePosition(event) {
        let CTM = this.CanvasSVG.getScreenCTM();
        return {
            x: (event.clientX - CTM.e) / CTM.a,
            y: (event.clientY - CTM.f) / CTM.d
        };
    }

    componentDidMount() {
        this.canvasRef.current.addEventListener('mousedown', this.startDrag);
        this.canvasRef.current.addEventListener('mousemove', this.drag);
        this.canvasRef.current.addEventListener('mouseup', this.endDrag);
        this.canvasRef.current.addEventListener('wheel', this.setZoom);
        this.canvasRef.current.addEventListener('contextmenu', e => e.preventDefault());

        this.CanvasSVG = document.getElementById('CanvasPanel');
        this.CanvasRect = document.getElementById('CanvasRect');
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        if (prevProps !== this.props) {
            this.SetNoFocusAllElements();
        }
    }
    
    render() {
        return (
            <svg
                xmlns='http://www.w3.org/2000/svg'
                version='1.1'
                preserveAspectRatio='xMinYMin'
                id='CanvasPanel'
                ref={this.canvasRef}
                style={{flexGrow: 2}}
                viewBox={[0, 0, this.props.widthRect*2, this.props.heightRect*2].join(' ')}>
                <rect 
                    fill='url(#grid)' 
                    stroke='none' 
                    rx='0' 
                    ry='0' 
                    id='CanvasRect' 
                    width={this.props.widthRect * 2} 
                    height={this.props.heightRect * 2} 
                />
                <SelectingRect 
                    width={this.state.widthSelect} 
                    height={this.state.heightSelect} 
                    x={this.state.xSelect} 
                    y={this.state.ySelect} 
                />
                
                {this.props.patterns.map(pattern => pattern)}
                {this.props.shapes.map(shape => shape)}
                {this.state.isShowRotateButton && (
                    <RotateButton startX={this.state.startXRotateButton} startY={this.state.startYRotateButton} />
                )}
                
                <defs>
                    <pattern id='grid' patternUnits='userSpaceOnUse' width='50' height='50'>
                        <rect width='50' height='50' fill='#DADADA' />
                        <circle cx='25' cy='25' r='1' fill='black' />
                    </pattern>
                </defs>
            </svg>
        );
    }
}
Canvas.propTypes = {
    patterns: PropTypes.array.isRequired,
    shapes: PropTypes.array.isRequired,
    widthRect: PropTypes.number.isRequired,
    heightRect: PropTypes.number.isRequired
}

export default Canvas;