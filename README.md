# Clock Angle Calculator API

A clean, minimal Web API that calculates the sum of angles for hour and minute hands on an analog clock.

## Solution Architecture

### Core Components

1. **ClockAngleController** (`/Controllers/ClockAngleController.cs`)
   - Single endpoint accepting flexible input formats
   - Clean error handling and validation

2. **ClockAngleCalculator** (`/Services/ClockAngleCalculator.cs`)
   - Pure calculation logic separated from HTTP concerns
   - Handles 12/24-hour format conversion
   - Validates input ranges

3. **Unit Tests** (`/ClockAngle.Tests/ClockAngleCalculatorTests.cs`)
   - Comprehensive test coverage
   - Tests edge cases and invalid inputs

## API Endpoint

**Route:** `/ClockAngle`  
**Method:** GET

### Parameters

Option 1: Time string
```
GET /ClockAngle?time=03:00
```

Option 2: Separate hour and minute
```
GET /ClockAngle?hour=3&minute=0
```

### Response
```json
{
  "totalAngle": 90
}
```

## Calculation Logic

- **Minute hand:** 6° per minute (360° / 60 minutes)
- **Hour hand:** 30° per hour + 0.5° per minute (360° / 12 hours)
- **Result:** Sum of both angles

### Examples
- `3:00` → Hour: 90°, Minute: 0° → Total: 90°
- `3:15` → Hour: 97.5°, Minute: 90° → Total: 187.5°  
  (Note: Hour hand moves 0.5° per minute, so at 3:15 it's at 90° + 7.5° = 97.5°)
- `6:00` → Hour: 180°, Minute: 0° → Total: 180°
- `12:00` → Hour: 0°, Minute: 0° → Total: 0°

## Running the Project

### API
```bash
cd ClockAngle
dotnet run
```

Navigate to `https://localhost:7xxx/swagger` to test the API.

### Tests
```bash
cd ClockAngle
dotnet test ClockAngle.Tests/ClockAngle.Tests.csproj
```

## Design Decisions

1. **Separation of Concerns**: Calculator logic is isolated in a service class, making it testable and reusable.

2. **Flexible Input**: Supports both time string and separate parameters for convenience.

3. **24-Hour Support**: Automatically converts 24-hour format to 12-hour for calculation (15:00 → 3:00).

4. **Input Validation**: Validates hour (0-23) and minute (0-59) ranges with clear error messages.

5. **Minimal Dependencies**: Uses only ASP.NET Core and xUnit - no unnecessary packages.

6. **Clean Code**: No comments needed - the code is self-documenting through clear naming and simple logic.

## Project Structure
```
ClockAngle/
├── Controllers/
│   └── ClockAngleController.cs    # API endpoint
├── Services/
│   └── ClockAngleCalculator.cs    # Core calculation logic
├── ClockAngle.Tests/
│   └── ClockAngleCalculatorTests.cs  # Unit tests
└── Program.cs                      # DI configuration
```
