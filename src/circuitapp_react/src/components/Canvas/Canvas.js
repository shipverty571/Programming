import React, {Component} from 'react';
import SelectingRect from './SelectingRect';
import PropTypes from "prop-types";
import $ from "jquery";

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
     * Хранит true, если выбрано много элементов, иначе false.
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
            viewBoxHeight: 0
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
        if (event.button === 2){
            this.isPanning = true;
            let coord = this.getMousePosition(event);
            this.startXPanning = coord.x;
            this.startYPanning = coord.y;
        } else if (event.target.classList.contains('draggable')) {
            this.down = true;
            if (this.selectedElement)
            {
                this.setFocus(this.selectedElement, false);
            }
            if (this.selectedElements) {
                this.setNoFocusAllElements(this.selectedElements);
            }

            let id = event.target.getAttribute('id');
            this.selectedElement = this.getRefElement(id);
            this.offset = this.getMousePosition(event);
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
        }
    }

    /**
     * Обработчик передвижения.
     * @param event Объект события.
     */
    onDrag(event) {
        this.mouseCoordinate = this.getMousePosition(event);
        if (this.isPanning) {
            this.onPanning();
        } else if (this.selectedElement && this.down) {
            event.preventDefault();
            this.changeCoordinateMovingElement();
        } else if (this.isAllSelecting && this.down) {
            this.onMultiSelecting();
        }
    }

    /**
     * Обработчик завершения передвижения.
     */
    onEndDrag() {
        this.down = false;
        this.isPanning = false;
        if (this.selectedElement) {
            this.selectedElement.isDragging(false);
        }
        if (this.selectedElements.length > 0) {
            this.setNoFocusAllElements(this.selectedElements);
            this.selectedElements = [];
        }
        if (this.isAllSelecting) {
            this.selectedElements = this.getSelectedElements();
        }
        
        this.selectingRectRef.current.setSize(0, 0, 0, 0);
        this.isAllSelecting = false;
        this.selectingRectX = null;
        this.selectingRectY = null;
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
        for (var i = 0; i < this.props.refs.length; i++) {
            let ref = this.props.refs[i];
            if (!ref) {
                continue;
            }
            if (ref.props.id === id) {
                element = this.props.refs[i];
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
        for (let elem of this.props.refs) {
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
            { widthRect : canvas.width(), heightRect:  canvas.height() }, 
            () => {
                this.setState({ viewBoxWidth: this.state.widthRect*2, viewBoxHeight: this.state.heightRect*2 })
            });
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        if (prevProps.shapes !== this.props.shapes) {
            this.setNoFocusAllElements(this.props.refs);
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
                style={{flexGrow: 2}}
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
                {this.props.shapes.map(shape => shape)}
                
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