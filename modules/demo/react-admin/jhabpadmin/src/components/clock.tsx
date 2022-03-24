import React, { useState, Suspense } from "react";
import { ThemeContext, themes } from "./theme-context";

// import FormDemo from "./formdemo";
const FormDemo = React.lazy(() => import("./formdemo"));
const ErrorBoundary = React.lazy(() => import("./ErrorBoundary"));

const ref = React.createRef();

export default class Clock extends React.Component {
  constructor(props: any) {
    super(props);
    //构造函数是唯一可以给 this.state 赋值的地方
    this.state = {
      date: new Date(),
      theme: themes.light,
      toggleTheme: this.toggleTheme,
    };
    //为handlerStopTimer()绑定this
    // this.handlerStopTimer = this.handlerStopTimer.bind(this);
  }
  toggleTheme = () => {
    this.setState((state) => ({
        //@ts-ignore
      theme: state.theme === themes.dark ? themes.light : themes.dark,
    }));
  };
  //dom渲染完之后执行  挂载时执行
  componentDidMount() {
    console.log("Clock上下文");
    console.log(this.context);
    //@ts-ignore
    this.timerId = setInterval(() => {
      this.tick();
    }, 1000);
  }
  //卸载后执行
  componentWillUnmount() {
    this.handlerStopTimer({});
    alert("释放timer");
  }
  render(): React.ReactNode {
    let stop1 = <button onClick={(e) => this.handlerStopTimer(e)}>stop</button>;
    let stop2 = <button onClick={this.handlerClickStopTimer}>stop2</button>;
    let btn;
    //@ts-ignore
    if (this.props.stop === "1") {
      btn = stop1;
      //@ts-ignore
    } else if (this.props.stop === "2") {
      btn = stop2;
    } else {
      return null; //不渲染组件
    }

    //小组件
    function ListItem(props: any) {
      return <li>{props.value}</li>;
    }

    //@ts-ignore
    const numbers = this.props.numbers;
    let numberLi = numbers.map((v: any) => (
      <ListItem key={v.toString()} value={v * 3} num={v} /> //key在兄弟节点必须唯一,key会传递信息给react
    ));

    return (
      <div>
        <h1>Hello,word!</h1>
        {/* @ts-ignore */}
        <h2>time : {this.state.date.toLocaleTimeString()}</h2>
        {/* {btn} */}
        {
          // @ts-ignore
          this.props.stop === "1" ? (
            <button onClick={(e) => this.handlerStopTimer(e)}>stop</button>
          ) : (
            <button onClick={this.handlerClickStopTimer}>stop2</button>
          )
        }
        <ul>{numberLi}</ul>
        <ul>
          {numbers.map((v: any) => (
            <ListItem key={v.toString()} value={v * 3} num={v} />
          ))}
        </ul>
        {/* @ts-ignore */}
        <ThemeContext.Provider value={this.state}>
          {/* 渲染Lazy组件 */}
          <Suspense fallback={<div>Loadding</div>}>
            <ErrorBoundary>
                {/* @ts-ignore */}
              <FormDemo ref={ref} name="formDemoName"></FormDemo>
            </ErrorBoundary>
          </Suspense>
        </ThemeContext.Provider>
      </div>
    );
  }
  handlerStopTimer(e: any) {
    console.log(e);
    //this必须绑定上下文才行，此this并非当前类，this为调用方法得当前上下文。所以需要在构造函数中绑定this,或者使用箭头函数
    //@ts-ignore
    clearInterval(this.timerId);
  }
  //html event 注意this得指向，箭头函数总是指向函数定义时所在得对象
  handlerClickStopTimer = (e: any) => {
    console.log(e);
    console.log(ref);
    //@ts-ignore
    clearInterval(this.timerId);
  };
  tick() {
    // this.setState({ date: new Date() });
    //setState会合并参数到state对象
    this.setState((state, props) => ({
      //@ts-ignore
      date: new Date(),
    }));
  }
}
Clock.contextType = ThemeContext; //赋值数据上下文
