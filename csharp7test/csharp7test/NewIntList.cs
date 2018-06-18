using System;
using static System.Console;

//ref return을 사용하면 원하는 요소의 참조만 반환하는 것이 가능하다
namespace csharp7test
{
    #region 7.1방식
    internal class NewIntList
    {

        int[] list = new int[2] { 1, 2 };

        public NewIntList()
        {
            WriteLine("NewIntList시작");
        }
        ~NewIntList()
        {
            WriteLine("NewIntList종료");
        }

        public ref int GetFirstItem()
        {
            return ref list[0];
        }
        internal void Print()
        {
            Array.ForEach(list, (e) => Write(e + ","));
            WriteLine();
        }

    }

    #endregion
}
