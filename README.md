# Web Application Design - CINEMA BOOKING PLATFORM

<div align="center">

**🎬 THE FILM VAULT a full-stack cinema booking platform built with ASP.NET Core MVC**

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet)
![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver)
![Razor Pages](https://img.shields.io/badge/Razor-Pages-512BD4?style=for-the-badge&logo=dotnet)

</div>


## OVERVIEW

**THE FILM VAULT** is a full-stack cinema management and ticket booking system built as an academic project. It supports browsing movies, managing screenings, purchasing tickets, handling promotions, and administering cinema halls — all wrapped in a **cinematic dark-themed UI** with red accents and premium animations.

The project repository is named `cinemawebapp`.



## ARCHITECTURE

```
cinemawebapp/
├── Areas/
│   └── Identity/
│       └── Pages/
│           └── Account/
│               ├── ForgotPassword.cshtml
│               ├── Login.cshtml
│               ├── Logout.cshtml
│               └── Register.cshtml
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
│   │   ├── ICinemaRepository.cs
│   │   ├── IHallRepository.cs
│   │   ├── IMovieRepository.cs
│   │   ├── IPromotionRepository.cs
│   │   ├── IScreeningRepository.cs
│   │   ├── ITicketRepository.cs
│   │   └── ITicketTypeRepository.cs
│   ├── CinemaRepository.cs
│   ├── HallRepository.cs
│   ├── MovieRepository.cs
│   ├── PromotionRepository.cs
│   ├── ScreeningRepository.cs
│   ├── TicketRepository.cs
│   └── TicketTypeRepository.cs
├── Services/
│   ├── Interfaces/
│   │   ├── IAuthService.cs
│   │   ├── ICinemaService.cs
│   │   ├── IHallService.cs
│   │   ├── IMovieService.cs
│   │   ├── IPromotionService.cs
│   │   ├── IScreeningService.cs
│   │   ├── ITicketService.cs
│   │   └── ITicketTypeService.cs
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
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   ├── Cinemas/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Halls/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Home/
│   │   ├── About.cshtml
│   │   ├── Cinemas.cshtml
│   │   ├── Index.cshtml
│   │   ├── MovieDetails.cshtml
│   │   ├── Movies.cshtml
│   │   ├── Profile.cshtml
│   │   ├── Program.cshtml
│   │   ├── PromoDetails.cshtml
│   │   ├── Promotions.cshtml
│   │   ├── Tarife.cshtml
│   │   ├── Tickets.cshtml
│   │   └── Upcoming.cshtml
│   ├── Movies/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Profile/
│   │   └── Index.cshtml
│   ├── Promotions/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Screenings/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _LoginPartial.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── Tickets/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── TicketTypes/
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   └── Users/
│       └── Index.cshtml
├── wwwroot/
│   ├── css/
│   │   └── style.css
│   ├── images/
│   ├── js/
│   │   └── site.js
│   └── uploads/
│       └── profiles/
├── appsettings.json
├── Program.cs
└── cinemawebapp.csproj
```


## DATABASE SCHEMA

### ENTITIES

| ENTITY | KEY FIELDS |
|---|---|
| `ApplicationUser` | `Id`, `UserName`, `Email`, `PasswordHash` |
| `Cinema` | `Id`, `Name`, `Location` |
| `Hall` | `Id`, `Name`, `Capacity`, `CinemaId` |
| `Movie` | `Id`, `Title`, `Genre`, `Duration`, `Description`, `TrailerUrl`, `IsUpcoming` |
| `Screening` | `Id`, `MovieId`, `HallId`, `StartTime`, `EndTime`, `Price` |
| `Ticket` | `Id`, `ScreeningId`, `TicketTypeId`, `UserId`, `SeatNumber`, `CustomerName`, `PurchaseDate` |
| `TicketType` | `Id`, `Name`, `Discount` |
| `Promotion` | `Id`, `Title`, `Description`, `ValidFrom`, `ValidTo` |

### RELATIONSHIPS

```
Cinema ──< Hall ──< Screening >── Movie
                       │
                    Ticket >── TicketType
                       │
                ApplicationUser

ApplicationUser (managed via ASP.NET Identity)
```


## FEATURES

### 🔐 ACCOUNT
- Register / Login / Logout via `AccountController`
- `LoginViewModel` and `RegisterViewModel` for form binding
- Authentication handled by `AuthService`

### 👤 USERS & PROFILE
- User listing via `UsersController`
- Personal profile page via `ProfileController`

### 🎥 MOVIES
- Full CRUD
- `IsUpcoming` flag — separates **Now Showing** from **Coming Soon**
- YouTube trailer support via `/watch?v=` (opens in new tab)
- Seeded via `MovieSeed.cs`

### 🏛️ CINEMAS & HALLS
- Full CRUD for cinemas and halls
- Halls scoped to a parent cinema
- Seeded via `CinemaSeed.cs` and `HallSeed.cs`

### 📅 SCREENINGS
- Full CRUD with movie and hall assignment
- **Overlap validation** — prevents double-booking a hall for the same time slot
- "Buy Ticket" links directly into the ticket form with pre-populated `ScreeningId`
- Seeded via `ScreeningSeed.cs`

### 🎟️ TICKETS & TICKET TYPES
- Full CRUD for tickets and ticket types
- Ticket types support discount tiers
- Purchase flow linked from screenings
- Seeded via `TicketSeed.cs`

### 🏷️ PROMOTIONS
- Full CRUD for promotional campaigns
- Date-range validity (`ValidFrom` / `ValidTo`)
- Seeded via `PromotionSeed.cs`

### 🏠 HOME PAGE
- Dynamically loads movies from the database
- **Now Showing** and **Coming Soon** sections



## UI / FRONTEND

### DESIGN LANGUAGE
- **Theme:** Cinematic dark — deep blacks, dark grays, red accents (`#8B1A1A`, `#B20000`)
- **Typography:** Uppercase letter-spacing headings; premium editorial feel
- **Animations:**
  - Slide-fill on buttons (`::before` pseudo-element)
  - Scale-from-center card reveals
  - Staggered page load transitions
- **Forms:** Floating label inputs, gradient submit buttons
- **Razor note:** `@keyframes` written as `@@keyframes` to avoid Razor parsing conflicts

### PAGES

| ROUTE | DESCRIPTION |
|---|---|
| `/` | Home — Now Showing + Coming Soon |
| `/Home/About` | About page |
| `/Home/Movies` | Public movie listing |
| `/Home/MovieDetails/{id}` | Public movie detail + trailer |
| `/Home/Upcoming` | Upcoming movies |
| `/Home/Cinemas` | Public cinema listing |
| `/Home/Program` | Screening program |
| `/Home/Promotions` | Public promotions listing |
| `/Home/PromoDetails/{id}` | Promotion detail |
| `/Home/Tarife` | Ticket pricing |
| `/Home/Tickets` | Public tickets info |
| `/Account/Login` | Login |
| `/Account/Register` | Register |
| `/Profile` | User profile |
| `/Users` | User management |
| `/Movies` | Movie listing (admin) |
| `/Movies/Details/{id}` | Movie detail + trailer |
| `/Movies/Create` | Add movie |
| `/Movies/Edit/{id}` | Edit movie |
| `/Movies/Delete/{id}` | Delete movie |
| `/Cinemas` | Cinema listing |
| `/Cinemas/Details/{id}` | Cinema detail |
| `/Cinemas/Create` | Add cinema |
| `/Cinemas/Edit/{id}` | Edit cinema |
| `/Cinemas/Delete/{id}` | Delete cinema |
| `/Halls` | Hall listing |
| `/Halls/Details/{id}` | Hall detail |
| `/Halls/Create` | Add hall |
| `/Halls/Edit/{id}` | Edit hall |
| `/Halls/Delete/{id}` | Delete hall |
| `/Screenings` | All screenings |
| `/Screenings/Details/{id}` | Screening detail |
| `/Screenings/Create` | Schedule screening |
| `/Screenings/Edit/{id}` | Edit screening |
| `/Screenings/Delete/{id}` | Delete screening |
| `/Tickets` | All tickets |
| `/Tickets/Details/{id}` | Ticket detail |
| `/Tickets/Create?screeningId={id}` | Buy ticket |
| `/Tickets/Edit/{id}` | Edit ticket |
| `/Tickets/Delete/{id}` | Delete ticket |
| `/TicketTypes` | Ticket type listing |
| `/TicketTypes/Create` | Add ticket type |
| `/TicketTypes/Edit/{id}` | Edit ticket type |
| `/Promotions` | Promotions listing |
| `/Promotions/Details/{id}` | Promotion detail |
| `/Promotions/Create` | Add promotion |
| `/Promotions/Edit/{id}` | Edit promotion |
| `/Promotions/Delete/{id}` | Delete promotion |



## DESIGN PATTERNS

| PATTERN | IMPLEMENTATION |
|---|---|
| **Repository Pattern** | `Repositories/` — one repository per entity, each implementing its interface from `Repositories/Interfaces/` |
| **Service Layer** | `Services/` — business logic abstracted from controllers, each implementing its interface from `Services/Interfaces/` |
| **MVC** | Standard ASP.NET Core MVC with Razor Views |
| **Seed Data** | Dedicated seed classes in `Data/` per entity |



## GETTING STARTED

### PREREQUISITES
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or SQL Server Express / LocalDB)
- Visual Studio 2022+ or VS Code

### SETUP

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

Navigate to `https://localhost:{port}` to open **The Film Vault**.

### MIGRATION NOTES

If you hit migration conflicts:
1. Drop all tables including `__EFMigrationsHistory`
2. Delete existing migration files
3. Run `dotnet ef migrations add InitialCreate`
4. Run `dotnet ef database update`
5. Use `SET IDENTITY_INSERT [Table] ON` if inserting explicit seed IDs manually


## TECH STACK

| LAYER | TECHNOLOGY |
|---|---|
| Framework | ASP.NET Core MVC (.NET 10) |
| ORM | Entity Framework Core |
| Database | Microsoft SQL Server |
| Views | Razor Pages (.cshtml) |
| IDE | Visual Studio 2026 |
| Auth | ASP.NET Core Identity |
| Diagrams | draw.io (Chen notation + relational schema) |
| Styling | Custom CSS (dark theme, animations) |


## CONTRIBUTIONS

Project created by **Cristian Florin Cojocaru** (**CSE.3** - **University of Craiova / Faculty of Automatics, Computer Science and Electronics**). Contributions are welcome ! If you have suggestions for improving the code or documentation, please submit a pull request.


## LICENSE

This project is licensed under the [MIT License](LICENSE).
