using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DateTimeExtention
/// </summary>
public static class DateTimeExtention
{
    public static DateTime FirstDayOfNextMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1).AddMonths(1);
    }

    public static DateTime LastDayOfNextMonth(this DateTime date)
    {
        date = date.AddMonths(1);
        return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }

    public static DateTime LastDayOfProvisionMonthMonth(this DateTime date)
    {
        date = date.AddMonths(1);
        return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month) - 5);
    }

}