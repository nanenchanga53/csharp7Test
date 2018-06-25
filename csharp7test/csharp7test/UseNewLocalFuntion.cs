using System;
using static System.Console;

namespace csharp7test
{
    internal class UseNewLocalFuntion
    {
        

        public UseNewLocalFuntion()
        {
            //oldLocalFuntion(); //기존에는 델리게이트를 정의 해야만 익명 메서드를 사용가능했다.
            newLocalFuntion(); // 지역함수 문법/다른 메서드의 내부에서 정의한다.
            
        }

        private void newLocalFuntion()
        {
            (bool, int) func(int a, int b)
            {
                if (b == 0) { return (false, 0); }
                return (true, a / b);
            };

            //단일식으로 정의될 수 있으면 람다 식으로 정의하는 것이 가능
            //(bool, int) func2(int a, int b) => (b == 0) ? (false, 0) : (true, a / b);

            WriteLine(func(10, 5));
        }

        #region 기존 익명 메서드에 대한 델리게이트 정의
        delegate (bool, int) MyDivide(int a, int b);
        private void oldLocalFuntion()
        {
            MyDivide func = delegate (int a, int b) //델리게이트 방식
            {
                if (b == 0)
                {
                    return (false, 0);
                }
                return (true, a / b);
                ;
            };

            MyDivide func2 = (a, b) =>             //람다방식
            {
                if (b == 0) { return (false, 0); }
                return (true, a / b);
            };



            WriteLine(func(10, 5));
            WriteLine(func(10, 0));
        }
    }
#endregion
}