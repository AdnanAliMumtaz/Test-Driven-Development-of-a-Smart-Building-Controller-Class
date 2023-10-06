namespace SmartBuilding
{
    public class BuildingController
    {
        public string buildingID;
        public string currentState;
        public string history;
        public bool isSetState;
        public ILightManager lightManager;
        public IFireAlarmManager fireAlarmManager;
        public IDoorManager doorManager;
        public IWebService webService;
        public IEmailService emailService;

        //Constructor 1
        public BuildingController(string id)
        {
            if (id == null) //Defensive programming to accept null values.
            {
                buildingID = id;
            }
            else
            {
                buildingID = id.ToLower();
            }
           
            //Sets the currentState to default value.
            currentState = "out of hours"; 
        }
        
        public string GetBuildingID()
        {
            return buildingID;
        }
        
        public void SetBuildingID(string id)
        {
            if (id == null) //Defensive programming to accept null values.
            {
                buildingID = id; 
            }
            else
            {
                buildingID = id.ToLower();
            }
        }
  
        public string GetCurrentState()
        {
            return currentState;
        }

        public bool SetCurrentState(string state)
        {
            //Normal Operation State Transitioning
            if (state == "open" && currentState == "out of hours")
            {
                //Statements allow the Level 2 normal and Level 3 stub and mock unit tests to work simultaneously.
                if (doorManager == null)
                {
                    currentState = state;
                    isSetState = true;
                }
                else if (doorManager != null && doorManager.OpenAllDoors()) //Checks if the doorManager has been initialised.
                {
                    isSetState = true;
                    currentState = state;
                }
                else
                {
                    isSetState = false;
                }
            }
            else if (state == "out of hours" && currentState == "open")
            {
                isSetState = true;
                currentState = state;
            }
            else if (state == "closed" && currentState == "out of hours")
            {
                //Statements allow the Level 2, 4 unit tests to work simultaneously.
                if (doorManager != null && lightManager != null)
                {
                    isSetState = true;
                    currentState = state;
                    doorManager.LockAllDoors();
                    lightManager.SetAllLights(false);
                }
                else if (doorManager != null && lightManager == null)
                {
                    isSetState = true;
                    currentState = state;
                    doorManager.LockAllDoors();
                }
                else if (lightManager != null && doorManager == null)
                {
                    isSetState = true;
                    currentState = state;
                    lightManager.SetAllLights(false);
                }
                else if (doorManager == null && lightManager == null)
                {
                    isSetState = true;
                    currentState = state;
                }
            }
            else if (state == "out of hours" && currentState == "closed")
            {
                isSetState = true;
                currentState = state;
            }

            // SuperState Transitionings
            //Checks "fire alarm" state can not be set from "fire drill" and any other states except the ones mentioned in the brief.
            else if (state == "fire alarm" && currentState != "fire drill" && (currentState == "open" || currentState == "out of hours" || currentState == "closed"))
            {
                //Statements allow the Level 2,4 unit tests to work simultaneously.
                if (fireAlarmManager == null && doorManager == null && lightManager == null && webService == null)
                {
                    history = currentState;
                    currentState = state;
                    isSetState = true;
                }
                else if (fireAlarmManager != null && doorManager != null && lightManager != null && webService != null)
                {
                    history = currentState;
                    currentState = state;
                    isSetState = true;
                    fireAlarmManager.SetAlarm(true);
                    doorManager.OpenAllDoors();
                    lightManager.SetAllLights(true);
                    try
                    {
                        webService.LogFireAlarm("fire alarm");
                    }
                    catch (Exception exception)
                    {
                        string message = exception.Message;
                        emailService.SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", message);
                    }
                }                
                else if (doorManager != null)
                {
                    history = currentState;
                    currentState = state;
                    isSetState = true;
                    doorManager.OpenAllDoors();
                }
            }
            //Checks "fire drill" state can not be set from "fire alarm" and any other states except the ones mentioned in the brief.
            else if (state == "fire drill" && currentState != "fire alarm" && (currentState == "open" || currentState == "out of hours" || currentState == "closed"))
            {
                history = currentState;
                currentState = state;
                isSetState = true;
            }
            //Checks the state goes back to the history state (one of the Normal Operation states) from where it transitioned into "fire alarm" or "fire drill".
            else if (state == history && (currentState == "fire alarm" || currentState == "fire drill"))
            {
                //Statements allow the Level 2,3 and 4 unit tests to work simultaneously.
                if (state == "open")
                {
                    if (doorManager == null)
                    {
                        currentState = state;
                        isSetState = true;
                    }
                    else if (doorManager != null && doorManager.OpenAllDoors()) //Checks if the doorManager has been initialised.
                    {
                        isSetState = true;
                        currentState = state;
                    }
                    else
                    {
                        isSetState = false;
                    }
                }
                else if (state == "closed")
                {
                    //Statements allow the Level 2, 4 unit tests to work simultaneously.
                    if (doorManager != null && lightManager != null)
                    {
                        isSetState = true;
                        currentState = state;
                        doorManager.LockAllDoors();
                        lightManager.SetAllLights(false);
                    }
                    else if (doorManager != null && lightManager == null)
                    {
                        isSetState = true;
                        currentState = state;
                        doorManager.LockAllDoors();
                    }
                    else if (lightManager != null && doorManager == null)
                    {
                        isSetState = true;
                        currentState = state;
                        lightManager.SetAllLights(false);
                    }
                    else if (doorManager == null && lightManager == null)
                    {
                        isSetState = true;
                        currentState = state;
                    }
                }
                else { 
                    currentState = state;
                    isSetState= true;
                }
            }
            //Checks if the user attempts to move to the present value of the state.
            else if (state == currentState)
            { 
                if (state == "open")
                {
                    if (doorManager == null)
                    {
                        isSetState = true;
                    }
                    else if (doorManager != null && doorManager.OpenAllDoors()) //Checks if the doorManager has been initialised.
                    {
                        isSetState = true;
                    }
                    else
                    {
                        isSetState = false;
                    }
                }
                else if (state == "closed")
                {
                    //Statements allow the Level 2, 4 unit tests to work simultaneously.
                    if (doorManager != null && lightManager != null)
                    {
                        isSetState = true;
                        currentState = state;
                        doorManager.LockAllDoors();
                        lightManager.SetAllLights(false);
                    }
                    else if (doorManager != null && lightManager == null)
                    {
                        isSetState = true;
                        currentState = state;
                        doorManager.LockAllDoors();
                    }
                    else if (lightManager != null && doorManager == null)
                    {
                        isSetState = true;
                        currentState = state;
                        lightManager.SetAllLights(false);
                    }
                    else if (doorManager == null && lightManager == null)
                    {
                        isSetState = true;
                        currentState = state;
                    }
                }
                else if (state == "fire alarm")
                {
                    //Statements allow the Level 2, 4 unit tests to work simultaneously.
                    if (fireAlarmManager == null && doorManager == null && lightManager == null && webService == null)
                    {
                        isSetState = true;
                    }
                    else if (fireAlarmManager != null && doorManager != null && lightManager != null && emailService != null && webService != null)
                    {
                        isSetState = true;
                        fireAlarmManager.SetAlarm(true);
                        doorManager.OpenAllDoors();
                        lightManager.SetAllLights(true);
                        try
                        {
                            webService.LogFireAlarm("fire alarm");
                        }
                        catch (Exception exception)
                        {
                            string message = exception.Message;
                            emailService.SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", message);
                        }
                    }
                    else if (doorManager != null)
                    {
                        history = currentState;
                        currentState = state;
                        isSetState = true;
                        doorManager.OpenAllDoors();
                    }

                }
                else
                {
                    isSetState = true;
                }
            }
            else // If the state isn't right or its transitioning is wrong, false is returned.
            {
                isSetState = false;
            }
            return isSetState;   
        }

        //Constructor 2
        public BuildingController(string id, string startState)
        {
            buildingID = id;
            startState = startState.ToLower();

            // if the startstate is not any of these three, exception is thrown.
            if (startState == "closed" || startState == "out of hours" || startState == "open")
            {
                currentState = startState.ToLower();
            }
            else
            {
                throw new ArgumentException("Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'");
            }
        }

        //Dependency Injection Constructor (Constructor 3)
        public BuildingController(string id, ILightManager iLightManager, IFireAlarmManager iFireAlarmManager, IDoorManager iDoorManager, IWebService iWebService, IEmailService iEmailService)
        {
            buildingID = id;
            lightManager = iLightManager;
            fireAlarmManager = iFireAlarmManager;
            doorManager = iDoorManager;
            webService = iWebService;
            emailService = iEmailService;
        }

        
        public string GetStatusReport()
        { 
            string faultyDevice = "";
            string statusReport = "";

            //Calling GetStatus() for all the managers and storing returned strings. 
            string lightStatus = lightManager.GetStatus();
            string doorStatus = doorManager.GetStatus();
            string fireAlarmStatus = fireAlarmManager.GetStatus();
            
            //Checks any device that contains the fault and adds to the faultyDevice variable.
            if (lightStatus.Contains("FAULT"))
            {
                faultyDevice += "Lights,";
            }
            
            if (fireAlarmStatus.Contains("FAULT"))
            {
                faultyDevice += "FireAlarm,";
            }

            if (doorStatus.Contains("FAULT"))
            {
                faultyDevice += "Doors,";
            }

            //If the faultyDevice isn't empty, LogEngineerRequried() is sent the report of the device having fault. 
            if (faultyDevice != "")
            {
                webService.LogEngineerRequired(faultyDevice);
            }

            //Appending the returned string into the statusReport in the order.
            statusReport = lightStatus + doorStatus + fireAlarmStatus;

            return statusReport;
        }
    }
}