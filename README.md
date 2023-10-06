# Test-Driven-Development-of-a-Smart-Building-Controller-Class
This GitHub repository contains the source code and documentation for the "Smart Building Controller" project, an individual assignment completed for UCLan. The project focuses on creating a custom-written object-oriented application in C# to control and manage the doors, lights, and fire alarm systems in a smart building. The application follows a test-driven development approach and includes unit tests using the NUnit 3 framework.

## Project Overview
The goal of this project is to create a **'BuildingController'** class responsible for managing various smart systems within a building. The **'BuildingController'** communicates with three different dependencies: **'LightManager'**, **'DoorManager'**, and **'FireAlarmManager'**. Additionally, it logs changes to the building's state to an online web service and sends maintenance emails as needed through communication with a **'WebService'** object and an **'EmailService'** object.

## Project Structure
This project consists of the following components:

- **'BuildingController.cs'**: The main class responsible for managing the smart systems and interacting with the dependencies.
- **'BuildingControllerTests.cs'**: Contains unit tests for the BuildingController class, with each test corresponding to a specific requirement (see comments in the test methods).
- Interface files for each of the five dependencies:
     - **'IDoorManager.cs'**
     - **'ILightManager.cs'**
     - **'IFireAlarmManager.cs'**
     - **'IWebService.cs'**
     - **'IEmailService.cs'**


## Getting Started
To get started with this project, follow these steps:

1. Clone the repository to your local machine:
```
git clone https://github.com/your-username/smart-building-controller.git

```
2. Open the project in your preferred C# development environment (e.g., Visual Studio).

3. Implement the **'BuildingController'** class and the required dependencies (**'LightManager'**, **'DoorManager'**, **'FireAlarmManager'**, **'WebService'**, **'EmailService'**) according to the specifications provided in Appendices A and B.

4. Write unit tests for the **'BuildingController'** class in the **'BuildingControllerTests.cs'** file following the test requirements specified in the comments.

5. Ensure that the method signatures in the interface files (**'IDoorManager.cs'**, **'ILightManager.cs'**, **'IFireAlarmManager.cs'**, **'IWebService.cs'**, **'IEmailService.cs'**) match the specifications in Appendices A and B.

## Appendix A - BuildingController Class Structure
For details about the structure and possible states of the **'BuildingController'** class, please refer to Appendix A in the project specification.

## Appendix B - Requirements
The requirements for implementing the **'BuildingController'** class and its unit tests are provided in Appendix B of the project specification.

## Contributing
Contributions to this project are not expected as it is an individual assignment. However, if you encounter any issues or have suggestions, please feel free to open an issue in this repository.

## License
This project is provided under the [MIT License](https://choosealicense.com/licenses/mit/).

