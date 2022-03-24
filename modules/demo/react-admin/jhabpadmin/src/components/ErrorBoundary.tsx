import React from "react";

export default class ErrorBoundary extends React.Component {
    constructor(props:any) {
      super(props);
      this.state = { hasError: false };
    }
  
    static getDerivedStateFromError(error:any) {
      // 更新 state 使下一次渲染能够显示降级后的 UI
      return { hasError: true };
    }
  
    componentDidCatch(error:any, errorInfo:any) {
      // 你同样可以将错误日志上报给服务器
      //@ts-ignore
      // logErrorToMyService(error, errorInfo);
    }
  
    render() {
      //@ts-ignore
      if (this.state.hasError) {
        // 你可以自定义降级后的 UI 并渲染
        return <h1>这个组件有点错误要处理.</h1>;
      }
      //返回slot得内容
      return this.props.children; 
    }
  }