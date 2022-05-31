using System;

namespace ConsoleApp13
{
    class Program
    {
        /// <summary>
        /// Этот метод выполняет умножение матрицы на число.
        /// </summary>
        /// <param name="matrixMultipFirst"></param> Заполненная матрица.
        /// <param name="n"></param>  Количество строк.
        /// <param name="m"></param> Количество столбцов.
        /// <param name="number"></param> Число, на которое нужно умножить.
        /// <returns>
        /// Возвращает результирующую матрицу.
        /// </returns>
        static int[,] MultiplonNumber(int[,] matrixMultipFirst, uint n, uint m, int number)
        {
            int[,] matrixResult = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    matrixResult[i, j] = matrixMultipFirst[i, j] * number;


                }
            }

            return matrixResult;
        }
        /// <summary>
        /// Этот метод выполняет умножение матриц.
        /// </summary>
        /// <param name="matrixMultipFirst"></param> Первая заполненная матрица.
        /// <param name="matrixMultipSecond"></param> Вторая заполненная матрица.
        /// <param name="n"></param> Количество строк.
        /// <param name="m"></param> Количество столбцов.
        /// <returns>
        /// Возвращает результирующую матрицу.
        /// </returns>
        static int[,] Multiplication(int[,] matrixMultipFirst, int[,] matrixMultipSecond, uint n, uint m, uint k)
        { // nm mk
            int[,] matrixMultipRes = new int[n, k];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    for (int y = 0; y < m; y++)
                        matrixMultipRes[i, j] += matrixMultipFirst[i, y] * matrixMultipSecond[y, j];
                }
            }
            return matrixMultipRes;
        }
        static int[,] Difference(int[,] matrixFive, int[,] matrixSix)
        {
            for (int i = 0; i < matrixFive.GetLength(0); i++)

                for (int j = 0; j < matrixFive.GetLength(1); j++)

                    matrixFive[i, j] -= matrixSix[i, j];
            return matrixFive;
        }
        /// <summary>
        /// Этот метод выполняет сложение матриц.
        /// </summary>
        /// <param name="matrixThree"></param> Первая заполненная матрица.
        /// <param name="matrixFour"></param> Вторая заполненная матрица.
        /// <param name="n"></param> Количество строк.
        /// <param name="m"></param> Количество столбцов.
        /// <returns>
        /// Возвращает результирующую матрицу.
        /// </returns>
        static int[,] SumMatrix(int[,] matrixThree, int[,] matrixFour, uint n, uint m)
        {
            for (int i = 0; i < n; i++)

                for (int j = 0; j < m; j++)

                    matrixThree[i, j] += matrixFour[i, j];

            return matrixThree;
        }
        /// <summary>
        /// Это метод вывода матрицы.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        static void Output(int[,] matrix, uint n, uint m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.Write("\n");
            }
        }
        /// <summary>
        /// Этот метод находит определитель матрицы.
        /// </summary>
        static int Determinant(int[,] matrixdet, uint n)
        {
            //Определитель.
            int det = 0;
            //Знак.
            int sign = 1;
            if (n == 1) return matrixdet[0, 0];
            int[,] matr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                Cofunct(matrixdet, matr, 0, i, n);
                det += (sign * matrixdet[0, i] * Determinant(matr, n - 1));
                sign = -sign;
            }

            return det;
        }
        /// <summary>
        /// Этот  метод находит кофактор.
        /// </summary>

        static void Cofunct(int[,] matrixdet, int[,] matr, int x, int y, uint n)
        {
            int m1 = 0;
            int m2 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (i != x && j != y)
                    {
                        matr[m1, m2++] = matrixdet[i, j];
                        if (m2 == n - 1)
                        {
                            m2 = 0;
                            m1++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Этот метод выполняет транспонирование матрицы.
        /// </summary>
        /// <param name="matrixSecond"></param> - Введеная матрица.
        /// <returns>
        /// Возвращает транспонированную матрицу.
        /// </returns>
        static int[,] Transposition(int[,] matrixSecond, int[,] matrixTrancepose)
        {

            for (int i = 0; i < matrixSecond.GetLength(0); i++)
                for (int j = 0; j < matrixSecond.GetLength(1); j++)
                    matrixTrancepose[i, j] = matrixSecond[j, i];
            return matrixTrancepose;

        }

        /// <summary>
        /// Этот метод выполняет операцию "1"- нахождение следа матрицы.
        /// </summary>
        /// <param name="matrixFirst"></param> - Матрица.
        /// <param name="n"></param> - Размерность матрицы.
        /// <returns>
        /// Возвращает след матрицы sum_tr.
        /// </returns>
        static int Trace(int[,] matrix2, uint n)
        {
            int sum_tr = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) { sum_tr += matrix2[i, j]; }
                }
            }
            return sum_tr;
        }
        /// <summary>
        /// Это метод заполнения матрицы. Пользователь выбирает как он хочет задать матрицу самостоятельно или с помощью рандома.
        /// </summary>
        /// <param name="n"></param> - Количество строк.
        /// <param name="m"></param> - Количество столбцов.
        /// <returns>
        /// Возвращает заполненную матрицу.
        /// </returns>
        static int[,] Generate(uint n, uint m)
        {
            int[,] matr1 = new int[n, m];
            Random random = new Random();
            var command = "";
            while (true)
            {
                Console.WriteLine("Сгенирировать матрицу или вы введете ее самостоятельно?  ");
                Console.WriteLine(" Введите + , если желаете ввести самостоятельно. Введите - , матрица будет сгенерирована с помощью рандома");
                command = Console.ReadLine();

                if (command == "+")
                {

                    // Ввод с клавиатуры.
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            do
                            {
                                Console.WriteLine(" Введите значения.Введите элементы  в диапозоне от [-100; 100] ");
                            } while (!int.TryParse(Console.ReadLine(), out matr1[i, j]) || matr1[i, j] > 100 || matr1[i, j] < -100);
                        }
                    }

                    return matr1;
                }
                else if (command == "-")
                {
                    Console.WriteLine(" Элементы матрицы находятся в диапозоне от [-100; 100] ");
                    // Заполнение Random.
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            matr1[i, j] = random.Next(-100, 100);
                        }
                    }
                    return matr1;
                }

                else
                {
                    Console.WriteLine("Неизвестная команда. Попробуйте снова");
                }
            }
        }
        static void Main(string[] args)
        {

            do
            {  //Вывод операций.
                Console.WriteLine("Добро пожаловать! Это калькулятор матриц. Возможные операциии:");
                Console.WriteLine("1 - нахождение следа матрицы");
                Console.WriteLine("2- транспонирование матрицы");
                Console.WriteLine("3 - сумма двух матриц");
                Console.WriteLine("4- разность двух матриц");
                Console.WriteLine("5 - произведение двух матриц");
                Console.WriteLine("6 - умножение матрицы на число");
                Console.WriteLine("7- нахождение определителя матриц");

                Console.WriteLine("Введите номер операции, которую желаете совершить : ");
                // Переменная операции.
                uint operation = 0;
                // Переменная n - размер матрицы. (кол-во строк , если n!=m)
                uint n = 0;
                uint m = 0;
                uint k = 0;

                string input = Console.ReadLine();
                while (!uint.TryParse(input, out operation) || operation > 7 || operation < 1)
                {
                    Console.Write("Ошибка. Можно ввести номер операции от 1 до 7. Попробуйте снова ");
                    input = Console.ReadLine();
                }
                switch (operation)
                {   // Нахождение следа матрицы.
                    case 1:
                        //Ввод размерности.
                        do
                        {
                            Console.WriteLine("Теперь укажите размерность матрицы. Это должна быть квадратная матрица (n<=10 и n>0) ");
                        } while (!uint.TryParse(Console.ReadLine(), out n) || n == 0 || n > 10);
                        //Создание и заполнение матрицы.
                        m = n;
                        int[,] matrixFirst = Generate(n, m);
                        Output(matrixFirst, n, m);
                        //Вывод следа матрицы.
                        Console.WriteLine("Результат операции 1: ");
                        Console.WriteLine(Trace(matrixFirst, (uint)matrixFirst.GetLength(1)));
                        break;
                    //Транспонирование матрицы.
                    case 2:
                        //Ввод размерности.
                        do
                        {
                            Console.WriteLine(" Теперь укажите размерность матрицы.Это должна быть квадратная матрица.(n<=10 и n>0) ");
                        } while (!uint.TryParse(Console.ReadLine(), out n) || n == 0 || n > 10);
                        m = n;
                        //  //Создание и заполнение матрицы.
                        int[,] matrixSecond = Generate(n, m);
                        Output(matrixSecond, n, m);
                        Console.Write("Транспонированная матрица");
                        Console.WriteLine();
                        int[,] matrixTrancepose = new int[m, n];
                        matrixTrancepose = Transposition(matrixSecond, matrixTrancepose);
                        //Вывод матрицы.
                        Console.WriteLine("Результат операции 2: ");
                        Output(matrixTrancepose, n, m);
                        break;
                    // Сумма матриц.
                    case 3:
                        //Ввод размерности.
                        do
                        {
                            Console.WriteLine("Введите количество строк матрицы (n<=10 и n>0) ");

                        }

                        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0 || n > 10);
                        do
                        {
                            Console.WriteLine("Теперь укажите количество столбцов (m<=10 и m>0) ");

                        }

                        while (!uint.TryParse(Console.ReadLine(), out m) || m == 0 || m > 10);
                        //Создание и заполнение первой матрицы.
                        int[,] matrixThree = Generate(n, m);
                        Output(matrixThree, n, m);
                        Console.WriteLine("Введите вторую матрицу");
                        //Создание и заполнение второй матрицы.
                        int[,] matrixFour = Generate(n, m);
                        Output(matrixFour, n, m);
                        //Создание результирующей матрицы.
                        int[,] sMatrix = new int[n, m];
                        sMatrix = SumMatrix(matrixThree, matrixFour, n, m);
                        Console.WriteLine("Результат операции 3: ");
                        Output(sMatrix, n, m);
                        break;
                    //Разность матриц.
                    case 4:
                        //Ввод размерности.
                        do
                        {
                            Console.WriteLine("Введите количество строк матрицы (n<=10 и n>0) ");

                        }

                        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0 || n > 10);
                        do
                        {
                            Console.WriteLine("Теперь укажите количество столбцов (m<=10 и m>0) ");

                        }

                        while (!uint.TryParse(Console.ReadLine(), out m) || m == 0 || m > 10);
                        int[,] matrixFive = Generate(n, m);
                        Output(matrixFive, n, m);
                        Console.WriteLine("Введите вторую матрицу");
                        int[,] matrixSix = Generate(n, m);
                        Output(matrixSix, n, m);
                        matrixFive = Difference(matrixFive, matrixSix);
                        Console.WriteLine("Результат операции 4: ");
                        Output(matrixFive, n, m);
                        break;
                    //Произведение двух матриц.
                    case 5:
                        //Ввод размерности.
                        do
                        {
                            Console.WriteLine("Введите количество строк первой матрицы  (n<=10 и n>0) ");

                        }

                        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0 || n > 10);
                        do
                        {
                            Console.WriteLine("Теперь укажите количество столбцов первой матрицы (m<=10 и m>0) ");

                        } while (!uint.TryParse(Console.ReadLine(), out m) || m == 0 || m > 10);

                        Console.WriteLine("Количество столбцов в 1-ой матрице должно быть равно количеству строк в 2-ой матрице.");
                        do
                        {
                            Console.WriteLine("Поэтому теперь введите количество столбцов второй матрицы (k<=10 и k>0)");

                        } while (!uint.TryParse(Console.ReadLine(), out k) || k == 0 || k > 10);

                        //Создание и заполнение первой матрицы.
                        int[,] matrixMultipFirst = Generate(n, m);
                        Output(matrixMultipFirst, n, m);
                        Console.WriteLine("Введите вторую матрицу");
                        //Создание и заполнение второй матрицы.
                        int[,] matrixMultipSecond = Generate(m, k);
                        Output(matrixMultipSecond, m, k);
                        //Создание результирующей матрицы.
                        int[,] matrixMultipResult = new int[n, k];
                        matrixMultipResult = Multiplication(matrixMultipFirst, matrixMultipSecond, n, m, k);
                        //Вывод матрицы.
                        Console.WriteLine("Результат операции 5: ");
                        Output(matrixMultipResult, n, k);
                        break;
                    //Умножение матрицы на число.
                    case 6:
                        //Ввод размерности.
                        do
                        {
                            Console.WriteLine("Введите количество строк матрицы (n<=10 и n>0) ");

                        }

                        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0 || n > 10);
                        do
                        {
                            Console.WriteLine("Теперь укажите количество столбцов (m<=10 и m>0) ");

                        }

                        while (!uint.TryParse(Console.ReadLine(), out m) || m == 0 || m > 10);
                        //Создание и заполнение  матрицы.
                        int[,] matrixMultNumb = Generate(n, m);
                        Output(matrixMultNumb, n, m);
                        //Число, на которое необходимо умножить.
                        int number = 0;
                        do
                        {
                            Console.WriteLine("Введите число, на которое желаете умножить матрицу");
                        }

                        while (!int.TryParse(Console.ReadLine(), out number));
                        //Создание результирующей матрицы.
                        int[,] matrixMultipNumberResult = new int[n, m];
                        matrixMultipNumberResult = MultiplonNumber(matrixMultNumb, n, m, number);
                        //Вывод матрицы.
                        Console.WriteLine("Результат операции 6: ");
                        Output(matrixMultipNumberResult, n, m);
                        break;
                    //Нахождение определителя матриц.
                    case 7:
                        //Ввод размерности.
                        do
                        {
                            Console.WriteLine("Теперь укажите размерность матрицы. Это должна быть квадратная матрица (n<=10 и n>0) ");
                        }
                        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0 || n > 10);
                        //Матрица квадратная.
                        m = n;
                        int[,] matrixSeven = Generate(n, m);
                        Output(matrixSeven, n, m);
                        //Вывод определителя.
                        Console.WriteLine("Результат операции 7: ");
                        Console.WriteLine(Determinant(matrixSeven, n));
                        break;
                    default:
                        Console.WriteLine("Не верно");
                        break;
                }
                // Повтор игры.
                Console.WriteLine("Если вы хотите завершить, то нажмите Escape.\n" +
                    "Иначе нажмите любую клавишу");
                Console.WriteLine();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);



        }
    }
}


