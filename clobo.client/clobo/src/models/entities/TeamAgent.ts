import { Agent } from "./Agent";
import { Team } from "./Team";

export interface TeamAgent{
    id: number;
    team: Team;
    agent: Agent;
    isLead: boolean;
}
