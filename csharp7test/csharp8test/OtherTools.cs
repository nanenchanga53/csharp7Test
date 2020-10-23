using System;

namespace csharp8test
{
        public class OtherTools
        {
                public OtherTools()
                {
                        Console.WriteLine("정적로컬 함수와 string에서 $,@순서를 마음대로 해도 되는게 늘었다.");

                        Console.WriteLine(@"
                        private void Run2()
                        {
                                double r = 1.0;
                                PrintArea(r);

                                // static local function
                                static void PrintArea(double radius)
                                {
                                        // 외부 변수 사용 못하고
                                        // 입력 파라미터 사용
                                        var area = Math.PI * radius * radius;
                                        Console.WriteLine('Run2');
                                        Console.WriteLine(area);
                                }

                                PrintArea(2.0);
                        }
                        ");

                        Run2();

                        Console.WriteLine(@"
                        string GetDataFile(string path)
                        {
                                string s = $@'{ path}\data.csv'; // 사용가능
                                s = @$'{path}\data.csv';        // 사용가능
                                return s;
                        }

                        ");
                        Console.WriteLine(GetDataFile("aasdfas"));
                }

                #region 정적 로컬 함수
                //C# 8.0 이전에 로컬 함수는 비정적(non-static) 함수이어야 했으며, 
                //로컬변수는 자신을 둘러싼 상위 범위 안(enclosing scope)에 있는 변수들을 엑세스 할 수 있었다. 
                //C# 8.0에서는 정적 로컬 함수(static local function)을 허용하고 있으며, 
                //정적 로컬 함수는 함수 밖의 변수를 사용할 수 없으며, 정적 로컬 함수로 전달된 파라미터만을 사용할 수 있다.

                /// <summary>
                /// 기존방식
                /// </summary>
                private void Run1()
                {
                        double r = 1.0;
                        PrintArea();

                        // non-static local function
                        void PrintArea()
                        {
                                // 외부의 r 변수를 사용
                                var area = Math.PI * r * r;
                                Console.WriteLine("Run1");
                                Console.WriteLine(area);
                        }

                        r = 2.0;
                        PrintArea();
                }

                /// <summary>
                /// 새로운 방식
                /// </summary>
                private void Run2()
                {
                        double r = 1.0;
                        PrintArea(r);

                        // static local function
                        static void PrintArea(double radius)
                        {
                                // 외부 변수 사용 못하고
                                // 입력 파라미터 사용
                                var area = Math.PI * radius * radius;
                                Console.WriteLine("Run2");
                                Console.WriteLine(area);
                        }

                        PrintArea(2.0);
                }
                #endregion

                #region 문자열 $,@
                string GetDataFile(string path)
                {
                        string s = $@"{path}\data.csv"; // 사용가능
                        s = @$"{path}\data.csv";        // 사용가능
                        return s;
                }
                #endregion
        }
}