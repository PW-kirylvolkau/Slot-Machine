# Slot machine 

Lab task from the "HTML to PostGIS" subject (1.5h given).

### Technologies used:
* ASP.NET Core 5
* Swagger 
* EF Core (In memory db)
* Vanilla js
* Bootstrap

### Endpoints
| **Endpoint**           | **Method** | **Info**                                                                 | **Mapping**                |
|------------------------|------------|--------------------------------------------------------------------------|----------------------------|
| slotmachine/firstdraw  | `GET`      | Returns one of three results with hardcoded probability.                 | none -> `text/plain`       |
| slotmachine/seconddraw | `GET`      | Returns one of three results with hardcoded probability.                 | none -> `text/plain`       |
| slotmachine/thirddraw  | `GET`      | Returns one of three results with hardcoded probability.                 | none -> `text/plain`       |
| slotmachine/results    | `GET`      | Returns all results from the DB.                                         | none -> `application/json` |
| slotmachine/saveresult | `POST`     | Create new result (will result in error if all the draws are different). | `application/json` -> none |

### Workflow
You press `Draw!` button and it calls all three API points connected with draws (you can get *APPLE*, *BANANA*, *PLUM*). The button is disabled untill all three results are ready (using `fetch` api and `Promice.all`) and after that they are all simultaneously displayed. If there is at least two similar slots drawn then the whole result is stored in the database and the table below the button is updated.