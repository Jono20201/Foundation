﻿using System;

namespace FGS.Pump.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset FloorToDay(this DateTimeOffset dateTimeOffset)
        {
            return new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 0, 0, 0, dateTimeOffset.Offset);
        }

        public static DateTimeOffset CeilingToDay(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.AddDays(1).FloorToDay().AddTicks(-1);
        }

        public static DateTimeOffset FloorToSecond(this DateTimeOffset dateTimeOffset)
        {
            return new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, dateTimeOffset.Hour, dateTimeOffset.Minute, dateTimeOffset.Second, dateTimeOffset.Offset);
        }

        public static DateTimeOffset CeilingToSecond(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.AddSeconds(1).FloorToSecond().AddTicks(-1);
        }
    }
}