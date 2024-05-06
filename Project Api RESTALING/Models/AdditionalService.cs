using System;
using System.Collections.Generic;

namespace Project_Api_RESTALING.Models;

public partial class AdditionalService
{
    public int IdУслуги { get; set; }

    public string? Наименование { get; set; }

    public string? Описание { get; set; }

    public decimal? Цена { get; set; }
}
