# SchoolManagementSystem

This is a project built for the enterprise systems module of my degree apprenticeship. I was restricted from using some already existing systems so I needed to develop my own version. The systems I developed include:

- Client-server networking through a custom protocol
- Multithreading functions that need to run separate from other code
- Mocking a database

## Functionality

- Client-server networking
- Separate clients for teachers and parents
- Teachers can add classes
- Parents can join classes using a code set by the teacher
- Teachers can assign grades that are revealed when the end date for the class is reached
- Parents can message teachers of classes they are part of
- Teachers can broadcast messages to all parents in a class

To test releasing grades when a class is finished, the teacher client can also set the simulated date.

## Requirements

- Visual Studio 2022
- .Net 6 support

## How to run

1. Open SchoolmanagementSystem.sln file in Visual Stuio.
2. From the menu at the top, select Build > Build Solution
3. Find the Server.exe file in SOLUTION_FOLDER/Server/bin/Debug/net6.0 and run it to start the server (The server must be running for the clients to function properly)
4. Find the ParentClient.exe file in SOLUTION_FOLDER/ParentClient/bin/Debug/net6.0 and run it to start a parent client
5. Find the TeacherClient.exe file in SOLUTION_FOLDER/TeacherClient/bin/Debug/net6.0 and run it to start a teacher client

If running from Visual Studio, select the server and both client projects to be run as startup projects in the solution properties.

### Test logins

There are 2 users of each type already created.

Teacher:
| Username | Password |
|----------|----------|
| Teacher1 | 1234     |
| Teacher2 | 12345    |

Parent:
| Username | Password |
|----------|----------|
| Parent1  | 1234     |
| Parent2  | 12345    |

## Running tests

1. Open SchoolmanagementSystem.sln file in Visual Stuio.
2. From the menu at the top, select Test > Run All Tests
