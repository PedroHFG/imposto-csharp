using System.Globalization;

namespace Imposto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double salarioAnual, salarioMensal, prestacaoDeServico, ganhoDeCapital, gastoMedico, gastosEducacao;
            double impostoSalarioAnual, impostoSalarioMensal, impostoPrestacaoDeServico, impostoGanhoDeCapital;

            Console.Write("Renda anual com salário: ");
            salarioAnual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Renda anual com prestação de serviço: ");
            prestacaoDeServico = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Renda anual com ganho de capital: ");
            ganhoDeCapital = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Gastos médico: ");
            gastoMedico = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Gastos educacionais: ");
            gastosEducacao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Cálculo de impostos sobre o salário mensal
            salarioMensal = salarioAnual / 12.0;

            if (salarioMensal < 3000.0)
            {
                impostoSalarioMensal = 0.0;
            }
            else if (salarioMensal <= 5000.0)
            {
                impostoSalarioMensal = salarioMensal * 0.10;
            }
            else
            {
                impostoSalarioMensal = salarioMensal * 0.20;
            }

            impostoSalarioAnual = impostoSalarioMensal * 12;

            // Cálculo de imposto sobre prestação de serviços
            impostoPrestacaoDeServico = (prestacaoDeServico > 0) ? prestacaoDeServico * 0.15 : 0.0;

            // Cálculo de impostos sobre ganho de capital
            impostoGanhoDeCapital = (ganhoDeCapital > 0) ? ganhoDeCapital * 0.20 : 0.0;

            double impostoTotal = impostoSalarioAnual + impostoPrestacaoDeServico + impostoGanhoDeCapital;
            double maximoDedutivel = impostoTotal * 0.30;
            double totalGastos = gastoMedico + gastosEducacao;
            double abatimento, impostoDevido;

            if (totalGastos < maximoDedutivel)
            {
                abatimento = totalGastos;
            }
            else
            {
                abatimento = maximoDedutivel;
            }

            impostoDevido = impostoTotal - abatimento;

            Console.WriteLine();
            Console.WriteLine("RELATÓRIO DE IMPOSTO DE RENDA");
            Console.WriteLine();
            Console.WriteLine("CONSOLIDADO DE RENDA:");
            Console.WriteLine($"Imposto sobre salário: {impostoSalarioAnual.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Imposto sobre serviços: {impostoPrestacaoDeServico.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Imposto sobre ganho de capital: {impostoGanhoDeCapital.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
            Console.WriteLine("DEDUÇÕES:");
            Console.WriteLine($"Máximo dedutível: {maximoDedutivel.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Gastos dedutíveis: {totalGastos.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
            Console.WriteLine("RESUMO:");
            Console.WriteLine($"Imposto total bruto: {impostoTotal.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Abatimento: {abatimento.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Imposto devido: {impostoDevido.ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}
