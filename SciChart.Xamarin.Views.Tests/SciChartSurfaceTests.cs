using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SciChart.Xamarin.Views.Tests.Stubs;
using SciChart.Xamarin.Views.Visuals;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Views.Tests
{
    [TestFixture]
    public class SciChartSurfaceTests
    {
        [Test]
        public void WhenCreateSciChartSurface_ShouldPropagateBindingContext()
        {
            var scs = new SciChartSurface();
            var rs = new StubRenderableSeries();
            scs.BindingContext = "ABindingContext";

            // Set binding context then series add
            scs.RenderableSeries.Add(rs);            

            Assert.That(rs.BindingContext, Is.EqualTo("ABindingContext"));
        }

        [Test]
        public void WhenCreateSciChartSurface_AndAddSeries_ShouldPropagateBindingContext()
        {
            var scs = new SciChartSurface();
            var rs = new StubRenderableSeries();
            scs.RenderableSeries.Add(rs);

            // Set binding context after series add 
            scs.BindingContext = "ABindingContext";

            Assert.That(rs.BindingContext, Is.EqualTo("ABindingContext"));
        }

        [Test]
        public void WhenCreateSciChartSurface_AndNewRenderableSeriesCollection_ShouldPropagateBindingContext()
        {
            var scs = new SciChartSurface();
            var rs = new StubRenderableSeries();
            scs.BindingContext = "ABindingContext";

            // Set binding context then series add
            scs.RenderableSeries = new ObservableCollection<IRenderableSeries>(new [] { rs });

            Assert.That(rs.BindingContext, Is.EqualTo("ABindingContext"));
        }
    }
}
