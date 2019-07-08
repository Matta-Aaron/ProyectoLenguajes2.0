import React from 'react';
import { ProductProvider, CartProvider } from './';

function ProviderComposer({ contexts, children }) {
  return contexts.reduceRight(
    // kids = accumulator, parent = currentValue
    (kids, parent) =>
      React.cloneElement(parent, {
        children: kids
      }),
    // initialValue for kids
    children
  );
}

function StateProvider({ children }) {
  return (
    <ProviderComposer
      contexts={[<ProductProvider />, <CartProvider />]}
    >
      {children}
    </ProviderComposer>
  );
}

export { StateProvider };
