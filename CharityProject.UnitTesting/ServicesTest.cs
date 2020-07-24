using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CharityProject.Controllers;
using CharityProject.Database;
using CharityProject.Entities.DomainClasses;
using CharityProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharityProject.UnitTesting
{
    [TestClass]
    public class ServicesTest
    {
        List<Partner> data = new List<Partner> {
                             new Partner {PartnerId=1, Name= "TestPartner1"},
                             new Partner {PartnerId=2, Name = "TestPartner2"},
                             new Partner {PartnerId=3, Name = "TestPartner3"}, 
                             new Partner {PartnerId=4, Name = "TestPartner4"},
                             new Partner {PartnerId=5, Name = "TestPartner5"}
        };



        Mock<IGenericRepository<Partner>> mockRepository = new Mock<IGenericRepository<Partner>>();


        [TestMethod]
        public void SampleTest()
        {
            Assert.AreEqual("HomeController", "HomeController");

        }


        [TestMethod]
        public void CountAllPartnersTest()
        {
            // Arrange                
            mockRepository.Setup(m => m.GetAll()).ReturnsAsync(data);

            // Act
            var Items = mockRepository.Object.GetAll();
                    
            // Assert
            Assert.AreEqual(5, Items.Result.Count);
        }


        [TestMethod]
        public void ReturnAllPartnersTest()
        {
            // Arrange
            Mock<DbContext> context = new Mock<DbContext>();

            mockRepository.Setup(d => d.GetAll()).ReturnsAsync(data);

            // Act
            var Items = mockRepository.Object.GetAll();
            
            // Assert
            Assert.AreEqual(data, Items.Result);
        }


        [TestMethod]
        public void GetByIdPartnersTest()
        {
            // Arrange
            mockRepository.Setup(d => d.GetAll()).ReturnsAsync(data);

            // Act

            mockRepository.Setup(mr => mr.GetById(It.IsAny<int>()))
                          .ReturnsAsync((int i) => data.Where(x => x.PartnerId == i).Single());

            // Assert
            Assert.AreEqual(3, mockRepository.Object.GetById(3).Result.PartnerId);
           
        }


        [TestMethod]
        public void GetPartnersNameTest()
        {
            // Arrange
            mockRepository.Setup(p => p.GetAll()).ReturnsAsync(data);

            // Act

            mockRepository.Setup(p => p.GetById(It.IsAny<int>()))
                          .ReturnsAsync((int i) => data.Where(x => x.PartnerId == i).Single());


            // Assert
            Assert.AreEqual("TestPartner3", mockRepository.Object.GetById(3).Result.Name);
        }


        [TestMethod]

        public void CanSavePartner()

        {
            mockRepository.Setup(p => p.GetAll()).ReturnsAsync(data);
           

            // Create a new partner
            Partner newPartner = new Partner
            { Name = "NewPartnerName", Description = "Short description here", PartnerId=9 };



            mockRepository.Setup(c => c.SaveAsync()).Returns(() => Task.Run(() => { data.Add(newPartner); }));

            int partnerCount = mockRepository.Object.GetAll().Result.Count;

            // Assert
            Assert.AreEqual(5, partnerCount); // Verify the expected Number pre-insert


   
            // try saving our new partner
            mockRepository.Object.SaveAsync().Wait();


            // demand a recount
            partnerCount = mockRepository.Object.GetAll().Result.Count;


            // verify that our new partner has been saved
            Assert.AreEqual(6, partnerCount); // Verify the expected Number post-insert
            Assert.IsInstanceOfType(newPartner, typeof(Partner)); // Test type
            Assert.AreEqual(9, newPartner.PartnerId); // Verify it has the expected productid

        }
    }
}
