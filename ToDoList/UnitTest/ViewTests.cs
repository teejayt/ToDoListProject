using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;
using System.Collections.ObjectModel;

namespace UnitTest
{
    [TestClass]
    public class ViewTests
    {
        [TestMethod]
        public void Test_ViewItems_ReturnsEmptyList_IfNoItemsAreInTheList()
        {
            //Arrange
            ViewModel viewmodel = new ViewModel();
            ObservableCollection<string> collection = new ObservableCollection<string>();

            //Act
            viewmodel.newList = collection;
            viewmodel.ViewItems();

            //Assert
            Assert.AreEqual(0,viewmodel.newList.Count);
        }
    }
}
