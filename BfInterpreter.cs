if (args.Length != 1)
{
    Console.Error.WriteLine("BfCompiler takes exactly one argument: <filepath>");
    return 1;
}

var path = args[0];

if (!File.Exists(path))
{
    Console.Error.WriteLine($"File not found: <{path}>");
    return 1;
}

var content = File.ReadAllText(path);
var validContent = new List<char>();
char[] validCommands = ['<', '>', '+', '-', '.', ',', '[', ']'];

foreach (var c in content)
{
    if (validCommands.Contains(c))
        validContent.Add(c);
}

var loopMap = new Dictionary<int, int>();
var stack = new Stack<int>();

for (int i = 0; i < validContent.Count; i++)
{
    if (validContent[i] == '[')
    {
        stack.Push(i);
    }
    else if (validContent[i] == ']')
    {
        if (stack.Count == 0)
        {
            Console.Error.WriteLine($"']' misses matching start at {i}");
            return 1;
        }
        int start = stack.Pop();
        loopMap[start] = i;
        loopMap[i] = start;
    }
}

if (stack.Count > 0)
{
    Console.Error.WriteLine($"'[' misses matching end");
    return 1;
}

int memoryLength = 30000;
byte[] memory = new byte[memoryLength];
int pointer = 0;
int programCounter = 0;

while (programCounter < validContent.Count)
{
    char cmd = validContent[programCounter];
    switch (cmd)
    {
        case '<':
            pointer--;
            break;
        case '>':
            pointer++;
            break;
        case '+':
            memory[pointer]++;
            break;
        case '-':
            memory[pointer]--;
            break;
        case '.':
            Console.Write((char)memory[pointer]);
            break;
        case ',':
            int input;
            do
            {
              input = Console.Read();  
            } while (input == '\r');
            memory[pointer] = input == -1 ? (byte)0 : (byte)input;
            break;
        case '[':
            if (memory[pointer] == 0)
                programCounter = loopMap[programCounter];
            break;
        case ']':
            if (memory[pointer] != 0)
                programCounter = loopMap[programCounter];
            break;
    }
    programCounter++;
}

return 0;