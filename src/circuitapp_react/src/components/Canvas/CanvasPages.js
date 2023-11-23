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
                    {this.props.pages.map(page => 
                        <PageButton 
                            key={page.id} 
                            id={page.id} 
                            name="Page 1" 
                            activePageId={this.props.activePageId} 
                            setActivePage={this.props.setActivePage} 
                        />)}
                </fieldset>
                <div id='edit-pages-count-div'>
                    <button id='add-page-button' onClick={() => this.props.onAddPage()} />
                    <button id='remove-page-button' onClick={() => this.props.onRemovePage()} />
                </div>
            </div>
        );
    }
}

export default CanvasPages;