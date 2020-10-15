using System;
using System.Collections.Generic;
using System.Text;

namespace csharp8test
{
        public class NullableReferenceType
        {
                //C# 8.0 에서는 Reference 타입에 NULL을 할당하면 컴파일러가 경고(Warning)를 주는 기능을 추가하였다.
                //즉, C# 8.0에서 (특별한 옵션을 설정하면) Reference 타입은 기본적으로 NULL을 넣을 수 없는 Non-nullable Reference Type이 되고, 
                //NULL을 허용하기 위해서는 string? 와 같이 레퍼런스 타입 뒤에 물음표(?)를 붙여 Nullable Reference Type임을 표시하게 된다
                public NullableReferenceType()
                {
                        Console.WriteLine(@"
                        C# 프로젝트 파일(*.csproj)에서 <Nullable>enable</Nullable> 을 
                        /Project/PropertyGroup 안에 넣으면, 프로젝트 레벨에서 Nullable Reference Type 기능을 사용하게 된다. 
                        또한, 소스 파일의 첫 라인에 #nullable enable 을 사용하면 파일 레벨에서 Nullable Reference Type 기능을 사용하게 된다. 
                        마찬가지로 소스 코드 중간에 #nullable enable을 넣으면 그 다음 라인부터 Nullable Reference 기능이 활성화 되고, 
                        #nullable disable을 넣으면 그 다음 라인부터 이 기능이 비활성화 된다.
                        ");

                        NoUseNullableReferenceType();
                        Console.WriteLine(@"
                        private void NoUseNullableReferenceType()
                        {
                                #nullable enable
                                string s1 = null; // Warning: Converting null literal or 
                                                  // possible null value to non-nullable type
                                if (s1 == null) return;

                                string? s2 = null;
                                if (s2 == null) return;

                                #nullable disable
                                string s3 = null; // No Warning
                                if (s3 == null) return;
                        }");


                        Console.WriteLine(@"
                        Nullable Reference Type은 기존 Reference Type 뒤에 물음표를 붙여 표시한다. 
                        예를 들어, string은 Non-nullable Reference Type이며, 
                        string? 은 Nullable Reference Type임을 표시한다. 
                        Nullable Reference Type의 변수를 사용할 때는 항상 먼저 NULL 인지를 체크해야 하며, 
                        만약 그렇지 않으면 컴파일러가 경고(Warning) 메시지를 표시한다");

                        Console.WriteLine(@"
                        private void UseNullableReferenceType(string? s)
                        {
                                Console.WriteLine(s.Length); // Warning: Dereference of a possibly null reference

                                if (s != null)
                                {
                                        Console.WriteLine(s);
                                }
                                else
                                {
                                        Console.WriteLine('Null값');
                                }
                        }");
                        UseNullableReferenceType(null);
                        UseNullableReferenceType("null이 아닌 값");
                }

                /// <summary>
                /// 널값이면 Warning을 방생하는 설정과 사용하지 않는 설정을 보자
                /// </summary>
                private void NoUseNullableReferenceType()
                {
                        #nullable enable
                        string s1 = null; // Warning: Converting null literal or 
                                          // possible null value to non-nullable type
                        if (s1 == null) return;

                        string? s2 = null;
                        if (s2 == null) return;

                        #nullable disable
                        string s3 = null; // No Warning
                        if (s3 == null) return;
                }

                #nullable enable
                /// <summary>
                /// Null값을 받아올 수 있는 설정이면 앞에 ?를 붙인다
                /// </summary>
                /// <param name="s"></param>
                private void UseNullableReferenceType(string? s)
                {
                        Console.WriteLine(s.Length); // Warning: Dereference of a possibly null reference

                        if (s != null)
                        {
                                Console.WriteLine(s);
                        }
                        else
                        {
                                Console.WriteLine("Null값");
                        }
                }
        }
}
