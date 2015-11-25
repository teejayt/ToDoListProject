using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;

namespace UnitTest
{
    [TestClass]
    public class AddItemTest
    {
        [TestMethod]
        public void Test_AddItem_AddsAnItemToTheListWhenGivenAnItem()
        {
            //Arrange
            ViewModel viewmodel = new ViewModel();

            //Act
            itemToBeAdded = viewmodel.AddItem("meeting");

            //Assert
            Assert.

        }
    }
}
