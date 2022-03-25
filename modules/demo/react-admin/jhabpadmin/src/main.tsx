import React,{Profiler} from 'react'
import ReactDOM from 'react-dom'
import './index.css'
import App from './App'
import Clock from './components/clock'
import { ThemeContext,themes } from './components/theme-context'

//测量渲染一个 React 应用多久渲染一次以及渲染一次的“代价”
function onRenderCallback(
  id:string, // 发生提交的 Profiler 树的 “id”
  phase:any, // "mount" （如果组件树刚加载） 或者 "update" （如果它重渲染了）之一
  actualDuration:number, // 本次更新 committed 花费的渲染时间
  baseDuration:number, // 估计不使用 memoization 的情况下渲染整颗子树需要的时间
  startTime:number, // 本次更新中 React 开始渲染的时间
  commitTime:number, // 本次更新中 React committed 的时间
  interactions:any // 属于本次更新的 interactions 的集合
) {
  // 合计或记录渲染时间。。。
  console.log(phase);
  console.log(`actualDuration:${actualDuration}`);
  console.log(`baseDuration:${baseDuration}`);
  console.log(`startTime:${startTime}`);
  console.log(`commitTime:${commitTime}`);
  console.log(interactions);
}

ReactDOM.render(
  /* 启用严格模式 */
  <React.StrictMode>
    {/* <App /> */}
    <Profiler id="clock-profiler" onRender={onRenderCallback}>
    {/* @ts-ignore */}
    <Clock  numbers={[1, 2, 3, 4, 5, 6]}></Clock>
    </Profiler>
  </React.StrictMode>,
  document.getElementById("root")
);
