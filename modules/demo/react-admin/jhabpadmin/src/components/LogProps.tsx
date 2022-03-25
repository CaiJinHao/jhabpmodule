
import React from "react";
//@ts-ignore
import hoistNonReactStatics from 'hoist-non-react-statics';

//HOC高阶组件是参数为组件，返回值为新组件的函数.它是一种基于 React 的组合特性而形成的设计模式
//@ts-ignore
export default function logProps(Component) {
    class LogProps extends React.Component {
      componentDidUpdate(prevProps:any) {
        console.log('old props:', prevProps);
        console.log('new props:', this.props);
       
      }
  
      render() {//此方法不允许使用HOC
          //@ts-ignore
        const {forwardedRef, ...rest} = this.props;//可以接收当前高阶组件中需要使用的props
  
        // 将自定义的 prop 属性 “forwardedRef” 定义为 ref
        return <Component ref={forwardedRef} {...rest} />;
      }
    }
    if (Component.name) {
      Component.displayName = Component.name; //包装显示名称以便轻松调试
    }
    
    //copy组件的所有静态方法
    hoistNonReactStatics(LogProps,Component);
  
    // 注意 React.forwardRef 回调的第二个参数 “ref”。
    // 我们可以将其作为常规 prop 属性传递给 LogProps，例如 “forwardedRef”
    // 然后它就可以被挂载到被 LogProps 包裹的子组件上。
    return React.forwardRef((props, ref) => {
          //@ts-ignore
      return <LogProps {...props} forwardedRef={ref} />;
    });
  }