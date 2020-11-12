using System;
using System.Runtime.InteropServices;

namespace csharp9test
{
        internal class PatternMattching
        {
                public PatternMattching()
                {
                        RelationalPattern();
                        LogicalPattern();
                        SimpleTypePattern();
                }

                private void SimpleTypePattern()
                {
                        Console.WriteLine(@"
switch 식에서 흔히 사용하지 않는 변수를 밑줄(_)로 표시하는데, 
기존에는 이 밑줄(discard parameter라고 불리움)을 생략할 수 없었다. 
C# 9에서는 어떤 타입의 변수를 사용하지 않는다면, 
밑줄을 생략할 수 있게 되었다. 
아래 예제에서 기존에는 Animal _ 을 사용하였지만, C# 9에서는 _ 을 생략할 수 있다.

void Check(Animal animal)
{
    string name = animal switch
    {
        Dog d => 'Dog',
        Cat c => 'Cat',
        //Animal _ => "" 
        Animal => ''
    };
        }
");
                        object animal =  new object();
                        Console.WriteLine(Check(animal));

                        string Check(object animal)
                        {
                                string name = animal switch
                                {
                                        int d => "Dog",
                                        char c => "Cat",
                                        //object _ => "" 
                                        object => "Null"
                                };

                                return name;
                        }
                }


                private void LogicalPattern()
                {
                                Console.WriteLine(@"
C# 9에서는 switch 식에서 and, or, not 등과 같은 논리 연산자를 사용할 수 있는 기능이 추가되었는데, 
관계 연산자와 논리 연산자는 혼합하여 사용할 수 있다.
아래 예제(A)는 category의 값에 따라 다른 숫자를 리턴하는 메서드인데, 
조건식에 and, not, or 같은 논리 연산자를 사용하고 있다.

// 예제(A) 논리 패턴
static int GetValue(int category)
{
    int val = category switch
    {
        0 or 1 => 101,
        > 1 and < 10 => 201,
        not 100 => 301,
        _ => 401
    };

    return val;
}

// 예제(B) not
void Check(Animal a)
{ 
    // if (!(a is Dog)) :기존방식
    if (a is not Dog)   :C# 9
    {
        //... 
    }
}

");

                                Console.WriteLine(GetValue(9));
                                Console.WriteLine(Check('3'));

                                // 예제(A) 논리 패턴
                                static int GetValue(int category)
                                {
                                        int val = category switch
                                        {
                                                0 or 1 => 101,
                                                > 1 and < 10 => 201,
                                                not 100 => 301,
                                                _ => 401
                                        };

                                        return val;
                                }

                                // 예제(B) not
                                bool Check(object a)
                                {
                                        // if (!(a is Dog)) :기존방식
                                        if (a is not int)   //:C# 9
                                        {
                                                return false;
                                        }
                                        else
                                                return true;
                                }
                }
                

                private void RelationalPattern()
                {
                        Console.WriteLine(@"
C# 9에서는 switch 식에서 >, <, >=, <=; 등과 같은 관계 연산자를 사용할 수 있는 기능이 추가되었다. 
아래 예제에서 GetGrade() 메서드의 switch 식은 score의 범위에 따라 A-F 학점을 리턴하고 있다. 
여기서 각 점수의 범위를 부등식을 사용하여 지정하고 있는데, 이것이 관계 연산자 패턴이다.");

                        


                        Console.WriteLine(@"
char g = GetGrade(75);
Console.WriteLine(g);

static char GetGrade(int score)
{
        // 관계 패턴
        char gr = score switch
        {
                >= 90 => 'A',
                >= 80 => 'B',
                >= 70 => 'C',
                >= 60 => 'D',
                _ => 'F'
        };

        return gr;
}");

                        char g = GetGrade(75);
                        Console.WriteLine(g);

                        static char GetGrade(int score)
                        {
                                // 관계 패턴
                                char gr = score switch
                                {
                                        >= 90 => 'A',
                                        >= 80 => 'B',
                                        >= 70 => 'C',
                                        >= 60 => 'D',
                                        _ => 'F'
                                };

                                return gr;
                        }
                }                

                

                
        }
}