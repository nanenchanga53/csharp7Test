using System;
using static System.Console;

//배열의 특정 요소의 값을 바꾸러면 배열 인스턴스 자체를 넘겨주거나(이거) 원하는 배열 요소만을 바꿀 수 있는 매서드를 정의해야했다
namespace csharp7test
{
    #region 7.1이전 방식
    internal class OldIntList
    {
        int[] list = new int[2] { 1, 2 };
        public OldIntList()
        {
            WriteLine("OldIntList시작");
        }
        ~OldIntList()
        {
            WriteLine("OldIntList 끝");
        }

        public int[] GetList()
        {
            return list;
        }

        internal void Print()
        {
            Array.ForEach(list, (e) => Write(e + ","));
            WriteLine();
        }

    }

    #endregion
}