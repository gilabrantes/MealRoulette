// Copyright (c) 2013 Gil Abrantes | MIT/X11 License

using System;
using Xunit;

namespace GA.MealRoulette.Model.Tests
{
    public class MainTests
    {
        #region Public Methods

        [Fact]
        public void Ctor_InitializesMembers_Test()
        {
            var expectedName = "Vegetables";

            var actual = new Main(expectedName);

            Assert.Equal(expectedName, actual.Name);
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsNull_Test()
        {
            Assert.Throws<ArgumentException>(() => new Main(null));
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsWhiteSpace_Test()
        {
            Assert.Throws<ArgumentException>(() => new Main(""));
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsEmpty_Test()
        {
            Assert.Throws<ArgumentException>(() => new Main(" "));
        }

        #endregion
    }
}
