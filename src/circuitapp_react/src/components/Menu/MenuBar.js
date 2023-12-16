import React, {Component} from 'react';
import toImg from 'react-svg-to-image'

/**
 * Компонент, содержащий кнопки меню.
 */
class MenuBar extends Component {
    saveSvgToPng() {
        /*const result = await window.chooseFileSystemEntries({ type: "save-file" });
        console.log(result);*/
        let svg = document.getElementById('canvas-panel');
        toImg('#canvas-panel', 'test', {
            scale: 1,
            format: 'png',
            download: true,
            /*ignore: '#canvas-rect'*/
        });
        console.log("success")
    }
    
    render() {
        return (
            <div 
                className='horizontal-content' 
                style={{ justifyContent : 'right', height: '100%', flexDirection: 'row', alignItems: 'flex-end' }}>
                <label id='time-saved-label'>saved at 15:08</label>
                <button id='download-button' onClick={() => this.saveSvgToPng()} />
            </div>
        );
    }
}

export default MenuBar;