using System;

namespace csharp8test
{
        public class UnmanagedConstructedType
        {
                public UnmanagedConstructedType()
                {
                        Console.WriteLine("소스확인");
                }
                #region 아래는 C# 7.3에서 추가된 3가지 Type Contraint에 대한 예제이다.

                //C# 7.3에서 제네릭 타입(Generic Type)의 Type Contraint로 
                //System.Enum, System.Delegate, unmanaged 라는 3개의 새로운 Contraint를 추가하였다. 
                //이 중 "unmanaged" Type Contraint는 일부 로우레벨의 Interop 코드(unsafe code)를 개발할 때 유용한 것으로, 
                //"unmanaged" Type Contraint는 해당 타입 아규먼트 T가 Unmanaged Type임을 표시한다.
                //https://ccambo.blogspot.com/ 참조(interop에 관한 자료 간단히 말하면 dll을 변환할때 사용하기 좋은 것)

                //CLR에서 Unmanaged Type이란 직간접적으로 Reference 타입을 포함하지 않는 Value 타입을 가리킨다.
                //Unmanaged Type에는 단순한 primitive data type (Value 타입)을 비롯하여 
                //Reference 타입 필드를 내부적으로 포함하지 않는 구조체(struct) 등을 포함한다.
                //sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool 타입들
                //모든 enum 타입
                //모든 pointer 타입
                //Unmanaged Type들을 필드로 갖는 구조체(struct). 
                //(단, 8.0 이전에는 Constructed Type을 전혀 허용하지 않았으나, 
                //C# 8.0에서는 모든 필드가 Unmanaged Type인 Constructed Type 구조체는 허용하였음)

                //즉 object 나 배열, 리스트 등을 제외하면 거의 전부라고 생각하자

                // System.Enum Type Contraint
                public Array GetValues<T>() where T : struct, System.Enum
                {
                        return Enum.GetValues(typeof(T));
                }

                // System.Delegate Type Contraint
                public T Combine<T>(T a, T b) where T : Delegate
                {
                        return (T)Delegate.Combine(a, b);
                }

                // unmanaged Type Contraint
                public unsafe void RunUnmng<T>(T val) where T : unmanaged
                {
                        int size = sizeof(T);
                        T* a = &val;
                        //...
                }

                #endregion

                #region 아래는 unmanaged Type Contraint를 사용한 간단한 예제

                //C# 제네릭에서 타입 아규먼트(T)에 "unmanaged" Type Contraint를 사용하면, 
                //즉, 타입 T에 Unmanaged Type을 지정하면, 
                //해당 제네릭 클래스/메서드 안에서 Unsafe 
                //코드에서 사용할 수 있는 많은 기능들을 사용할 수 있다. 
                //예를 들어, 타입 T의 주소를 얻어 T* 포인터에 할당하거나, 
                //sizeof 연산자를 사용하여 타입 T 의 크기를 구할 수 있으며, 
                //stackalloc을 통해 타입 T의 배열을 스택에 할당할 수 있고, 
                //Heap 상에 타입 T의 배열을 할당하면서 fixed 문을 사용하여 고정(pin)하는 일 등등을 할 수 있다.

                //타입 T가 int (Unmanaged Type)인 경우를 예시한 것이다. 
                //만약 Type Contraint로서 unmanaged를 사용하지 않고 struct를 사용한다면, 
                //Unsafe Code에서 사용할 수 있는 기능들을 사용할 수 없게 되어 컴파일러는 
                //"Cannot take the address of, get the size of, or declare a pointer to a managed type (T)" 라는 에러를 내게 된다.

                unsafe void RunUnmng2<T>(T val) where T : unmanaged //unmanaged로 사용하면서 sizeof,포인터 등을 사용할 수 있다.
                {
                        // sizeof
                        int size = sizeof(T);
                        Console.WriteLine(size);

                        // pointer variable
                        T* a = &val;
                        Console.WriteLine(*a);

                        // stackalloc
                        T* arr = stackalloc T[10];

                        // pin heap allocation
                        fixed (T* p = new T[10])
                        {
                                // ...
                        }
                }

                void Run2()
                {
                        RunUnmng2<int>(100);
                }

                #endregion

                #region 

                //C# 제네릭 타입(Generic Type)으로부터 타입 아규먼트를 지정한 것을 Constructed Type이라 한다. 
                //예를 들어, Func<T, TResult>는 제네릭 타입이고, Func<int, double>은 Constructed Type이다.
                //C# 8.0에서 구조체(struct) 제네릭 타입으로부터 생성한 Constructed Type을 Unmanaged Type으로 허용하게 되었는데, 
                //이때 한가지 조건으로 해당 구조체의 모든 필드는 Unmanaged Type이어야 한다. 
                //아래 예제는 Coords<T> 제네릭 구조체로부터 Coords<int> 라는 Constructed Type을 생성한 후, 
                //C# 8.0에서 Unmanaged Type으로 사용한 것을 예시한 것이다. 
                //여기서 Coords<int>는 Unmanaged Type이므로, 
                //stackalloc이나 포인터 연산 등을 수행할 수 있게 된다. 
                //만약 Coords<int> 대신 Coords<object> 를 사용한다면, 
                //구조체의 필드가 Unmanaged Type이 아니기 때문에 
                //Coords<object>은 Unmanaged Type이 되지 못하여 아래 코드는 컴파일 에러를 내게 된다.
                //즉 이제는 제네릭 타입 T를 선언한 걸 이용해서도 여러가지 사용이 가능하게 해줬다는 것

                struct Coords<T>
                {
                        public T X;
                        public T Y;
                }

                unsafe void Run3()
                {
                        Coords<int>* c = stackalloc Coords<int>[10];
                        Span<Coords<int>> span = new Span<Coords<int>>(c, 10);

                        (*c).X = 1;  // Coords<int>[0]
                        (*c).Y = 1;
                        c++;
                        (*c).X = 2;  // Coords<int>[1]
                        (*c).Y = 2;

                        for (int i = 0; i < span.Length; i++)
                        {
                                Console.WriteLine(span[i].X);
                        }
                }
                #endregion
        }
}