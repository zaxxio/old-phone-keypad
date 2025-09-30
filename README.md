# Old Phone Pad Text Input Simulator

A C# implementation that simulates typing text on old mobile phone keypads where you had to press number keys multiple times to get different letters.

## How It Works

On old mobile phones, each number key corresponded to multiple letters:
- **2**: ABC
- **3**: DEF  
- **4**: GHI
- **5**: JKL
- **6**: MNO
- **7**: PQRS
- **8**: TUV
- **9**: WXYZ
- **0**: Space
- **1**: &'(

### Special Controls
- **#**: Send/End input
- **\***: Backspace (removes last character or cancels current key sequence)
- **Space**: Pause (confirms current character, allows same key to be used for next character)

### Examples
```
"33#" → "E"                    (press 3 twice)
"227*#" → "B"                  (2=A, 2=B, 7=P, *=backspace P)
"4433555 555666#" → "HELLO"    (44=H, 33=E, 555=L, space, 555=L, 666=O)
"222 2 22#" → "CAB"            (222=C, space, 2=A, 22=B)
```

## Implementation

The project contains two implementations:

1. **OldPhonePadSolver** (Program.cs): Optimized version using character buffers
2. **Driver** (Driver.cs): Simple version using string concatenation

Both implementations produce identical results.

## Running the Code

### Prerequisites
- .NET 8.0 or later

### Build and Run
```bash
cd Master
dotnet build
dotnet run
```

### Run Tests
```bash
cd Master.Tests
dotnet test
```

## Testing

The project includes comprehensive unit tests covering:
- Basic character input
- Multi-character words
- Backspace functionality
- Pause/space handling
- Special characters
- Character cycling
- Edge cases
- Both implementation consistency

## Project Structure
```
Master/
├── Master/                 # Main application
│   ├── Program.cs         # Optimized implementation
│   ├── Driver.cs          # Simple implementation  
│   └── Master.csproj      # Project file
├── Master.Tests/          # Unit tests
│   ├── OldPhonePadTests.cs
│   └── Master.Tests.csproj
└── README.md
```
