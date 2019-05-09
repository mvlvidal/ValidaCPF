using System;

namespace ValidaCPF
{
    class Program
    {
        

        static void Main(string[] args)
        {
            ValidadorCPF vcpf = new ValidadorCPF();

            Console.WriteLine("Digite seu CPF!");

            string cpf = Console.ReadLine();

            bool resultado = vcpf.Validacao(cpf);

            if (resultado == true) {
                Console.WriteLine("CPF Válido");
            }
            else
            {
                Console.WriteLine("CPF Inválido");
            }

        }

        
    }

    class ValidadorCPF
    {
        private char[] num1;
        private int[] num2;

        public bool Validacao(string cpf)
        {
            num1 = new char[10];
            num2 = new int[10];

           num2 = ConverteVetor(cpf);

            int dig = 0;
            int dig1 = 10;
            int dig2 = 11;


            //Primeiro Digito
            for (int i = 0; i < 10; i++)
            {
                dig += num2[i] * dig1;
                dig--;
            }

            if (dig % 11 == 0 || dig % 11 == 1)
            {
                dig1 = 0;
            }
            else
            {
                dig1 = 11 - (dig % 11);
            }

            num2[9] = dig1;
            dig = 0;

            //Segundo Digito

            for (int j = 0; j < 11; j++)
            {
                dig += num2[j] * dig2;
                dig--;
            }

            if (dig % 11 == 0 || dig % 11 == 1)
            {
                dig2 = 0;
            }
            else
            {
                dig2 = 11 - (dig % 11);
            }

            num2[10] = dig2;

            string num3 = num2.ToString();

            if (!num3.Equals(cpf))
            {
                return false;
            }

            return true;
        }

        public int[] ConverteVetor(string cpfNum)
        {

            int[] num = new int[10];
            char[] numeros = new char[10];

            numeros = cpfNum.ToCharArray();

            for(int i = 0; i <= num.Length; i++)
            {
                num[i] = (int)Char.GetNumericValue(numeros[i]);
            }

            return num;
        }

    }
}
