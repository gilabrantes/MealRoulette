// Copyright (c) 2013 Gil Abrantes | MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA.MealRoulette.Engine.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        /// <remarks>
        /// Method suggested by Thomas Levesque on StackOverFlow
        /// http://stackoverflow.com/questions/7611402/how-to-get-the-date-of-the-next-sunday.
        /// </remarks>
        public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
        {
            var start = (int) from.DayOfWeek;
            var target = (int)dayOfWeek;
            if (target <= start)
            {
                target += 7;
            }
            return from.AddDays(target - start);
        }
    }
}
