import React, {Component} from 'react';

class MenuBar extends Component {
    render() {
        return (
            <div className="horizontal_content" style={{justifyContent : "right", height: "100%", flexDirection: "row", alignItems: "flex-end" }}>
                <label id="TimeSavedLabel">saved at 15:08</label>
                <button id="FolderButton" />
                <button id="SaveButton" />
            </div>
        );
    }
}

export default MenuBar;