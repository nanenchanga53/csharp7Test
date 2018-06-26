using System;
using System.Collections;
using System.Net;
using System.Text;
using static System.Console;

namespace csharp7test
{
    internal class UseNewPattern
    {
        public UseNewPattern()
        {
            newIs();
            newSwitch();
        }

        //switch문에 when 을 넣어서 추가 조건을 지정 가능하게 되었다. : case int i when i > 300 // int 타입이고 그 값이 300보다 큰 경우
        private void newSwitch()
        {
            string text = "한글입력기";
            switch (text)
            {
                case var item when (ContainsAt(item, "https://www.naver.com/")):
                    WriteLine("In Naver");
                    break;

                case var item when (ContainsAt(item, "http://www.daum.net")):
                    WriteLine("In daum");
                    break;

                default:
                    WriteLine("None");
                    break;

            }
        }

        private static bool ContainsAt(string item, string url)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string text = wc.DownloadString(url);

            return text.IndexOf(item) != -1;
        
        }

        // 변환 여부만 알 수 있었던 is에 변환결과를 포함할 수 있게 되었다. (as 가 가지고 있었던것)
        private void newIs()
        {
            object[] objList = new object[] { 100, null, DateTime.Now, new ArrayList() };

            foreach (object item in objList)
            {
                if(item is 100) // 상수 패턴
                {
                    Console.WriteLine(item);
                }
                else if(item is null) // 상수 패턴
                {
                    Console.WriteLine("null");
                }

                else if (item is DateTime dt) // 타입 패턴 (값 형식)
                {
                    WriteLine(dt);
                }
                else if(item is ArrayList arr) // 타입 패턴(참조 형식)
                {
                    WriteLine(arr.Count);
                }
            }
        }
    }
}