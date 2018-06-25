using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace csharp7test
{
    internal class UseNewAsync
    {
        public UseNewAsync()
        {
            //Oldasync(); //기존에는 동기 방식으로 돌아가는 메소드도 Task 객체를 생성했었다.
            NewAsync();  //ValueTask<T>는 비동기 방식때는 Task 객체를 생성해서 return 하지 않는다.
            
        }

        static Task<string> ReadAllTextAsync(string filePath)
        {
            return Task.Factory.StartNew(() =>
            {
                return File.ReadAllText(filePath);
            }
            );
        }

        #region ValueTask로 변환
        private void NewAsync()
        {
            ValueTask<(string, int tid)> result = NewFileReadAsync(@"C:\windows\system32\drivers\etc\HOSTS");

            int tid = Thread.CurrentThread.ManagedThreadId;
            WriteLine($"MainThreadID: {tid}, AsyncThreadID: {result.Result.tid}");

            result = NewFileReadAsync(@"C:\windows\system32\drivers\etc\HOSTS");
            tid = Thread.CurrentThread.ManagedThreadId;

            WriteLine($"MainThreadID: {tid}, AsyncThreadID: {result.Result.tid}");
        }
        //ValueTask<T> 타입은 async 메서드 내에 동기 처리와 비동기 처리가 혼합되어 있을 때 유용하다.
        private static async ValueTask<(string, int tid)> NewFileReadAsync(string filePath)
        {
            if(string.IsNullOrEmpty(_fileContents) == false)
            {
                return (_fileContents, Thread.CurrentThread.ManagedThreadId);
            }

            _fileContents = await ReadAllTextAsync(filePath);
            return (_fileContents, Thread.CurrentThread.ManagedThreadId);
        }
        #endregion

        #region 이전 aync 매서드에서 값을 반환하는 매서드
        private void Oldasync()
        {
            Task<(string, int tid)> result = FileReadAsync(@"C:\Windows\system32\drivers\etc\HOSTS");
            int tid = Thread.CurrentThread.ManagedThreadId;
            WriteLine($"MainThreadID: {tid}, AsyncThreadID: {result.Result.tid}");
            result = FileReadAsync(@"C:\Windows\system32\drivers\etc\HOSTS");
            tid = Thread.CurrentThread.ManagedThreadId;
            WriteLine($"MainThreadID: {tid}, AsyncThreadID: {result.Result.tid}");
        }

        

        static string _fileContents = string.Empty;

        //첫번째로 호출한 경우에는 await의 호출로 비동기 처리되지만 두번째 호출부터는 동기 방식으로 호출을 완료한다. 그래도 Task<T> 객체가 생성
        private static async Task<(string, int)> FileReadAsync(string filePath)
        {
            if(string.IsNullOrEmpty(_fileContents) == false)
            {
                return (_fileContents, Thread.CurrentThread.ManagedThreadId);
            }

            _fileContents = await ReadAllTextAsync(filePath);
            return (_fileContents, Thread.CurrentThread.ManagedThreadId);
        }
    }
#endregion
}