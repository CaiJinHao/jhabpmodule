import React from "react";
import { ThemeContext, themes } from "./theme-context";
import logProps from "./LogProps";

class FormDemo extends React.Component {
  constructor(props: any) {
    super(props);
    this.state = {
      value: "111"
    };
  }
  componentDidMount() {
    console.log("FormDemo上下文");
    console.log(this.context);
  }
  render(): React.ReactNode {
    return (
      <div style={{ backgroundColor: this.context.theme.background }}>
        <form onSubmit={this.handleSubmit}>
          <label>
            名字:
            <input
              type="text"
              //@ts-ignore
              value={this.state.value}
              onChange={this.handleChange}
            />
          </label>
          <input type="submit" value="提交" />
          <button onClick={this.manualOprationUpdate}>修改值</button>
        </form>
        <div>
            {/* 多个数据上下文时使用多个进行包裹，但不能使用contextType进行赋值了 */}
          <ThemeContext.Consumer>
            {/* @ts-ignore */}
            {({ theme, toggleTheme }) => (
              <button
                onClick={toggleTheme}
                style={{ backgroundColor: theme.background }}
              >
                Toggle Theme
              </button>
            )}
          </ThemeContext.Consumer>
        </div>
      </div>
    );
  }
  handleSubmit = (event: any) => {
    event.preventDefault();
    //@ts-ignore
    console.log(this.state.value);
  };
  handleChange = (event: any) => {
    // this.setState({value: event.target.value});
    this.setState((state, props) => ({
      //@ts-ignore
      value: event.target.value,
    }));
  };
  manualOprationUpdate = () => {
    this.setState((state, props) => ({
      value: "shoudongupdate",
    }));
  };
}
FormDemo.contextType = ThemeContext;

//“logProps” HOC 透传（pass through）所有 props 到其包裹的组件
export default logProps(FormDemo);
