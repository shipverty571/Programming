import React, {Component} from 'react';
import SelectingRect from './SelectingRect';
import RotateButton from './RotateButton';
import PropTypes from "prop-types";

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
     * Базовая ширина рамки выбранного элемента.
     * @type {number}
     * @private
     * @const
     */
    SelectedStrokeWidth = 2;

    /**
     * Базовое число ширины прерывистой линии.
     * @type {number}
     * @private
     * @const
     */
    SelectedStrokeDashArray = 8;

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
     * Создает экземпляр класса Canvas.
     * @param props Свойства.
     */
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
        
        this.onStartDrag = this.onStartDrag.bind(this);
        this.onDrag = this.onDrag.bind(this);
        this.onEndDrag = this.onEndDrag.bind(this);
        this.setNoFocusElement = this.setNoFocusElement.bind(this);
        this.getMousePosition = this.getMousePosition.bind(this);
        this.onSetZoom = this.onSetZoom.bind(this);
        this.setFocus = this.setFocus.bind(this);
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
                this.setNoFocusElement();
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
            this.setNoFocusElement();
        }
    }

    /**
     * Обработчик передвижения.
     * @param event Объект события.
     */
    onDrag(event) {
        this.mouseCoordinate = this.getMousePosition(event);
        if (this.isPanning) {
            let viewBox = this.canvasSVG.viewBox.animVal;
            let newX = viewBox.x - (this.mouseCoordinate.x - this.startXPanning);
            let newY = viewBox.y - (this.mouseCoordinate.y - this.startYPanning);
            this.canvasSVG.setAttribute('viewBox', `${newX} ${newY} ${viewBox.width} ${viewBox.height}`)
            this.canvasRect.setAttribute('x', newX);
            this.canvasRect.setAttribute('y', newY);
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

    /**
     * Обработчик завершения передвижения.
     */
    onEndDrag() {
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

        let elements = this.canvasSVG.getElementsByTagName('use');
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

    /**
     * Устанавливает визуальный фокус элемента.
     * @param element Элемент.
     */
    setFocus(element) {
        this.setDashArraySelectingRect(element, this.SelectedStrokeWidth, this.SelectedStrokeDashArray);
        this.setState( {
            startXRotateButton: element.getAttribute('x')-16,
            startYRotateButton: element.getAttribute('y')-16} )
    }

    /**
     * Приближает и отдаляет канвас.
     * @param event Объект события.
     */
    onSetZoom(event) {
        event.preventDefault();

        let viewBox = this.canvasSVG.viewBox.animVal;
        let newWidth = viewBox.width;
        let newHeight = viewBox.height;
        if (event.deltaY > 0) {
            newWidth = viewBox.width * (1 + this.ScaleFactor);
            newHeight = viewBox.height * (1 + this.ScaleFactor);
        } else {
            newWidth = viewBox.width * (1 - this.ScaleFactor);
            newHeight = viewBox.height * (1 - this.ScaleFactor);
        }

        if (newWidth < this.props.widthRect || newHeight < this.props.heightRect) {
            return;
        } else if (newWidth >= this.MaxZoomWidth || newHeight >= this.MaxZoomHeight) {
            return;
        }

        this.canvasSVG.setAttribute('viewBox', `${viewBox.x} ${viewBox.y} ${newWidth} ${newHeight}`);
        this.canvasRect.setAttribute('width', newWidth);
        this.canvasRect.setAttribute('height', newHeight);
    }

    /**
     * Устанавливает прерывистые рамки для визуального фокуса элемента.
     * @param element Элемент.
     * @param strokeWidth Ширина рамки.
     * @param strokeDashArray Массив прерывистых линий.
     */
    setDashArraySelectingRect(element, strokeWidth, strokeDashArray) {
        element.setAttributeNS(null, 'stroke-width', strokeWidth);
        element.setAttributeNS(null, 'stroke-dasharray', strokeDashArray);
    }

    /**
     * Убирает фокус со всех элементов.
     */
    setNoFocusAllElements() {
        let elements = this.canvasSVG.getElementsByTagName('use');
        for (var element of elements) {
            this.setDashArraySelectingRect(element, '0', 'none');
        }
        this.setState( {isShowRotateButton: false} );
    }

    /**
     * Убирает фокус с выбранного элемента.
     */
    setNoFocusElement() {
        if (!this.selectedElement) return;

        this.setDashArraySelectingRect(this.selectedElement, '0', 'none');
        this.selectedElement = null;
        this.setState( {isShowRotateButton: false} );
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
    }

    componentDidUpdate(prevProps, prevState, snapshot) {
        if (prevProps !== this.props) {
            this.setNoFocusAllElements();
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
                viewBox={[0, 0, this.props.widthRect*2, this.props.heightRect*2].join(' ')}>
                <rect 
                    fill='url(#grid)' 
                    stroke='none' 
                    rx='0' 
                    ry='0' 
                    id='canvas-rect' 
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
                        <circle cx='0' cy='0' r='2' fill='black' />
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