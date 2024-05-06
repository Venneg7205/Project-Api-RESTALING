﻿using System;
using System.Collections.Generic;

namespace Project_Api_RESTALING.Models;

public partial class Client
{
    public int IdКлиента { get; set; }

    public string? Фио { get; set; }

    public string? Пол { get; set; }

    public DateTime? ДатаРождения { get; set; }

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public string? ПаспортныеДанные { get; set; }

    public string? Активность { get; set; }

    public string? ВодительскоеУдостоверение { get; set; }
}
