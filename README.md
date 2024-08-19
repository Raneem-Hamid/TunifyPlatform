# Tunify Platform :headphones: :musical_note:

## Overview

Tunify is a music streaming platform that allows users to create playlists, listen to songs, and explore artists and albums. This platform is built using ASP.NET Core and utilizes Entity Framework Core to manage and interact with the database.

## ERD Diagram

The following Entity-Relationship Diagram (ERD) outlines the structure of the Tunify Platform's database:

![Tunify ERD Diagram](Tunify-Platform/ERD/Tunify.png)

## Entities and Relationships

### Users
- **UserID** (Primary Key)
- **Username**
- **Email**
- **Join_Date**
- **Subscription_ID** (Foreign Key)

### Subscriptions
- **Subscription_ID** (Primary Key)
- **Subscription_Type**
- **Price**

### Playlist
- **Playlist_ID** (Primary Key)
- **User_ID** (Foreign Key)
- **Playlist_Name**
- **Created_Date**

### Songs
- **Song_ID** (Primary Key)
- **Title**
- **Artist_ID** (Foreign Key)
- **Album_ID** (Foreign Key)
- **Duration**
- **Genre**

### Albums
- **Album_ID** (Primary Key)
- **Album_Name**
- **Release_Date**
- **Artist_ID** (Foreign Key)

### Artists
- **Artist_ID** (Primary Key)
- **Name**
- **Bio**

### PlaylistSongs
- **PlaylistSong_ID** (Primary Key)
- **Playlist_ID** (Foreign Key)
- **Song_ID** (Foreign Key)

### Relationships
- **Users** are linked to **Subscriptions** through the `Subscription_ID` foreign key.
- **Users** can create multiple **Playlists**, and each playlist belongs to a single user.
- **Songs** can belong to an **Album** and are performed by an **Artist**.
- **Playlists** can contain multiple **Songs**, and a single **Song** can appear in multiple playlists. This many-to-many relationship is managed by the `PlaylistSongs` junction table.

## Repository Design Pattern

### Overview

The Repository Design Pattern is implemented to decouple the data access logic from the business logic. By defining repository interfaces and service classes, this pattern provides a layer of abstraction that makes the code more maintainable, testable, and easier to extend.

### Repository Pattern

#### Overview
The Repository Design Pattern is a structural approach that isolates the logic responsible for interacting with the data storage system from the core application logic. This separation enhances the organization of code by placing data access operations into dedicated classes known as repositories, resulting in a more modular and cleaner codebase.

#### Implementation in Tunify Platform
- **Repository Interfaces:** Stored in the `Repositories/Interfaces` folder, these interfaces define the core methods required for CRUD operations and other entity-specific logic for entities like `Users`, `Playlist`, `Song`, and `Artist`.
- **Repository Services:** Found in the `Repositories/Services` folder, these classes implement the repository interfaces, effectively encapsulating data access logic for each entity.
- **Refactored Controllers:** The controllers in Tunify Platform now interact with repositories to handle data operations, promoting a clear separation of concerns. Dependency injection is used to supply the repositories to the controllers via their constructors.
- **Service Registration:** Both repositories and controllers are registered in the `ConfigureServices` method in `Program.cs`, ensuring correct dependency injection and lifecycle management across the application.

#### Benefits of the Repository Pattern
- **Separation of Concerns:** By delegating data access to repositories, application components such as controllers remain independent of the intricacies involved in data storage and retrieval.
- **Testability:** Repositories offer a consistent interface for data operations, simplifying the process of mocking or stubbing them during unit testing, thus improving test coverage.
- **Maintainability:** Modifications to data access, whether it involves changing the database or altering query logic, are isolated within the repository layer, minimizing the impact on other parts of the application.
- **Reusability:** Repositories centralize common data access logic, allowing it to be reused across multiple areas of the application, reducing code duplication.
