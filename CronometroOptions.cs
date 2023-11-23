using System;
using System.Globalization;

public class CronometroOptions
{
    public int qtdeUnidades = Enum.GetValues(typeof(UnidadesTempo)).Length;

    public UnidadesTempo unidadeMedida {get; set;}
}