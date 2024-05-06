using System;
using System.Collections.Generic;

namespace Project_Api_RESTALING.Models;

public partial class CarMarking
{
    public int IdМарки { get; set; }

    public string? Наименование { get; set; }

    public string? ТехническиеХарактеристики { get; set; }

    public string? Описание { get; set; }
}
