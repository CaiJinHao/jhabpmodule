import React from 'react'
import ReactDOM from 'react-dom'
import './index.css'
import App from './App'
import Clock from './components/clock'
import { ThemeContext,themes } from './components/theme-context'



ReactDOM.render(
  <React.StrictMode>
    {/* <App /> */}
    {/* @ts-ignore */}
    <Clock stop="2" numbers={[1, 2, 3, 4, 5, 6]}></Clock>
  </React.StrictMode>,
  document.getElementById("root")
);
