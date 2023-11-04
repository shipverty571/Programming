import React, {Component} from 'react';

/**
 * Компонент строки поиска элемента.
 */
class SearchInput extends Component {
    render() {
        return (
            <div style={{ display: 'flex' }}>
                <input style={{ flexGrow: 1 }} placeholder={'Search...'} id='search-input' type='text' />
            </div>
        );
    }
}

export default SearchInput;