// Copyright (c) 2013 Gil Abrantes | MIT License

using System;
using Xunit;

namespace GA.MealRoulette.Model.Tests
{
    public class SoupTests
    {
        #region Public Methods

        [Fact]
        public void Ctor_InitializesMembers_Test()
        {
            var expectedName = "Couves";

            var actual = new Soup(expectedName);

            Assert.Equal(expectedName, actual.Name);
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsNull_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new Soup(null));
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsWhiteSpace_Test()
        {
            Assert.Throws<ArgumentException>(() => new Soup(" "));
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsEmpty_Test()
        {
            Assert.Throws<ArgumentException>(() => new Soup(""));
        }

        #endregion
    }
}
