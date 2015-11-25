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
            viewmodel.additemCommand.Execute(value);

            //Assert
            Assert.AreEqual(expectedList.Count , viewmodel.schedule.list.Count);
        }

        [TestMethod]
        public void Test_AddItem_AddsOneItemWhenPassedMoreThanOneItem()
        {
            //Arrange
            ViewModel viewmodel = new ViewModel();
            string value = "meeting";
            string value2 = "lunch";
            ObservableCollection<string> expectedList = new ObservableCollection<string>()
            {
                value, value2
            };

            //Act
            viewmodel.additemCommand.Execute(value);
            viewmodel.additemCommand.Execute(value2);


            //Assert
            Assert.AreEqual(expectedList.Count, viewmodel.schedule.list.Count);
        }
    }
}
