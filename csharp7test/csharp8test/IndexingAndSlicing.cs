using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8test
{
        class IndexingAndSlicing
        {
                public IndexingAndSlicing()
                {
                                               

                        N1();
                        N2();

                }

                private void N2()
                {
                        Console.WriteLine(@"
System.Index와 ^ 연산자에 기반하여 시퀀스 인덱싱을 사용할 수 있고, 
System.Range와 .. 범위 연산자를 이용하여 시퀀스를 슬라이스(slice)하는 기능을 사용할 수 있다. 
아래 예제는 문자열 시퀀스를 인덱싱하고 슬라이싱하는 여러 방법들을 예시한 것이다.
여기서 주의해야할 점은 Python의 [1:4] 과 다르게 [1..4]는 [1..3]과 같다 즉 ..m은 m직전까지 검색하라는 뜻이다
                        string s = 'Hello World';

                        // 인덱싱
                        char ch1 = s[0];  // H
                        char ch1 = s[1];  // e
                        char ch2 = s[^1]; // d
                        char ch2 = s[^2]; // l

                        // 슬라이싱
                        var s1 = s[1..4];   // ell
                        var s2 = s[^5..^2]; // Wor
                        var s3 = s[..];  // Hello World
                        var s4 = s[..3]; // Hel
                        var s5 = s[3..]; // lo World

                        Range rng = 1..^0;
                        var s6 = s[rng];  // ello World
                        ");

                        string s = "Hello World";

                        // 인덱싱
                        char ch1 = s[0];  // H
                        char ch1_1 = s[1];  // e
                        char ch2 = s[^1]; // d
                        char ch2_1 = s[^2]; // l

                        // 슬라이싱
                        var s1 = s[1..4];   // ell
                        var s2 = s[^5..^2]; // Wor
                        var s3 = s[..];  // Hello World
                        var s4 = s[..3]; // Hel
                        var s5 = s[3..]; // lo World

                        Range rng = 1..^0;
                        var s6 = s[rng];  // ello World

                        Console.WriteLine($"s1 : {s1}");
                }

                private void N1()
                {
                        Console.WriteLine(@"
C# 8.0에서 새로 도입된 System.Index 구조체는 시퀀스의 시작 또는 끝으로부터 인덱싱을 표현하는데 사용된다. 
끝으로부터의 인덱싱을 위해서는 ^ 연산자를 사용하는데, 마지막 시퀀스 요소의 인덱스를 ^1 로 표시하고, 
끝에서 2번째는 ^2, 끝에서 3번째는 ^3 과 같이 표시한다.
                        string s = 'Hello World';
                        // System.Index
                        Index idx = ^2;
                        ch = s[idx]; // l
");

                        string s = "Hello World";

                        // System.Index
                        Index idx = ^2;
                        var ch = s[idx]; // l

                        Console.WriteLine($"ide : {idx}");
                        Console.WriteLine($"ch : {ch}");

                        Console.WriteLine(@"
System.Range 구조체는 시작 인덱스(Start 속성)와 마지막 인덱스(End 속성)를 함께 가지며 범위를 표현할 때 사용한다. 
Range에서 특히 주의할 점은 마지막 End 인덱스는 실제 범위의 마지막 다음 요소라는 점이다. 
즉, Range 가 1..4 이면 1부터 3까지만이 실제 범위가 된다.
                        // System.Range
                        Range r1 = 1..4;
                        string str1 = s[r1]; // ell
                        Index start = r1.Start;
                        bool b = start.IsFromEnd; // false
                        int v1 = start.Value;  // 1
                        int v2 = r1.End.Value; // 4
");

                        // System.Range
                        Range r1 = 1..4;
                        string str1 = s[r1]; // ell
                        Index start = r1.Start;
                        bool b = start.IsFromEnd; // false
                        int v1 = start.Value;  // 1
                        int v2 = r1.End.Value; // 4

                        Console.WriteLine($"str1 : {str1}");
                        Console.WriteLine($"b : {b}");
                        Console.WriteLine($"v1 : {v1}");
                        Console.WriteLine($"v2 : {v2}");
                }
        }
}
