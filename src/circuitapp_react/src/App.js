import './App.css';
import SideBar from './components/SideBar/SideBar';
import CanvasBar from './components/Canvas/CanvasBar';
import Header from './components/Header/Header';
import React, {Component} from 'react';
import Resistor from './components/Shapes/Patterns/Resistor';
import Capacitor from './components/Shapes/Patterns/Capacitor';
import Inductor from './components/Shapes/Patterns/Inductor';
import {CapacitorSize, InductorSize, ResistorSize} from "./Resources/ShapesSizes";
import UseResistor from "./components/Shapes/UseShapes/UseResistor";
import $ from "jquery";
import UseCapacitor from "./components/Shapes/UseShapes/UseCapacitor";
import UseInductor from "./components/Shapes/UseShapes/UseInductor";
import {Shapes} from "./components/Shapes/FundamentalShapes";
import Shape from "./components/Shapes/Shape";

/**
 * Главный компонент.
 */
class App extends Component {
    /**
     * Создает экземпляр класса App.
     * @param props Свойства.
     */
    constructor(props) {
        super(props);
        this.state = {
            // TODO Переделать с использованием УГО
            patterns: [
                <Resistor id="ResistorSymbol" />,
                <Capacitor id="CapacitorSymbol" />,
                <Inductor id="InductorSymbol" />
            ],
            shapes: [],
            shapesOfPage: [],
            pages: [],
            selectedPage: null,
            widthRect: 0,
            heightRect:  0,
            activePageId: null,
            canNotRemovePage: true,
            countPages: 1,
            newShapeDrag: null,
            widthDragSvg: 0,
            heightDragSvg: 0,
            isMoveShape: false,
            addShapeName: null,
            refDragShape: null
        }

        this.onAddShape = this.onAddShape.bind(this);
        this.onRemoveShape = this.onRemoveShape.bind(this);
        this.onAddPage = this.onAddPage.bind(this);
        this.onRemovePage = this.onRemovePage.bind(this);
        this.setActivePage = this.setActivePage.bind(this);
        this.setNewPropsShape = this.setNewPropsShape.bind(this);
        this.setIsMove = this.setIsMove.bind(this);
        this.setAddShapeName = this.setAddShapeName.bind(this);
        this.onMouseMoveShape = this.onMouseMoveShape.bind(this);
        this.onMouseUpShape = this.onMouseUpShape.bind(this);
        this.setRefDragShape = this.setRefDragShape.bind(this);
    }

    /**
     * Добавляет элемент в канвас.
     * @param shape Имя элемента, который нужно добавить.
     * @param X Координата X.
     * @param Y Координата Y.
     */
    // TODO Переделать с использованием УГО
    onAddShape(shape, X, Y) {
        let element = null;
        switch (shape) {
            case 'Resistor':
                element = {
                    href: "#ResistorSymbol",
                    width: ResistorSize.width,
                    height: ResistorSize.height
                }
                break;
            case 'Capacitor':
                element = {
                    href: "#CapacitorSymbol",
                    width: CapacitorSize.width,
                    height: CapacitorSize.height
                }
                break;
            case 'Inductor':
                element = {
                    href: "#InductorSymbol",
                    width: InductorSize.width,
                    height: InductorSize.height
                }
                break;
            default:
                break;
        }
        
        if (element) {
            if (!X && !Y) {
                X = 100;
                Y = 100;
            }
            const id = crypto.randomUUID();
            element.id = id;
            element.x = X;
            element.y = Y;
            element.rotate = 0;
            element.page = this.state.activePageId;
            this.setState( previousState => ({ 
                shapes : [...previousState.shapes, element] 
            }), ()=> {
                this.setState({ shapesOfPage: this.state.shapes.filter(shape => shape.page === this.state.activePageId) });
            });
            
        }
    }

    /**
     * Удаляет элемент из коллекции.
     * @param id Уникальный идентификатор элемента, который нужно удалить.
     */
    onRemoveShape(id) {
        if (!id) return;
        
        this.setState(
            previousState => ({ shapes: previousState.shapes.filter(shape => shape.id !== id) }),
            () => {
                this.setState({ shapesOfPage: this.state.shapes.filter(shape => shape.page === this.state.activePageId) });
        });
    }

    /**
     * Добавляет страницу.
     */
    onAddPage() {
        let id = crypto.randomUUID();
        let page = { id: id, name: `Page ${this.state.countPages}` };
        this.setState(previousState => ({ pages : [...previousState.pages, page] }), () => {
            if (this.state.pages.length === 1) {
                this.setActivePage(id);
                this.setState({ canNotRemovePage: true });
            }
            else {
                this.setState({ canNotRemovePage: false });
            }
        });
        this.setState(previousState => ({ countPages: previousState.countPages + 1 }));
    }

    /**
     * Удаляет страницу.
     */
    onRemovePage() {
        this.setState(
            previousState => ({ shapes: previousState.shapes.filter(shape => shape.page !== this.state.activePageId) }),
            ()=> {
            this.setState({ shapesOfPage: this.state.shapes.filter(shape => shape.page === this.state.activePageId) })
        });
        this.setState(
            previousState => ({ pages: previousState.pages.filter(page => page.id !== this.state.activePageId) }), 
            ()=> {
                if (this.state.pages.length === 1) {
                    this.setState({ canNotRemovePage: true });
                }
                else {
                    this.setState({ canNotRemovePage: false });
                }
                this.setActivePage(this.state.pages[0].id);
            });
    }

    /**
     * Устанавливает новые свойства в коллекцию.
     * @param id Уникальный идентификатор элемента, чьи свойства надо обновить.
     * @param props Новые свойства.
     */
    setNewPropsShape(id, props) {
        let shape = this.state.shapes.filter(shape => shape.id === id)[0];
        if (!shape) return;
        let newShape = shape;
        newShape.x = props.X;
        newShape.y = props.Y;
        newShape.rotate = props.rotate;

        let newShapes = this.state.shapes.filter(shape => shape.id !== id)
        newShapes = [...newShapes, newShape];
        this.setState({ shapes: newShapes });
    }

    /**
     * Определяет активную страницу.
     * @param id Уникальный идентификатор страницы.
     */
    setActivePage(id) {
        this.setState({ activePageId: id }, () => {
            this.setState({ shapesOfPage: this.state.shapes.filter(shape => shape.page === id) });
        });
    }

    /**
     * Устанавливает значение в состояние, указывающее, что происходит перенос объекта на канву.
     * @param flag Если true, то объект переносится на канву, иначе false.
     */
    setIsMove(flag) {
        this.setState({ isMoveShape: flag });
    }

    /**
     * Устанавливает имя добавляемого объекта в состояние.
     * @param name Имя добавляемого объекта.
     */
    setAddShapeName(name) {
        this.setState({ addShapeName: name });
    }

    /**
     * Устанавливает ссылку на элемент.
     * @param ref Ссылка.
     */
    setRefDragShape(ref) {
        this.setState({ refDragShape: ref });
    }

    /**
     * Устанавливает в состояние объект, который будет перемещаться в канву.
     * @param event Объект события.
     */
    // TODO Переделать с использованием УГО
    setNewShapeDrag(event) {
        let x = event.screenX;
        let y = event.screenY;
        let element = null;
        let shape = Shapes.filter(shape => shape.name === this.state.addShapeName);
        if (shape.length === 0) {
            return;
        }
        element = <Shape x={x} y={y} ref={this.setRefDragShape} html={shape[0].html} />
        /*switch (this.state.addShapeName) {
            case 'Resistor':
                element = 
                break;
            case 'Capacitor':
                element = <UseCapacitor ref={this.setRefDragShape} href="#CapacitorSymbol" x={x} y={y} />
                break;
            case 'Inductor':
                element = <UseInductor ref={this.setRefDragShape} href="#InductorSymbol" x={x} y={y} />
                break;
            default:
                break;
        }*/
        if (element) {
            this.setState({ newShapeDrag: element });
        }
    }

    /**
     * Срабатывает при переносе элементов с меню в канву.
     * @param event Объект события.
     */
    onMouseMoveShape(event) {
        if (!this.state.isMoveShape) {
            return;
        }
        if (!this.state.newShapeDrag) {
            this.setNewShapeDrag(event);
            return;
        } 
        if (this.state.refDragShape) {
            let dragSvg = document.getElementById('dragShapesToCanvasSvg');
            let ctm = dragSvg.getScreenCTM();
            let x = (event.clientX - ctm.e) / ctm.a;
            let y = (event.clientY - ctm.f) / ctm.d;
            console.log(this.state.refDragShape)
            this.state.refDragShape.setCoordinate(x, y);
        }
    }

    /**
     * Срабатывает, когда левая кнопка мыши отпускается
     */
    onMouseUpShape() {
        if (!this.state.isMoveShape) {
            return;
        }
        this.setIsMove(false);
    }

    /**
     * Срабатывает при вхождении мыши в элемент.
     */
    onMouseEnter() {
        if (!this.state.newShapeDrag) {
            return;
        }
        this.setState({ newShapeDrag: null, refDragShape: null });
        this.setIsMove(false);
        this.setAddShapeName(null);
    }

    componentDidMount() {
        if (this.state.pages.length === 0) {
            this.onAddPage();
        }
    }
    
    componentDidUpdate(prevProps, prevState, snapshot) {
        if (this.state.newShapeDrag !== prevState.newShapeDrag) {
            let svg = $('#dragShapesToCanvasSvg');
            this.setState({ widthDragSvg: svg.width(), heightDragSvg: svg.height() });
        }
    }

    render() {
        return (
            <div className='container-column' style={{ flexGrow: 2, margin: 0 }}>
                {this.state.isMoveShape && (
                    <svg 
                        id='dragShapesToCanvasSvg' 
                        style={{ zIndex: 1000, position: "fixed", width: '100%', height: '100%'}}
                        viewBox={[0, 0, this.state.widthDragSvg * 2, this.state.heightDragSvg * 2].join(' ')}
                        onMouseMove={(event) => this.onMouseMoveShape(event)}
                        onMouseUp={() => this.onMouseUpShape()}
                        onMouseLeave={() => this.onMouseUpShape()}>
                        {this.state.newShapeDrag}
                        {this.state.patterns.map(pattern => pattern)};
                    </svg>
                )}
                <div 
                    className='container-column' 
                    style={{ flexGrow: 2, margin: '10px' }} 
                    onMouseEnter={() => this.onMouseEnter()}>
                    <div className='container-row' style={{ justifyContent: 'left' }}>
                        <div className='container-column'>
                            <Header />
                        </div>
                    </div>
                    <div className='App container-row' style={{ flexGrow: 2 }}>
                        <div className='container-column' style={{ width: '400px', backgroundColor: '#F3F3F3' }}>
                            <SideBar 
                                onAddShape={this.onAddShape} 
                                setIsMove={this.setIsMove} 
                                setAddShapeName={this.setAddShapeName}
                            />
                        </div>
                        <div className='container-column'>
                            <CanvasBar
                                patterns={this.state.patterns}
                                shapes={this.state.shapesOfPage}
                                onRemoveShape={this.onRemoveShape}
                                onAddPage={this.onAddPage}
                                onRemovePage={this.onRemovePage}
                                pages={this.state.pages}
                                setActivePage={this.setActivePage}
                                activePageId={this.state.activePageId}
                                setNewPropsShape={this.setNewPropsShape}
                                canNotRemovePage={this.state.canNotRemovePage}
                                newShapeDragName={this.state.addShapeName}
                                onAddShape={this.onAddShape}
                            />
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default App;
