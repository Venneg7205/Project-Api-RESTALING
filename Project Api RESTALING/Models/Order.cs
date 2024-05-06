﻿using System;
using System.Collections.Generic;

namespace Project_Api_RESTALING.Models;

public partial class Order
{
    public int IdЗаказа { get; set; }

    public int IdКлиента { get; set; }

    public int IdАвтомобиля { get; set; }

    public DateTime ДатаЗаказа { get; set; }

    public TimeSpan ВремяЗаказа { get; set; }
}
