﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Models;
using Highcharts.Mvc.Configurator.PlotOptions;

namespace Highcharts.Mvc
{
    public class ColumnPlotOptionsConfigurator : CommonPlotOptionsConfigurator<ColumnPlotOptionsConfigurator>
    {
        private readonly ColumnPlotOptions columnPlotOptions;
        internal ColumnPlotOptionsConfigurator(ColumnPlotOptions columnPlotOptions)
            : base(columnPlotOptions)
        {
            this.columnPlotOptions = columnPlotOptions;
        }
    }
}
