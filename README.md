# Brainfuck
- Esoterische Programmiersprache von 1993 von Urban Müller
- Originaler Compiler Nur 240 Bytes bzw. 1920 Bits lang
- Nur 8 Befehle
- Ein langes Zahlen Array mit einem Pointer auf 0 (erste Zelle)
  - Pointer sind im Grunde eine Ganzzahl die eine Addresse beschreibt

# Commands

- `\>` => Pointer um 1 erhöhen (zur nächsten Zelle bewegen)
- `<` => Pointer um 1 reduzieren (zur vorherigen Zelle bewegen)
- `\+` => Jetzige Zellenwert um 1 erhöhen
- `\-` => Zellenwert minus 1
- `.` => Zellenwert als ASCII Charakter an den STDOUT schieben
- `,` => Einen Charakter aus dem STDIN lesen und in die jetzige Zelle schreiben
- `[` => spring zum dazugehörigen ']' wenn die jetzige Zelle 0 ist (scoping wird respektiert)
- `\]` => spring zum dazugehörigen '[' wenn die jetzige Zelle nicht 0 ist

# Compilierung

Man kann tatsächlich einen eigenen Compiler dazu relativ einfach aufsetzen. <br />
Online Compiler gibt es, aber es ist interessant so etwas selber aufzusetzen

Ich hab einen eigenen Interpreter geschrieben.

Mein(e) Interpreter:
- C# geschrieben
- 2161 Bytes (effektiv fast 10 mal zu groß)
- selbst wenn ich alle keywords soweit es geht kürze + leerzeichen und LFs entferne dann komme ich auf 1019 Bytes (5 mal so groß)

# Ausführung

Am besten eignet sich der Online Interpreter von jdoodle: https://www.jdoodle.com/execute-b******k-online <br />
Einfach den Code von `VIE_AdventsRaetsel.bf` im Online Interpreter einpflegen und auf oben rechts auf execute drücken.

Um die BF Datei lokal auszuführen benötigt man die dotnet sdk mindestens in CLI Form auf dem Rechner

- Prüfen: `dotnet --version`

Ausführung: `dotnet run .\BfInterpreter.cs -- .\VIE_AdventsRaetsel.bf`