import { Component, input } from '@angular/core';
import { Product } from '../models/product.model';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-product-item',
  imports: [CurrencyPipe],
  template: `
    <div class="product-card">
      <img [src]="product().image" [alt]="product().name" class="product-image" />
      <div class="product-info">
        <h3 class="product-name">{{ product().name }}</h3>
        <p class="product-price">{{ product().price | currency }}</p>
      </div>
    </div>
  `,
  styles: `
    .product-card {
      border: 1px solid #e0e0e0;
      border-radius: 8px;
      overflow: hidden;
      transition: box-shadow 0.2s;
    }
    .product-card:hover {
      box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    }
    .product-image {
      width: 100%;
      height: 200px;
      object-fit: cover;
    }
    .product-info {
      padding: 12px;
    }
    .product-name {
      margin: 0 0 8px;
      font-size: 1rem;
    }
    .product-price {
      margin: 0;
      font-weight: bold;
      color: #2a7ae2;
    }
  `
})
export class ProductItemComponent {
  product = input.required<Product>();
}
