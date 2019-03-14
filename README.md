# Geometric Layouts code test

## Test the App

### UI
A running instance of the application is available on https://geometric-layouts.herokuapp.com

### Swagger
Swagger documentation for the application API is available [here](https://geometric-layouts.herokuapp.com/swagger).

### Postman
[This Postman collection](GeometricLayouts.postman_collection.json) contains 2 sample requests to test the API.

## Build and Run
Get the code by direct download or by running this command:

    git clone https://github.com/lbanvillet/GeometricLayouts.git

The application is built with **.NET Core 2.1** and **Angular 7**. The front-end assets have to be generated first and made available in the _wwwroot_ folder.

### Build the front-end assets
**Pre-requisite**: _Node.js_ has to be installed on your machine.
1. Open a command prompt in _<local-repo>/GeometricLayouts/Views_ folder.
2. Run `npm install` to download the project dependencies.
3. Run `ng build --prod` to generate the output files in _wwwroot_ folder.

More details about the Angular project is available [here](GeometricLayouts/Views/README.md).

### Build and run the .NET core app
1. Open a command prompt in _<local-repo>/GeometricLayouts_ folder.
2. Run `dotnet publish -c Release`
3. Navigate to the _publish_folder_: `cd bin/Release/netcoreapp2.1/publish`
4. Run `dotnet GeometricLayouts.dll`
5. Open a browser at http://localhost:5000

## Decisions
I have captured the major choices made throughout the implementation of the coding test and listed them in this section.

### "Get triangle name" operation uses a _POST_
To retrieve a triangle column and row (question 1.B) that I called _name_ to simplify, the request data must contain the triangle coordinates. This data structure is not trivial and query parameters are not suitable. Therefore, even if _GET_ is preferred for read-only operations, I decided to use _POST_ because a request body is needed to send the triangle details and using a request body in _GET_ is not recommended.

### Triangle vertices are ordered
I have made the assumption that vertices are not interchangeable:
* V1 must be the right angle vertex
* V2 is the top left vertex
* V3 is the bottom right vertex.

To allow the service consumer to pass the triangle coordinates in any order, the definition of equality for two triangles would have to be modified. This logic is currently implemented in the _Triangle.Equals()_ function. I usually avoid adding any logic to the models but I did not find a proper workaround. If equality definition had to change, this code could probably move to the service implementation.

### Service implementation
After analysing the test questions, I came up with 2 options to implement the service logic:
* Calculate the triangle coordinates and the triangle name **at runtime**
* At service initialization, generate a **dictionary** containing the coordinates for each triangle name

Because there is **a limited number of triangles**, I thought it would be quicker to retrieve the triangle coordinates for a given name using a dictionary. It also greatly simplifies the implementation.

### UI notes
* As the requirements were open to interpretation around the front-end implementation, I decided to go for an Angular app.
* The design could certainly be enhanced with extra interactions such as tooltips to improve the user experience.
* The automated testing has been reduced to the very minimum with no HTML checks or end-to-end testing.
* To improve the look and feel, the size of the triangles has been multiplied by 10 (100 pixels instead of 10).

### Possible back-end improvements
I had to compromise between code readability and maintenance. I have made architecture decisions I would not necessarily make for a real project because I knew it was not meant to evolve. For this reason, all the SOLID principles were not followed. Here is a list of improvements we could make to get closer to a production-ready application:
* The same objects are used by the REST controller and the services. They should ideally be differentiated.
* The project could be more extensive by introducing a Shape interface the Triangle class would extend.
* The service implementation deals with several concerns. It could be split to follow the single-responsibility principle:
	* The dictionary provisioning could be moved to a data layer and injected in the service.
	* Calculation of coordinates could be delegated to the shape itself.