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
            pages: [],
            selectedPage: null,
            widthRect: 0,
            heightRect:  0
        }

        this.onAddShape = this.onAddShape.bind(this);
        this.onRemoveShape = this.onRemoveShape.bind(this);
        this.setRefToShape = this.setRefToShape.bind(this);
        this.onAddPage = this.onAddPage.bind(this);
        this.onRemovePage = this.onRemovePage.bind(this);
    }

    /**
     * Добавляет ссылку на элемент в коллекцию.
     * @param ref Ссылка.
     */
    setRefToShape = (ref) => {
        this.setState( previousState => ({
            refsShapes : [...previousState.refsShapes, ref]
        }));
    }

    /**
     * Добавляет элемент в канвас.
     * @param shape Имя элемента, который нужно добавить.
     */
    onAddShape(shape) {
        let element = null;
        const X = 100;
        const Y = 100;
        const id = crypto.randomUUID();
        
        switch (shape) {
            case 'Resistor':
                element = <UseResistor 
                    href="#ResistorSymbol" 
                    x={X} 
                    y={Y} 
                    id={id} 
                    key={id}
                    width={250}
                    height={150}
                    ref={this.setRefToShape} 
                />
                break;
            case 'Capacitor':
                element = <UseCapacitor 
                    href="#CapacitorSymbol" 
                    x={X} 
                    y={Y} 
                    id={id}
                    key={id}
                    width={150}
                    height={150}
                    ref={this.setRefToShape} 
                />
                break;
            case 'Inductor':
                element = <UseInductor 
                    href="#InductorSymbol" 
                    x={X} 
                    y={Y}
                    id={id}
                    key={id}
                    width={300}
                    height={100}
                    ref={this.setRefToShape}
                />
                break;
            default:
                break;
        }
        
        if (element) {
            this.setState( previousState => ({ 
                shapes : [...previousState.shapes, element] 
            }));
        }
    }

    /**
     * Удаляет элемент из коллекции.
     * @param id Уникальный идентификатор элемента, который нужно удалить.
     */
    onRemoveShape(id) {
        if (!id) return;
        
        this.setState(previousState => ({ shapes: previousState.shapes.filter(shape => shape.props.id !== id) }));
    }
     
    onAddPage() {
        let id = crypto.randomUUID();
        let page = <PageButton id={id} name="Page 1" />
        this.setState(previousState => ({ pages : [...previousState.pages, page] }), ()=>{console.log(this.state.pages)})
    }
    
    onRemovePage() {
        
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
                            shapes={this.state.shapes}
                            widthRect={this.state.widthRect}
                            heightRect={this.state.heightRect}
                            refs={this.state.refsShapes}
                            onRemoveShape={this.onRemoveShape}
                            onAddPage={this.onAddPage}
                            onRemovePage={this.onRemovePage}
                            pages={this.state.pages}
                        />
                    </div>
                </div>
            </div>
        );
    }
}

export default App;
