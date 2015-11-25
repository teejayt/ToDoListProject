using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;
using System.Collections.ObjectModel;
using Moq;

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
            string value = "meeting";
            ObservableCollection<string> expectedList = new ObservableCollection<string>() 
            {
                value
            };

            //Act
            viewmodel.AddItem(value);

            //Assert
            Assert.AreEqual(expectedList.Count , viewmodel.newList.Count);
        }
    }
}
