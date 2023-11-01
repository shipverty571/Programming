import React, {Component} from 'react';
import MenuBar from '../Menu/MenuBar';

class Header extends Component {
    render() {
        return (
            <div style={{ display: 'flex', minWidth: '100%' }}>
                <h1 style={{ float: 'left' }}>SCHEMA_NAME</h1>
                <div style={{ width: '100%', margin: '5px' }}>
                    <MenuBar />
                </div>
            </div>
        );
    }
}

export default Header;