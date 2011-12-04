﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Globalization;
using NUnit.Framework;

namespace Highcharts.Mvc.Test
{
    public static class HtmlAssert
    {
        public static void AreEqual(IHtmlString expected, IHtmlString actual)
        {
            string expectedString = expected.ToString().Replace(" ", "").Replace(Environment.NewLine, "");
            string actualString = actual.ToString().Replace(" ", "").Replace(Environment.NewLine, "");
            Assert.AreEqual(expectedString, actualString);
        }
    }
}