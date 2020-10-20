using System;
using static System.Console;
using static System.Convert;

namespace csharp8test
{
        class Program
        {
                static void Main(string[] args)
                {
                        WriteLine("새 기능들 리스트 중 하나를 고르시오(참조사이트 http://www.csharpstudy.com/latest/CS-new-features.aspx)");
                        WriteLine("C# 8.0을 사용하기 위해서는 Visual Studio 2019과 .NET Core 3.0이상 필요");
                        WriteLine("---------------------------------------------------------------------------------------------------------");
                        WriteLine("1.디폴트 인터페이스 멤버 (Default Inteface Members)");
                        WriteLine("2.향상된 패턴 매칭 기능 (Pattern Matching)");
                        WriteLine("3.Nullable Reference Type");
                        WriteLine("4.인덱싱과 슬라이싱 (Indexing / Slicing)");
                        WriteLine("5.비동기 스트림 (Async Stream)");
                        WriteLine("6.using 선언");
                        WriteLine("7.널 병합 할당 연산자 (Null-coalescing assignment)");
                        WriteLine("8.구조체(struct) 읽기 전용 멤버");
                        WriteLine("9.기타 기능들");

                        int selectedNum = ToInt32(ReadLine());

                        switch (selectedNum)
                        {
                                case 1:
                                        WriteLine("1.디폴트 인터페이스 멤버 (Default Inteface Members)");
                                        WriteLine("Selected");

                                        DefaultInterfaceMembers dim = new DefaultInterfaceMembers();

                                        break;
                                case 2:
                                        WriteLine("2.향상된 패턴 매칭 기능 (Pattern Matching)");
                                        WriteLine("Selected");

                                        PatternMatching ptm = new PatternMatching();

                                        break;
                                case 3:
                                        WriteLine("3.Nullable Reference Type");
                                        WriteLine("Selected");
                                        NullableReferenceType nrt = new NullableReferenceType();

                                        break;
                                case 4:
                                        WriteLine("4.인덱싱과 슬라이싱 (Indexing / Slicing)");
                                        WriteLine("Selected");

                                        IndexingAndSlicing ias = new IndexingAndSlicing();

                                        break;
                                case 5:
                                        WriteLine("5.비동기 스트림 (Async Stream)");
                                        WriteLine("Selected");

                                        AsyncStream ast = new AsyncStream();

                                        break;
                                case 6:
                                        WriteLine("6.using 선언");
                                        WriteLine("Selected");

                                        NewUsing nu = new NewUsing();
                                        break;
                                case 7:
                                        WriteLine("7.널 병합 할당 연산자 (Null-coalescing assignment)");
                                        WriteLine("Selected");

                                        NullCoalescingAssignment nca = new NullCoalescingAssignment();

                                        break;
                                case 8:
                                        WriteLine("8.구조체(struct) 읽기 전용 멤버");
                                        WriteLine("Selected");

                                        break;
                                case 9:
                                        WriteLine("9.기타 기능들");
                                        WriteLine("Selected");

                                        break;

                        }


                }
        }
}
