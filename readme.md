Notes:


- [ ] Folder structure is not common (not following best practices)
    - [ ] Solution is part of Bootstrap project
        - [ ] [https://blog.jetbrains.com/dotnet/2022/05/11/structure-and-organize-net-projects-with-rider/](https://blog.jetbrains.com/dotnet/2022/05/11/structure-and-organize-net-projects-with-rider/)
        - [ ] [https://learn.microsoft.com/en-us/dotnet/core/porting/project-structure](https://learn.microsoft.com/en-us/dotnet/core/porting/project-structure)
    - [ ] Recommendation:
        - [ ] Make sln part of root folder
        - [ ] create src and tests folders
        - [ ] organize projects accordingly
- [ ] Lack of a README file to describe approaches taken, structure of the project and stack used
- [ ] OnlineLibrary.ConsoleTest??

## Projects Analysis

- [ ] Clean Code analysis
    - [ ] Abstractions
    - [ ] Code references or not used imports
    - [ ] Folder structure within projects not following common practices (Implementations is not indicative of the concrete classes within)
    - [ ] Dependencies are not safe guarded (if dependency was not configured in DI it should raise the problem to avoid NullExceptions)
    - [ ] Async / Await patterns not applied
- [ ] SOLID principles
    - [ ] Single Responsibility Principle
    - [ ] Open / Closed Principle
    - [ ] Liskov Substitution Principle ⚠️
        - [ ] DbContext is not abstracted from a concrete implementation (currently coupled to an OnlineLibraryDBContext which prevents us from choosing another database engine)
        - [ ] Components should be abstracted as interfaces so that they are easily replacable by any other implementatio
    - [ ] Interface Segregation Principle ⚠️
        - [ ] There are some abstractions present which promotes a more decoupled implementation of certain components
        - [ ] However, still room for improvement (DbContext not abstracted)
        - [ ] Separation of interfaces from their implementations
    - [ ] Dependecy Inversion (IOC)
        - [ ] Services are injected as external dependencies
        - [ ] Database configuration is not exposed for further and more flexible configuration

            - [ ] Hard-coded configuration


- [ ]  OnlineLibrary
    - [ ] Notes:
        - [ ] Naming is not indicative of its purpose → choose better naming and follow conventions for microservice like solutions

            - [ ] e.g, OnlineLibrary Solution

                - [ ] Service project


		- [ ] Data context configuration

			- [ ] Missing 


		- [ ] Has Controllers folder ✅

			- [ ] Controllers are well named ✅

			- [ ] Route directive ✅

			- [ ] ApiController directive ✅

			- [ ] ControllerBase Implementation ✅

			- [ ] Responses and Error Handling

				- [ ] Returning HttpActionResult ❌

				- [ ] Returning valid Responses ⚠️

				- [ ] Swagger enriched with appropriate metadata ⚠️

					- [ ] Only success metadata

					- [ ] Should include


- [ ]  Repositories
    - [ ] Not implementing generic approach with similar methods (duplicate code)
    - [ ] Not making use of async / await pattern (this is a huge downside since it's making all communication between database and service synchronous and not making use of machine resources while query is being performed for other jobs)
    - [ ] Only a single method for Create and Update operations (Single-Responsibility principle violation)
    - [ ] Naming of folders not following conventions
