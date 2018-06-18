using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace csharp7test
{
    class Program
    {
        static void Main(string[] args)
        {
            NewOut();
            OldRef();
            NewRef();
            
            
        }

        private static void NewRef()
        {
            NewIntList intlist = new NewIntList();
            ref int item = ref intlist.GetFirstItem();
        }



        private static void OldRef()
        {
            OldIntList intList = new OldIntList();
            int[] list = intList.GetList();
            list[0] = 5;

            
            intList.Print();
        }

        private static void NewOut()
        {
            int.TryParse("5", out int _); //out쪽을 생략할 수 있음 ㄷㄷ
            int.TryParse("5", out int result); //미리 result 를 지정해두지 않아도 바로 불러와 쓸수있음

            int a = 5;
            ref int b = ref a;  //같은 메모리영역을 갖는다 참조하는 주소값을 따로 갖지않는다!
        }
    }

    class NewIntList
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

    class OldIntList
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

    
}
