using System;
using static System.Console;

namespace csharp7test
{
    internal class UseNewTuple
    {
        #region 이전 Tuple

        ////기존에는 Tuple<int,string> 이런식으로 앞에 Tuple을 붙여줘야 했다.
        ////변수의 이름이 Item1,2,3 만 반환 가능하였다.
        //public UseNewTuple()
        //{
        //    Tuple<bool, int> result = ParseInteger("50");
        //    WriteLine(result.Item1);
        //    WriteLine(result.Item2);

        //}

        //Tuple<bool, int> ParseInteger(string text)
        //{
        //    int number = 0;
        //    bool result = false;

        //    try
        //    {
        //        number = Int32.Parse(text);
        //    }
        //    catch
        //    {

        //    }

        //    return Tuple.Create(result, number);
        //}

        #endregion
        #region 새로운 Tuple

        //
        public UseNewTuple()
        {
            var result = ParseInteger("50");
            WriteLine(result.Parsed); //.Item1
            WriteLine(result.Number); //.Item2
            
            //만약 튜플을 반환하는 메서드가 지정한 튜플의 이름들을 원하지 않거나 또는 이름이 지정되지 않은 튜플인 경우 이름 지정 가능
            (bool Success, int number2) result2 = ParseInteger("50");
            WriteLine(result2.Success);
            WriteLine(result2.number2);

            //개별 필드를 분해해서 받는 구문도 가능
            (var Success3, var number3) = ParseInteger("50");
            WriteLine(Success3);
            WriteLine(number3);

            //생략도 가능
            (var _, var n) = ParseInteger("49");
            WriteLine(n);

            DeconstructRectangle rect = new DeconstructRectangle(5, 6, 20, 25);
            {
                (int x, int y) = rect;
                WriteLine($"x = {x}, y = {y}");
            }

        }

        (bool Parsed, int Number) ParseInteger(string text)
        {
            int number = 0;
            bool result = false;

            try
            {
                number = Int32.Parse(text);
                result = true;
            }
            catch { }

            return (result, number);
        }

        #endregion

    }

    //Deconstruct 튜플의 반환값을 분해하는 구문을 원하면 Deconstruct라는 메서들를 정의하면 된다.
    internal class DeconstructRectangle
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public DeconstructRectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

    }
}