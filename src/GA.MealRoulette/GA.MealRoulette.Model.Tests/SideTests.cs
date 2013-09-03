// Copyright (c) 2013 Gil Abrantes | MIT License

using System;
using Xunit;

namespace GA.MealRoulette.Model.Tests
{
    public class SideTests
    {
        #region Public Methods

        [Fact]
        public void Ctor_InitializesMembers_Test()
        {
            var expectedName = "alface";

            var actual = new Side(expectedName);

            Assert.Equal(expectedName, actual.Name);
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsNull_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new Side(null));
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsWhiteSpace_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new Side(" "));
        }

        [Fact]
        public void Ctor_ThrowsIfNameIsEmpty_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new Side(""));
        }

        #endregion
    }
}
