using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList;
using System.Collections.ObjectModel;
using Moq;

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
            viewmodel.additemCommand.Execute(value);
            viewmodel.RemoveitemCommand.Execute(value);

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
            viewmodel.additemCommand.Execute(value);
            viewmodel.additemCommand.Execute(value2);

            //Removes only one item
            expectedList.Remove(value);
            viewmodel.RemoveitemCommand.Execute(value);


            //Assert
            Assert.AreEqual(expectedList.Count, viewmodel.schedule.list.Count);

        }

 /*       [TestMethod]
         [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_RemoveItemThrowsAnExceptionWhenTheItemdoesnotexist_ReturnsAnExceptionOfTypeArgumentOutOfRangeException()
        {  
            //Arrange
          //  ViewModel> viewmodel1 = new Mock<ViewModel>();
           viewmodel = new ViewModel();
            viewmodel.additemCommand.Execute("tola");
              viewmodel.additemCommand.Execute("james");
            viewmodel.additemCommand.Execute("dan");

            //Act
            viewmodel.RemoveitemCommand.Execute("dan1");

            //Assert
           

        }
        */

        [TestCleanup]
        public void CleanUp()
        {
            viewmodel = null;
            expectedList = null;
        }
    }
}