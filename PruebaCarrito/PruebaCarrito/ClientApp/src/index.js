import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { BrowserRouter } from 'react-router-dom';
import { StateProvider } from './global-state/state';

ReactDOM.render(
    <StateProvider>
        <BrowserRouter>
            <App />
        </BrowserRouter>
    </StateProvider>,
    document.getElementById('root')
);
