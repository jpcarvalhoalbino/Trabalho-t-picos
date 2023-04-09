// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using ControleContas.Model;
try
{
    Cliente jose = new Cliente("José", "12345678909", 2004);
    Conta conta1 = new ContaCorrente(123456789, jose, 100);

    Cliente joao = new Cliente("João", "09876543211", 2000);
    Conta conta2 = new ContaCorrente(987654321, joao, 100);
    conta2.Deposito(2341.42);

    conta1.Deposito(1000);

    Console.WriteLine($"{conta1.ToString()}");
    Console.WriteLine($"{conta2.ToString()}");

    //conta1.Transferencia(500, conta2);
    Console.WriteLine($"{conta1.ToString()}");
    Console.WriteLine($"{conta2.ToString()}");

    Console.WriteLine("O saldo total das duas contas é " + (conta1.Saldo + conta2.Saldo));

    Console.WriteLine($"A conta de maior saldo é {Conta._contaMaiorSaldo} cujo saldo é {Conta._maiorSaldo}");

}
catch(ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
}