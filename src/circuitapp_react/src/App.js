import './App.css';
import SideBar from './components/SideBar/SideBar';
import CanvasBar from './components/Canvas/CanvasBar';
import Header from './components/Header/Header';
import React, {Component} from 'react';
import Resistor from './components/Shapes/Patterns/Resistor';
import UseResistor from './components/Shapes/UseShapes/UseResistor';
import Capacitor from './components/Shapes/Patterns/Capacitor';
import Inductor from './components/Shapes/Patterns/Inductor';
import UseCapacitor from './components/Shapes/UseShapes/UseCapacitor';
import UseInductor from './components/Shapes/UseShapes/UseInductor';
import {CapacitorSize, InductorSize, ResistorSize} from "./Resources/ShapesSizes";
import $ from 'jquery';
import PageButton from "./components/Canvas/PageButton";

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
            patterns: [
                <Resistor id="ResistorSymbol" />,
                <Capacitor id="CapacitorSymbol" />,
                <Inductor id="InductorSymbol" />
            ],
            shapes: [],
            refsShapes: [],
            shapesOfPage: [],
            pages: [],
            selectedPage: null,
            widthRect: 0,
            heightRect:  0,
            activePageId: null,
            canNotRemovePage: true
        }

        this.onAddShape = this.onAddShape.bind(this);
        this.onRemoveShape = this.onRemoveShape.bind(this);
        this.onAddPage = this.onAddPage.bind(this);
        this.onRemovePage = this.onRemovePage.bind(this);
        this.setActivePage = this.setActivePage.bind(this);
        this.setNewPropsShape = this.setNewPropsShape.bind(this);
    }

    /**
     * Добавляет элемент в канвас.
     * @param shape Имя элемента, который нужно добавить.
     */
    onAddShape(shape) {
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
            const X = 100;
            const Y = 100;
            const id = crypto.randomUUID();
            
            element.id = id;
            element.x = X;
            element.y = Y;
            element.rotate = 0;
            element.page = this.state.activePageId;
            console.log(this.state.shapes)
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
        
        this.setState(previousState => ({ shapes: previousState.shapes.filter(shape => shape.id !== id) }), () => {
            this.setState({ shapesOfPage: this.state.shapes.filter(shape => shape.page === this.state.activePageId) });
        });
    }
     
    onAddPage() {
        let id = crypto.randomUUID();
        let page = { id: id }
        /*let page = <PageButton key={id} id={id} name="Page 1" activePageId={this.state.activePageId} onChange={this.setActivePage} />*/
        this.setState(previousState => ({ pages : [...previousState.pages, page] }), () => {
            if (this.state.pages.length === 1) {
                this.setActivePage(id);
                this.setState({ canNotRemovePage: true });
            }
            else {
                this.setState({ canNotRemovePage: false });
            }
        })
    }
    
    onRemovePage() {
        this.setState(
            previousState => ({ shapes: previousState.shapes.filter(shape => shape.page !== this.state.activePageId) }),
            ()=> {
            this.setState({ shapesOfPage: this.state.shapes.filter(shape => shape.page === this.state.activePageId) })
        });
        this.setState(
            previousState => ({ pages: previousState.pages.filter(page => page.id !== this.state.activePageId) }), ()=> {
                if (this.state.pages.length === 1) {
                    this.setState({ canNotRemovePage: true });
                }
                else {
                    this.setState({ canNotRemovePage: false });
                }
            });
    }

    setNewPropsShape(id, props) {
        let shape = this.state.shapes.filter(shape => shape.id === id)[0]
        let newShape = shape;
        newShape.x = props.X;
        newShape.y = props.Y;
        newShape.rotate = props.rotate;

        let newShapes = this.state.shapes.filter(shape => shape.id !== id)
        newShapes = [...newShapes, newShape];
        this.setState({ shapes: newShapes }, () => console.log(this.state.shapes));
    }
    
    setActivePage(id) {
        this.setState({ activePageId: id }, () => {
            this.setState({ shapesOfPage: this.state.shapes.filter(shape => shape.page === id) });
        });
    }

    componentDidMount() {
        if (this.state.pages.length === 0) {
            this.onAddPage();
        }
    }

    render() {
        return (
            <div className='container-column'>
                <div className='container-row' style={{ justifyContent: 'left' }}>
                    <div className='container-column'>
                        <Header />
                    </div>
                </div>
                <div className='App container-row' style={{ flexGrow: 2 }}>
                    <div className='container-column' style={{ width: '400px', backgroundColor: '#F3F3F3' }}>
                        <SideBar onAddShape={this.onAddShape} />
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
                        />
                    </div>
                </div>
            </div>
        );
    }
}

export default App;
