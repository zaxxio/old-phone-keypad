# OldPhonePadSolver (Revisited with minimal design pattern)

Tiny C# library that converts “old phone keypad” input into text.
Supports digits `0–9`, pause (space), backspace `*`, and send `#`.

## Features

* Enum-based keypad (`KeyDigit`) with classic mapping:

    * `2: ABC`, `3: DEF`, `4: GHI`, `5: JKL`, `6: MNO`, `7: PQRS`, `8: TUV`, `9: WXYZ`, `0: space`, `1: &'(`
* Strategy handlers: Digit / Pause / Backspace / Send
* Backspace semantics: **cancels pending letter first**, else deletes last committed letter
* Robust to inputs without `#` (commits the pending letter at end)

## Quick Start

```bash
# build & test
dotnet build
dotnet test
```

## API

```csharp
var solver = new Master.OldPhonePadSolver();
string text = solver.OldPhonePad("4433555 555666#"); // "HELLO"
```

## Examples

* `"2#"` → `A`, `"22#"` → `B`, `"222"` → `C`
* `"4433555 555666#"` → `HELLO`
* `"4 666 666 3 0 6 33#"` → `GOOD ME`
* `"4433555 555666**#"` → `HEL` (two deletions)
* `"4433555 555666***#"` → `HE` (third deletion)

## Tests

NUnit tests are included (`Master.Tests`).

## Notes

* Input groups on the **same key** must be separated by a **space** (pause).
* `#` is the “send” key; recommended, but the solver still commits if omitted.
