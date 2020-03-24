#    Handle Students


The main project is locate inside **handleStudents/handleStudents** folder.

The unitest of project  is locate inside **handleStudents/HandleStudentUniTest** folder.

The application .exe is locate inside **application** folder.

The unitest .dll is locate inside **test** folder.

## Available commands


In the project directory, you can run:

**Note: this commands only run on CMD and Powershell**

To build the main project:

### `dotnet restore`

### `dotnet build`

To publish the main project to get an executable .exe only after the build the main project

### `dotnet publish -p:Platform=x64`

The executable will be locate inside **handleStudents/HandleStudentUniTest/bin/x64/Debug/netcoreapp3.0** folder.

To run the application

### `.\handleStudents.exe`

To build the unitest of project 

### `dotnet restore`

### `dotnet build`

To publish the unitest of project  to get an executable .exe only after the build the main project

### `dotnet publish -p:Platform=x64`

The executable will be locate inside **handleStudents/handleStudents/bin/Debug/netcoreapp3.0** folder.

To run the test

### `dotnet vstest HandleStudentUniTest.dll`


To run the application with options, you can run the application directly 

only you to go at **application** folder.

Commands:

To run the application without options

### `.\handleStudents.exe`

To run the application with csv file

### `.\handleStudents.exe --input .\MOCK_DATA.csv`

To run the application with csv file and search an student by name

### `.\handleStudents.exe --name caroline --input .\MOCK_DATA.csv`

To run the application with csv file and search an student by type

### `.\handleStudents.exe --type elementary --input .\MOCK_DATA.csv`

To run the application with csv file and search an student by type and gender

### `.\handleStudents.exe --type kinder --gender F --input .\MOCK_DATA.csv`

Also if you dont have a csv file the application have fake students to try the program


To run the test, you can run the test directly

only you to go at **test** folder.

and the following command

### `dotnet vstest HandleStudentUniTest.dll`


