using System;
using System.Diagnostics;

namespace UseListReturnApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch _stopwatch = new Stopwatch();
            UseListReturnRepository _ListReturn = new UseListReturnRepository();

            int _rowCount = 0;

            _stopwatch.Start();
            foreach (var item in _ListReturn.GetItems())
            {
                _rowCount = _rowCount + 1;
                var _rowguid = item.rowguid;
            }
            _stopwatch.Stop();

            Console.WriteLine($"total count: {_rowCount}\telapsed: {_stopwatch.Elapsed}");
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }

}
