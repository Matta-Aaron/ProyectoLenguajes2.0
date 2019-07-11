import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';

export default function CartTotal({ cartState, cartActions }) {
  const { cart, subtotal, iva, total } = cartState;
  const { addTotals, clearCart } = cartActions;
  // Updating Total value
  useEffect(() => {
    addTotals();
  }, [subtotal]);
  return (
    <div className="container">
      <div className="row">
        <div className="col-10 mt-2 ml-sm-5 ml-md-auto col-sm-8 text-capitalized text-right">
          <Link to="/">
            <button
              onClick={() => clearCart(cart)}
              className="btn btn-outline-danger text-uppercase mb-3 px-5"
              type="button"
            >
              Limpiar Lista Productos
            </button>
                  </Link>

                  <Link to="/Envio">
                      <button
                          className="btn btn-outline-danger text-uppercase mb-3 px-5"
                          type="button"
                      >
                          Enviar Correo
            </button>
                  </Link>


          <h3>
            <span className="text-title">Subtotal: </span>
            <strong>${subtotal}</strong>
          </h3>
          <h5>
            <span className="text-title">I.V.A: </span>
            <strong>${iva}</strong>
          </h5>
          <h5>
            <span className="text-title">Total: </span>
            <strong>${total}</strong>
          </h5>
        </div>
      </div>
    </div>
  );
}
