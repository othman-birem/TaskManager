export enum AccessPrivileges {
    Admin = 0,
    Manager = 1,
    Employee = 2,
    Observer =3
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
