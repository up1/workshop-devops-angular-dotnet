export interface Product {
  id: number;
  name: string;
  price: number;
  image: string;
}

export interface ProductsResponse {
  products: Product[];
  total: number;
  page: number;
  limit: number;
}
