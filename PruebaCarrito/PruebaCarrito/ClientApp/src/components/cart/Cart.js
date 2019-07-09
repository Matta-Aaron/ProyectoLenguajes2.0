import React from 'react';
import CartColumns from './CartColumns';
import EmptyCart from './EmptyCart';
import CartList from './CartList';
import CartTotal from './CartTotal';
import { useCartState } from '../../global-state';

export default function Cart() {
  const { cartState, cartActions } = useCartState();
  const { cart } = cartState;
  let content;
  content =
    cart.length > 0 ? (
      <>
          <h1 al>Tu Lista de Compras</h1>
          <h1/>
        <CartColumns />
        <CartList cart={cart} />
        <CartTotal cartState={cartState} cartActions={cartActions} />
      </>
    ) : (
      <EmptyCart />
    );
  return content;
}
