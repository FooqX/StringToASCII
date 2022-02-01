Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("~~ Text to decimal ASCII v1.0.1");
Console.ResetColor();

// Getting string from user input
Console.Write("Enter the string >> ");
string text = Console.ReadLine();

// Getting seperator from user input
Console.Write("Enter a seperator (char) >> ");
char seperator = Console.ReadKey().KeyChar;

Console.Write("\nConverting to ASCII array... ");
// Creating ASCII array that will store ASCII numbers
uint[] asciiArray = new uint[text.Length];

for (int i = 0; i < text.Length; i++) {
    asciiArray[i] = Convert.ToUInt32(text[i]);
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\rSuccessfully converted text to ASCII array!");
Console.ResetColor();

Console.Write("Seperating ASCII with custom seperator...");

string output = "";
for (int i = 0; i < text.Length; i++) {
    output = output + seperator + asciiArray[i];
}

// A fix for the seperator being at the beginning
if (','.Equals(seperator) || ' '.Equals(seperator)) {
    output = output.Remove(0, 1);
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\rSuccessfully seperated ASCII with custom seperator!\n");
Console.ResetColor();

if (output.Length >= 150) {
    Console.WriteLine("- Output: Too big to show (length greater than 150)");
} else {
    Console.WriteLine("- Output: " + output);
}

Console.Write("Copy output to clipboard? (Y)es/(N)o >> ");

if ("y".Equals(Console.ReadLine().ToLower())) {
    using System.Diagnostics.Process cmd = new();
    cmd.StartInfo.FileName = "cmd.exe";
    cmd.StartInfo.RedirectStandardInput = true;
    cmd.StartInfo.RedirectStandardOutput = true;
    cmd.StartInfo.CreateNoWindow = true;
    cmd.StartInfo.UseShellExecute = false;
    cmd.Start();

    cmd.StandardInput.WriteLine("echo|set/p=" + output + "|clip");
    cmd.StandardInput.Flush();
    cmd.StandardInput.Close();
    cmd.WaitForExit();
    cmd.Dispose();
}

Console.WriteLine("Press return to terminate the program;");
Console.ReadKey();
Environment.Exit(0);
