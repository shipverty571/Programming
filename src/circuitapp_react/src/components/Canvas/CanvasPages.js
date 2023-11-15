import React, {Component} from 'react';
import PageButton from "./PageButton";

/**
 * Компонент страниц канваса.
 */
class CanvasPages extends Component {
    render() {
        return (
            <div className='horizontal-content' style={{ justifyContent: 'space-between', backgroundColor: '#F3F3F3' }}>
                <fieldset className='horizontal-content' id='pages-group'>
                    <PageButton id="000111" name="Page 1111" />
                    <PageButton id="0001121" name="Page 1111" />
                    <PageButton id="0001311" name="Page 1111" />
                    {/*<div>
                        <input type='radio' value='1' name='pages-group' id='Page1' />
                        <label htmlFor='Page1'>Page 1</label>
                    </div>
                    <div>
                        <input type='radio' value='2' name='pages-group' id='Page2' />
                        <label htmlFor='Page2'>Page 2</label>
                    </div>
                    <div>
                        <input type='radio' value='3' name='pages-group' id='Page3' />
                        <label htmlFor='Page3'>Page 3</label>
                    </div>*/}
                </fieldset>
                <div id='edit-pages-count-div'>
                    <button id='add-page-button' />
                    <button id='remove-page-button' />
                </div>
            </div>
        );
    }
}

export default CanvasPages;