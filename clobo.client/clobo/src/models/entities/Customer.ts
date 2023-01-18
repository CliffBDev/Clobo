import { CustomerUser } from "./CustomerUser";

export interface Customer{
    id: number;
    name: string;
    address: string;
    city: string;
    state: string;
    zipCode: string;
    country: string;
    customerUsers: CustomerUser[];

}
