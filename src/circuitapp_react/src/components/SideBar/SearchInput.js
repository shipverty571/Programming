import React, {Component} from 'react';

class SearchInput extends Component {
    render() {
        return (
            <div style={{display: "flex"}}>
                <input style={{flexGrow: 1}} placeholder={"Search..."} id="SearchInput" type="text"/>
            </div>
        );
    }
}

export default SearchInput;