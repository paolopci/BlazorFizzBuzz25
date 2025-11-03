# Repository Guidelines

## Project Structure & Module Organization
- The root hosts application entry points: `Program.cs`, `App.razor`, `_Imports.razor`, and `BlazorFizzBuzz.csproj` for configuration.
- Razor UI lives in `Pages/` for routable components (e.g., `Counter.razor`, `Weather.razor`) and `Layout/` for shared shells (`MainLayout.razor`, `NavMenu.razor` plus CSS companions).
- Static assets and mock data reside in `wwwroot/` (`css/`, `bootstrap/`, `sample-data/weather.json`). Avoid editing files under `obj/` or `bin/`; they are regenerated.

## Build, Test, and Development Commands
- `dotnet restore` ensures NuGet dependencies are present; run after pulling new packages.
- `dotnet build` compiles the Blazor WebAssembly app and validates Razor components.
- `dotnet run` serves the app locally at the configured localhost port; use `--urls` to override.
- `dotnet publish -c Release` produces optimized output under `bin/Release/`.

## Coding Style & Naming Conventions
- Follow C# conventions: 4-space indentation, PascalCase for classes/components, camelCase for locals and parameters, and ALL_CAPS for constants.
- Razor components should include a matching `.razor.css` when scoped styling is required.
- Prefer dependency injection via `Program.cs` and avoid static state. Use `@code` blocks with explicit access modifiers.
- Run `dotnet format` before pushing to align with .NET analyzers.

## Testing Guidelines
- Unit tests live in a sibling `BlazorFizzBuzz.Tests` project (create if missing) using xUnit.
- Name test files after the SUT (`WeatherServiceTests.cs`) and methods as `MethodName_ShouldExpectedBehavior`.
- Execute `dotnet test` from the solution root; aim to keep coverage for new logic above 80% and include regression cases for fizz-buzz edge inputs.

## Commit & Pull Request Guidelines
- Use short, imperative commit subjects in English (e.g., `Add fizz buzz input validation`); include body details when behavior changes.
- Reference Azure Boards or GitHub issues with `Fixes #123` when applicable; note any UI changes with before/after screenshots.
- PRs must describe scope, validation steps (`dotnet build`, `dotnet test`), and highlight impacted components or data contracts.

## Blazor-Specific Tips
- Register reusable services in `Program.cs` and consume via `[Inject]` or `@inject`.
- Favor C# logic over JavaScript interop; when necessary, isolate scripts under `wwwroot/js/` with typed wrapper methods.
- Keep sample data in `wwwroot/sample-data/` for demos; replace with API calls using `HttpClient` for production.
