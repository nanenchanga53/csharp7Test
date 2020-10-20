using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp8test
{
        public class NewUsing
        {
                public NewUsing()
                {
                        Console.WriteLine(@"
using 선언은 using 키워드 뒤에 오는 변수 선언으로서,
using 뒤에 있는 변수가 using을 둘러싼 범위를 벗어날 경우 Dispose 하도록 컴파일러에게 지시하게 된다. 
기존의 using문을 사용할 경우 괄호 {...} 를 표시해야 했는데, 
using 블럭 전체를 들여쓰기 해야 하는 불편함이 있었다. 
using 선언은 (별도의 괄호를 메서드 내부에 사용하지 않는 한) 
통상 메서드가 끝날 때 Dispose() 를 자동 호출하게 해 준다. 
물론 경우에 따라 긴 메서드 안에 특정 부분에서만 using을 사용하고 빨리 Dispose() 해 주어야 한다면, 
기존의 using문을 사용할 수 있다.

");

                        Console.WriteLine(@"
                // C# 8.0
                private void GetDataCS8()
                { 
                        using var reader = new StreamReader('src.txt');
                        string data = reader.ReadToEnd();
                        Debug.WriteLine(data);

                        // 여기서 Dispose() 호출됨
                }

                // C# 모든 버전
                private void GetData()
                {
                        using (var reader = new StreamReader('src.txt'))
                        {
                                string data = reader.ReadToEnd();
                                Debug.WriteLine(data);
                        }  // 여기서 Dispose() 호출됨

                        // ...
                        Debug.WriteLine('...');
                }
");

                        GetData();
                        GetDataCS8();

                }


                // C# 8.0
                private void GetDataCS8()
                {
                        
                        using var reader = new StreamReader("src.txt");
                        Console.WriteLine("c# 8.0");
                        string data = reader.ReadToEnd();
                        Console.WriteLine(data);

                        // 여기서 Dispose() 호출됨
                }

                // C# 모든 버전
                private void GetData()
                {
                        
                        using (var reader = new StreamReader("src.txt"))
                        {
                                Console.WriteLine("c# All version");
                                string data = reader.ReadToEnd();
                                Console.WriteLine(data);
                        }  // 여기서 Dispose() 호출됨

                        // ...
                        Console.WriteLine("...");
                }
        }
}
