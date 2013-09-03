// Copyright (c) 2013 Gil Abrantes | MIT/X11 License

using System;

namespace GA.MealRoulette.Model
{
    public class Meal
    {
        #region Constructors

        public Meal(Soup soup, Main main, Side side, DateTime date)
        {
            Soup = soup;
            Main = main;
            Side = side;
            Date = date;
        }

        #endregion

        #region Properties

        public int Id { get; set; }
        public DateTime Date { get; private set; }
        public virtual Soup Soup { get; private set; }
        public virtual Main Main { get; private set; }
        public virtual Side Side { get; private set; }

        #endregion
    }
}
