# Hospital PMS (Console) — Multi-File C# Project (Fixed)

This version avoids special currency symbols (uses `INR`) to prevent encoding issues.

## Run
```bash
dotnet run
```

## Structure
- `Program.cs` (system flow)
- `Core/` (Hospital, Input, BillPrinter)
- `Domain/` (Patient hierarchy, TreatmentItem, Bill)
- `Billing/` (delegate + strategies)
- `Events/` (EventArgs)
- `Departments/` (event subscribers)
