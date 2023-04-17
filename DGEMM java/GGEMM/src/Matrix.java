import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Matrix {

    private Integer height;

    private Integer width;

    private List<List<Double>> matrix = new ArrayList<>();

    private void GenerateMatrix() {
        if (matrix.size() == 0) {
            for (int i = 0; i < height; i++) {
                List<Double> v = new ArrayList<>();
                for (int j = 0; j < width; j++) {
                    Random rand = new Random();
                    v.add(rand.nextDouble() * 10000);
                }
                matrix.add(v);
            }
        } else {
            System.out.println("Matrix already generated");
        }

    }

    public int GetHeight() {
        return height;
    }

    public int GetWidth() {
        return width;
    }

    public List<List<Double>> GetMatrix() {
        return matrix;
    }

    public void SetMatrix(List<List<Double>> matrix) {
        this.matrix = matrix;
    }

    public Matrix(int height, int width, Boolean isGenerate) {
        this.height = height;
        this.width = width;
        if (isGenerate) {
            GenerateMatrix();
        }

    }

    static public void PrintMatrix(Matrix m) {
        for (List<Double> list : m.GetMatrix()) {
            String s = "";
            for (double v : list) {
                s += v + ", ";
            }

            System.out.println(s);
        }
    }

    static public Matrix MultiplyMatrix(Matrix m1, Matrix m2) {
        Matrix newMatrix = new Matrix(m1.GetHeight(), m2.GetWidth(), false);
        if (m1.GetWidth() == m2.GetHeight()) {
            List<List<Double>> newMatrixList = new ArrayList<>();

            for (int i = 0; i < m1.GetHeight(); i++) {
                List<Double> matrix_str = new ArrayList<>();
                for (int j = 0; j < m2.GetWidth(); j++) {
                    double newItem = 0.0;
                    for (int k = 0; k < m1.GetWidth(); k++) {
                        newItem += m1.GetMatrix().get(i).get(k) * m2.GetMatrix().get(k).get(j);
                    }
                    matrix_str.add(newItem);
                }
                newMatrixList.add(matrix_str);
            }
            newMatrix.SetMatrix(newMatrixList);

        }

        return newMatrix;

    }

    static public Matrix AdditionalMatrix(Matrix m1, Matrix m2) {
        Matrix newMatrix = new Matrix(m1.GetHeight(), m2.GetWidth(), false);
        if (m1.GetHeight() == m2.GetHeight() && m1.GetWidth() == m2.GetWidth()) {
            List<List<Double>> newMatrixList = new ArrayList<>();
            for (int i = 0; i < m1.GetHeight(); i++) {
                List<Double> matrixStr = new ArrayList<>();
                for (int j = 0; j < m2.GetWidth(); j++) {
                    double newItem = m1.GetMatrix().get(i).get(j) + m2.GetMatrix().get(i).get(j);
                    matrixStr.add(newItem);
                }
                newMatrixList.add(matrixStr);
            }
            newMatrix.SetMatrix(newMatrixList);
        }

        return newMatrix;
    }

    static public Matrix ScalarMultiplyMatrix(int scalar, Matrix m) {
        Matrix newMatrix = new Matrix(m.GetHeight(), m.GetWidth(), false);
        List<List<Double>> newMatrixList = new ArrayList<>();
        for (int i = 0; i < m.GetHeight(); i++) {
            List<Double> matrixStr = new ArrayList<>();
            for (int j = 0; j < m.GetWidth(); j++) {
                matrixStr.add(m.GetMatrix().get(i).get(j) * scalar);
            }
            newMatrixList.add(matrixStr);

        }
        newMatrix.SetMatrix(newMatrixList);
        return newMatrix;
    }

    static public Matrix DGEMM(Matrix a, Matrix b, Matrix c, int alfa, int beta) {
        Matrix AB = Matrix.MultiplyMatrix(a, b);
        ;
        Matrix alfaAB = Matrix.ScalarMultiplyMatrix(alfa, AB);
        Matrix betaC = Matrix.ScalarMultiplyMatrix(beta, c);
        Matrix result = Matrix.AdditionalMatrix(alfaAB, betaC);
        return result;
    }
}


