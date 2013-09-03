// Copyright (c) 2013 Gil Abrantes | MIT/X11 License

using System;
using System.Collections.Generic;
using Xunit;

namespace GA.MealRoulette.Model.Tests
{
    public class PlanTests
    {
        #region Public Methods

        [Fact]
        public void Ctor_InitializesMembers_Test()
        {
            var expectedMeals = new Dictionary<DateTime, Meal>
                {
                    {DateTime.Today, new Meal(new Soup("test"), new Main("test"), new Side("test"), DateTime.Today)}
                };
            var expectedFirstDay = DateTime.Today;
            var expectedLastDay = DateTime.Today;

            var actual = new Plan(expectedMeals, expectedFirstDay, expectedLastDay);

            Assert.Same(expectedMeals, actual.Meals);
            Assert.Equal(expectedFirstDay, actual.FirstDay);
            Assert.Equal(expectedLastDay, actual.LastDay);
        }

        [Fact]
        public void Ctor_ThrowsIfMealsIsNull_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new Plan(null, DateTime.Today, DateTime.Today));
        }

        [Fact]
        public void Ctor_ThrowsIfMealsIsEmpty_Test()
        {
            Assert.Throws<ArgumentException>(() => new Plan(new Dictionary<DateTime, Meal>(), DateTime.Today, DateTime.Today));
        }

        [Fact]
        public void Ctor_ThrowsIfFirstDayIsAfterLastDay_Test()
        {
            Assert.Throws<ArgumentException>(
                () => new Plan(
                    new Dictionary<DateTime, Meal>
                    {
                        {DateTime.Today, new Meal(new Soup("test"), new Main("test"), new Side("test"), DateTime.Today)}
                    },
                    DateTime.Today.AddDays(1), 
                    DateTime.Today));
        }

        #endregion
    }
}
