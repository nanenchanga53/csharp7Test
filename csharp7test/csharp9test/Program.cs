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

                                        break;
                                case 4:
                                        WriteLine("4.향상된 패턴 매칭 (Pattern matching)");
                                        WriteLine("Selected");

                                        break;
                                case 5:
                                        WriteLine("5.향상된 타겟 타이핑 (Target typing)");
                                        WriteLine("Selected");

                                        break;
                                case 6:
                                        WriteLine("6.공변 리턴 타입 (Covariant return type)");
                                        WriteLine("Selected");

                                        break;

                        }

                }
        }
        
}
