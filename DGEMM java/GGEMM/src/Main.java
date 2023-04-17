import java.util.Random;

public class Main {
    public static void main(String[] args) {

        System.out.println("Hello world!");


        long fullTime = 0;
        for (int i = 0; i < 100; i++) {
            int m = rand(1, 100);
            int k = rand(1, 100);
            int n = rand(1, 100);
            int alfa = rand(0, 100);
            int beta = rand(0, 100);
            Matrix aMatrix = new Matrix(m, k, true);
            Matrix bMatrix = new Matrix(k, n, true);
            Matrix cMatrix = new Matrix(m, n, true);
            TickCounter t = new TickCounter();
            t.start();
            Matrix resMatrix = Matrix.DGEMM(aMatrix, bMatrix, cMatrix, alfa, beta);
            t.end();
            fullTime += t.result();
        }
        System.out.println("Время выполнения 100 операций " + fullTime + " мс");
        //Время выполнения 100 операций 374 мс
        //Время выполнения 100 операций 431 мс
        //Время выполнения 100 операций 407 мс
        //Время выполнения 100 операций 424 мс
        fullTime = 0;
        for (int i = 0; i < 100; i++) {
            int m = rand(1, 100);
            int k = rand(1, 100);
            int n = rand(1, 100);
            int alfa = rand(0, 100);
            int beta = rand(0, 100);
            MatrixBig aMatrix = new MatrixBig(m, k, true);
            MatrixBig bMatrix = new MatrixBig(k, n, true);
            MatrixBig cMatrix = new MatrixBig(m, n, true);
            TickCounter t = new TickCounter();
            t.start();
            MatrixBig resMatrix = MatrixBig.DGEMM(aMatrix, bMatrix, cMatrix, alfa, beta);
            t.end();
            fullTime += t.result();
        }
        System.out.println("Время выполнения 100 операций " + fullTime + " мс");
        //Время выполнения 100 операций 2284 мс
        //Время выполнения 100 операций 2457 мс
        //Время выполнения 100 операций 2215 мс
        //Время выполнения 100 операций 2850 мс
    }

    public static Integer rand(int min, int max) {
        Random rnd = new Random();
        Integer res = min + (int) (rnd.nextDouble() * max);
        return res;

    }
}