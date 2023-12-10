import React, {Component} from 'react';
import SelectingRect from './SelectingRect';
import PropTypes from "prop-types";
import $ from "jquery";
import UseResistor from "../Shapes/UseShapes/UseResistor";
import UseCapacitor from "../Shapes/UseShapes/UseCapacitor";
import UseInductor from "../Shapes/UseShapes/UseInductor";

/**
 * Компонент канваса.
 */
class Canvas extends Component {
    /**
     * Базовая координата смещения по оси абсцисс.
     * @const 
     * @private 
     * @type {number}
     */
    X = 50;

    /**
     * Базовая координата смещения по оси ординат.
     * @const
     * @private
     * @type {number}
     */
    Y = 50;

    /**
     * Числа, относительно которого происходит приближение и отдаление.
     * @type {number}
     * @private
     * @const
     */
    ScaleFactor = 0.1;

    /**
     * Максимальная ширина масштабирования.
     * @type {number}
     * @private
     * @const
     */
    MaxZoomWidth = 5000;

    /**
     * Максимальная высота масштабирования.
     * @type {number}
     * @private
     * @const
     */
    MaxZoomHeight = 5000;

    /**
     * Выбранный элемент.
     * @type {JSX.Element} 
     * @private
     */
    selectedElement;

    /**
     * Координаты мыши.
     * @type {Array}
     * @private
     */
    mouseCoordinate;

    /**
     * Список выбранных элементов.
     * @type {[]}
     * @private
     */
    selectedElements = [];

    /**
     * Начальная координата X выделения.
     * @type {number}
     * @private
     */
    selectingRectX;

    /**
     * Начальная координата Y выделения.
     * @type {number}
     * @private
     */
    selectingRectY;

    /**
     * Хранит true, если выбирается много элементов, иначе false.
     * @type {boolean}
     * @private
     */
    isAllSelecting = false;

    /**
     * Хранит true, если левая кнопка мыши зажата, иначе false.
     * @type {bool}
     * @private
     */
    down = false;

    /**
     * Хранит координаты мыши при первом нажатии на элемент.
     * @private
     */
    offset;

    /**
     * Хранит true, если выбран режим масштабирования, иначе false.
     * @type {boolean}
     * @private
     */
    isPanning = false;

    /**
     * Начальная координата X масштабирования.
     * @type {number}
     * @private
     */
    startXPanning;

    /**
     * Начальная координата Y масштабирования.
     * @type {number}
     * @private
     */
    startYPanning;

    /**
     * Хранит ссылку на элемент канвас.
     * @private
     */
    canvasSVG;

    /**
     * Хранится ссылку на элемент прямоугольника канваса.
     * @private
     */
    canvasRect;

    /**
     * Хранит ссылку на прямоугольник выделения.
     * @private
     */
    selectingRectRef;

    /**
     * Хранит ссылки на элементы.
     */
    refs = [];

    newShapeDragRef = null;

    /**
     * Создает экземпляр класса Canvas.
     * @param props Свойства.
     */
    constructor(props) {
        super(props);
        this.state = {
            widthSelect : 0,
            heightSelect : 0,
            viewBoxX: 0,
            viewBoxY: 0,
            viewBoxWidth: 0,
            viewBoxHeight: 0,
            MultiSelectingX: null,
            MultiSelectingY: null,
            newShapeDrag: null,
            newShapeDragName: null
        }
        this.canvasRef = React.createRef();
        this.selectingRectRef = React.createRef();
        
        this.onStartDrag = this.onStartDrag.bind(this);
        this.onDrag = this.onDrag.bind(this);
        this.onEndDrag = this.onEndDrag.bind(this);
        this.onPanning = this.onPanning.bind(this);
        this.getMousePosition = this.getMousePosition.bind(this);
        this.onSetZoom = this.onSetZoom.bind(this);
        this.setFocus = this.setFocus.bind(this);
        this.changeCoordinateMovingElement = this.changeCoordinateMovingElement.bind(this);
        this.setNoFocusAllElements = this.setNoFocusAllElements.bind(this);
    }

    /**
     * Обработчик события старта передвижения.
     * @param event Объект события.
     */
    onStartDrag(event) {
        if (this.state.newShapeDrag) {
            return;
        }
        if (event.button === 2){
            this.isPanning = true;
            let coord = this.getMousePosition(event);
            this.startXPanning = coord.x;
            this.startYPanning = coord.y;
        } else if (event.target.classList.contains('draggable')) {
            this.down = true;
            this.offset = this.getMousePosition(event);
            let id = event.target.getAttribute('id');
            if (this.selectedElements.length > 0) {
                let hasSelect = this.selectedElements.filter(element => element.props.id === id);
                if (hasSelect.length !== 0) {
                    for (let element of this.selectedElements) {
                        element.isDragging(true);
                    }
                    return;
                } else {
                    this.setState({ MultiSelectingX: null, MultiSelectingY: null });
                    this.props.setCenterRotate(null, null);
                }
            }
            if (this.selectedElement)
            {
                this.setFocus(this.selectedElement, false);
            }
            if (this.selectedElements) {
                this.setNoFocusAllElements(this.selectedElements);
            }
            
            this.selectedElement = this.getRefElement(id);
            this.offset.x -= this.selectedElement.state.X;
            this.offset.y -= this.selectedElement.state.Y;
            this.selectedElement.isDragging(true);
            this.setFocus(this.selectedElement, true);
        } else {
            this.down = true;
            this.mouseCoordinate = this.getMousePosition(event);
            if (!this.selectingRectX && !this.selectingRectY)
            {
                this.selectingRectX = this.mouseCoordinate.x;
                this.selectingRectY = this.mouseCoordinate.y;
                this.isAllSelecting = true;
            }
            this.setFocus(this.selectedElement, false);
            this.setNoFocusAllElements(this.selectedElements);
            this.setState({ MultiSelectingX: null, MultiSelectingY: null });
            this.props.setCenterRotate(null, null);
        }
    }

    /**
     * Обработчик передвижения.
     * @param event Объект события.
     */
    onDrag(event) {
        this.mouseCoordinate = this.getMousePosition(event);
        if (this.props.newShapeDrag && !this.state.newShapeDrag) {
            this.newShapeDragRef = React.createRef();
            let x = Math.floor(this.mouseCoordinate.x / this.X) * this.X;
            let y = Math.floor(this.mouseCoordinate.y  / this.Y) * this.Y;
            let element;
            switch (this.props.newShapeDragName) {
                case "Resistor":
                    element = <UseResistor ref={this.newShapeDragRef} href={this.props.newShapeDrag.props.href} x={x} y={y} />;
                    break;
                case "Capacitor":
                    element = <UseCapacitor ref={this.newShapeDragRef} href={this.props.newShapeDrag.props.href} x={x} y={y} />;
                    break;
                case "Inductor":
                    element = <UseInductor ref={this.newShapeDragRef} href={this.props.newShapeDrag.props.href} x={x} y={y} />;
                    break;
            }
            this.setState({ newShapeDrag: element, newShapeDragName: this.props.newShapeDragName });
        } else if (this.state.newShapeDrag) {
            let x = Math.floor(this.mouseCoordinate.x / this.X) * this.X;
            let y = Math.floor(this.mouseCoordinate.y  / this.Y) * this.Y;
            this.newShapeDragRef.current.setCoordinate(x, y);
        } else if (this.isPanning) {
            this.onPanning();
        } else if (this.selectedElement && this.down) {
            event.preventDefault();
            this.changeCoordinateMovingElement();
        } else if (this.isAllSelecting && this.down) {
            this.onMultiSelecting();
        } else if (this.selectedElements.length > 0 && this.down) {
            event.preventDefault();
            this.onMultiMoving();
        }
    }

    /**
     * Обработчик завершения передвижения.
     */
    onEndDrag() {
        if (this.state.newShapeDrag) {
            this.props.onAddShape(
                this.state.newShapeDragName, 
                this.newShapeDragRef.current.state.X, 
                this.newShapeDragRef.current.state.Y);
            this.setState({ newShapeDrag: null });
            this.newShapeDragRef = null;
            return;
        }
        
        this.down = false;
        this.isPanning = false;
        if (this.selectedElement) {
            this.props.setNewPropsShape(this.selectedElement.props.id, this.selectedElement.state);
            this.selectedElement.isDragging(false);
        }
        
        if (this.isAllSelecting) {
            this.selectedElements = this.getSelectedElements();
            if (this.selectedElements.length === 1) {
                this.selectedElement = this.selectedElements[0];
                this.setFocus(this.selectedElement, true);
                this.selectedElements = [];
            } else if (this.selectedElements.length !== 0) {
                this.props.setSelectedElementInState(this.selectedElements);
                let coord = this.getMultiSelectingCenter();
                this.setState({ MultiSelectingX: coord.centerX, MultiSelectingY: coord.centerY });
                this.props.setCenterRotate(coord.centerX, coord.centerY);
            }
        }
        
        if (this.selectedElements.length > 0 && this.selectedElements.length !== 1) {
            for (let element of this.selectedElements) {
                this.props.setNewPropsShape(element.props.id, element.state);
                element.isDragging(false);
            }
            let coord = this.getMultiSelectingCenter();
            this.setState({ MultiSelectingX: coord.centerX, MultiSelectingY: coord.centerY });
            this.props.setCenterRotate(coord.centerX, coord.centerY);
        }
        
        this.selectingRectRef.current.setSize(0, 0, 0, 0);
        this.isAllSelecting = false;
        this.selectingRectX = null;
        this.selectingRectY = null;
    }

    /**
     * Высчитывает центр среди выбранных элементов.
     * @returns {{centerY: number, centerX: number}} Возвращает координаты центра.
     */
    getMultiSelectingCenter() {
        let xMin = this.selectedElements[0].state.X;
        let xMax = this.selectedElements[0].state.X;
        let yMin = this.selectedElements[0].state.Y;
        let yMax = this.selectedElements[0].state.Y;

        for (let element of this.selectedElements) {
            if (xMin > element.state.X) {
                xMin = element.state.X;
            }
            if (xMax <= (element.state.X + element.state.width)) {
                xMax = element.state.X + element.state.width;
            }

            if (yMin > element.state.Y) {
                yMin = element.state.Y;
            }
            if (yMax <= element.state.Y + element.state.height) {
                yMax = element.state.Y + element.state.height;
            }
        }
        let centerX = (xMax + xMin) / 2;
        let centerY = (yMax + yMin) / 2;
        
        return ({
            centerX: centerX,
            centerY: centerY
        })
    }

    /**
     * Перемещает множество элементов.
     */
    onMultiMoving() {
        let x = Math.floor((this.mouseCoordinate.x - this.offset.x) / this.X) * this.X;
        let y = Math.floor((this.mouseCoordinate.y - this.offset.y) / this.Y) * this.Y;
        if (Math.abs(x) !== this.X && Math.abs(y) !== this.Y) {
            return;
        }
        for (let element of this.selectedElements) {
            let xState = element.state.X;
            let yState = element.state.Y;
            element.setCoordinate(xState + x, yState + y);
        }
        this.offset.x += x;
        this.offset.y += y;
    }

    /**
     * Изменяет размеры прямоугольника выделения.
     */
    onMultiSelecting() {
        let x = this.selectingRectX;
        let y = this.selectingRectY;
        let width = Math.abs(this.mouseCoordinate.x - x);
        let height = Math.abs(this.mouseCoordinate.y - y);
        if (this.mouseCoordinate.x < x) {
            x = this.mouseCoordinate.x;
        }
        if (this.mouseCoordinate.y < y) {
            y = this.mouseCoordinate.y;
        }
        this.selectingRectRef.current.setSize(x, y, width, height);
    }

    /**
     * Перемещает макет.
     */
    onPanning() {
        let newX = this.state.viewBoxX - (this.mouseCoordinate.x - this.startXPanning);
        let newY = this.state.viewBoxY - (this.mouseCoordinate.y - this.startYPanning);
        this.setState({ viewBoxX: newX, viewBoxY: newY });
    }

    /**
     * Получает ссылку на элемент из коллекции. 
     * @param id Уникальный идентификатор элемента.
     * @returns {*|null} Возвращает ссылку на элемент. Если не найдена, то возвращает null.
     */
    getRefElement(id) {
        let element;
        for (var i = 0; i < this.refs.length; i++) {
            let ref = this.refs[i];
            if (!ref) {
                continue;
            }
            if (ref.props.id === id) {
                element = this.refs[i];
                return element;
            }
        }

        return null;
    }

    /**
     * Перебирает все элементы на вхождение их в прямоугольник выделения.
     * @returns {*[]} Возвращает элементы.
     */
    getSelectedElements() {
        let rectX1 = this.selectingRectRef.current.state.x;
        let rectY1 = this.selectingRectRef.current.state.y;
        let rectX2 = rectX1 + this.selectingRectRef.current.state.width;
        let rectY2 = rectY1 + this.selectingRectRef.current.state.height;

        let elements = []
        for (let elem of this.refs) {
            if (!elem) {
                continue;
            }
            let x = elem.state.X;
            let y = elem.state.Y;
            if (rectX1 <= x && rectX2 >= x && rectY1 <= y && rectY2 >= y) {
                if (this.selectedElement) {
                    this.setFocus(this.selectedElement, false);
                }
                this.setFocus(elem, true);
                elements.push(elem);
            }
        }
        
        return elements;
    }

    /**
     * Изменяет координаты элемента при его перемещении.
     */
    changeCoordinateMovingElement() {
        let x = Math.floor((this.mouseCoordinate.x - this.offset.x) / this.X) * this.X;
        let y = Math.floor((this.mouseCoordinate.y - this.offset.y) / this.Y) * this.Y;
        this.selectedElement.setCoordinate(x, y);
    }

    /**
     * Устанавливает визуальный фокус элемента.
     * @param element Элемент.
     * @param flag Если true, то фокус устанавливается, иначе false.
     */
    setFocus(element, flag) {
        if (element) {
            element.isFocus(flag);
        }
        
        if (flag) {
            this.props.setSelectedElementInState(element);
        } else {
            if (element === this.selectedElement) {
                this.props.setSelectedElementInState(null);
                this.selectedElement = null;
            }
        }
    }

    /**
     * Приближает и отдаляет канвас.
     * @param event Объект события.
     */
    onSetZoom(event) {
        event.preventDefault();
        if (event.deltaY > 0) {
            if (this.state.viewBoxWidth >= this.MaxZoomWidth || this.state.viewBoxHeight >= this.MaxZoomHeight) {
                return;
            }
            this.setState(previousState => ({ 
                viewBoxWidth: previousState.viewBoxWidth * (1 + this.ScaleFactor),
                viewBoxHeight: previousState.viewBoxHeight * (1 + this.ScaleFactor)}));
        } else {
            if (this.state.viewBoxWidth < this.state.widthRect || this.state.viewBoxHeight < this.state.heightRect) {
                return;
            }
            this.setState(previousState => ({
                viewBoxWidth: previousState.viewBoxWidth * (1 - this.ScaleFactor),
                viewBoxHeight: previousState.viewBoxHeight * (1 - this.ScaleFactor)}));
        }
    }

    /**
     * Убирает фокус со всех элементов.
     */
    setNoFocusAllElements(elements) {
        if (this.selectedElement) {
            this.setFocus(this.selectedElement, false);
        }
        for (let element of elements) {
            if (!element) {
                continue;
            }
            this.setFocus(element, false);
        }
        this.selectedElements = [];
    }

    /**
     * Получает координаты мыши.
     * @param event Объект события.
     * @returns {{x: number, y: number}} Возвращает координаты.
     */
    getMousePosition(event) {
        let CTM = this.canvasSVG.getScreenCTM();
        return {
            x: (event.clientX - CTM.e) / CTM.a,
            y: (event.clientY - CTM.f) / CTM.d
        };
    }

    /**
     * Добавляет ссылку на элемент в коллекцию.
     * @param ref Ссылка.
     */
    setRefToShape = (ref) => {
        this.refs = [...this.refs, ref];
    }

    /**
     * Создает компоненты фигур.
     * @param shape Имя фигуры.
     * @returns {JSX.Element|string} Возвращает компонент фигуры.
     */
    getUseComponent(shape) {
        switch(shape.href) {
            case "#ResistorSymbol":
                return (<UseResistor
                    href={shape.href}
                    x={shape.x}
                    y={shape.y}
                    id={shape.id}
                    key={shape.id}
                    width={shape.width}
                    height={shape.height}
                    rotate={shape.rotate}
                    ref={this.setRefToShape}
                    setNewPropsShape={this.props.setNewPropsShape}
                />);
            case "#CapacitorSymbol":
                return <UseCapacitor
                    href={shape.href}
                    x={shape.x}
                    y={shape.y}
                    id={shape.id}
                    key={shape.id}
                    width={shape.width}
                    height={shape.height}
                    rotate={shape.rotate}
                    ref={this.setRefToShape}
                    setNewPropsShape={this.props.setNewPropsShape}
                />
            case "#InductorSymbol":
                return <UseInductor
                    href={shape.href}
                    x={shape.x}
                    y={shape.y}
                    id={shape.id}
                    key={shape.id}
                    width={shape.width}
                    height={shape.height}
                    rotate={shape.rotate}
                    ref={this.setRefToShape}
                    setNewPropsShape={this.props.setNewPropsShape}
                />
            default:
                return 'Element not found';
        }
    }

    componentDidMount() {
        this.canvasRef.current.addEventListener('mousedown', this.onStartDrag);
        this.canvasRef.current.addEventListener('mousemove', this.onDrag);
        this.canvasRef.current.addEventListener('mouseup', this.onEndDrag);
        this.canvasRef.current.addEventListener('wheel', this.onSetZoom);
        this.canvasRef.current.addEventListener('contextmenu', e => e.preventDefault());

        this.canvasSVG = document.getElementById('canvas-panel');
        this.canvasRect = document.getElementById('canvas-rect');
        
        let canvas = $('#canvas-panel');
        this.setState(
            { widthRect: canvas.width(), heightRect: canvas.height() }, 
            () => {
                this.setState({ viewBoxWidth: this.state.widthRect*2, viewBoxHeight: this.state.heightRect*2 })
            });
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        if (prevProps.shapes !== this.props.shapes) {
            this.setNoFocusAllElements(this.refs);
            this.props.setSelectedElementInState(null);
            this.setState({ MultiSelectingX: null, MultiSelectingY: null });
            this.props.setCenterRotate(null, null);
            
            let newRefs = []
            for (let ref of this.refs) {
                if (!ref) {
                    continue;
                } 
                if (this.props.shapes.filter(shape => shape.id === ref.props.id).length !== 0) {
                    newRefs.push(ref);
                }
            }
            if (newRefs.length !== 0) {
                this.refs = newRefs;
            }
        }
        
        if (prevProps.activePageId !== this.props.activePageId) {
            this.refs = []
        }
    }
    
    render() {
        return (
            <svg
                xmlns='http://www.w3.org/2000/svg'
                version='1.1'
                preserveAspectRatio='xMinYMin'
                id='canvas-panel'
                ref={this.canvasRef}
                style={{flexGrow: 2, zIndex: 2000}}
                viewBox={[this.state.viewBoxX, this.state.viewBoxY, this.state.viewBoxWidth, this.state.viewBoxHeight].join(' ')}>
                <rect 
                    fill='url(#grid)' 
                    stroke='none' 
                    rx='0' 
                    ry='0' 
                    id='canvas-rect'
                    x={this.state.viewBoxX}
                    y={this.state.viewBoxY}
                    width={this.state.viewBoxWidth} 
                    height={this.state.viewBoxHeight} 
                />
                <SelectingRect ref={this.selectingRectRef} />
                {this.props.patterns.map(pattern => pattern)}
                {this.props.shapes.map(shape => this.getUseComponent(shape))}
                {this.state.newShapeDrag}
                {(this.state.MultiSelectingX && this.state.MultiSelectingY) && (
                    <circle cx={this.state.MultiSelectingX} cy={this.state.MultiSelectingY} r='5' fill='#66CD79' />
                )}
                <defs>
                    <pattern id='grid' patternUnits='userSpaceOnUse' width='50' height='50'>
                        <rect width='50' height='50' fill='#DADADA' />
                        <circle cx='0' cy='0' r='2' fill='black' />
                        <circle cx='50' cy='0' r='2' fill='black' />
                        <circle cx='0' cy='50' r='2' fill='black' />
                        <circle cx='50' cy='50' r='2' fill='black' />
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