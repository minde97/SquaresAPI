# SquaresAPI

## Developer Thoughts
API is pretty much done, there can be more improvements regarding validations, more tests, more testing in general and connection with DB and etc. However tried to limiting my time. API is kinda basic, has two controllers. One responsible for CRUD operations, other one for squares. As database was not used in solution, API has one life storage for simplicity, meanining it will lose data when shut down. Tests added for logic of calculating squares as there was not much to test controllers and had to manage time. From what was tested manually API covers "Happy paths", but when I'm starting to think there might be some parts to improve and many edge cases.. But all in all just try it and see for yourself. :)

## API Documentation
To read and understand api go to [Swagger Editor](https://editor.swagger.io/) and import file [SquaresAPI.yaml](../master/SquaresAPI/NSwag/SquaresAPI.yaml)

## Launch application
- In root folder there is compiled binary zipped and named **Release.zip**
- Download compiled binary 
- Extract it
- go to **net7.0** folder
- Execute **SquaresAPI.exe**
- Execute calls to given localhost listening port.
