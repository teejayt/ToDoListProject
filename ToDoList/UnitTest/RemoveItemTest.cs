using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;
using System.Collections.ObjectModel;

namespace UnitTest
{
    [TestClass]
    public class RemoveItemTest
    {
        ViewModel viewmodel;
        ObservableCollection<string> expectedList;
        [TestInitialize]
        public void Setup()
        {
            viewmodel = null;
            expectedList = null;
        }
        [TestMethod]
        public void Test_RemoveItemMethodwhenoneObjectIsInTheCollection_ReturnszerowhentheOnlyObjectIsRemoved()
        {
            //Arrange
            viewmodel = new ViewModel();

            string value = "meeting";

            expectedList = new ObservableCollection<string>() 
            {
                value
            };
            expectedList.Remove(value);

            //Act
            viewmodel.AddItem(value);
            viewmodel.RemoveItem(value);

            //Assert
            Assert.AreEqual(expectedList.Count, viewmodel.newList.Count);
        }

        [TestMethod]
        public void Test_Test_RemoveItemMethodwhenTwoObjectsAreInTheCollection_ReturnsOnewhentheOnlyOneObjectIsRemoved()
        {
            //Arrange
            viewmodel = new ViewModel();
            string value = "meeting";
            string value2 = "Babbage meeting";
            expectedList = new ObservableCollection<string>() 
            {
                value, value2
            };

            //Act
            //Adds two schedules to the expectedList and the actual list in the viewmodel
            viewmodel.AddItem(value);
            viewmodel.AddItem(value2);
            //Removes only one item
            expectedList.Remove(value);
            viewmodel.RemoveItem(value);


            //Assert
            Assert.AreEqual(expectedList.Count, viewmodel.schedule.list.Count);

        }

        [TestMethod]
        // [ExpectedException]
        //Arrange



        [TestCleanup]
        public void CleanUp()
        {
            viewmodel = null;
            expectedList = null;
        }
    }
}