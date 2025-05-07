### Things about the Auth 
| Feature           | `IdentityUser`                                 | `IdentityRole`                                   | `IdentityUserRole`                               | `UserManager`                                                                |
|-------------------|-------------------------------------------------|---------------------------------------------------|----------------------------------------------------|------------------------------------------------------------------------------|
| **Purpose** | Represents a user in the application.           | Represents a role (group of permissions).        | Represents the link between a user and a role.     | Provides APIs for managing users and their related data.                     |
| **Core Data** | User properties (Id, UserName, Email, PasswordHash, etc.). Can be extended. | Role properties (Id, Name). Can be extended.      | Foreign keys `UserId` and `RoleId`.             | Offers methods for creating, reading, updating, and deleting users.          |
| **Relationships** | Can have many roles (through `IdentityUserRole`). | Can have many users (through `IdentityUserRole`). | Connects one `IdentityUser` to one `IdentityRole`. | Interacts with `IdentityUser`, `IdentityRole`, and implicitly with `IdentityUserRole`. |
| **Interaction** | Primarily used as the user entity in your data model. | Primarily used to define and manage roles in your system. | Usually not directly interacted with; managed by Identity framework. | The main service you use to perform user-related operations (creation, login, roles, etc.). |
| **Key Properties**| `Id`, `UserName`, `Email`, `PasswordHash`, etc. | `Id`, `Name`                                      | `UserId`, `RoleId`                                 | Provides methods like `CreateAsync`, `FindByEmailAsync`, `AddToRoleAsync`, etc. |


## IConfiguration: 
1. It is used to access configuration settings in a .NET application. 
1. It allows you to read configuration settings from various sources like JSON files, environment variables, command-line arguments, and more.
1. It provides a centralized way to manage and access configuration settings throughout your application.
## Claim:
1.  A Claim is a statement about an entity by an Issuer.
1.  A Claim consists of a Type, Value, a Subject and an Issuer.
1.  Additional properties, ValueType, Properties and OriginalIssuer help understand the claim when making decisions.