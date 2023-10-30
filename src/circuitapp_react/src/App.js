import './App.css';
import SideBar from "./components/SideBar/SideBar";
import CanvasBar from "./components/Canvas/CanvasBar";
import Header from "./components/Header/Header";
import {Component} from "react";
import Resistor from "./components/Shapes/Patterns/Resistor";
import UseResistor from "./components/Shapes/UseShapes/UseResistor";
import Capacitor from "./components/Shapes/Patterns/Capacitor";
import Inductor from "./components/Shapes/Patterns/Inductor";
import UseCapacitor from "./components/Shapes/UseShapes/UseCapacitor";
import UseInductor from "./components/Shapes/UseShapes/UseInductor";
import $ from "jquery";

class App extends Component {
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
    render() {
        return (
            <div className="container_column">
                <div className="container_row" style={{justifyContent: "left"}}>
                    <div className="container_column">
                        <Header />
                    </div>
                </div>
                <div className="App container_row" style={{flexGrow: 2}}>
                    <div className="container_column" style={{width: "400px", backgroundColor: "#F3F3F3"}}>
                        <SideBar onAddShape={this.onAddShape} />
                    </div>
                    <div className="container_column" >
                        <CanvasBar 
                            patterns={this.state.patterns}
                            shapes={this.state.shapes} 
                            widthRect={this.state.widthRect} 
                            heightRect={this.state.heightRect} />
                    </div>
                </div>
            </div>
        );
    }
    
    componentDidMount() {
        this.setState({ widthRect : $("#CanvasPanel").width() })
        this.setState({ heightRect:  $("#CanvasPanel").height() })
    }
    
    onAddShape(shape) {
        var element = null;
        switch (shape) {
            case "Resistor":
                element = <UseResistor href="#ResistorSymbol" x="100" y="100" />
                break;
            case "Capacitor":
                element = <UseCapacitor href="#CapacitorSymbol" x="100" y="100" />
                break;
            case "Inductor":
                element = <UseInductor href="#InductorSymbol" x="100" y="100" />
                break;
            default:
                console.log("error");
                break;
        }
        
        if (element) {
            this.setState({shapes : [...this.state.shapes, element]})
        }
    }
}

export default App;
