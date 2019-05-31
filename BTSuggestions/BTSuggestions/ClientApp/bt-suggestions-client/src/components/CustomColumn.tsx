import React from "react";
import ReactDOM from "react-dom";
import "antd/dist/antd.css";
import { Menu, Icon } from "antd";

const { SubMenu } = Menu;

class App extends React.Component {
  state = {
    current: "mail"
  };

  handleClick = e => {
    console.log("click ", e);
    this.setState({
      current: e.key
    });
  };

  render() {
    return (
      <Menu
        onClick={this.handleClick}
        selectedKeys={[this.state.current]}
        mode="horizontal"
      >
        <SubMenu
          title={ 
            <span className="hi">              
              Navigation Three - Submenu
            </span>
          }
        >
          <Menu.Item key="setting:1 onTitleClick">Option 1</Menu.Item>
          <Menu.Item key="setting:2">Option 2</Menu.Item>
        </SubMenu>
      
      </Menu>
    );
  }
}

ReactDOM.render(<App />, document.getElementById("container"));
