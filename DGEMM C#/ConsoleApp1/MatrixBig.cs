using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MatrixBig
    {
        private int height;

        private int width;

        private List<List<BigInteger>> matrix = new List<List<BigInteger>>();
         

        private void GenerateMatrix()
        {
            if (matrix.Count == 0)
            {
                for (int i = 0; i < height; i++)
                {
                    List<BigInteger> v = new List<BigInteger>();
                    for (int j = 0; j < width; j++)
                    {
                        Random rand = new Random();
                        v.Add(rand.Next());
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
        public List<List<BigInteger>> GetMatrix()
        {
            return matrix;
        }
        public void SetMatrix(List<List<BigInteger>> matrix)
        {
            this.matrix = matrix;
        }
        public MatrixBig(int height, int width, bool isGenerate = true) { 
            this.height = height;
            this.width = width;
            if (isGenerate) { GenerateMatrix(); }
            
        }
        static public void PrintMatrix(MatrixBig m)
        {
            foreach (List<BigInteger> list in m.GetMatrix())
            {
                string s = string.Empty;
                foreach(BigInteger v in list)
                {
                    s += v.ToString() + ", ";
                }
                
                Console.WriteLine(s);
            }
        }
        static public MatrixBig MultiplyMatrix(MatrixBig m1, MatrixBig m2)

        {
            MatrixBig newMatrix = new MatrixBig(m1.GetHeight(), m2.GetWidht(), false);
            if (m1.GetWidht() == m2.GetHeight())
            {
                List<List<BigInteger>> newMatrixList = new List<List<BigInteger>>();

                for (int i = 0; i < m1.GetHeight(); i++)
                {
                    List<BigInteger> matrix_str = new List<BigInteger>();
                    for (int j = 0; j < m2.GetWidht(); j++)
                    {
                        BigInteger newItem = 0;
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

        static public MatrixBig AdditionalMatrix(MatrixBig m1, MatrixBig m2)
        {
            MatrixBig newMatrix = new MatrixBig(m1.GetHeight(), m2.GetWidht(), false);
            if (m1.GetHeight() == m2.GetHeight() && m1.GetWidht()== m2.GetWidht())
            {
                List<List<BigInteger>> newMatrixList = new List<List<BigInteger>>();
                for (int i = 0; i < m1.GetHeight(); i++)
                {
                    List<BigInteger> matrixStr = new List<BigInteger>();
                    for (int j = 0; j < m2.GetWidht();j++)
                    {
                        BigInteger newItem = m1.GetMatrix()[i][j] + m2.GetMatrix()[i][j];
                        matrixStr.Add(newItem);
                    }
                    newMatrixList.Add(matrixStr);
                }
                newMatrix.SetMatrix(newMatrixList);
            }

            return newMatrix;
        }
        static public MatrixBig ScalarMultiplyMatrix(int scalar, MatrixBig m)
        {
            MatrixBig newMatrix = new MatrixBig(m.height, m.width, false);
            List<List<BigInteger>> newMatrixList = new List<List<BigInteger>>();
            for (int i = 0; i < m.GetHeight(); i++)
            {
                List<BigInteger> matrixStr = new List<BigInteger>();
                for (int j = 0; j < m.GetWidht(); j++)
                {
                    matrixStr.Add(m.GetMatrix()[i][j] * scalar);
                }
                newMatrixList.Add(matrixStr);

            }
            newMatrix.SetMatrix(newMatrixList);
            return newMatrix;
        }
        static public MatrixBig DGEMM(MatrixBig a, MatrixBig b, MatrixBig c, int alfa, int beta)
        {
            MatrixBig AB = MatrixBig.MultiplyMatrix(a, b); ;
            MatrixBig alfaAB = MatrixBig.ScalarMultiplyMatrix(alfa, AB);
            MatrixBig betaC = MatrixBig.ScalarMultiplyMatrix(beta, c);
            MatrixBig result = MatrixBig.AdditionalMatrix(alfaAB, betaC);
            return result;
        }
    }
}
