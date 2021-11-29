using System;

namespace FinagoTechInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kullanıcıdan alınacak değişkenler tanımlanır
            string wolfCountEntered = String.Empty;
            int wolfCount = 0;
            string[] wolfs;
            int[] wolfsIntArray;
            int[] counts = new int[5];

            wolfCountEntered = Console.ReadLine();
            if (ValidateInput(wolfCountEntered) == false)
            {
                Main(null);
            }

            wolfCount = Convert.ToInt32(wolfCountEntered);
            wolfs = Console.ReadLine().Split(' '); // dizi değerleri arasında boşluk bulunur.
            if (wolfs.Length != wolfCount)
            {
                Console.WriteLine("Girilen kurt sayısı, verilen dizi ile eşleşmiyor");
                return;
            }
            try
            {
                wolfsIntArray = ConvertToIntArray(wolfs);
            }
            catch
            {
                Console.WriteLine("Girilen dizi tamsayılardan oluşmalıdır.");
                return;
            }

            for (int i = 0; i < wolfsIntArray.Length; i++)
            {
                counts[wolfsIntArray[i] - 1]++; //indexten dolayı -1 işlemi ile 5 sayı toplamları kontrol edilir.
            }
            Console.WriteLine(FindMaximumIndex(counts));
            Console.Read();
        }

        private static int[] ConvertToIntArray(string[] input)
        {
            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    numbers[i] = Convert.ToInt32(input[i]);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return numbers;
        }

        private static int FindMaximumIndex(int[] input)
        {
            int max = input[0];
            int maxIndex = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                    maxIndex = i;
                }
            }
            return maxIndex + 1; //index değeri olduğu için +1 eklenir
        }

        private static bool ValidateInput(string input)
        {
            int inputConverted;
            try
            {
                inputConverted = int.Parse(input);
            }
            catch (Exception)
            {

                Console.WriteLine("Lütfen Sadece Tam sayı Giriniz");
                return false;
            }
            if (inputConverted < 5 || inputConverted > 200000)
            {
                Console.WriteLine("Girilen kurt sayısı 5-200.000 arası olmalıdır");
                return false;
            }
            return true;
        }

    }
}
