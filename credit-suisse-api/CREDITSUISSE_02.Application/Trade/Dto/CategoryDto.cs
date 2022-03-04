using System;

namespace CREDITSUISSE_02.Application.Trade.Dtos
{
    public static class CategoryDto
    {
        public static double Value { get; set; }
        public static string ClientSector { get; set; }
        public static DateTime NextPaymentDate { get; set; }
        public static string Category { get; set; }
    }
}