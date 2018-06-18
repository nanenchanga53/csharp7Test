namespace csharp7test
{
    internal class MyMatrix
    {
        int[,] _matrix = new int[100, 100];

        public ref int Put(int column, int row)
        {
            return ref _matrix[column, row];
            // 지역 변수를 return ref로 반환해서는 안 된다. 지역 변수의 유혀 범위가 스택 상에 있을 때로 한정되기때문 해제될 수 있다
        }
    }
}