# Web Application Design - CINEMA BOOKING PLATFORM

<div align="center">

# 🎬 CinemaWebApp

**A full-stack cinema booking platform built with ASP.NET Core MVC**

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet)
![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver)
![Razor Pages](https://img.shields.io/badge/Razor-Pages-512BD4?style=for-the-badge&logo=dotnet)

</div>

---

## 📋 Overview

CinemaWebApp is a full-stack cinema management and ticket booking system built as an academic project. It supports browsing movies, managing screenings, purchasing tickets, handling promotions, and administering cinema halls — all wrapped in a **cinematic dark-themed UI** with red accents and premium animations.

---

## 🏗️ Architecture

```
cinemawebapp/
├── Controllers/
│   ├── AccountController.cs
│   ├── CinemasController.cs
│   ├── HallsController.cs
│   ├── HomeController.cs
│   ├── MoviesController.cs
│   ├── ProfileController.cs
│   ├── PromotionsController.cs
│   ├── ScreeningsController.cs
│   ├── TicketsController.cs
│   ├── TicketTypesController.cs
│   └── UsersController.cs
├── Data/
│   ├── AppDbContext.cs
│   ├── AppDbContextFactory.cs
│   ├── CinemaSeed.cs
│   ├── HallSeed.cs
│   ├── MovieSeed.cs
│   ├── PromotionSeed.cs
│   ├── ScreeningSeed.cs
│   └── TicketSeed.cs
├── Migrations/
├── Models/
│   ├── ApplicationUser.cs
│   ├── Cinema.cs
│   ├── Hall.cs
│   ├── Movie.cs
│   ├── Promotion.cs
│   ├── Screening.cs
│   ├── Ticket.cs
│   └── TicketType.cs
├── Repositories/
│   ├── Interfaces/
│   ├── CinemaRepository.cs
│   ├── HallRepository.cs
│   ├── MovieRepository.cs
│   ├── PromotionRepository.cs
│   ├── ScreeningRepository.cs
│   ├── TicketRepository.cs
│   └── TicketTypeRepository.cs
├── Services/
│   ├── Interfaces/
│   ├── AuthService.cs
│   ├── CinemaService.cs
│   ├── HallService.cs
│   ├── MovieService.cs
│   ├── PromotionService.cs
│   ├── ScreeningService.cs
│   ├── TicketService.cs
│   └── TicketTypeService.cs
├── ViewModels/
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
└── Views/
    ├── Account/
    ├── Cinemas/
    ├── Halls/
    ├── Home/
    ├── Movies/
    ├── Profile/
    ├── Promotions/
    ├── Screenings/
    ├── Shared/
    ├── Tickets/
    ├── TicketTypes/
    └── Users/
```

---

## 🗄️ Database Schema

### Entities

| Entity | Key Fields |
|---|---|
| `ApplicationUser` | `Id`, `UserName`, `Email`, `PasswordHash` |
| `Cinema` | `Id`, `Name`, `Location` |
| `Hall` | `Id`, `Name`, `Capacity`, `CinemaId` |
| `Movie` | `Id`, `Title`, `Genre`, `Duration`, `Description`, `TrailerUrl`, `IsUpcoming` |
| `Screening` | `Id`, `MovieId`, `HallId`, `StartTime`, `EndTime`, `Price` |
| `Ticket` | `Id`, `ScreeningId`, `TicketTypeId`, `SeatNumber`, `CustomerName`, `PurchaseDate` |
| `TicketType` | `Id`, `Name`, `Discount` |
| `Promotion` | `Id`, `Title`, `Description`, `ValidFrom`, `ValidTo` |

### Relationships

```
Cinema ──< Hall ──< Screening >── Movie
                       │
                    Ticket >── TicketType

ApplicationUser (managed via ASP.NET Identity)
```

---

## ⚙️ Features

### 🔐 Account
- Register / Login / Logout via `AccountController`
- `LoginViewModel` and `RegisterViewModel` for form binding
- Authentication handled by `AuthService`

### 👤 Users & Profile
- User listing via `UsersController`
- Personal profile page via `ProfileController`

### 🎥 Movies
- Full CRUD
- `IsUpcoming` flag — separates **Now Showing** from **Coming Soon**
- YouTube trailer support via `/watch?v=` (opens in new tab)
- Seeded via `MovieSeed.cs`

### 🏛️ Cinemas & Halls
- Full CRUD for cinemas and halls
- Halls scoped to a parent cinema
- Seeded via `CinemaSeed.cs` and `HallSeed.cs`

### 📅 Screenings
- Full CRUD with movie and hall assignment
- **Overlap validation** — prevents double-booking a hall for the same time slot
- "Buy Ticket" links directly into the ticket form with pre-populated `ScreeningId`
- Seeded via `ScreeningSeed.cs`

### 🎟️ Tickets & Ticket Types
- Full CRUD for tickets and ticket types
- Ticket types support discount tiers
- Purchase flow linked from screenings
- Seeded via `TicketSeed.cs`

### 🏷️ Promotions
- Full CRUD for promotional campaigns
- Date-range validity (`ValidFrom` / `ValidTo`)
- Seeded via `PromotionSeed.cs`

### 🏠 Home Page
- Dynamically loads movies from the database
- **Now Showing** and **Coming Soon** sections

---

## 🎨 UI / Frontend

### Design Language
- **Theme:** Cinematic dark — deep blacks, dark grays, red accents (`#8B1A1A`, `#B20000`)
- **Typography:** Uppercase letter-spacing headings; premium editorial feel
- **Animations:**
  - Slide-fill on buttons (`::before` pseudo-element)
  - Scale-from-center card reveals
  - Staggered page load transitions
- **Forms:** Floating label inputs, gradient submit buttons
- **Razor note:** `@keyframes` written as `@@keyframes` to avoid Razor parsing conflicts

### Pages

| Route | Description |
|---|---|
| `/` | Home — Now Showing + Coming Soon |
| `/Account/Login` | Login |
| `/Account/Register` | Register |
| `/Profile` | User profile |
| `/Users` | User management |
| `/Movies` | Movie listing |
| `/Movies/Details/{id}` | Movie detail + trailer |
| `/Movies/Create` | Add movie |
| `/Movies/Edit/{id}` | Edit movie |
| `/Cinemas` | Cinema listing |
| `/Halls` | Hall listing |
| `/Screenings` | All screenings |
| `/Screenings/Create` | Schedule screening |
| `/Tickets` | All tickets |
| `/Tickets/Create?screeningId={id}` | Buy ticket |
| `/TicketTypes` | Ticket type management |
| `/Promotions` | Promotions listing |

---

## 🧩 Design Patterns

| Pattern | Implementation |
|---|---|
| **Repository Pattern** | `Repositories/` — one repository per entity, each implementing its interface from `Repositories/Interfaces/` |
| **Service Layer** | `Services/` — business logic abstracted from controllers, each implementing its interface from `Services/Interfaces/` |
| **MVC** | Standard ASP.NET Core MVC with Razor Views |
| **Seed Data** | Dedicated seed classes in `Data/` per entity |

---

## 🚀 Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or SQL Server Express / LocalDB)
- Visual Studio 2022+ or VS Code

### Setup

```bash
git clone https://github.com/cristianflorincojocaru/cinemawebapp.git
cd cinemawebapp
```

Update `appsettings.json` with your connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CinemaWebApp;Trusted_Connection=True;"
}
```

Apply migrations and run:

```bash
dotnet ef database update
dotnet run
```

Navigate to `https://localhost:{port}`.

### Migration Notes

If you hit migration conflicts:
1. Drop all tables including `__EFMigrationsHistory`
2. Delete existing migration files
3. Run `dotnet ef migrations add InitialCreate`
4. Run `dotnet ef database update`
5. Use `SET IDENTITY_INSERT [Table] ON` if inserting explicit seed IDs manually

---

## 🧰 Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 10) |
| ORM | Entity Framework Core |
| Database | Microsoft SQL Server |
| Views | Razor Pages (.cshtml) |
| IDE | Visual Studio 2026 |
| Auth | ASP.NET Core Identity |
| Diagrams | draw.io (Chen notation + relational schema) |
| Styling | Custom CSS (dark theme, animations) |

---

## 🤝 CONTRIBUTIONS

Project created by **Cristian Florin Cojocaru** *(CSE.3 — University of Craiova / Faculty of Automatics, Computer Science and Electronics)*.

Contributions are welcome! If you have suggestions for improving the code or documentation, please submit a pull request.

---

## 📄 LICENSE

This project is licensed under the [MIT License](https://github.com/cristianflorincojocaru/PIC24-PROCESSOR-VHDL-SEMESTER-PROJECT-1/blob/main/LICENSE).
