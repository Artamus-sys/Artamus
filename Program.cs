using System;

namespace Atividade
{
    class Program
    {
        static void Main(string[] args)
        {
            float val_pag;
            Console.WriteLine("Informar Nome");
            string var_nome = Console.ReadLine();
            Console.WriteLine("Informar Endereço");
            string var_endereco = Console.ReadLine();
            Console.WriteLine("Pessoa Física (f) ou Jurídica (j) ?");
            string var_tipo = Console.ReadLine();

            Cliente cliente = new Cliente();
            cliente.Nome = var_nome;
            cliente.Endereco = var_endereco;

            if (var_tipo == "f")
            {
                // Pessoa Física
                Console.WriteLine("Informar CPF:");
                cliente.Cpf = Console.ReadLine();
            }
            else if (var_tipo == "j")
            {
                // Pessoa Jurídica
                Console.WriteLine("Informar CNPJ:");
                cliente.Cnpj = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            Console.WriteLine("Informar Valor de Compra:");
            val_pag = float.Parse(Console.ReadLine());
            cliente.PagarImposto(val_pag);

            Console.WriteLine("-------- Cliente ---------");
            Console.WriteLine("Nome ..........: " + cliente.Nome);
            Console.WriteLine("Endereço ......: " + cliente.Endereco);

            if (var_tipo == "f")
            {
                Console.WriteLine("CPF ...........: " + cliente.Cpf);
            }
            else if (var_tipo == "j")
            {
                Console.WriteLine("CNPJ ..........: " + cliente.Cnpj);
            }

            Console.WriteLine("Valor de Compra: " + cliente.Valor.ToString("C"));
            Console.WriteLine("Imposto .......: " + cliente.ValorImposto.ToString("C"));
            Console.WriteLine("Total a Pagar : " + cliente.Total.ToString("C"));
        }
    }

    // Classe Cliente que representa tanto pessoa física quanto jurídica
    class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public float Valor { get; set; }
        public float ValorImposto { get; set; }
        public float Total { get; set; }

        public void PagarImposto(float val)
        {
            Valor = val;

            if (!string.IsNullOrEmpty(Cpf))
            {
                // Pessoa Física
                ValorImposto = val * 0.1f; // Imposto de 10%
            }
            else if (!string.IsNullOrEmpty(Cnpj))
            {
                // Pessoa Jurídica
                ValorImposto = val * 0.2f; // Imposto de 20%
            }

            Total = Valor + ValorImposto;
        }
    }
}
