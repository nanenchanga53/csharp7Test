﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace csharp7test
{
    class Program
    {
        static void Main(string[] args)
        {
            NewOut(); //out의 편의성이 높아졌다 미리 정의된 변수에 out안에 넘겨야했던게 받아온 곳에서 바로 선언해 사용 가능하다.
            OldRef();//배열의 특정 요소의 값을 바꾸러면 배열 인스턴스 자체를 넘겨주거나(이거) 원하는 배열 요소만을 바꿀 수 있는 매서드를 정의해야했다
            NewRef();//ref return을 사용하면 원하는 요소의 참조만 반환하는 것이 가능하다
            MethodRef(); //메서드 값에 값을 대입가능
            
        }

        private static void MethodRef()
        {
            MyMatrix matrix = new MyMatrix();
            matrix.Put(0, 0) = 1;
            int result = matrix.Put(1, 1) = 100;
            WriteLine($"메서드 값(0,0) : {matrix.Put(0,0)}");
        }

        private static void NewRef()
        {
            NewIntList intlist = new NewIntList();
            ref int item = ref intlist.GetFirstItem();
            intlist.Print();
        }



        private static void OldRef()
        {
            OldIntList intList = new OldIntList();
            int[] list = intList.GetList();
            list[0] = 5;

            
            intList.Print();
        }

        private static void NewOut()
        {
            int.TryParse("5", out int _); //out쪽을 생략할 수 있음 ㄷㄷ
            int.TryParse("5", out int result); //미리 result 를 지정해두지 않아도 바로 불러와 쓸수있음

            int a = 5;
            ref int b = ref a;  //같은 메모리영역을 갖는다 참조하는 주소값을 따로 갖지않는다!
        }
    }




}
