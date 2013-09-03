// Copyright (c) 2013 Gil Abrantes | MIT/X11 License

using System;
using System.Collections.Generic;

namespace GA.MealRoulette.Model
{
    // TODO docs
    public class Plan
    {
        #region Constructors

        public Plan(IDictionary<DateTime, Meal> meals, DateTime firstDay, DateTime lastDay)
        {
            Meals = meals;
            FirstDay = firstDay;
            LastDay = lastDay;
        }

        #endregion

        #region Properties

        public int Id { get; set; }
        public DateTime FirstDay { get; private set; }
        public DateTime LastDay { get; private set; }
        public IDictionary<DateTime, Meal> Meals { get; private set; }

        #endregion
    }
}
