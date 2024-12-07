export enum AccessPrivileges {
    Admin = "Admin",
    Manager = "Manager",
    Employee = "Employee",
    Observer = "Observer"
}
export interface UserAccount {
    Id: string;
    fullName: string;
    dateOfBirth: string;
    occupation: string;
    email: string;
    password: string;
    teamId: string;
    accessPrivilege: AccessPrivileges;
}
