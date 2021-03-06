﻿using System.Configuration;

namespace API
{
    public static class AppSettings
    {
        public static decimal TaxRate => decimal.Parse(ConfigurationManager.AppSettings["TaxRate"]);
        public static decimal MaxRetry => int.Parse(ConfigurationManager.AppSettings["MaxRetry"]);
    }
}