import { Product } from "./Product";

export interface ProductLine{
    id: number;
    name: string;
    products: Product[];
}
