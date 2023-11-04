import './App.css';
import SideBar from './components/SideBar/SideBar';
import CanvasBar from './components/Canvas/CanvasBar';
import Header from './components/Header/Header';
import {Component} from 'react';
import Resistor from './components/Shapes/Patterns/Resistor';
import UseResistor from './components/Shapes/UseShapes/UseResistor';
import Capacitor from './components/Shapes/Patterns/Capacitor';
import Inductor from './components/Shapes/Patterns/Inductor';
import UseCapacitor from './components/Shapes/UseShapes/UseCapacitor';
import UseInductor from './components/Shapes/UseShapes/UseInductor';
import $ from 'jquery';

/**
 * Главный компонент.
 */
class App extends Component {
    /**
     * Создает экземпляр класса App.
     * @param props Пропсы.
     */
    constructor(props) {
        super(props);
        this.state = {
            patterns: [
                <Resistor id="ResistorSymbol" />,
                <Capacitor id="CapacitorSymbol" />,
                <Inductor id="InductorSymbol" />
            ],
            shapes : [],
            widthRect : 0,
            heightRect:  0
        }
        
        this.onAddShape = this.onAddShape.bind(this);
    }
    
    componentDidMount() {
        let canvas = $('#canvas-panel');
        this.setState({ widthRect : canvas.width() });
        this.setState({ heightRect:  canvas.height() });
    }

    /**
     * Добавляет элемент в канвас.
     * @param shape Имя элемента, который нужно добавить.
     */
    onAddShape(shape) {
        let element = null;
        const X = 100;
        const Y = 100;
        
        switch (shape) {
            case 'Resistor':
                element = <UseResistor href="#ResistorSymbol" x={X} y={Y} />
                break;
            case 'Capacitor':
                element = <UseCapacitor href="#CapacitorSymbol" x={X} y={Y} />
                break;
            case 'Inductor':
                element = <UseInductor href="#InductorSymbol" x={X} y={Y} />
                break;
            default:
                break;
        }
        
        if (element) {
            this.setState({ shapes : [...this.state.shapes, element] });
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
                    <div className='container-column' >
                        <CanvasBar
                            patterns={this.state.patterns}
                            shapes={this.state.shapes}
                            widthRect={this.state.widthRect}
                            heightRect={this.state.heightRect}
                        />
                    </div>
                </div>
            </div>
        );
    }
}

export default App;
