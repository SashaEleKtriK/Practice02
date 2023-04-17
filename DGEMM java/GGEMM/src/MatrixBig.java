import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class MatrixBig {
    private Integer height;

    private Integer width;

    private List<List<BigInteger>> matrix = new ArrayList<>();

    private void GenerateMatrix() {
        if (matrix.size() == 0) {
            for (int i = 0; i < height; i++) {
                List<BigInteger> v = new ArrayList<>();
                for (int j = 0; j < width; j++) {
                    Random rand = new Random();
                    v.add(BigInteger.valueOf((rand.nextInt())));
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

    public List<List<BigInteger>> GetMatrix() {
        return matrix;
    }

    public void SetMatrix(List<List<BigInteger>> matrix) {
        this.matrix = matrix;
    }

    public MatrixBig(int height, int width, Boolean isGenerate) {
        this.height = height;
        this.width = width;
        if (isGenerate) {
            GenerateMatrix();
        }

    }

    static public void PrintMatrix(MatrixBig m) {
        for (List<BigInteger> list : m.GetMatrix()) {
            String s = "";
            for (BigInteger v : list) {
                s += v + ", ";
            }

            System.out.println(s);
        }
    }

    static public MatrixBig MultiplyMatrix(MatrixBig m1, MatrixBig m2) {
        MatrixBig newMatrix = new MatrixBig(m1.GetHeight(), m2.GetWidth(), false);
        if (m1.GetWidth() == m2.GetHeight()) {
            List<List<BigInteger>> newMatrixList = new ArrayList<>();

            for (int i = 0; i < m1.GetHeight(); i++) {
                List<BigInteger> matrix_str = new ArrayList<>();
                for (int j = 0; j < m2.GetWidth(); j++) {
                    BigInteger newItem = BigInteger.valueOf(0);
                    for (int k = 0; k < m1.GetWidth(); k++) {
                        newItem = newItem.add( m1.GetMatrix().get(i).get(k).multiply(m2.GetMatrix().get(k).get(j)));
                    }
                    matrix_str.add(newItem);
                }
                newMatrixList.add(matrix_str);
            }
            newMatrix.SetMatrix(newMatrixList);

        }

        return newMatrix;

    }

    static public MatrixBig AdditionalMatrix(MatrixBig m1, MatrixBig m2) {
        MatrixBig newMatrix = new MatrixBig(m1.GetHeight(), m2.GetWidth(), false);
        if (m1.GetHeight() == m2.GetHeight() && m1.GetWidth() == m2.GetWidth()) {
            List<List<BigInteger>> newMatrixList = new ArrayList<>();
            for (int i = 0; i < m1.GetHeight(); i++) {
                List<BigInteger> matrixStr = new ArrayList<>();
                for (int j = 0; j < m2.GetWidth(); j++) {
                    BigInteger newItem = m1.GetMatrix().get(i).get(j).add(m2.GetMatrix().get(i).get(j)) ;
                    matrixStr.add(newItem);
                }
                newMatrixList.add(matrixStr);
            }
            newMatrix.SetMatrix(newMatrixList);
        }

        return newMatrix;
    }

    static public MatrixBig ScalarMultiplyMatrix(int scalar, MatrixBig m) {
        MatrixBig newMatrix = new MatrixBig(m.height, m.width, false);
        List<List<BigInteger>> newMatrixList = new ArrayList<>();
        for (int i = 0; i < m.GetHeight(); i++) {
            List<BigInteger> matrixStr = new ArrayList<>();
            for (int j = 0; j < m.GetWidth(); j++) {
                matrixStr.add(m.GetMatrix().get(i).get(j).multiply(BigInteger.valueOf(scalar)));
            }
            newMatrixList.add(matrixStr);

        }
        newMatrix.SetMatrix(newMatrixList);
        return newMatrix;
    }

    static public MatrixBig DGEMM(MatrixBig a, MatrixBig b, MatrixBig c, int alfa, int beta) {
        MatrixBig AB = MatrixBig.MultiplyMatrix(a, b);
        ;
        MatrixBig alfaAB = MatrixBig.ScalarMultiplyMatrix(alfa, AB);
        MatrixBig betaC = MatrixBig.ScalarMultiplyMatrix(beta, c);
        MatrixBig result = MatrixBig.AdditionalMatrix(alfaAB, betaC);
        return result;
    }
}
