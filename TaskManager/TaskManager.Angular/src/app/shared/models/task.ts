export interface Task {
    id:number;
    userId:number;
    title:string;
    description:string;
    dueDate:Date;
    priority:CharacterData;
    remarks:string;
}