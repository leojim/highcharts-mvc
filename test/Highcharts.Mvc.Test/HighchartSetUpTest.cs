﻿using System.Web.Mvc;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class HighchartSetUpTest
    {
        [Test]
        public void EmptySetUp()
        {
            HighchartsSetUp setup = new HighchartsSetUp("myChart");
            var actual = setup.ToHtmlString();
            var expected = MvcHtmlString.Create(@"$(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          }
                                                      });
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ChartColors()
        {
            var setup = new HighchartsSetUp("myChart").Colors("#4572A7", "#AA4643", "#89A54E", "#80699B", "#3D96AE", "#DB843D", "#92A8CD", "#A47D7C", "#B5CA92");
            var actual = setup.ToHtmlString();
            var expected = MvcHtmlString.Create(@"$(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          colors: [
	                                                          '#4572A7', 
	                                                          '#AA4643', 
	                                                          '#89A54E', 
	                                                          '#80699B', 
	                                                          '#3D96AE', 
	                                                          '#DB843D', 
	                                                          '#92A8CD', 
	                                                          '#A47D7C', 
	                                                          '#B5CA92'
                                                          ]
                                                      });
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void PrintDisabled()
        {
            var setup = new HighchartsSetUp("myChart").Exporting(ex => ex.Buttons(b => b.PrintButton(pb => pb.Hide())));
            var actual = setup.ToHtmlString();
            var expected = MvcHtmlString.Create(@"$(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          exporting: { buttons: { printButton: { enabled: false }} }
                                                      });
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ExportDisabled()
        {
            var setup =
                new HighchartsSetUp("myChart").Exporting(
                    ex => ex.Buttons(b => b.ExportButton(eb => eb.Hide())));

            var actual = setup.ToHtmlString();
            var expected = MvcHtmlString.Create(@"$(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          exporting: { buttons: { exportButton: { enabled: false }} }
                                                      });
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ExportAndPrintDisabled()
        {
            var setup = new HighchartsSetUp("myChart")
                            .Exporting(ex =>
                                ex.Buttons(b =>
                                    b.ExportButton(eb => eb.Hide())
                                     .PrintButton(pb => pb.Hide())
                                )
                            );

            var actual = setup.ToHtmlString();
            var expected = MvcHtmlString.Create(@"$(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart'
                                                          },
                                                          exporting: { buttons: { exportButton: { enabled: false }, printButton: { enabled: false } }}
                                                      });
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FullSetUp()
        {
            HighchartsSetUp setup = new HighchartsSetUp("myChart")
                                        .WithSerieType(ChartSerieType.Line)
                                        .Title("The title")
                                        .Subtitle("This is the subtitle")
                                        .AxisY(x =>
                                            x.Title("Months")
                                        )
                                        .AxisX(x =>
                                            x.Title("Months", y =>
                                                y.Rotation(180)
                                            )
                                        )
                                        .Credits(x => x.Hide())
                                        .Legend(x => x.Position(y => y.Center()))
                                        .Options(
                                            PlotOptions.Series.NoAnimation()
                                        )
                                        .Series(
                                            new PieSerie("Tickets", new int[] { 2, 5 })
                                        )
                                        .Tooltip(x => x.Crosshairs());

            var actual = setup.ToHtmlString();
            var expected = MvcHtmlString.Create(@"$(document).ready(function () {
                                                      hCharts['myChart'] = new Highcharts.Chart({
                                                          chart: {
                                                            renderTo: 'myChart',
                                                            type: 'line'
                                                          },
                                                          title: { text: 'The title' },
                                                          subtitle: { text: 'This is the subtitle' },
                                                          yAxis: {
                                                            title: { text: 'Months' }
                                                          },
                                                          xAxis: { 
                                                            title: {
                                                                rotation: 180,
                                                                text: 'Months'
                                                            }
                                                          },
                                                          credits: { enabled: false },
                                                          legend: { align: 'center' },
                                                          plotOptions: {
                                                            series: { animation: false }
                                                          },
                                                          tooltip: { crosshairs: true },
                                                          series: [
                                                            { name: 'Tickets', type: 'pie', data: [ 2, 5 ] }
                                                          ]
                                                      });
                                                  });");

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}
