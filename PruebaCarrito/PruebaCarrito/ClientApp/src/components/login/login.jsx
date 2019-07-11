import React from "react";


export class Login extends React.Component {
  constructor(props) {
      super(props);
      

      this.state = {
          username: '',
          password: ''
       
      }
      this.handleChange = this.handleChange.bind(this)

  }

    handleChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }
    
  render() {
    return (
      <div className="base-container" ref={this.props.containerRef}>
        <div className="header">Login</div>
        <div className="content">
          
          <div className="form">
            <div className="form-group">
              <label htmlFor="username">Username</label>
                        <input type="text" name="username" placeholder="username" id="username" onChange={this.handleChange}/>
            </div>
            <div className="form-group">
              <label htmlFor="password">Password</label>
                        <input type="password" name="password" placeholder="password" id="password" onChange={this.handleChange} />
            </div>
          </div>
        </div>
        <div className="footer">
                <button type="button" className="btn">
                    
            Login
        </button>
             
        </div>
      </div>
    );
  }
}
