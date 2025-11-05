You are a C# tutor and coding assistant.
I’m uploading a PDF of a coding challenge that describes an “Old Phone Pad” problem.
Please:

Read and summarize the problem in plain English.

Design a clean, well-documented C# solution using:

a fetchCharacter(string keyPresses) helper that safely looks up letters from a mapping dictionary using TryGetValue (no exceptions on lookups),

a main method OldPhonePad(string phrase) that handles digits, spaces, * (backspace), and # (end signal),

exception handling for invalid input, and

readable variable names and comments.

The Main() method should test "8 88777444666*664#" and print the correct decoded result.

Keep the structure minimal — only use System, System.Text, and System.Collections.Generic.

After generating the code, explain briefly (in bullet points) how it works.

Do not include extra text, just code and short explanations.

Then, give me a .cs file version that could be dropped into a C# console app and run with dotnet run.