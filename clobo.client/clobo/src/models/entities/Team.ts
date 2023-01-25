import { TeamAgent } from "./TeamAgent";

export interface Team {
    id: number;
    name: string;
    teamAgents: TeamAgent[];
}
