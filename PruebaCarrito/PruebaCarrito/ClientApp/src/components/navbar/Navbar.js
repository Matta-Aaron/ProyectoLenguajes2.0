import React from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';

export default function Navbar() {
    return (
        <NavWrapper className="navbar navbar-expand-sm navbar-dark px-sm-5">

            <ul className="navbar-nav align-items-center">
                <li className="nav-item ml-5">
                    <Link to="/" className="nav-link">

                        <img src="http://www.agenciaeplus.com.br/wp-content/uploads/2017/07/ecommerce-website-design-services.png" width="35" height="35" />

                        HOME
                    </Link>
                </li>
            </ul>
            <Link to="/cart" className="ml-auto">

                <span className="mr-2">
                    <i className="fas fa-cart-plus" />
                </span>
                Mi Carro
      
             </Link>
        </NavWrapper>
    );
}

const NavWrapper = styled.nav`
  background: var(--negro);
  .nav-link {
    color: var(--blanco) !important;
    font-size: 1.3rem;
    text-transform: capitalize;
  }
`;
