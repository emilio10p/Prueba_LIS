using System.Web.Mvc;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LMCStore.Controllers;
using Moq;
using LMCStore.Models;
using System.Linq;
using System.Collections.Generic;


namespace LMCStore.Tests.Controllers
{
    [TestClass]
    public class AreasControllerTest
    {
        //moq instatiate

        AreasController controller;
        List<Area> areas;
        Mock<IMockAreas> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            //moq data
            areas = new List<Area>
            {
                new Area{Area_id = 52, Area_name="area one", Area_level=1},
                new Area{Area_id = 53, Area_name="area two", Area_level=2},
                new Area{Area_id = 54, Area_name="area three"}
            };

            //set up and populate the mock
            mock = new Mock<IMockAreas>();
            mock.Setup(c => c.Areas).Returns(areas.AsQueryable());

            //initialize and pass the mock
            controller = new AreasController(mock.Object);

        }
        [TestMethod]
        public void EditSave(Area area)
        {
            // arrange
            // now handled in TestInitialize
            // act
            var results = (List<Area>)((ViewResult)controller.Edit(52)).Model;
            // assert
            CollectionAssert.AreEqual(areas.OrderBy(p => p.Area_name).ToList(), results);
        }

        [TestMethod]
        public void IndexLoadsAreas()
        {
            //act
            var results = (List<Area>)((ViewResult)controller.Index()).Model;

            //asert
            CollectionAssert.AreEqual(areas.OrderBy(c => c.Area_name).ToList(), results);
        }

        [TestMethod]
        public void EditPostIndexViewLoads()
        {
            // act
            RedirectToRouteResult result = controller.Edit(areas[0]) as RedirectToRouteResult;

            // assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditPostIndexViewName()
        {
            // act
            RedirectToRouteResult result = controller.Edit(areas[0]) as RedirectToRouteResult;

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostInavlidModelViewLoads()
        {
            controller.ModelState.AddModelError("Description", "error");
            // act
            ViewResult result = controller.Edit(areas[0]) as ViewResult;

            // assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            //arrange = TestInitialize Method

            //act
            ViewResult result = controller.Index() as ViewResult;
            //assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void CreateViewLoads()
        {
            // Arrange
            controller = new AreasController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void IndexViewError()
        {
            //arrange
            //handled on TestInitialized

            //act
            ViewResult result = controller.Create(areas[0]) as ViewResult;
            //asert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexViewBag()
        {
            //handled on TestInitialize

            //act
            SelectList result = (controller.Create(areas[0]) as ViewResult).ViewBag.Area_id;
            //asert
            Assert.AreEqual(52, result);

        }

        [TestMethod]
        public void EditPostInvalidModelViewName()
        {
            controller.ModelState.AddModelError("Description", "error");
            // act
            ViewResult result = controller.Edit(areas[0]) as ViewResult;

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditPostViewBag()
        {

            controller.ModelState.AddModelError("Description", "error");
            // act
            SelectList result = (controller.Edit(areas[0]) as ViewResult).ViewBag.Area_id;
            // assert
            Assert.AreEqual(52, result.SelectedValue);
        }

        [TestMethod]

        public void DetailsViewLoads()

        {
            //Act
            ViewResult res = controller.Details(52) as ViewResult;
            //Assert
            Assert.AreEqual("Details", res.ViewName);
        }

        [TestMethod]
        public void DetailsViewNullId()
        {
            //Act
            HttpStatusCodeResult res = controller.Details(null) as HttpStatusCodeResult;
            //Assert
            Assert.AreEqual(52, res.StatusCode);
        }

        [TestMethod]
        public void DetailsViewNullArea()

        {
            //Act
            HttpNotFoundResult res = controller.Details(52) as HttpNotFoundResult;
            //Assert
            Assert.AreEqual(52, res.StatusCode);
        }

        [TestMethod]
        public void DetailsViewProduct()
        {
            //Act
            var res = ((ViewResult)controller.Details(52)).Model;
            //Assert
            Assert.AreEqual(areas.SingleOrDefault(p => p.Area_id == 52), res);
        }

        [TestMethod]
        public void CheckValidIdRedirect()

        {
            // act
            RedirectToRouteResult result = controller.DeleteConfirmed(52) as RedirectToRouteResult;
            var resultlist = result.RouteValues.ToArray();
            // assert
            Assert.AreEqual("Index", resultlist[0].Value);
        }

        [TestMethod]
        public void CheckInvalidIdRedirect()

        {
            RedirectToRouteResult result = controller.DeleteConfirmed(52) as RedirectToRouteResult;
            // act
            var resultlist = result.RouteValues.ToArray();
            // assert
            Assert.AreEqual("Index", resultlist[0].Value);

        }
    }

}
