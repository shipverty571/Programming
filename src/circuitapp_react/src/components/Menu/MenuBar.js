import React, {Component} from 'react';

/**
 * Компонент, содержащий кнопки меню.
 */
class MenuBar extends Component {
    render() {
        return (
            <div 
                className='horizontal-content' 
                style={{ justifyContent : 'right', height: '100%', flexDirection: 'row', alignItems: 'flex-end' }}>
                <label id='time-saved-label'>saved at 15:08</label>
                <button id='download-button' />
            </div>
        );
    }
}

export default MenuBar;