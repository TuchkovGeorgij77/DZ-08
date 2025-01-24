namespace shs_rpo_Tuckov_DZ_08
{
    public class Program
    {
        private static int _x;
        private static int _rc; // Кол-во читателей
        private static Mutex _rcMutex = new Mutex();
        private static Semaphore _semaphore = new Semaphore(1, 1);


        private static void Main(string[] args)
        {
        }

        private static void readFunction()
        {
            if (_rc == 0)
            {
                _rcMutex.WaitOne();
                _rc++;
                _rcMutex.ReleaseMutex();
            }
            else if (_rc != 0)
            {
                _semaphore.WaitOne();
                Console.WriteLine($"{_x}");
                _semaphore.Release();

                _rcMutex.WaitOne();
                _rc--;
                _rcMutex.ReleaseMutex();
            }
        }

        private static void writeFunction()
        {
            if (_rc == 0)
            {
                _semaphore.WaitOne();
                _x++;
                _semaphore.Release();
            }
            else return;
        }
    }
}
