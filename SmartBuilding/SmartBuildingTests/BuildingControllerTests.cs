using NSubstitute;
using NUnit.Framework;
using SmartBuilding;

namespace SmartBuildingTests
{
    [TestFixture]
    public class BuildingControllerTests
    {
        ///////////////////////////////////////////////////////////////////////// Level 1        
        ////////L1R1
        [Test]
        public void BuildingControllerConstructor_InitialiseBuildingID_IsNotEmpty()
        {
            //Arrange
            string buildingID = "B123";

            //Act
            BuildingController building = new BuildingController(buildingID);

            //Assert
            Assert.IsNotEmpty(building.buildingID);
        }

        ////////L1R1
        [TestCase("building123")]
        [TestCase("")]
        [TestCase(null)] // Defensive programming activates in the main implementation.
        public void BuildingControllerConstructor_InitialiseBuildingID_SetsBuildingIDCorrectly(string buildingID)
        {
            //Arrange & Act
            BuildingController building = new BuildingController(buildingID);

            //Assert
            Assert.AreEqual(buildingID, building.buildingID);
        }

        ////////L1R1
        [Test] 
        public void BuildingControllerConstructor_InitialiseBuildingIDForMultipleInstances_SetsBuildingIDCorrectly()
        {
            //Arrange
            string[] buildingID = { "building111", "building2222" };

            //Act
            BuildingController building_0 = new BuildingController(buildingID[0]);
            BuildingController building_1 = new BuildingController(buildingID[1]);

            //Assert
            Assert.AreEqual(buildingID[0], building_0.buildingID);
            Assert.AreEqual(buildingID[1], building_1.buildingID);
        }

        ////////L1R2
        [TestCase("")]
        [TestCase("build311")]
        [TestCase("building!2")]
        [TestCase("bba23")]
        [TestCase("234234")]
        public void GetBuildingID_InitialiseBuildingID_ReturnsBuildingIDCorrectly(string buildingID)
        {
            //Arrange
            string desiredBuildingID = buildingID.ToLower();

            //Act
            BuildingController building = new BuildingController(buildingID);
            string actualID = building.GetBuildingID();

            //Assert
            Assert.AreEqual(desiredBuildingID, actualID);
        }

        ////////L1R2
        [Test]
        public void GetBuildingID_InitialiseBuildingIDForMultipleInstances_ReturnsBuildingIDCorrectly()
        {
            //Arrange
            string[] desiredBuildingID = { "build1231", "b123" };
            //string Expected = "Out of hours";

            //Act
            BuildingController building_0 = new BuildingController(desiredBuildingID[0]);
            BuildingController building_1 = new BuildingController(desiredBuildingID[1]);
            string actualID_0 = building_0.GetBuildingID();
            string actualID_1 = building_1.GetBuildingID();

            //Assert
            Assert.AreEqual(desiredBuildingID[0], actualID_0);
            Assert.AreEqual(desiredBuildingID[1], actualID_1);
        }

        ////////L1R2
        [Test]
        public void GetBuildingID_InitialiseBuildingID_ReturnsLongBuildingIDCorrectly()
        {
            //Arrange
            string desiredBuildingID = new string('b', 1000);

            //Act
            BuildingController building = new BuildingController(desiredBuildingID);
            string actualID = building.GetBuildingID();

            //Assert
            Assert.AreEqual(desiredBuildingID, actualID);
        }

        ////////L1R3
        [TestCase("BuIlDiNg123")]
        [TestCase("BAf!12")]
        [TestCase("Ba!2f£21")]
        public void GetBuildingID_InitialiseBuildingIDLowerCase_ReturnsBuildingIDCorrectly(string buildingID)
        {
            //Arrange
            string desiredBuildingID = buildingID.ToLower();

            //Act
            BuildingController building = new BuildingController(buildingID);
            string actualID = building.GetBuildingID();

            //Assert
            Assert.AreEqual(desiredBuildingID, actualID);
        }

        ////////L1R4
        [TestCase("build231")]
        [TestCase("B123")]
        [TestCase("BUILDING111")]
        [TestCase("")]
        public void SetBuildingID_InitialiseBuildingID_SetsBuildingIDCorrectly(string buildingID)
        {
            //Arrange
            string desiredBuildingID = buildingID.ToLower();

            //Act
            BuildingController building = new BuildingController("B23");
            building.SetBuildingID(buildingID);

            //Assert
            Assert.AreEqual(desiredBuildingID, building.buildingID);
        }

        ////////L1R4
        [Test]
        public void SetBuildingID_InitialisedBuildingID_SetsLongBuildingIDCorrectly()
        {
            //Arrange
            string desiredBuildingID = new string('a', 10000);

            //Act
            BuildingController building = new BuildingController(desiredBuildingID);
            building.SetBuildingID(desiredBuildingID);

            //Assert
            Assert.AreEqual(desiredBuildingID, building.buildingID);
        }

        ////////L1R4
        [Test]
        public void SetBuildingID_InitialiseBuildingIDForMultipleInstances_SetsBuildingIDCorrectly()
        {
            //Arrange
            string[] desiredBuildingID = { "b11", "b22" };

            //Act
            BuildingController building_0 = new BuildingController("B1111111");
            BuildingController building_1 = new BuildingController("B2222222");
            building_0.SetBuildingID(desiredBuildingID[0]);
            building_1.SetBuildingID(desiredBuildingID[1]);

            //Assert
            Assert.AreEqual(desiredBuildingID[0], building_0.buildingID);
            Assert.AreEqual(desiredBuildingID[1], building_1.buildingID);
        }

        ////////L1R5
        [Test]
        public void BuildingControllerConstructor_DefaultCurrentState_IsOutOfHours()
        {
            //Arrange
            string desiredCurrentState = "out of hours";

            //Act
            BuildingController building = new BuildingController("B1");

            //Assert
            Assert.AreEqual(desiredCurrentState, building.currentState);
        }

        ////////L1R6
        [Test]
        public void GetCurrentState_DefaultCurrentState_ReturnsOutOfHours()
        {
            //Arrange
            string desiredCurrentState = "out of hours";

            //Act
            BuildingController building = new BuildingController("B1");

            //Assert
            Assert.AreEqual(desiredCurrentState, building.GetCurrentState());
        }

        ////////L1R6
        [Test]
        public void GetCurrentState_UpdatedCurrentState_ReturnsClosedState()
        {
            //Arrange
            string desiredCurrentState = "closed";

            //Act
            BuildingController building = new BuildingController("B1");
            building.currentState = desiredCurrentState;

            //Assert
            Assert.AreEqual(desiredCurrentState, building.GetCurrentState());
        }

        ////////L1R6
        [Test]
        public void GetCurrentState_UpdateCurrentStateForMultipleInstances_ReturnsCorrectStateForEachInstance()
        {
            //Arrange
            string desiredCurrentState_0 = "out of hours";
            string desiredCurrentState_1 = "open";

            //Act
            BuildingController building_0 = new BuildingController("B12");
            BuildingController building_1 = new BuildingController("B13");
            building_0.currentState = desiredCurrentState_0;
            building_1.currentState = desiredCurrentState_1;

            //Assert
            Assert.AreEqual(desiredCurrentState_0, building_0.GetCurrentState());
            Assert.AreEqual(desiredCurrentState_1, building_1.GetCurrentState());
        }

        ////////L1R7
        [TestCase("open")]
        [TestCase("out of hours")]
        [TestCase("closed")]
        [TestCase("fire alarm")]
        [TestCase("fire drill")]
        public void SetCurrentState_ValidState_ReturnsTrueAndSetsCurrentState(string desiredCurrentState)
        {
            //Arrange & Act
            BuildingController building = new BuildingController("B1");
            bool actualState = building.SetCurrentState(desiredCurrentState);

            //Assert
            Assert.IsTrue(actualState);
            Assert.AreEqual(desiredCurrentState, building.currentState);
        }
        
        ////////L1R6
        [Test]
        public void SetCurrentState_InvalidState_IsFalse()
        {
            //Arrange
            string invalidState = "invalid closure";

            //Act
            BuildingController building = new BuildingController("B2");
            bool actualState = building.SetCurrentState(invalidState);

            //Assert
            Assert.IsFalse(actualState);
        }

        ///////////////////////////////////////////////////////////////////////// Level 2
        ////////L2R1
        [TestCase("out of hours", "open")]
        [TestCase("open", "out of hours")]
        [TestCase("out of hours", "closed")]
        [TestCase("closed", "out of hours")]
        public void SetCurrentState_ValidStates_ChangesCurrentStateAndReturnsTrue(string fromState, string toState)
        {
            //Arrange
            BuildingController building = new BuildingController("B1");
            building.currentState = fromState;

            //Act
            bool isChanged = building.SetCurrentState(toState);

            //Assert
            Assert.IsTrue(isChanged);
            Assert.AreEqual(toState, building.currentState);
        }

        ////////L2R1
        [TestCase("open", "closed")]
        [TestCase("closed", "open")]
        public void SetCurrentState_InvalidState_ReturnsFalseAndDoesNotChangeCurrentState(string fromState, string toState)
        {
            //Arrange
            BuildingController building = new BuildingController("B111");
            building.currentState = fromState;

            //Act
            bool isChanged = building.SetCurrentState(toState);

            //Assert
            Assert.IsFalse(isChanged);
            Assert.AreEqual(fromState, building.currentState); //Checks the currentState isn't changed.
        }

        ////////L2R1
        [TestCase("open", "fire alarm", "open")]
        [TestCase("out of hours", "fire alarm", "out of hours")]
        [TestCase("closed", "fire alarm", "closed")]
        [TestCase("open", "fire drill", "open")]
        [TestCase("out of hours", "fire drill", "out of hours")]
        [TestCase("closed", "fire drill", "closed")]
        public void SetCurrentState_ValidTransition_ReturnsTrueAndChangesToFinalCurrentState(string currentState, string toState, string finalState)
        {
            //Arrange
            BuildingController building = new BuildingController("B23");
            building.currentState = currentState;

            //Act
            building.SetCurrentState(toState);
            bool actualState = building.SetCurrentState(finalState);

            //Assert
            Assert.IsTrue(actualState);
            Assert.AreEqual(finalState, building.currentState);//Checks the currentState has been changed.
        }

        ////////L2R1
        [TestCase("open", "fire alarm", "closed")]
        [TestCase("out of hours", "fire alarm", "open")]
        [TestCase("closed", "fire alarm", "fire drill")]
        [TestCase("open", "fire drill", "out of hours")]
        [TestCase("out of hours", "fire drill", "fire alarm")]
        [TestCase("out of hours", "fire drill", "closed")]
        public void SetCurrentState_InvalidTransition_ReturnsFalseAndDoesNotChangeCurrentState(string currentState, string toState, string finalState)
        {
            //Arrange
            BuildingController building = new BuildingController("B23");
            building.currentState = currentState;

            //Act
            building.SetCurrentState(toState);
            bool actualState = building.SetCurrentState(finalState);

            //Assert
            Assert.IsFalse(actualState);
            Assert.AreEqual(toState, building.currentState);
        }

        ////////L2R1
        [TestCase("alarming")]
        [TestCase("unalarmed")]
        [TestCase("Invalid Unalarmed")]
        public void SetCurrentState_InvalidState_ReturnFalse(string state)
        {
            //Arrange
            BuildingController building = new BuildingController("B111");

            //Act
            bool isChanged = building.SetCurrentState(state);

            //Assert
            Assert.IsFalse(isChanged);
        }

        ////////L2R1
        [TestCase("fire alarm", "fire drill")]
        [TestCase("fire drill", "fire alarm")]
        public void SetCurrentState_InvalidTransition_ReturnFalse(string fromState, string toState)
        {
            //Arrange
            BuildingController building = new BuildingController("B76");

            //Act
            building.SetCurrentState(fromState);
            bool isChanged = building.SetCurrentState(toState);

            //Assert
            Assert.IsFalse(isChanged);
        }

        ////////L2R1
        [TestCase("", "open")]
        [TestCase("sdfsdf", "fire alarm")]
        public void SetCurrentState_InvalidStateTransition_ReturnsFalse(string fromState, string toState)
        {
            //Arrange
            BuildingController building = new BuildingController("B111");
            building.currentState = fromState;

            //Act
            bool isChanged = building.SetCurrentState(toState);

            //Assert
            Assert.IsFalse(isChanged);
        }

        ////////L2R2
        [TestCase("open", "open")]
        [TestCase("out of hours", "out of hours")]
        [TestCase("closed", "closed")]
        [TestCase("fire alarm", "fire alarm")]
        [TestCase("fire drill", "fire drill")]
        public void SetCurrentState_SameCurrentState_ReturnsTrueAndDoesNotChangeCurrentState(string currentState, string toState)
        {
            //Arrange
            BuildingController building = new BuildingController("B123");
            building.currentState = currentState;

            //Act
            bool isChanged = building.SetCurrentState(toState);

            //Assert
            Assert.IsTrue(isChanged);
            Assert.AreEqual(toState, building.currentState); //Checks the state isn't changed to anything else.
        }

        ////////L2R3
        [TestCase("B123")]
        [TestCase("b234")]
        [TestCase("cb123")]
        public void BuildingControllerConstructor_InitialiseBuildingID_ReturnsExpectedBuildingID(string buildingID)
        {
            //Arrange & Act
            BuildingController building = new BuildingController(buildingID, "open");

            //Assert
            Assert.AreEqual(buildingID, building.buildingID);
        }

        ////////L2R3
        [TestCase("closed")]
        [TestCase("out of hours")]
        [TestCase("open")]
        [TestCase("CLOSED")]
        [TestCase("OUT OF HOURS")]
        [TestCase("OPeN")]
        public void BuildingControllerConstructor_InitialiseCurrentState_ReturnsExpectedLowerCaseCurrentState(string state)
        {
            //Arrange
            string buildingID = "B162";
            string desiredCurrentState = state.ToLower();
            //Act
            BuildingController building = new BuildingController(buildingID, state);

            //Assert
            Assert.AreEqual(desiredCurrentState, building.currentState);
        }

        ////////L2R3
        [TestCase("fire drill")]
        [TestCase("fire alarm")]
        [TestCase("closure")]
        public void BuildingControllerConstructor_InvalidValues_ReturnsException(string state)
        {
            //Arrange
            string buildingID = "B123";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new BuildingController(buildingID, state));
        }
 
        ////////L2R3 
        [TestCase("B123", "closed")]
        [TestCase("B231", "open")]
        [TestCase("B342", "out of hours")]
        [TestCase("B123", "CloSeD")]
        [TestCase("B33", "OpEn")]
        public void BuildingControllerConstructor_InitialiseClass_ReturnsBuildingIDandCurrentState(string buildingID, string state)
        {
            //Arrange &
            string desiredCurrentState = state.ToLower();

            //Act
            BuildingController building = new BuildingController(buildingID, state);

            //Assert
            Assert.AreEqual(buildingID, building.buildingID);
            Assert.AreEqual(desiredCurrentState, building.currentState);
        }


        ///////////////////////////////////////////////////////////////////////// Level 3
        ////////L3R1
        [Test]
        public void BuildingControllerConstructor_InitialiseAllDependencies_ReturnsCorrectValues()
        {
            //Arrange
            string buildingID = "B123";
            ILightManager lightManagerStub = Substitute.For<ILightManager>();
            IFireAlarmManager fireAlarmManagerStub = Substitute.For<IFireAlarmManager>();
            IDoorManager doorManagerStub = Substitute.For<IDoorManager>();
            IWebService webServiceStub = Substitute.For<IWebService>();
            IEmailService emailServiceStub = Substitute.For<IEmailService>();

            //Act
            BuildingController building = new BuildingController(buildingID, lightManagerStub, fireAlarmManagerStub, doorManagerStub, webServiceStub, emailServiceStub);

            //Assert
            Assert.AreEqual(buildingID, building.buildingID);
            Assert.AreEqual(lightManagerStub, building.lightManager);
            Assert.AreEqual(fireAlarmManagerStub, building.fireAlarmManager);
            Assert.AreEqual(doorManagerStub, building.doorManager);
            Assert.AreEqual(webServiceStub, building.webService);
            Assert.AreEqual(emailServiceStub, building.emailService);
        }

        ////////L3R1
        [TestCase(true, 12)]
        [TestCase(false, 122)]
        public void BuildingControllerConstructor_ILightManager_CallsSetLightWithCorrectValues(bool isOn, int lightID)
        {
            //Arrange
            string buildingID = "B123";
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, null, null, null, null);

            //Act
            building.lightManager.SetLight(isOn, lightID);

            //Assert
            lightManagerMock.Received(1).SetLight(isOn, lightID);
        }

        ////////L3R1
        [TestCase(true)]
        [TestCase(false)]
        public void BuildingControllerContructor_ILightManager_CallsSetAllLightsWithCorrectValues(bool isOn)
        {
            //Arrange
            string buildingID = "123";
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, null, null, null, null);

            //Act
            building.lightManager.SetAllLights(isOn);

            //Assert
            lightManagerMock.Received(1).SetAllLights(isOn);
        }

        ////////L3R1
        [TestCase(true)]
        [TestCase(false)]
        public void BuildingControllerContstructor_IFireAlarmManager_CallsSetAlarmWithCorrectValues(bool isActive)
        {
            //Arrange
            string buildingID = "B11";
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            BuildingController building = new BuildingController(buildingID, null, fireAlarmManagerMock, null, null, null);

            //Act
            building.fireAlarmManager.SetAlarm(isActive);

            //Assert
            fireAlarmManagerMock.Received().SetAlarm(isActive);
        }

        ////////L3R1
        [TestCase(23)]
        [TestCase(231314)]
        public void BuildingControllerConstructor_IDoorManager_CallsOpenDoorWithCorrectValues(int doorID)
        {
            //Arrange
            string buildingID = "B1231";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController(buildingID, null, null, doorManagerMock, null, null);
            doorManagerMock.OpenDoor(doorID).Returns(true);

            //Act
            bool openAllDoors = building.doorManager.OpenDoor(doorID);

            //Assert
            Assert.IsTrue(openAllDoors);
            doorManagerMock.Received(1).OpenDoor(doorID);
        }

        ////////L3R1
        [TestCase(234)]
        [TestCase(234234)]
        public void BuildingControllerConstructor_IDoorManager_CallsLockDoorWWithCorrectValue(int doorID)
        {
            //Arrange
            string buildingID = "B123";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController(buildingID, null, null, doorManagerMock, null, null);
            
            //Act
            doorManagerMock.LockDoor(doorID).Returns(true);
            bool isDoorLocked = building.doorManager.LockDoor(doorID);

            //Assert
            Assert.IsTrue(isDoorLocked);
            doorManagerMock.Received(1).LockDoor(doorID);
        }

        ////////L3R1
        [TestCase(true)]
        [TestCase(false)]
        public void BuildingControllerConstructor_IDoorManager_CallsOpenAllDoorsWithCorrectValues(bool openAllDoors)
        {
            // Arrange
            string id = "BB21";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController(id, null, null, doorManagerMock, null, null);

            // Act
            doorManagerMock.OpenAllDoors().Returns(openAllDoors);
            bool actual = building.doorManager.OpenAllDoors();

            // Assert
            Assert.AreEqual(openAllDoors, actual);
            doorManagerMock.Received(1).OpenAllDoors();
        }

        ////////L3R1
        [TestCase(true)]
        [TestCase(false)]
        public void BuildingControllerConstructor_IDoorManager_CallsLockAllDoorsWithCorrectValues(bool lockAllDoors)
        {
            // Arrange
            string buidingID = "B1234";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController(buidingID, null, null, doorManagerMock, null, null);

            // Act
            doorManagerMock.LockAllDoors().Returns(lockAllDoors);
            bool allDoorsLocked = building.doorManager.LockAllDoors();

            // Assert
            Assert.AreEqual(allDoorsLocked, lockAllDoors);
            doorManagerMock.Received(1).LockAllDoors();
        }

        ////////L3R1
        [TestCase("smartbuilding@uclan.ac.uk", "failed to log alarm", "exception Message")]
        [TestCase("test@uclan.ac.uk", "log alarm", "message")]
        public void BuildingControllerConstructor_IEmailService_CallsSendMailWithCorrectValues(string emailAddress, string subject, string message)
        {
            // Arrange
            string buildingID = "b12";
            IEmailService emailServiceMock = Substitute.For<IEmailService>();
            BuildingController building = new BuildingController(buildingID, null, null, null, null, emailServiceMock);

            // Act
            building.emailService.SendMail(emailAddress, subject, message);

            // Assert
            emailServiceMock.Received(1).SendMail(emailAddress, subject, message);
        }

        ////////L3R1
        [TestCase("Lights")]
        [TestCase("FireAlarm")]
        public void BuildingControllerConstructor_IWebService_CallsLogStateChangeWithCorrectValues(string state)
        {
            // Arrange
            string buildingID = "B123";
            IWebService webServiceMock = Substitute.For<IWebService>();
            BuildingController building = new BuildingController(buildingID, null, null, null, webServiceMock, null);

            // Act
            building.webService.LogStateChange(state);

            // Assert
            webServiceMock.Received(1).LogStateChange(state);
        }

        ////////L3R1
        [TestCase("Lights,FireAlarm,")]
        [TestCase("FireAlarm,Doors,")]
        public void BuildingControllerConstructor_IWebService_CallsLogEngineerRequiredWithCorrectValues(string logDetails)
        {
            //Arrange
            string buildingID = "B214";
            IWebService webServiceMock = Substitute.For<IWebService>();
            BuildingController building = new BuildingController(buildingID, null, null, null, webServiceMock, null); ;

            //Act
            building.webService.LogEngineerRequired(logDetails);

            //Assert
            webServiceMock.Received(1).LogEngineerRequired(logDetails);
        }

        ////////L3R1
        [TestCase("")]
        [TestCase("fire alarm")]
        public void BuildingControllerConstructor_IWebService_CallsLogFireAlarmWithCorrectValues(string logFireAlarm)
        {
            //Arrange
            string buildingID = "Build123";
            IWebService webServiceMock = Substitute.For<IWebService>();
            BuildingController building = new BuildingController(buildingID, null, null, null, webServiceMock, null);

            //Act
            building.webService.LogFireAlarm(logFireAlarm);

            //Assert
            webServiceMock.Received(1).LogFireAlarm(logFireAlarm);
        }

        ////////L3R2
        [TestCase("Lights,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        [TestCase("Lights,FAULT,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        [TestCase("Lights,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,")]
        public void GetStatus_ILightManager_ReturnsGetStatus(string expectedStatus)
        {
            // Arrange
            string buildingID = "B23";
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, null, null, null, null);
            lightManagerMock.GetStatus().Returns(expectedStatus);

            // Act
            string actualStatus = building.lightManager.GetStatus();

            // Assert
            Assert.AreEqual(expectedStatus, actualStatus);
            lightManagerMock.Received(1).GetStatus();
        }

        ////////L3R2
        [TestCase("FireAlarm,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        [TestCase("FireAlarm,FAULT,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        [TestCase("FireAlarm,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,")]
        public void GetStatus_IFireAlarmManager_ReturnsGetStatus(string expectedStatus)
        {
            //Arrange
            string buildingID = "B123";
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            BuildingController building = new BuildingController(buildingID, null, fireAlarmManagerMock, null, null, null);
            fireAlarmManagerMock.GetStatus().Returns(expectedStatus);

            //Act
            string actualStatus = building.fireAlarmManager.GetStatus();

            //Assert
            Assert.AreEqual(expectedStatus, actualStatus);
            fireAlarmManagerMock.Received(1).GetStatus();
        }

        ////////L3R2
        [TestCase("Doors,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        [TestCase("Doors,FAULT,OK,OK,OK,OK,OK,OK,OK,OK,OK,")]
        [TestCase("Doors,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,")]
        public void GetStatus_IDoorManager_ReturnsGetStatus(string expectedStatus)
        {
            //Arrange
            string buildingID = "B123";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>(); 
            BuildingController building = new BuildingController(buildingID, null, null, doorManagerMock, null, null);
            doorManagerMock.GetStatus().Returns(expectedStatus);
            
            //Act
            string actualStatus= building.doorManager.GetStatus();

            //Assert
            Assert.AreEqual(expectedStatus, actualStatus);
            doorManagerMock.Received(1).GetStatus();
        }

        ////////L3R3
        [TestCase("Lights,OK,OK,OK,OK,OK,OK,OK,OK,OK,OK,", "Doors,OK,OK,OK,OK,OK,OK,OK,OK,", "FireAlarm,OK,OK,OK,OK,OK,OK,")]
        [TestCase("Lights,OK,OK,FAULT,OK,OK,OK,OK,OK,OK,OK,", "Doors,OK,OK,OK,OK,FAULT,OK,OK,OK,", "FireAlarm,FAULT,OK,OK,OK,OK,OK,")]
        [TestCase("Lights,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,", "Doors,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,", "FireAlarm,FAULT,FAULT,FAULT,FAULT,FAULT,FAULT,")]
        public void GetStatusReport_GetStatus_ReturnsExpectedValuesForAllManagers(string lights, string doors, string firealarm)
        {
            // Arrange
            string buildingID = "Bs123";
            ILightManager lightManagerStub = Substitute.For<ILightManager>();
            IDoorManager doorManagerStub = Substitute.For<IDoorManager>();
            IFireAlarmManager fireAlarmManagerStub = Substitute.For<IFireAlarmManager>();
            IWebService webServiceStub = Substitute.For<IWebService>();
            IEmailService emailServiceStub = Substitute.For<IEmailService>();
            BuildingController building = new BuildingController(buildingID, lightManagerStub, fireAlarmManagerStub, doorManagerStub, webServiceStub, emailServiceStub);
            lightManagerStub.GetStatus().Returns(lights);
            doorManagerStub.GetStatus().Returns(doors);
            fireAlarmManagerStub.GetStatus().Returns(firealarm);
            building.currentState = "out of hours";

            // Act
            string expectedStatus = lights + doors + firealarm;
            string actualStatus = building.GetStatusReport();

            // Assert
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        ////////L3R4
        [TestCase("open", "out of hours", "open")]
        [TestCase("open", "fire alarm", "open")]
        [TestCase("open", "fire drill", "open")]
        [TestCase("open", "open", "open")]
        public void SetCurrentState_InvalidTransitionToOpen_ReturnsFalseAndDoesNotChangeCurrentState(string defaulState, string nextState, string toState)
        {
            //Arrange
            string buildingID = "B123";
            IDoorManager doorManagerStub = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController(buildingID, null, null, doorManagerStub, null, null);
            doorManagerStub.OpenAllDoors().Returns(false); //Doesn't open all doors by giving it a false value.
            building.currentState = defaulState; //Sets the currentState as it is not set in the dependency constructor.

            //Act
            building.SetCurrentState(nextState);//Sets the next state from currentState.
            bool isStateChanged = building.SetCurrentState(toState); //Tries to go back to the "open".

            //Assert
            Assert.IsFalse(isStateChanged);
            Assert.AreEqual(nextState, building.currentState);//Doors aren't opened, currentState wouldn't be set to "open".
        }
 
        ////////L3R5
        [TestCase("open", "out of hours", "open")]
        [TestCase("open","fire alarm", "open")]
        [TestCase("open", "fire drill", "open")]
        public void SetCurrentState_ValidTransitionToOpen_CallsOpenAllDoorsOnDoorManager(string defaulState, string nextState, string toState)
        {
            //Arrange
            string buildingID = "B123";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController(buildingID, null, null, doorManagerMock, null, null);
            doorManagerMock.OpenAllDoors().Returns(true); //All doors are opened.
            building.currentState = defaulState; //Sets the currentState as it is not set in the dependency constructor.

            //Act
            building.SetCurrentState(nextState); //Changes to the next state from defaultState.
            bool isStateChanged = building.SetCurrentState(toState); //Tried to back to the "open".

            //Assert
            Assert.IsTrue(isStateChanged);
            Assert.AreEqual(toState, building.currentState); //States will be successfully changed back to the "open".
            doorManagerMock.Received().OpenAllDoors(); // will receive to openalldoors because 
        }

        ////////L3R4 & L3R5
        [TestCase(true)]
        [TestCase(false)] //All doors are not opened.
        public void SetCurrentState_OpenAllDoors_ReturnsTrueIfDoorsOpenedOtherwiseFalse(bool openingdoors)
        {
            // Arrange
            string buildingID = "B234";
            IDoorManager doorManagerStub = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController(buildingID, null, null, doorManagerStub, null, null);
            doorManagerStub.OpenAllDoors().Returns(openingdoors);
            building.currentState = "out of hours";

            // Act
            bool isStateChanged = building.SetCurrentState("open");

            // Assert
            Assert.AreEqual(openingdoors, isStateChanged);
        }

        ///////////////////////////////////////////////////////////////////////// Level 4
        ////////L4R1
        [Test]
        public void SetCurrentState_ClosedState_LocksAllDoorsSuccessfully()
        {
            //Arrange
            string buildingID = "B123";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController(buildingID, null, null, doorManagerMock, null, null);
            doorManagerMock.LockAllDoors().Returns(true);
            building.currentState = "out of hours";
            
            //Act
            building.SetCurrentState("closed");

            //Assert
            doorManagerMock.Received(1).LockAllDoors();
        }

        ////////L4R1
        [Test]
        public void SetCurrentState_ClosedState_SetAllLightsToFalse()
        {
            //Arrange
            string bulidingID = "B321";
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            BuildingController building = new BuildingController(bulidingID, lightManagerMock, null, null, null, null);
            building.currentState = "out of hours";
            
            //Act
            building.SetCurrentState("closed");

            //Assert
            lightManagerMock.Received(1).SetAllLights(false);
        }
        
        ////////L4R1
        [TestCase("out of hours", "closed")]
        [TestCase("closed", "closed")]
        public void SetCurrentState_ClosedState_LockAllDoorsAndSetAllLightsFalseAndCurrentStateIsChanged(string fromState, string toState)
        {
            //Arrange
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            BuildingController buildingController = new BuildingController("B23", lightManagerMock, null, doorManagerMock, null, null);
            doorManagerMock.LockAllDoors().Returns(true);
            buildingController.currentState = fromState;

            //Act
            bool isStateChanged = buildingController.SetCurrentState(toState);

            //Assert
            Assert.IsTrue(isStateChanged);
            doorManagerMock.Received(1).LockAllDoors();
            lightManagerMock.Received(1).SetAllLights(false);
        }

        ////////L4R1 
        [TestCase("out of hours", "open")]
        [TestCase("open", "fire drill")]
        public void SetCurrentState_DoesNotLockDoorsOrTurnOffLights_WhenMovingToStateOtherThanClosed(string defaultState, string toState)
        {
            //Arrange
            string buildingID = "B!23";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, null, doorManagerMock, null, null);
            building.currentState = defaultState;

            //Act
            building.SetCurrentState(toState);

            //Assert
            doorManagerMock.DidNotReceive().LockAllDoors();
            lightManagerMock.DidNotReceive().SetAllLights(false);
        }

        ////////L4R2
        [Test]
        public void SetCurrentState_ValidTransitionToFireAlarmState_CallsSetAlarmCorrectly()
        {
            //Arrange
            string buildingID = "B123";
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            BuildingController building = new BuildingController( buildingID , null, fireAlarmManagerMock, null, null, null);
            building.currentState = "open";
            fireAlarmManagerMock.SetAlarm(true);

            //Act
            building.SetCurrentState("fire alarm");

            //Assert
            fireAlarmManagerMock.Received(1).SetAlarm(true);
        }

        ////////L4R2
        [Test]
        public void SetCurrentState_ValidTransitionToFireAlarmState_CallsOpenAllDoorsCorrectly()
        {
            //Arrange
            string desiredState = "fire alarm";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            BuildingController building = new BuildingController("B23", null, null, doorManagerMock, null, null);
            doorManagerMock.OpenAllDoors().Returns(true);
            building.currentState = "out of hours";
            
            //Act
            building.SetCurrentState(desiredState);

            //Assert
            Assert.AreEqual(desiredState, building.currentState);
            doorManagerMock.Received(1).OpenAllDoors();
        }

        ////////L4R2
        [Test]
        public void SetCurrentState_ValidTransitionToFireAlarmState_SetsAllLightsTrue()
        {
            //Arrange
            string buildingID = "B123";
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, null, null, null, null);
            building.currentState = "out of hours";
            lightManagerMock.SetAllLights(true);
            
            //Act
            building.SetCurrentState("fire alarm");

            //Assert
            lightManagerMock.Received(1).SetAllLights(true);
        }

        ////////L4R2
        [TestCase("open")]
        [TestCase("out of hours")]
        [TestCase("fire drill")]
        public void SetCurrentState_DoesNotCallLockAllDoorsAndSetAllLights_WhenMovingToStateOtherThanFireAlarm(string toState)
        {
            //Arrange
            string buildingID = "B123";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, null, doorManagerMock, null, null);
            building.currentState = "out of hours";

            //Act
            building.SetCurrentState(toState);

            //Assert
            doorManagerMock.DidNotReceive().LockAllDoors();
            lightManagerMock.DidNotReceive().SetAllLights(false);
        }

        ////////L4R2
        [Test]
        public void SetCurrentState_ValidTransitionToFireAlarmState_ReturnTrueAndAllMethodsAreCalledCorrectly()
        {
            //Arrange
            string buildingID = "B123";
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            IWebService webServiceMock = Substitute.For<IWebService>();
            IEmailService emailServiceStub = Substitute.For<IEmailService>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, fireAlarmManagerMock, doorManagerMock, webServiceMock, emailServiceStub);
            fireAlarmManagerMock.SetAlarm(true);
            doorManagerMock.OpenAllDoors().Returns(true);
            lightManagerMock.SetAllLights(true);
            webServiceMock.LogFireAlarm("fire alarm");
            building.currentState = "out of hours";
            
            //Act
            bool isStateChanged = building.SetCurrentState("fire alarm");
            
            //Assert
            Assert.IsTrue(isStateChanged);
            fireAlarmManagerMock.Received().SetAlarm(true);
            doorManagerMock.Received().OpenAllDoors();
            lightManagerMock.Received().SetAllLights(true);
            webServiceMock.Received().LogFireAlarm("fire alarm");
        }

        ////////L4R3
        [Test]
        public void GetStatusReport_WhenLightStatusHasFault_LogEngineerRequiredCalledOnceWithCorrectFaultyDevice()
        {
            //Arrange
            string buildingID = "B123";
            string faultDevice = "Lights,";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            IWebService webServiceMock = Substitute.For<IWebService>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, fireAlarmManagerMock, doorManagerMock, webServiceMock, null);
            doorManagerMock.GetStatus().Returns("OK");
            lightManagerMock.GetStatus().Returns("FAULT");
            fireAlarmManagerMock.GetStatus().Returns("OK");

            //Act
            building.GetStatusReport();

            //Assert
            webServiceMock.Received(1).LogEngineerRequired(faultDevice);
        }

        ////////L4R3
        [Test]
        public void GetStatusReport_WhenFireAlarmStatusReportHasFault_LogEngineerRequiredCalledOnceWithCorrectFaultyDevice()
        {
            //Arrange
            string buildingID = "B123";
            string faultyDevice = "FireAlarm,";
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            IWebService webServiceMock = Substitute.For<IWebService>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, fireAlarmManagerMock, doorManagerMock, webServiceMock, null);
            fireAlarmManagerMock.GetStatus().Returns("FAULT");

            //Act
            string statusReport = building.GetStatusReport();

            //Assert 
            webServiceMock.Received(1).LogEngineerRequired(faultyDevice);
        }
        
        ////////L4R3
        [Test]
        public void GetStatusReport_WhenDoorStatusHasFault_LogEngineerRequiredCalledOnceWithCorrectFaultyDevice()
        {
            // Arrange
            string buildingID = "B4323";
            string faultyDevice = "Doors,";
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            IWebService webServiceMock = Substitute.For<IWebService>();
            BuildingController building = new BuildingController(buildingID, lightManagerMock, fireAlarmManagerMock, doorManagerMock, webServiceMock, null);
            doorManagerMock.GetStatus().Returns("FAULT");
            lightManagerMock.GetStatus().Returns("OK");
            fireAlarmManagerMock.GetStatus().Returns("OK");
            building.currentState = "out of hours";

            // Act
            building.GetStatusReport();

            // Assert
            webServiceMock.Received(1).LogEngineerRequired(faultyDevice);
        }
        
        ////////L4R3
        [Test]
        public void GetStatusReport_WhenMultipleDevicesFault_LogEngineerRequiredCalledOnceWithCorrectFaultyDevices()
        {
            // Arrange
            string buildingID = "B123";
            string faultyDevice = "Lights,Doors,";
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            IWebService webServiceMock = Substitute.For<IWebService>();
            BuildingController buildingController = new BuildingController(buildingID, lightManagerMock, fireAlarmManagerMock, doorManagerMock, webServiceMock, null);

            // Set up device status
            lightManagerMock.GetStatus().Returns("FAULT");
            doorManagerMock.GetStatus().Returns("FAULT");
            fireAlarmManagerMock.GetStatus().Returns("OK");

            // Act
            string statusReport = buildingController.GetStatusReport();

            // Assert
            webServiceMock.Received(1).LogEngineerRequired(faultyDevice);
        }

        ////////L4R3
        [TestCase("OK", "FAULT", "OK", "FireAlarm,")]
        [TestCase("OK", "FAULT", "FAULT", "FireAlarm,Doors,")]
        [TestCase("FAULT", "FAULT", "FAULT", "Lights,FireAlarm,Doors,")]
        public void GetStatusReport_WhenDifferentDeviceStatusIsFault_LogEngineerRequiredCalledOnceWithCorrectFaultyDevices(string lightStatus, string fireAlarmStatus, string doorStatus, string faultyDevice)
        {
            // Arrange
            string buildingID = "BH234";
            ILightManager lightManagerMock = Substitute.For<ILightManager>();
            IDoorManager doorManagerMock = Substitute.For<IDoorManager>();
            IFireAlarmManager fireAlarmManagerMock = Substitute.For<IFireAlarmManager>();
            IWebService webServiceMock = Substitute.For<IWebService>();
            IEmailService emailServiceMock = Substitute.For<IEmailService>();
            lightManagerMock.GetStatus().Returns(lightStatus);
            fireAlarmManagerMock.GetStatus().Returns(fireAlarmStatus);
            doorManagerMock.GetStatus().Returns(doorStatus);
            BuildingController building = new BuildingController(buildingID, lightManagerMock, fireAlarmManagerMock, doorManagerMock, webServiceMock, emailServiceMock);
            building.currentState = "out of hours";

            // Act
            string statusReport = building.GetStatusReport();

            // Assert
            webServiceMock.Received(1).LogEngineerRequired(faultyDevice);
        }

        ////////L4R4
        [Test]
        public void SetCurrentState_ValidStateTransitiontoFireAlarm_LogFireAlarmThrowsExceptionAndSendMailCalledOnce()
        {
            //Arrange
            string buildingID = "B123";
            IDoorManager doorManagerStub = Substitute.For<IDoorManager>();
            ILightManager lightManagerStub = Substitute.For<ILightManager>();
            IWebService webServiceMock = Substitute.For<IWebService>();
            IEmailService emailServiceMock = Substitute.For<IEmailService>();
            IFireAlarmManager fireAlarmManagerStub = Substitute.For<IFireAlarmManager>();
            BuildingController building = new BuildingController(buildingID, lightManagerStub, fireAlarmManagerStub, doorManagerStub, webServiceMock, emailServiceMock);
            doorManagerStub.OpenAllDoors().Returns(true);
            lightManagerStub.SetAllLights(true);
            webServiceMock.When(x => x.LogFireAlarm("fire alarm")).Do(x => throw new Exception("Mock exception"));

            //Act and Assert
            Assert.Throws<Exception>(() => building.SetCurrentState("fire alarm"));
            emailServiceMock.Received(1).SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", "Mock exception");
        }

        ////////L4R4
        [Test]
        public void SetCurrentState_ValidTransitionToFireAlarmState_LogFireAlarmCalledCorrectly()
        {
            // Arrange
            string buildingID = "build123";
            IFireAlarmManager fireAlarmManagerStub = Substitute.For<IFireAlarmManager>();
            IDoorManager doorManagerStub = Substitute.For<IDoorManager>();
            ILightManager lightManagerStub = Substitute.For<ILightManager>();
            IWebService webServiceMock = Substitute.For<IWebService>();
            IEmailService emailServiceStub = Substitute.For<IEmailService>();

            BuildingController building = new BuildingController(buildingID, lightManagerStub, fireAlarmManagerStub, doorManagerStub, webServiceMock, emailServiceStub);
            building.currentState = "out of hours";

            // Act
            webServiceMock.When(x => x.LogFireAlarm("fire alarm")).Throw(new Exception("failed to log alarm"));
            building.SetCurrentState("fire alarm");

            // Assert
            webServiceMock.Received(1).LogFireAlarm("fire alarm");
        }
    }
}