import React, {Component} from 'react';
import Shape from './Shape';
import PropTypes from "prop-types";

/**
 * Компонент группы кнопок элементов.
 */
class ShapesGroup extends Component {
    /**
     * Создает экземпляр класса ShapesGroup.
     * @param props Свойства.
     */
    constructor(props) {
        super(props);
        this.state = {
            isHidden: false
        }
        
        this.showGroup = this.showGroup.bind(this);
    }

    /**
     * Кнопка показа и скрытия блока с кнопками.
     */
    showGroup() {
        this.setState( {isHidden : !this.state.isHidden} )
    }

    /**
     * Рендерит группу элементов.
     * @param name Имя группы.
     * @returns {JSX.Element|string} Возвращает блок с элементами.
     */
    renderGroup(name) {
        switch (name) {
            case 'Fundamental Items':
                return (
                    <div className='shapes-container' hidden={this.state.isHidden}>
                        <Shape name="Resistor" onAddShape={this.props.onAddShape} setIsMove={this.props.setIsMove} />
                        <Shape name="Capacitor" onAddShape={this.props.onAddShape} setIsMove={this.props.setIsMove} />
                        <Shape name="Inductor" onAddShape={this.props.onAddShape} setIsMove={this.props.setIsMove} /> 
                    </div>
                );
            case 'Custom Items':
                return <div className='shapes-container' hidden={this.state.isHidden} />;
            default:
                return 'Not found group';
        }
    }
    
    componentDidUpdate(prevProps, prevState, snapshot) {
        var elements = document
            .getElementById('shapes-group')
            .getElementsByTagName('use');
        for (var element of elements) {
            element.setAttributeNS(null, 'stroke-width', '0');
            element.setAttributeNS(null, 'stroke-dasharray', 'none');
        }
    }

    render() {
        return (
            <div id='shapes-group'>
                <div style={{ display: 'flex' }}>
                    <button 
                        id='shapes-group-button' 
                        onClick={this.showGroup}>
                        <h3>{this.props.groupName}</h3>
                    </button>
                </div>
                {this.state.isHidden && (
                    this.renderGroup(this.props.groupName)
                )}
            </div> 
        );
    }
}
ShapesGroup.propTypes = {
    groupName: PropTypes.string.isRequired,
    onAddShape: PropTypes.func
}
ShapesGroup.defaultProps = {
    onAddShape: (() => ({}))
}

export default ShapesGroup;