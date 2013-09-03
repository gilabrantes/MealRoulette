// Copyright (c) 2013 Gil Abrantes | MIT/X11 License

using System;
using Xunit;

namespace GA.MealRoulette.Model.Tests
{
    public class MealTests
    {
        #region Public Methods

        [Fact]
        public void Ctor_InitializesMembers_Test()
        {
            var expectedSoup = new Soup("test");
            var expectedMain = new Main("test");
            var expectedSide = new Side("test");
            var expectedDate = DateTime.Today;

            var actual = new Meal(expectedSoup, expectedMain, expectedSide, expectedDate);

            Assert.Equal(expectedSoup, actual.Soup);
            Assert.Equal(expectedMain, actual.Main);
            Assert.Equal(expectedSide, actual.Side);
            Assert.Equal(expectedDate, actual.Date);
        }

        [Fact]
        public void Ctor_ThrowsIfSoupIsNull_Test()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Meal(null, new Main("test"), new Side("test"), DateTime.Today));

        }

        [Fact]
        public void Ctor_ThrowsIfMainIsNull_Test()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Meal(new Soup("test"), null, new Side("test"), DateTime.Today));
        }

        [Fact]
        public void Ctor_ThrowsIfSideIsNull_Test()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Meal(new Soup("test"), new Main("test"), null, DateTime.Today));
        }

        #endregion
    }
}
