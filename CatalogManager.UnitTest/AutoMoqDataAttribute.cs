using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture.AutoMoq;
using AutoFixture;
using AutoFixture.Xunit2;

namespace CatalogManager.UnitTest
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
