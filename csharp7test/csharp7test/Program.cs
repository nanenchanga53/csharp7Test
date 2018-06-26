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
            //NewOut(); //out의 편의성이 높아졌다 미리 정의된 변수에 out안에 넘겨야했던게 받아온 곳에서 바로 선언해 사용 가능하다.
            //OldRef();//배열의 특정 요소의 값을 바꾸러면 배열 인스턴스 자체를 넘겨주거나(이거) 원하는 배열 요소만을 바꿀 수 있는 매서드를 정의해야했다
            //NewRef();//ref return을 사용하면 원하는 요소의 참조만 반환하는 것이 가능하다
            //MethodRef(); //메서드 값에 값을 대입가능
            //NewTuple(); //튜플의 새로운 정의 방법이 생겼다. Tuple<,>가 (,)로 편하게 바뀌었다.
            //NewRanda(); //이전에는 매서드,속성get,인덱서get이 사용가능했다 하지만 생성자,소멸자,이벤트,속성과인덱서의 set까지 확장되었다.
            //NewLocalFuctions();//메서드 안에서만 호출 가능한 메서드를 정의할 수 있는 지역함수 문법을 추가했다.
            //NewAsync(); ////ValueTask<T> 타입은 async 메서드 내에 동기 처리와 비동기 처리가 혼합되어 있을 때 유용하다
            //NewThrow(); //throw가 의미 있게 사용될 만한 식에서 허용이된다.
            newNumberLiteral(); //숫자 중간에 _를 넣어서 기독성을 높일 수 있다 아쉽게도 ,는 못쓴다.

        }

        private static void newNumberLiteral()
        {
            int number1 = 10000000; //1천만인지 한눈에 인식이 안됨
            int number2 = 1000_0000; //세 자리마다 띄어 한눈에 1천만임을 알 수 있음

            uint hex1 = 0xFFFFFFFF;
            uint hex2 = 0xFF_FF_FF_FF; // 1바이트마다 띄어서 표현
            uint hex3 = 0xFFFF_FFFF; // 2바이트마다 띄어서 표현

            //2진 비트열의 리터럴 표현 추가 접두사로 '0b'를 사용하여 기독성 높은 2진 비트열을 정의하는 것이 가능
            uint bin1 = 0b0001000100010001; // 2진 비트열로 숫자 데이터 정의
            uint bin2 = 0b0001_0001_0001_0001; // 4자리마다 구분자를 사용해 기독성을 높임

            double dob1 = 1.234256;
            double dob2 = 1.234_256;

            WriteLine($"1000_0000 = {number2}");
            WriteLine($"0xFFFF_FFFF = {hex3}");
            WriteLine($"0b0001000100010001 =  {bin1}");
            WriteLine($"0b0001_0001_0001_0001 = {bin2}");
            WriteLine($"1.234_256 = {dob2}");
        }

        private static void NewThrow()
        {
            UseNewThrow newThrow = new UseNewThrow();
        }

        private static void NewAsync()
        {
            UseNewAsync newAsyncs = new UseNewAsync();
        }

        private static void NewLocalFuctions()
        {
            UseNewLocalFuntion funtions = new UseNewLocalFuntion();
        }

        private static void NewRanda()
        {
            UseNewRanda randa = new UseNewRanda();
        }

        private static void NewTuple()
        {
            UseNewTuple tuple = new UseNewTuple();
        }

        private static void MethodRef()
        {
            MyMatrix matrix = new MyMatrix();
            matrix.Put(0, 0) = 1;
            int result = matrix.Put(1, 1) = 100;
            WriteLine($"메서드 값(0,0) : {matrix.Put(0,0)}");
        }

        private static void NewRef()
        {
            NewIntList intlist = new NewIntList();
            ref int item = ref intlist.GetFirstItem();
            intlist.Print();
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




}
