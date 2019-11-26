﻿using System.Collections.Generic;
using System.ComponentModel;
using Android.Content;
using Java.Util;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Drawing.Canvas;
using SciChart.Drawing.OpenGL;
using SciChart.Xamarin.Android.Renderer;
using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

[assembly: ExportRenderer(typeof(SciChartSurfaceX), typeof(SciChartSurfaceAndroidRenderer))]

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidRenderer : ViewRenderer<SciChartSurfaceX, SciChartSurface>
    {
        private PropertyMapper<SciChartSurfaceX, SciChartSurface> _propertyMapper;
        private string _license;

        public SciChartSurfaceAndroidRenderer(Context context) : base(context) 
        {
            // Apply license 
            if (_license == null)
            {
                _license = SciChartLicenseManager.GetLicense(SciChartPlatform.Android);
                if (_license != null)
                {
                    SciChartSurface.SetRuntimeLicenseKey(_license);
                }
            }
        }        

        protected override void OnElementChanged(ElementChangedEventArgs<Views.Visuals.SciChartSurface> e)
        {
            if (Control == null)
            {
                // Create the native control 
                SciChartSurface surface = new SciChartSurface(Context);

                // Enable the zoom
                using (surface.SuspendUpdates())
                {
                    surface.ChartModifiers = new Charting.Model.ChartModifierCollection
                    {
                        new Charting.Modifiers.ZoomPanModifier(),
                        new Charting.Modifiers.PinchZoomModifier(),
                        new Charting.Modifiers.ZoomExtentsModifier(),
                    };
                }

                this.SetNativeControl(surface);
                Control.RenderSurface = new RenderSurface(Context);

                // Setup the property mapper 
                _propertyMapper = new SciChartSurfaceAndroidPropertyMapper(e.NewElement, Control);                                        
            }

            base.OnElementChanged(e);
        }        
    }
}
