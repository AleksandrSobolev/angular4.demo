import { TaskModel } from "./TaskModel";

export class ClientModel {
    id: number;
    firstName: string;
    lastName: string;
    address: string;
    phones: string;
    tasks: TaskModel[]
}