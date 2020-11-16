using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using static System.Console;

namespace csharp9test
{
        public class TargetTypeing
        {
                // 필드에서 new() 사용할 때 유용
                private Dictionary<string, string> hash = new();

                public TargetTypeing()
                {
                        WhatNew();
                        WhatTargetTyping();
                        
                }

                

                private void WhatNew()
                {
                        WriteLine(@"
new Employee() 대신 new() 를 사용하면, 컴파일러는 그 타입이 Employee인 것을 전후 맥락을 통해 추론하게 된다.

public class Employee { }

class Program
{
    // 필드에서 new() 사용할 때 유용
    private Dictionary<string, string> hash = new();

    static void Main(string[] args)
    {
        // var 사용
        var a = new Employee();
            
        // new() 사용
        Employee b = new();
    }
}
");

                        // var 사용
                        var a = new Employee();

                        // new() 사용
                        Employee b = new();
                }

                public class EmployeeTT { }
                public class FulltimeTT : EmployeeTT { }
                public class ParttimeTT: EmployeeTT { }


                [STAThread]
                private void WhatTargetTyping()
                {
                        WriteLine(@"
C# 9에서 ? : 조건연산자를 사용할 때, 
공유되는 타입이 있다면 조건연산자 안에서 사용할 수 있게 되었다. 
예를 들어, 아래 예제에서 Fulltime, Parttime 클래스는 Employee 클래스로부터 파생된 클래스인데, 
? : 조건연산자에서 파생클래스가 Base 클래스 타입을 공유하기 때문에 이러한 표현을 사용할 수 있게 되었다.
이는 int? 타입에서 0 혹은 null을 리턴하는 것도 동일한 맥락이다.


public class Employee { }
public class Fulltime : Employee { }
public class Parttime : Employee { }

static class Program
{
    [STAThread]
    static void Main()
    {
        Fulltime fte = null;
        Parttime part = new Parttime();
        bool ok = true;

        // Base 타입 공유
        Employee emp = ok ? fte : part;

        // nullable value type
        int? i = ok ? 0 : null;
    }
}
");

                        FulltimeTT fte = null;
                        ParttimeTT part = new ParttimeTT();
                        bool ok = true;

                        // Base 타입 공유
                        EmployeeTT emp = ok ? fte : part;

                        // nullable value type
                        int? i = ok ? 0 : null;
                }
        }

}