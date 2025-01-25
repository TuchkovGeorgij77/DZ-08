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
            _rcMutex.WaitOne();

            if (_rc == 0)
            {
                _semaphore.WaitOne();
            }

            _rc++;

            _rcMutex.ReleaseMutex();


            Console.WriteLine(_x);


            _rcMutex.WaitOne();

            if (--_rc == 0)
            {
                _semaphore.Release();
            }

            _rc--;

            _rcMutex.ReleaseMutex();
        }

        private static void writeFunction()
        {
            _semaphore.WaitOne();
            _x++;
            _semaphore.Release();
        }
    }
}