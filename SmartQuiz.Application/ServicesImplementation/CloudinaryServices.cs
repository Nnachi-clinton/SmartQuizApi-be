﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartQuiz.Application.ServicesImplementation
{
    public class CloudinarySetting
    {
        public string CloudName { get; set; } = string.Empty;
        public string APIKey { get; set; } = string.Empty;
        public string APISecret { get; set; } = string.Empty;
    }
}