using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.Packages
{
    public static class MatrixMultiplication
    {
        public static double[,] SequentialMultiplication(double[,] matrixA , double[,] matrixB)
        {
            var matrixARows = matrixA.GetLength(0);
            var matrixACols = matrixA.GetLength(1);
            var matrixBRows = matrixB.GetLength(0);
            var matrixBCols = matrixB.GetLength(1);

            if (matrixACols != matrixBRows)
                throw new InvalidOperationException ("Columns of first matrix must equal to Rows of second matrix");

            double[,] result = new double[matrixARows, matrixBCols];

            for (int row_in_MatrixA = 0; row_in_MatrixA < matrixARows; row_in_MatrixA++)
                for (int col_in_matrixB = 0; col_in_matrixB < matrixBCols; col_in_matrixB++)
                    for (int matrix1_col = 0; matrix1_col < matrixACols; matrix1_col++)
                        result[row_in_MatrixA, col_in_matrixB] += matrixA[row_in_MatrixA, matrix1_col] * matrixB[matrix1_col, col_in_matrixB];

            return result;
        }

        public static double[,] ParalleledMultiplication(double[,] matrixA, double[,] matrixB )
        {

            var matrixARows = matrixA.GetLength(0);
            var matrixACols = matrixA.GetLength(1);
            var matrixBRows = matrixB.GetLength(0);
            var matrixBCols = matrixB.GetLength(1);
            
            if (matrixACols != matrixBRows)
                throw new InvalidOperationException("Columns of first matrix must equal to Rows of second matrix");
            
            double[,] result = new double[matrixARows, matrixBCols];

            Parallel.For(0, matrixARows, row_in_MatrixA =>
            {
                for (int col_in_matrixB = 0; col_in_matrixB < matrixBCols; col_in_matrixB++)
                {
                    for (int matrix1_col = 0; matrix1_col < matrixACols; matrix1_col++)
                        result[row_in_MatrixA, col_in_matrixB] += matrixA[row_in_MatrixA, matrix1_col] * matrixB[matrix1_col, col_in_matrixB];
                }
            });

            return result;
        }
    }
}
