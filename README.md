# EcoMapGbg
## 🌱 Connecting Gothenburg with reuse spots, second-hand shops, and repair hubs for a more circular city. 🌱



# ♻️ ReuseMap (Återbrukskartan)

> A location-based web app for promoting reuse, sharing, and circular consumption in Gothenburg.

---

## 🌍 Project Overview

**ReuseMap** helps people in Gothenburg discover and share places where items can be reused instead of thrown away – such as second-hand shops, repair stations, swap shelves, and recycling centers.

The project aims to reduce waste and support local sustainability by crowd-sourcing reuse locations and making them easy to find via a searchable map interface.

---

## 🎯 Key Features

- 📍 Interactive map with reuse locations
- 🗂️ Filter by category, neighborhood, opening hours
- ➕ Add new places via form (crowdsourcing)
- 🧾 Detail page with info, opening hours and contact
- 🌱 Future ideas: event calendar, gamification, Västtrafik integration

---

## 🧪 Tech Stack

| Area          | Technology              |
|---------------|--------------------------|
| Backend       | ASP.NET Core, C#, Clean Architecture, DDD |
| Frontend      | React *(or Razor Pages / Blazor)* |
| Database      | MongoDB                  |
| Maps          | Leaflet.js or Google Maps API |
| Testing       | xUnit, Moq, FluentAssertions |
| DevOps        | GitHub Actions, Docker   |
| Docs          | Swagger / OpenAPI        |

---

## 🗂️ Project Structure

```

EcoMapGbg/
├── .gitignore
├── README.md
├── docker-compose.yml      #  MongoDB
├── backend/                # Single ASP.NET Core project
│   ├── EcoMapGbg.csproj
│   ├── Program.cs
│   ├── Models/             # Simple models
│   │   └── Location.cs
│   ├── Controllers/
│   │   └── LocationsController.cs
│   ├── Data/
│   │   └── LocationRepository.cs
│   └── wwwroot/           # Static frontend files
│       ├── index.html
│       ├── app.js
│       └── style.css
└── docs/
    └── mvp-features.md

````

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [Node.js & npm](https://nodejs.org/) (if using React frontend)
- [MongoDB](https://www.mongodb.com/) or Docker
- Git

---

### Clone and run

```bash
# 1. Clone repo
git clone https://github.com/yourusername/reusemap.git
cd reusemap

# 2. Build backend
cd backend
dotnet restore
dotnet build

# 3. Run backend
dotnet run --project src/ReuseMap.API

# 4. Run frontend (if using React)
cd ../../frontend
npm install
npm start
````

---

## 👥 Contributors

* [Nor](https://github.com/NorAjami) – Project Lead
* [Yotaka](https://github.com/Yotaka88) – Project Lead

---

## 📄 License

MIT License – feel free to reuse and contribute.

```


```
