using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8test
{
        public class NullCoalescingAssignment
        {
                public NullCoalescingAssignment()
                {
                        //C# 6.0에서 ?하고 ?? 연산자가 있던것을 기억하자
                        //C# 8.0에서 NULL 병합 할당 연산자 ??= 이 도입되었는데, 
                        //??= 연산자 앞의 변수가 NULL 일 경우 뒤에 오는 피연산자의 값을 가져와 앞의 변수에 할당하게 된다.

                        Console.WriteLine(@"
/C# 8.0에서 NULL 병합 할당 연산자 ??= 이 도입되었는데, 
//??= 연산자 앞의 변수가 NULL 일 경우 뒤에 오는 피연산자의 값을 가져와 앞의 변수에 할당하게 된다.
//아래처럼 사용하던것을
                        if (list == null)
                        {
                           list = new List<int>();
                        }

//아래처럼 사용되도록 변경할 수 있게 됬다.
//C# 8.0에서 도입된 널 병합 할당자 (Null Coalescing Assignment Operator)는 
//위와 같은 코드를 더욱 간결하게 ??= 연산자를 써서 표현할 수 있게 한 것이다.
//아래 예제는 입력 파라미터들의 값이 NULL 인 경우 널 병합 할당자를 사용하여 
//객체를 초기화하거나 디폴트 값을 할당하는 것을 예시한 것이다.

                        static List<int> AddData(List<int> list, int? a, int? b)
                        {
                            // 널 병합 연산자
                            list ??= new List<int>();
                            list.Add(a ??= 1);
                            list.Add(b ??= 2);

                            return list;
                        }
");
                        List<int> l1 = AddData(null, null, null); //l1 = {1,2}
                        List<int> l2 = AddData(null, null, 10);  //l2 = {1, 10}

                        //널 병합 연산자(??)는 앞의 값이 NULL일 경우 뒤의 값을 리턴하는 기능이고, 
                        //널 병합 할당 연산자(??=)는 앞의 값이 NULL일 경우 뒤의 값을 앞의 피연산자 변수에 할당하는 기능이다.
                        WatDiffrent();

                        Console.WriteLine(@"
//널 병합 연산자(??)는 앞의 값이 NULL일 경우 뒤의 값을 리턴하는 기능이고, 
//널 병합 할당 연산자(??=)는 앞의 값이 NULL일 경우 뒤의 값을 앞의 피연산자 변수에 할당하는 기능이다.

                        int? a = null;
                        // (1) 널 병합 연산자
                        int b = a ?? 1;
                        // 위 문장 실행후: a = null, b = 1


                        // (2) 널 병합 할당 연산자
                        a ??= 100;
                        // 위 문장 실행후: a = 100
");

                }

                private void WatDiffrent()
                {
                        int? a = null;
                        // (1) 널 병합 연산자
                        int b = a ?? 1;
                        // 위 문장 실행후: a = null, b = 1


                        // (2) 널 병합 할당 연산자
                        a ??= 100;
                        // 위 문장 실행후: a = 100
                }

                //C# 8.0에서 도입된 널 병합 할당자 (Null Coalescing Assignment Operator)는 위와 
                //같은 코드를 더욱 간결하게 ??= 연산자를 써서 표현할 수 있게 한 것이다. 
                //아래 예제는 입력 파라미터들의 값이 NULL 인 경우 널 병합 할당자를 사용하여 객체를 초기화하거나 
                //디폴트 값을 할당하는 것을 예시한 것이다.
                static List<int> AddData(List<int> list, int? a, int? b)
                {
                        // 널 병합 연산자
                        list ??= new List<int>();
                        list.Add(a ??= 1);
                        list.Add(b ??= 2);

                        return list;
                }


        }
}
