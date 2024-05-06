using System;
using System.Collections.Generic;

namespace Project_Api_RESTALING.Models;

public partial class Position
{
    public int IdДолжности { get; set; }

    public string? Наименование { get; set; }

    public decimal? Зарплата { get; set; }

    public string? Обязанности { get; set; }

    public string? Требования { get; set; }
}
