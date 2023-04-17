using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Matrix
    {
        private int height;

        private int width;

        private List<List<double>> matrix = new List<List<double>>();

        private void GenerateMatrix()
        {
            if (matrix.Count == 0)
            {
                for (int i = 0; i < height; i++)
                {
                    List<double> v = new List<double>();
                    for (int j = 0; j < width; j++)
                    {
                        Random rand = new Random();
                        v.Add(rand.NextDouble()*10000);
                    }
                    matrix.Add(v);
                }
            }
            else { Console.WriteLine("Matrix already generated"); }
            
        }
        public int GetHeight()
        {
            return height;
        }
        public int GetWidht()
        {
            return width;
        }
        public List<List<double>> GetMatrix()
        {
            return matrix;
        }
        public void SetMatrix(List<List<double>> matrix)
        {
            this.matrix = matrix;
        }
        public Matrix(int height, int width, bool isGenerate = true) { 
            this.height = height;
            this.width = width;
            if (isGenerate) { GenerateMatrix(); }
            
        }
        static public void PrintMatrix(Matrix m)
        {
            foreach (List<double> list in m.GetMatrix())
            {
                string s = string.Empty;
                foreach(double v in list)
                {
                    s += v.ToString() + ", ";
                }
                
                Console.WriteLine(s);
            }
        }
        static public Matrix MultiplyMatrix(Matrix m1, Matrix m2)

        {
            Matrix newMatrix = new Matrix(m1.GetHeight(), m2.GetWidht(), false);
            if (m1.GetWidht() == m2.GetHeight())
            {
                List<List<double>> newMatrixList = new List<List<double>>();

                for (int i = 0; i < m1.GetHeight(); i++)
                {
                    List<double> matrix_str = new List<double>();
                    for (int j = 0; j < m2.GetWidht(); j++)
                    {
                        double newItem = 0.0;
                        for (int k = 0; k < m1.GetWidht(); k++)
                        {
                            newItem += m1.GetMatrix()[i][k] * m2.GetMatrix()[k][j];
                        }
                        matrix_str.Add(newItem);
                    }
                    newMatrixList.Add(matrix_str);
                }
                newMatrix.SetMatrix(newMatrixList);

            }
            
            return newMatrix;
            
        }

        static public Matrix AdditionalMatrix(Matrix m1, Matrix m2)
        {
            Matrix newMatrix = new Matrix(m1.GetHeight(), m2.GetWidht(), false);
            if (m1.GetHeight() == m2.GetHeight() && m1.GetWidht()== m2.GetWidht())
            {
                List<List<double>> newMatrixList = new List<List<double>>();
                for (int i = 0; i < m1.GetHeight(); i++)
                {
                    List<double> matrixStr = new List<double>();
                    for (int j = 0; j < m2.GetWidht();j++)
                    {
                        double newItem = m1.GetMatrix()[i][j] + m2.GetMatrix()[i][j];
                        matrixStr.Add(newItem);
                    }
                    newMatrixList.Add(matrixStr);
                }
                newMatrix.SetMatrix(newMatrixList);
            }

            return newMatrix;
        }
        static public Matrix ScalarMultiplyMatrix(int scalar, Matrix m)
        {
            Matrix newMatrix = new Matrix(m.height, m.width, false);
            List<List<double>> newMatrixList = new List<List<double>>();
            for (int i = 0; i < m.GetHeight(); i++)
            {
                List<double> matrixStr = new List<double>();
                for (int j = 0; j < m.GetWidht(); j++)
                {
                    matrixStr.Add(m.GetMatrix()[i][j] * scalar);
                }
                newMatrixList.Add(matrixStr);

            }
            newMatrix.SetMatrix(newMatrixList);
            return newMatrix;
        }
        static public Matrix DGEMM(Matrix a, Matrix b, Matrix c, int alfa, int beta)
        {
            Matrix AB = Matrix.MultiplyMatrix(a, b); ;
            Matrix alfaAB = Matrix.ScalarMultiplyMatrix(alfa, AB);
            Matrix betaC = Matrix.ScalarMultiplyMatrix(beta, c);
            Matrix result = Matrix.AdditionalMatrix(alfaAB, betaC);
            return result;
        }
    }
}
