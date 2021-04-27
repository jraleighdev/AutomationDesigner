using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.ViewModels.Interfaces.Capture
{
    public interface IDimensionCapture
    {
        void AddDimension();

        void AddFeature();

        void DimensionSelectionChanged();

        void FeatureSelectionChanged();

        Task CaptureDimensions();
    }
}
