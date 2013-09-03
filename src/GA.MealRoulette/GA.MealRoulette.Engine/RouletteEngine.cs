// Copyright (c) 2013 Gil Abrantes | MIT License

using GA.MealRoulette.Engine.Extensions;
using GA.MealRoulette.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GA.MealRoulette.Engine
{
    public sealed class RouletteEngine
    {
        #region Declarations

        private readonly DataEngine _dataEngine;
        private readonly Random _randomNumberGenerator;
        
        #endregion

        #region Constructors 

        public RouletteEngine(DataEngine dataEngine)
        {
            _dataEngine = dataEngine;
            _randomNumberGenerator = new Random();
        }

        #endregion

        #region Public Methods
        
        public Plan GeneratePlan()
        {
            var day = DateTime.Today;
            if (day.DayOfWeek < DayOfWeek.Friday)
            {
                return GeneratePlanFor(DateTime.Now, DateTime.Now.Next(DayOfWeek.Friday));
            }
            return GeneratePlanFor(DateTime.Now.Next(DayOfWeek.Monday), DateTime.Now.Next(DayOfWeek.Friday));
        }

        private Plan GeneratePlanFor(DateTime firstDay, DateTime lastDay)
        {
            var day = firstDay;
            var meals = new Dictionary<DateTime, Meal>();
            do
            {
                meals.Add(day, GenerateMeal(day));
                day = day.AddDays(1);
            } while (day <= lastDay);
            return new Plan(meals, firstDay, lastDay);
        }

        public Meal GenerateMeal(DateTime date)
        {
            return new Meal(DrawSoup(), DrawMain(), DrawSide(), date);
        }

        #endregion

        #region Private Methods

        private Soup DrawSoup()
        {
            var soups = _dataEngine.GetAllSoups().ToArray();
            var soupNumber = _randomNumberGenerator.Next(soups.Count());
            return soups[soupNumber];
        }

        private Main DrawMain()
        {
            var mains = _dataEngine.GetAllMains().ToArray();
            var mainNumber = _randomNumberGenerator.Next(mains.Count());
            return mains[mainNumber];  
        }

        private Side DrawSide()
        {
            var sides = _dataEngine.GetAllSides().ToArray();
            var sideNumber = _randomNumberGenerator.Next(sides.Count());
            return sides[sideNumber];  
        }

        #endregion
    }
}
