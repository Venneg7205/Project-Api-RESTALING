using System;
using System.Collections.Generic;

namespace Project_Api_RESTALING.Models;

public partial class АвтомобилиВПрокате
{
    public DateTime? ДатаПроката { get; set; }

    public string? Наименование { get; set; }

    public string? ТехническиеХарактеристики { get; set; }

    public string? ГосНомер { get; set; }

    public string? Фио { get; set; }

    public string? Услуги1 { get; set; }

    public string? Услуги2 { get; set; }

    public string? Услуги3 { get; set; }

    public string? СотрудникиФио { get; set; }
}
