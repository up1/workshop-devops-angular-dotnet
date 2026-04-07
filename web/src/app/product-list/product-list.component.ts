import { Component, inject, signal, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { timeout, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { Product, ProductsResponse } from '../models/product.model';
import { ProductItemComponent } from '../product-item/product-item.component';

@Component({
  selector: 'app-product-list',
  imports: [ProductItemComponent],
  template: `
    <div class="container">
      <h1>Products</h1>

      @if (loading()) {
        <div class="loading">Loading products...</div>
      }

      @if (error()) {
        <div class="error">{{ error() }}</div>
      }

      @if (!loading() && !error()) {
        <div class="product-grid">
          @for (product of products(); track product.id) {
            <app-product-item [product]="product" />
          }
        </div>

        <div class="pagination">
          <button
            (click)="goToPage(currentPage() - 1)"
            [disabled]="currentPage() <= 1"
          >
            Previous
          </button>
          <span>Page {{ currentPage() }} of {{ totalPages() }}</span>
          <button
            (click)="goToPage(currentPage() + 1)"
            [disabled]="currentPage() >= totalPages()"
          >
            Next
          </button>
        </div>
      }
    </div>
  `,
  styles: `
    .container {
      max-width: 1000px;
      margin: 0 auto;
      padding: 20px;
    }
    h1 {
      text-align: center;
      margin-bottom: 24px;
    }
    .product-grid {
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
      gap: 16px;
    }
    .pagination {
      display: flex;
      justify-content: center;
      align-items: center;
      gap: 16px;
      margin-top: 24px;
    }
    .pagination button {
      padding: 8px 16px;
      border: 1px solid #ccc;
      border-radius: 4px;
      background: #fff;
      cursor: pointer;
    }
    .pagination button:disabled {
      opacity: 0.5;
      cursor: not-allowed;
    }
    .loading {
      text-align: center;
      padding: 40px;
      font-size: 1.2rem;
      color: #666;
    }
    .error {
      text-align: center;
      padding: 40px;
      color: #d32f2f;
      font-size: 1.1rem;
    }
  `
})
export class ProductListComponent implements OnInit {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5001/api/products';
  private limit = 10;

  products = signal<Product[]>([]);
  loading = signal(false);
  error = signal<string | null>(null);
  currentPage = signal(1);
  total = signal(0);
  totalPages = signal(0);

  ngOnInit() {
    this.fetchProducts(1);
  }

  goToPage(page: number) {
    this.fetchProducts(page);
  }

  private fetchProducts(page: number) {
    this.loading.set(true);
    this.error.set(null);

    this.http
      .get<ProductsResponse>(this.apiUrl, {
        params: { page: page.toString(), limit: this.limit.toString() }
      })
      .pipe(
        timeout(5000),
        catchError((err) => {
          const message =
            err.name === 'TimeoutError'
              ? 'Request timed out. Please try again.'
              : err.error?.error || 'Failed to load products.';
          this.error.set(message);
          this.loading.set(false);
          return of(null);
        })
      )
      .subscribe((data) => {
        if (data) {
          this.products.set(data.products);
          this.total.set(data.total);
          this.currentPage.set(data.page);
          this.totalPages.set(Math.ceil(data.total / data.limit));
        }
        this.loading.set(false);
      });
  }
}
