import React, {Component} from 'react';
import PageButton from "./PageButton";

/**
 * Компонент страниц канваса.
 */
class CanvasPages extends Component {
    render() {
        return (
            <div className='horizontal-content' id='canvas-pages'>
                <div id='edit-pages-count-div'>
                    <button id='add-page-button' onClick={() => this.props.onAddPage()} />
                    <button 
                        id='remove-page-button' 
                        onClick={() => this.props.onRemovePage()} 
                        disabled={this.props.canNotRemovePage} 
                    />
                </div>
                <div id='pages-group'>
                    {this.props.pages.map(page =>
                        <PageButton
                            key={page.id}
                            id={page.id}
                            name={page.name}
                            activePageId={this.props.activePageId}
                            setActivePage={this.props.setActivePage}
                        />)}
                </div>
            </div>
        );
    }
}

export default CanvasPages;