import React from 'react';

export default function CartColumns() {
  return (
    <div className="container-fluid text-center d-none d-lg-block">
      <div className="row">
        <div className="col-10 mx-auto col-lg-2">
          <p className="text-uppercase">Producto</p>
        </div>
        <div className="col-10 mx-auto col-lg-2">
          <p className="text-uppercase">Nombre</p>
        </div>
        <div className="col-10 mx-auto col-lg-2">
          <p className="text-uppercase">Precio Por Unidad</p>
        </div>
        <div className="col-10 mx-auto col-lg-2">
          <p className="text-uppercase">Cantidad</p>
        </div>
        <div className="col-10 mx-auto col-lg-2">
          <p className="text-uppercase">Borrar</p>
        </div>
        <div className="col-10 mx-auto col-lg-2">
          <p className="text-uppercase">Precio Total</p>
        </div>
      </div>
    </div>
  );
}
