using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8__32_
{
    class Program
    {
        //функция проверки ввода целого числа
        public static int CheckInputInt(string message, int minValue, int maxValue)
        //(сообщение, мин вводимое значение, макс вводимое значение)
        {
            int input; //переменная, которой будет присвоено значение, введенное с клавиатуры
            do
            {
                input = maxValue + 1;  //переменной присваивается значение, выходящее за макс значение
                Console.WriteLine(message); //печать сообщения
                try
                {
                    string buf = Console.ReadLine();
                    input = Convert.ToInt16(buf);
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
            } while ((input < minValue) || (input > maxValue)); //пока значение больше макс/меньше мин
            return input;
        }

        //проверка смежные ли вершины
        static bool IsIncident(int[,] incMatrix,int vertix1,int vertix2)
            //матрица инциденций, вершина1, вершина2
        {
            for(int j = 0; j < incMatrix.GetLength(1); j++)
            {
                if (incMatrix[vertix1, j] + incMatrix[vertix2, j] == 2)
                {
                    return true;
                }
            }
            return false;
        }

        //удалить смежные вершины из списка вершин
        static List<int> DeleteIncidentVerticesFromArray(List<int> range,int[,]incMatrix)
            //список вершин, матрица инциденций
        {
            for (int i = 0; i < range.Count; i++)//
            {
                int k = 1;

                while (range.Count > i + k)
                {
                    if (IsIncident(incMatrix, range[i], range[i + k]))
                    {
                        range.Remove(range[i + k]);
                        k--;
                    }
                    k++;
                }
            }
            return range;
        }

        //выбрать список максимального количества несмежных вершин
        static List<int> SelectRange(int[,]incMatrix,ref List<int>freeVertices)
            //матрица инциденций, список доступных вершин
        {
            List<int> range = new List<int>();//список несмежных вершин
           
            for(int i = 0; i < freeVertices.Count; i++)//записать все доступные вершины в список несмежных вершин
                range.Add(freeVertices[i]);

            //удалить все смежные вершины из списка
            range = DeleteIncidentVerticesFromArray(range, incMatrix);

            for (int i = 0; i < range.Count; i++) //удалить выбранные вершины из списка доступных
                freeVertices.Remove(range[i]);

            return range;
        }
        
        //выбрать все независимые множества
        static void SelectAllRanges(List<List<int>> ranges, int[,] incMatrix, ref List<int> freeVertices)
        {
            do
            {
                ranges.Add(SelectRange(incMatrix, ref freeVertices));

            } while (freeVertices.Count != 0);
        }

        //если число раскрасок К больше минимальной раскраски, то переместить вершины из независимых множеств в отдельные множества
        static void ColourIsMoreThanMininmal(List<List<int>> ranges,int k)
        {
            if (k > ranges.Count)
            {
                int difference = k - ranges.Count;//разность между К цветов и минимальной раскраской
                int removed = 0;//количество перемещенных
                int length = ranges.Count;

                for (int i = 0; i < length; i++)//проход по спискам независимых множеств вершин
                {
                    if (difference != removed)
                    {
                        for (int j = ranges[i].Count - 1; j > 0; j--)//проход по элементам списка несмежных вершин
                        {
                            if (difference != removed)
                            {
                                List<int> dopRange = new List<int>();
                                dopRange.Add(ranges[i][j]);
                                ranges[i].Remove(ranges[i][j]);

                                ranges.Add(dopRange);
                                removed++;
                            }
                            else
                                break;
                        }
                    }
                    else
                        break;
                }
            }

        }

        //печать матрицы инциденций
        static void PrintIncidenceMatrix(int [,] incMatrix)
        {
            for (int i = 1; i < incMatrix.GetLength(0); i++)//1
            {
                for (int j = 1; j < incMatrix.GetLength(1); j++)//1
                {
                    Console.Write(incMatrix[i, j] + "    ");
                }
                Console.WriteLine();
            }
        }

        //печать множеств вершин раскрашенных разными цветами
        static void PrintColouredRanges(List<List<int>> ranges)
        {
            int y = 1;
            foreach (List<int> oneRange in ranges)
            {
                Console.WriteLine($"Вершины, раскрашенный цветом №{ y}");
                foreach (int v in oneRange)
                {
                    Console.Write(v + "    ");
                }
                y++;
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            //программа находит какю-либо правильную раскраску грфа с помощью К цветов
            
            //сгенерировать случайную матрицу инциденций из класса матриц инциденций
            int[,] incidenceMatrix = IncidenceMatrices.GenerateRandomIncidenceMatrix();

            //напечатать матрицы инциденций
            PrintIncidenceMatrix(incidenceMatrix);
            
            //ввод количества красок и проверка ввода
            int k = CheckInputInt($"Введите K красок от 1 до {incidenceMatrix.GetLength(0)-1}", 1, incidenceMatrix.GetLength(0)-1);


            List<int> freeVertices = new List<int>();//список доступных вершин (не выбранных в список несмежных вершин)
            for (int i = 1; i < incidenceMatrix.GetLength(0); i++)
                freeVertices.Add(i);


            List<List<int>> ranges = new List<List<int>>(); //список списков несмежных вершин

            //выбрать все независимые множества вершин
            SelectAllRanges(ranges, incidenceMatrix, ref freeVertices);

            
            if (ranges.Count > k)
            {
                Console.WriteLine($"Не получается раскрасить граф заданным количеством красок, но можно закрасить с помощью {ranges.Count} красок");
            }
            else
            {
                //если число раскрасок К больше минимальной раскраски, то переместить вершины из независимых множеств в отдельные множества
                ColourIsMoreThanMininmal(ranges, k);

                //печать множеств вершин раскрашенных разными цветами
                PrintColouredRanges(ranges);
            }


        }
    }
}
