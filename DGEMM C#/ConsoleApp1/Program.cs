// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");
TickCounter t = new TickCounter();
Random rnd = new Random(100);
double fullTime = 0.0;
for( int i = 0; i < 100; i++)
{
    int m = rnd.Next(1, 100);
    int k = rnd.Next(1, 100);
    int n = rnd.Next(1, 100);
    int alfa = rnd.Next(0, 100);
    int beta = rnd.Next(0, 100);
    Matrix aMatrix = new Matrix(m, k);
    Matrix bMatrix = new Matrix(k, n);
    Matrix cMatrix = new Matrix(m, n);
    t.Start();
    Matrix resMatrix = Matrix.DGEMM(aMatrix, bMatrix, cMatrix, alfa, beta);
    t.Stop();
    fullTime += t.GetTime().TotalMilliseconds;
}

Console.WriteLine($"Время выполнения 100 операций {fullTime} мс");
// Время выполнения 100 операций 526,2631000000002 мс
//Время выполнения 100 операций 449,94460000000004 мс
//Время выполнения 100 операций 487,50519999999983 мс
//Время выполнения 100 операций 497,69390000000016 мс
fullTime = 0.0;
for (int i = 0; i < 100; i++)
{
    int m = rnd.Next(1, 100);
    int k = rnd.Next(1, 100);
    int n = rnd.Next(1, 100);
    int alfa = rnd.Next(0, 100);
    int beta = rnd.Next(0, 100);
    MatrixBig aMatrix = new MatrixBig(m, k);
    MatrixBig bMatrix = new MatrixBig(k, n);
    MatrixBig cMatrix = new MatrixBig(m, n);
    t.Start();
    MatrixBig resMatrix = MatrixBig.DGEMM(aMatrix, bMatrix, cMatrix, alfa, beta);
    t.Stop();
    fullTime += t.GetTime().TotalMilliseconds;
}

Console.WriteLine($"Время выполнения 100 операций {fullTime} мс");
//Время выполнения 100 операций 2284,949 мс
//Время выполнения 100 операций 2294,6290999999987 мс
//Время выполнения 100 операций 2298,5006000000008 мс
//Время выполнения 100 операций 2253,1642 мс