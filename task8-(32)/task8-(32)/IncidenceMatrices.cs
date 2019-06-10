using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8__32_
{
    public class IncidenceMatrices
    {
        static Random rnd = new Random();
        public static int[,] GenerateRandomIncidenceMatrix()
        {
            int r = rnd.Next(1, 4);
            if (r == 1)
            {
                int[,] incidenceMatrix = new int[7 + 1, 7 + 1];
                incidenceMatrix[1, 1] = 1;
                incidenceMatrix[1, 5] = 1;
                incidenceMatrix[2, 1] = 1;
                incidenceMatrix[2, 2] = 1;
                incidenceMatrix[2, 6] = 1;
                incidenceMatrix[3, 2] = 1;
                incidenceMatrix[3, 3] = 1;
                incidenceMatrix[4, 3] = 1;
                incidenceMatrix[4, 4] = 1;
                incidenceMatrix[4, 7] = 1;
                incidenceMatrix[5, 4] = 1;
                incidenceMatrix[5, 5] = 1;
                incidenceMatrix[5, 6] = 1;
                incidenceMatrix[6, 7] = 1;
                incidenceMatrix[7, 7] = 1;

                return incidenceMatrix;
            }
            if (r == 2)
            {
                int[,] incidenceMatrix = new int[5 + 1, 6 + 1];
                incidenceMatrix[1, 1] = 1;
                incidenceMatrix[1, 2] = 1;
                incidenceMatrix[1, 3] = 1;
                incidenceMatrix[1, 5] = 1;
                incidenceMatrix[2, 1] = 1;
                incidenceMatrix[2, 4] = 1;
                incidenceMatrix[3, 2] = 1;
                incidenceMatrix[3, 6] = 1;
                incidenceMatrix[4, 3] = 1;
                incidenceMatrix[4, 6] = 1;
                incidenceMatrix[5, 4] = 1;
                incidenceMatrix[5, 5] = 1;

                return incidenceMatrix;
            }
            if (r == 3)
            {
                int[,] incidenceMatrix = new int[4 + 1, 6 + 1];
                incidenceMatrix[1, 1] = 1;
                incidenceMatrix[1, 2] = 1;
                incidenceMatrix[2, 1] = 1;
                incidenceMatrix[2, 3] = 1;
                incidenceMatrix[2, 4] = 1;
                incidenceMatrix[3, 4] = 1;
                incidenceMatrix[3, 5] = 1;
                incidenceMatrix[4, 2] = 1;
                incidenceMatrix[4, 3] = 1;
                incidenceMatrix[4, 5] = 1;

                incidenceMatrix[1, 6] = 1;
                incidenceMatrix[3, 6] = 1;

                return incidenceMatrix;
            }

            return null;
        }
    }
}
