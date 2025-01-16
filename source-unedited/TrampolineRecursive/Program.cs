// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using TrampolineRecursive;

Console.WriteLine("Hello, factorial!");
// Factorial function using trampoline that returns a tuple with the result and the stack frame count.
Func<FuncRec<int, int, Tuple<int, int>>, Func<int, int, FuncRec<int, int, Tuple<int, int>>>> fac_ =
    f => (x, a) => x <= 1 ? f.Break(new Tuple<int, int>(a, new StackTrace().FrameCount)) : f(x - 1, a * x);
Func<int, Tuple<int, int>> fac = (int n) => fac_.Fix()(n, 1);
var f3 = fac(3);
Console.WriteLine($"Factorial 3 = {f3.Item1}, stack frame count = {f3.Item2}");
var f5 = fac(5);
Console.WriteLine($"Factorial 5 = {f5.Item1}, stack frame count = {f5.Item2}");


