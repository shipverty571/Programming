import React, {Component} from 'react';

class CanvasPages extends Component {
    render() {
        return (
            <div className='horizontal_content' style={{ justifyContent: 'space-between', backgroundColor: '#F3F3F3' }}>
                <fieldset className='horizontal_content' id='PagesGroup'>
                    <input type='radio' value='1' name='PagesGroup' id='Page1' />
                    <label htmlFor='Page1'>Page 1</label>
                    <input type='radio' value='2' name='PagesGroup' id='Page2' />
                    <label htmlFor='Page2'>Page 2</label>
                    <input type='radio' value='3' name='PagesGroup' id='Page3' />
                    <label htmlFor='Page3'>Page 3</label>
                </fieldset>
                <div id='EditPagesCountDiv'>
                    <button id='AddPageButton' />
                    <button id='RemovePageButton' />
                </div>
            </div>
        );
    }
}

export default CanvasPages;