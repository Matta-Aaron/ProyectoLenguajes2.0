import React from 'react';
import ProductItem from '../product-item/ProductItem';
import { useProductState } from '../../../global-state';

export default function ProductList() {
  // Accessing productState
  const { productState } = useProductState();
  const { products } = productState;
  let productItems = products.map(product => (
    <ProductItem key={product.id} product={product} />
  ));
  return (
    <>
      <div className="py-5">
        <div className="container">
          <h1>Nuestros Productos</h1>
          <div className="row">{productItems}</div>
        </div>
      </div>
    </>
  );
}
