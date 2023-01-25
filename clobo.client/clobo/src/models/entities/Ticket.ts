import { Agent } from "./Agent";
import { Customer } from "./Customer";
import { Product } from "./Product";
import { Team } from "./Team";
import { TicketNote } from "./TicketNote";
import { TicketStatus } from "./TicketStatus";

export interface Ticket{
    id:number;
    name:string;
    description:string;
    agent?:Agent;
    team?:Team;
    ticketStatus: TicketStatus;
    customer:Customer;
    product:Product;
    ticketNotes: TicketNote[];
}
