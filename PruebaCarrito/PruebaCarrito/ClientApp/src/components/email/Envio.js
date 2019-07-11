import React, { Component } from 'react';
import { Col, Grid, Row, Button } from 'react-bootstrap';


class Envio extends Component {

    constructor() {
        super()

        this.state = {
            name: '',
            email: '',
            message: ''
        }
        this.handleChange = this.handleChange.bind(this)

    }

    handleChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    contactUs() {
 

    }


    render() {
        return (
            <form>
                <Row>
                    <Col sm={2}>
                        <label for="nya">Nombre:</label>
                    </Col>

                    <Col sm={2}>
                        <input type="text" name="name" id="name" onChange={this.handleChange} />
                    </Col>
                </Row>
                <Row>
                    <Col sm={2}>
                        <label for="email">Correo:</label>
                    </Col>
                    <Col sm={2}>
                        <input type="text" name="email" id="email" onChange={this.handleChange} />
                    </Col>

                </Row>

                <Row>
                    <Col sm={2}>
                        <label for="email">Mensaje:</label>
                    </Col>
                    <Col sm={2}>
                        <input type="textarea" name="message" id="message" onChange={this.handleChange} />
                    </Col>

                </Row>

                <Row>
                    <Col sm={2}>
                        <label></label>
                    </Col>
                    <Col sm={2}>

                    </Col>

                </Row>
                <Button onClick={this.contactUs.bind(this)}  id="idBtnEnviar" >Enviar!!!</Button>
            </form>

        )
    }
}

export default Envio;