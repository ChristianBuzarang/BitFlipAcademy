# BitFlipAcademy

**BitFlipAcademy** is an interactive, gamified web-based learning platform built with .NET Blazor and Tailwind CSS. It features secure user session management, PostgreSQL database persistence via Entity Framework Core, and interactive practice sandboxes designed to make learning technical concepts engaging.

---

## Key Features

* **Custom Authentication & Sessions**: Built-in Register, Login, and personalized Home dashboards supporting state management across user sessions.
* **Interactive Practice Sandboxes**: Hands-on mini-projects and logic components (including bitwise challenges and score tracking).
* **Supabase & PostgreSQL Integration**: Robust data modeling using Entity Framework Core, mapping C# entities (`User`, `GameProgress`, `Feedback`) to PostgreSQL `snake_case` schemas.
* **Modern Responsive Design**: Styled using Tailwind CSS v4 with custom color themes, typography, and responsive layouts.

---

## Tech Stack

* **Framework**: .NET Blazor Web App (Interactive Server Render Mode)
* **Database & ORM**: PostgreSQL (Supabase) via Entity Framework Core
* **Styling**: Tailwind CSS v4
* **Tooling**: .NET CLI, Git / GitHub

---

## Database Schema Overview

The application utilizes three core relational tables:
1. **`users`**: Stores user credentials, email records, and cumulative scores (`total_score`).
2. **`game_progress`**: Tracks user completion status, highest scores, and timestamps per level.
3. **`feedbacks`**: Collects user ratings (1–5), categories, and comments for continuous platform improvement.

---

## Getting Started

### Prerequisites
Make sure you have the following installed on your machine:
* [.NET SDK](https://dotnet.microsoft.com/) (version 8.0 or higher)
* [Node.js & npm](https://nodejs.org/) (for compiling Tailwind CSS)
* Git

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/ChristianBuzarang/BitFlipAcademy.git](https://github.com/ChristianBuzarang/BitFlipAcademy.git)
   cd BitFlipAcademy
