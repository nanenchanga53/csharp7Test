using System;
using static System.Console;
using static System.Convert;

namespace csharp9test
{

        
        class Program
        {

                static void Main(string[] args)
                {
                        

                        WriteLine("새 기능들 리스트 중 하나를 고르시오(참조사이트 http://www.csharpstudy.com/latest/CS-new-features.aspx)");
                        WriteLine("C# 9.0을 사용하기 위해서는 .NET 5.0 SDK를 설치하고,과 isual Studio 2019의 최신 Preview 버젼 (예: 2020-10-13 VS 2019 16.8 Preview 4)을 설치한다.");
                        WriteLine("---------------------------------------------------------------------------------------------------------");
                        WriteLine("1.레코드(record) 타입");
                        WriteLine("2.init accessor");
                        WriteLine("3.최상위 프로그램 (Top-level Program)");
                        WriteLine("4.향상된 패턴 매칭 (Pattern matching)");
                        WriteLine("5.향상된 타겟 타이핑 (Target typing)");
                        WriteLine("6.공변 리턴 타입 (Covariant return type)");
                        WriteLine("7.Native Int 타입 (nint, nuint)");

                        int selectedNum = ToInt32(ReadLine());

                        switch (selectedNum)
                        {
                                case 1:
                                        WriteLine("레코드(record) 타입");
                                        WriteLine("Selected");

                                        RecordType ry = new RecordType();

                                        break;
                                case 2:
                                        WriteLine("2.init accessor");
                                        WriteLine("Selected");
                                        InitOnlyType iot = new InitOnlyType();


                                        break;
                                case 3:
                                        WriteLine("3.최상위 프로그램 (Top-level Program)");
                                        WriteLine("Selected");

                                        WriteLine("이제 파이썬처럼 main에서 시작할 필요가 없다. 그런데 하나의 파일에서만 가능하다");
                                        WriteLine("그러면 명령인자(프로그램 시작시 넣고 시작하는 값)는 어떻게 할까?");
                                        WriteLine(@"
// 프로그래명이 test.exe 일 때
//   test.exe 100 200
// 와 같이 호출한다고 가정
int a = int.Parse(args[0]); // 100
int b = int.Parse(args[1]); // 200

// 로컬함수 사용
int c = Calculate(a, b);
System.Console.WriteLine(c);

// 로컬함수 정의
int Calculate(int x, int y)
{
    int k = x + y;
    return k;
}

");

                                        break;
                                case 4:
                                        WriteLine("4.향상된 패턴 매칭 (Pattern matching)");
                                        WriteLine("Selected");

                                        PatternMattching pm = new PatternMattching();

                                        break;
                                case 5:
                                        WriteLine("5.향상된 타겟 타이핑 (Target typing)");
                                        WriteLine("Selected");

                                        TargetTypeing tt = new();

                                        break;
                                case 6:
                                        WriteLine("6.공변 리턴 타입 (Covariant return type)");
                                        WriteLine("Selected");

                                        CovariantReturnType crt = new();
                                        break;
                                case 7:
                                        WriteLine("7.Native Int 타입 (nint, nuint)");
                                        WriteLine("Selected");

                                        NativeIntType nit = new();
                                        break;

                        }

                }
        }
        
}
