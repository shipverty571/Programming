import React, {Component} from 'react';
import SelectingRect from "./SelectingRect";
import RotateButton from "./RotateButton";

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
    canvas = null;
    
    isPanning = false;
    startXPanning = null;
    startYPanning = null;
    
    constructor(props) {
        super(props);
        this.state = {
            xSelect : 0,
            ySelect : 0,
            widthSelect : 0,
            heightSelect : 0
        }
        this.canvasRef = React.createRef();
        
        this.startDrag = this.startDrag.bind(this);
        this.drag = this.drag.bind(this);
        this.endDrag = this.endDrag.bind(this);
        this.SetNoFocusElement = this.SetNoFocusElement.bind(this);
        this.getMousePosition = this.getMousePosition.bind(this);
        this.CreateSelectingRect = this.CreateSelectingRect.bind(this);
    }
    
    startDrag(event) {
        if (event.ctrlKey){
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

            this.selectedElement = event.target;
            this.offset = this.getMousePosition(event);
            this.offset.x -= parseFloat(this.selectedElement.getAttributeNS(null, "x"));
            this.offset.y -= parseFloat(this.selectedElement.getAttributeNS(null, "y"));
            this.setDashArraySelectingRect(this.selectedElement, this.SelectedStrokeWidth, this.SelectedStrokeDashArray);
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
            let canvas = document
                .getElementById("CanvasPanel");
            let viewBox = canvas.viewBox.animVal;
            canvas.setAttribute("viewBox", 
                `${viewBox.x - (this.mouseCoordinate.x - this.startXPanning)} 
                       ${viewBox.y - (this.mouseCoordinate.y - this.startYPanning)}
                       ${viewBox.width} 
                       ${viewBox.height}`)
        } else if (this.selectedElement && this.down) {
            event.preventDefault();
            this.selectedElement.setAttributeNS(
                null, 
                "x", 
                Math.floor((this.mouseCoordinate.x - this.offset.x) / this.X) * this.X);
            this.selectedElement.setAttributeNS(
                null, 
                "y", 
                Math.floor((this.mouseCoordinate.y - this.offset.y) / this.Y) * this.Y);
        } else if (this.isAllSelecting && this.down)
        {
            var width, height;
            var x, y;
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
                this.setDashArraySelectingRect(element, "0", "none");
            }
            this.selectedElements = [];
        }
        var rectX1 = this.state.xSelect;
        var rectY1 = this.state.ySelect;
        var rectX2 = parseInt(rectX1) + parseInt(this.state.widthSelect);
        var rectY2 = parseInt(rectY1) + parseInt(this.state.heightSelect);

        var elements = document
            .getElementById("CanvasPanel")
            .getElementsByTagName("use");
        for (var elem of elements)
        {
            var x = parseInt(elem.getAttribute("x"));
            var y = parseInt(elem.getAttribute("y"));

            if (rectX1 <= x && rectX2 >= x && rectY1 <= y && rectY2 >= y)
            {
                this.setDashArraySelectingRect(elem, this.SelectedStrokeWidth, this.SelectedStrokeDashArray);
                this.selectedElements.push(elem);
            }
        }

        this.setState({ xSelect: 0, ySelect : 0, widthSelect : 0, heightSelect : 0});
        this.isAllSelecting = false;
        this.selectingRectX = null;
        this.selectingRectY = null;
    }
    
    setDashArraySelectingRect(element, strokeWidth, strokeDashArray) {
        element.setAttributeNS(null, "stroke-width", strokeWidth);
        element.setAttributeNS(null, "stroke-dasharray", strokeDashArray);
    }

    SetNoFocusAllElements() {
        var elements = document
            .getElementById("CanvasPanel")
            .getElementsByTagName("use");
        for (var element of elements) {
            this.setDashArraySelectingRect(element, "0", "none");
        }
    }

    SetNoFocusElement() {
        if (!this.selectedElement) return;

        this.setDashArraySelectingRect(this.selectedElement, "0", "none");
        this.selectedElement = null;
    }

    getMousePosition(event) {
        var svg = document.getElementById("CanvasPanel");
        var CTM = svg.getScreenCTM();
        return {
            x: (event.clientX - CTM.e) / CTM.a,
            y: (event.clientY - CTM.f) / CTM.d
        };
    }

    CreateSelectingRect(x, y) {
        var rect = document.createElementNS("http://www.w3.org/2000/svg", "rect");
        rect.setAttributeNS(null, "stroke", "black");
        rect.setAttributeNS(null, "stroke-width", "2");
        rect.setAttributeNS(null, "fill", "none");
        rect.setAttributeNS(null, "id", "SelectingRect");
        rect.setAttributeNS(null, "x", x);
        rect.setAttributeNS(null, "y", y);

        return rect;
    }

    componentDidMount() {
        console.log("AA")
        this.canvasRef.current.addEventListener('mousedown', this.startDrag);
        this.canvasRef.current.addEventListener('mousemove', this.drag);
        this.canvasRef.current.addEventListener('mouseup', this.endDrag);
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        if (prevProps !== this.props) {
            this.SetNoFocusAllElements();
        }
    }
    
    render() {
        return (
            <svg
                xmlns="http://www.w3.org/2000/svg"
                version="1.1"
                preserveAspectRatio="xMinYMin"
                id="CanvasPanel"
                ref={this.canvasRef}
                style={{flexGrow: 2}}
                viewBox={[0, 0, this.props.widthRect*2, this.props.heightRect*2].join(' ')}>
                <rect 
                    fill="url(#grid)" 
                    stroke="none" 
                    rx="0" 
                    ry="0" 
                    id="CanvasRect" 
                    width={this.props.widthRect * 2} 
                    height={this.props.heightRect * 2}>
                    
                </rect>
                <SelectingRect width={this.state.widthSelect} height={this.state.heightSelect} x={this.state.xSelect} y={this.state.ySelect} />
                {this.props.patterns.map((pattern) => (pattern))}
                {this.props.shapes.map((shape) => (shape))}
                <RotateButton />
                <defs>
                    <pattern id="grid" patternUnits="userSpaceOnUse" width="50" height="50">
                        <rect width="50" height="50" fill="#DADADA" />
                        <circle cx="25" cy="25" r="1" fill="black" />
                    </pattern>
                </defs>
            </svg>
        );
    }
}



export default Canvas;