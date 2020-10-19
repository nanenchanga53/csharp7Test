using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace csharp8test
{
        public class AsyncStream
        {
                public AsyncStream()
                {
                        Console.WriteLine(@"C# 5.0에서 소개된 async/await는 비동기적인 방식으로 결과를 리턴받는 기능을 쉽게 구현하도록 하였다. 
이러한 async/await 기능은 결과를 한번 리턴받는 기능으로서, 
연속적으로 여러 결과들을 가져오지는 않았다. 
하지만, 요즘 클라우드나 IoT와 같은 데이타 소스에서 스트림을 연속적으로 가져오는 경우가 있는데, 
이에 C# 8.0에서는 비동기적으로 여러 개의 연속적인 결과 스트림을 가져올 수 있는 기능을 추가하게 되었다.

C# 8.0에서 여러 결과를 비동기적으로 리턴하기 위해 IAsyncEnumerable<T> 인터페이스를 추가하였으며, 
비동기 결과들을 비동기적으로 받기위해서 await foreach 라는 키워드를 도입하였다. 
즉, foreach 앞에 await를 쓰면, 비동기적으로 결과들을 가져와 처리할 수 있게 한 것이다.

아래 예제에서 Device.GetTemperatures() 메서드는 연속적인 스트림 데이타를 비동기로 전달하는 메서드로서 디바이스에서 온도를 가져와서 온도 변화가 있을 때만 
결과를 리턴하게 된다. 
무제한으로 결과를 리턴할 수 있지만, 
여기 예제에서는 100개의 데이타만 리턴하도록 하였다. 
다음 TempTest() 메서드에서는 GetTemperatures() 메서드를 호출하여 비동기로 결과를 받아와서 출력하게 되는데, 
여기서 foreach 앞에 await가 있는 점에 주목해야 한다. 
즉, IAsyncEnumerable 을 사용하여 비동기 스트림 데이타를 받아오기 위해서는 await foreach를 사용해야 한다.
");

                        Console.WriteLine(@"
                        class Device
                        {
                            private int lastTemp = 0;

                            public async IAsyncEnumerable<int> GetTemperatures()
                            {
                                for(int i=0; i<100; i++)
                                {
                                    int currTemp = await GetTempFromDevice();
                                    if (currTemp != lastTemp)
                                    {
                                        lastTemp = currTemp;
                                        yield return lastTemp;
                                    }
                                }
                            }

                            // private async Task<int> GetTempFromDevice() {...}
                        }


                        static void Main(string[] args)
                        {
                            TempTest().Wait();
                        }

                        static async Task TempTest()
                        {
                            var dev = new Device();
                            await foreach (var temp in dev.GetTemperatures()) //foreach로 검색가능한거에 주목
                            {
                                Console.WriteLine($'{ DateTime.Now}: { temp}');
                            }
                        }

");

                        TempTest().Wait(); //TempTest Task 가 종료될때까지 기다림
                }


                static async Task TempTest()
                {
                        var dev = new Device();
                        await foreach (var temp in dev.GetTemperatures()) //GetTempertures에서 100개의 연속적인 값을 가져오게 만들었다 그러니 foreach 가 가능
                        {
                                Console.WriteLine($"{DateTime.Now}: {temp}");
                        }
                }
        }

        class Device
        {
                private int lastTemp = 0;

                //아래 IAsyncEnumerable이 이번 새로운 기능이다 이전까지는 yield같이 여러 값을 연속적으로 반환하는 것을 사용하지 못했는데 이제 가능하다
                public async IAsyncEnumerable<int> GetTemperatures()
                {
                        for (int i = 0; i < 100; i++)
                        {
                                int currTemp = await GetTempFromDevice();
                                if (currTemp != lastTemp)
                                {
                                        lastTemp = currTemp;
                                        yield return lastTemp;
                                }
                        }
                }

                /// <summary>
                /// 기기에서 온도를 가져온다라고 가정하자
                /// </summary>
                /// <returns></returns>
                private async Task<int> GetTempFromDevice()
                {
                        int temp;
                        Random r = new Random();
                        await Task.Delay(1);//기기에서 응답을 기다린다 
                        temp = r.Next(1, 100);// 기기에서 응답받은 온도를 가져올것이다
                        return temp; 
                }


                // private async Task<int> GetTempFromDevice() {...}
        }
}
