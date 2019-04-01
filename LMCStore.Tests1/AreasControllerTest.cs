// <copyright file="AreasControllerTest.cs">Copyright ©  2019</copyright>
using System;
using System.Web.Mvc;
using LMCStore.Controllers;
using LMCStore.Models;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LMCStore.Controllers.Tests
{
    /// <summary>This class contains parameterized unit tests for AreasController</summary>
    [PexClass(typeof(AreasController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AreasControllerTest
    {
        /// <summary>Test stub for Create(Area)</summary>
        [PexMethod]
        public ActionResult CreateTest([PexAssumeUnderTest]AreasController target, Area area)
        {
            ActionResult result = target.Create(area);
            return result;
            // TODO: add assertions to method AreasControllerTest.CreateTest(AreasController, Area)
        }
    }
}
