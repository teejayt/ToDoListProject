using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;

namespace UnitTest
{
    [TestClass]
    public class MarkItemTests
    {
        [TestMethod]
        public void Test_MarkItem_ReturnsAStringEndingWIthCompleted()
        {
            //Arrange
            ViewModel viewmodel = new ViewModel();
            string value = "Meeting";


            //Act
            viewmodel.MarkitemCommand.Execute(value);

            //Assert
            //Assert.AreEqual()

        }
    }
}
