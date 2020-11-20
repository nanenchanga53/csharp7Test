using System;
namespace csharp9test
{
        public class NativeIntType
        {
                public NativeIntType()
                {
                        Console.WriteLine(@"
Native Int란 플랫폼에 따라 다른 크기를 갖는 정수를 말하는데, 
예를 들어 32비트 플랫폼에서는 32비트 정수가 되고, 
64비트 플랫폼에서는 64비트 정수가 된다. 
C# 9에서 Native Int를 지원하기 위해 nint와 nuint 라는 새로운 키워드를 도입하였다. 
nint는 부호(sign)를 갖는 Native Int 타입이고, 
nuint는 unsigned int 타입의 Native Int 타입을 가리킨다. 
Native Int는 주로 Unmanaged 코드와의 연동이나 저수준 라이브러리에서 유용하게 사용될 수 있다.

//(1) 32bit로 컴파일되었을 때 4바이트 정수
nint a = 100;

//(2) 64bit로 컴파일되었을 때 8바이트 정수
nint b = 100;


플랫폼에 따라 다른 크기의 정수를 가졌던 것으로 기존에 System.IntPtr과 System.UIntPtr 들이 있었는데, 
이들은 주로 포인터나 핸들을 담는 용도로 사용되었으며, 
간단한 포인터 주소 연산이나 동일성(Equals) 비교 등의 제한된 기능만을 가지고 있었다. 
C# 9의 Native Int 타입인 nint, nuint은 기본적으로 System.IntPtr, System.UIntPtr 타입에 기초한 것으로, 
컴파일러가 보다 다양한 연산이나 크기 비교 연산 등을 지원한 것이다.

static void Main(string[] args)
{
    nint a = 5;
    int b = 10;

    nint c = a + b;
    Console.WriteLine(typeof(nint)); // System.IntPtr

    long d = 15;
    if (a < d)
    {
        Console.WriteLine(a + d); // 20
    }
}
");

                        nint a = 5;
                        int b = 10;

                        nint c = a + b;
                        Console.WriteLine(typeof(nint)); // System.IntPtr

                        long d = 15;
                        if (a < d)
                        {
                                Console.WriteLine(a + d); // 20
                        }



                }
        }
}