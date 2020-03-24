# Module 3 Capstone - National Park Weather Service

For this pair programming capstone project, we developed a dynamic web application using ASP .NET. It employed MVC design principles and used HTML, CSS, C#, and integrated with a SQL database for the park data. The project called for getting the weather from a database, but I made it so it pulls from the National Weather Service API instead.

## Screenshots of the application
 ###  **Home page**
 Displays parks that are in the database

![HomePage](https://github.com/amygurski/National-Park-Weather-Service/blob/master/img/HomePage.png)

 ###  **Detail page**
 The detail page display all of the information for the park from the database

![DetailPage](https://github.com/amygurski/National-Park-Weather-Service/blob/master/img/ParkDetails.PNG)

 ###  **Weather Forecast**
 The 5 day weather forecast is getting pulled from the National Weather Service API. It also allows the user to change temperature units and stores the units in session.

![WeatherForecast](https://github.com/amygurski/National-Park-Weather-Service/blob/master/img/Weather.PNG)

 ###  **Survey**
 Includes user validation

![Survey](https://github.com/amygurski/National-Park-Weather-Service/blob/master/img/Survey.PNG)

 ###  **Survey Results**
 Completing the survey redirects to the survey results
 
![SurveyResults](https://github.com/amygurski/National-Park-Weather-Service/blob/master/img/SurveyResults.PNG)

## Requirements

1. As a user of the system, I need the ability to view a list of all national parks from the home page.
    a. The home page should only show a picture of the park, its name, location, and a short summary.
2. As a user of the system, I need the ability select a park and view additional details about the selected park. All detail described in the Park Data Source needs to be displayed.
3. As a user of the system, once I select a park for viewing I have a way of viewing its 5-day weather
    forecast. Each daily forecast should provide a recommendation so that the user knows how to prepare for the weather appropriately.
       a. This may be on the same page as the park detail or on a separate page.
       b. The forecast for each park can be obtained from the Weather Forecast database table.
       c. If the daily forecast calls for snow, then tell the user to pack snowshoes.
       d. If the daily forecast calls for rain, then tell the user to pack rain gear and wear waterproof shoes.
       e. If the daily forecast calls for thunderstorms, tell the user to seek shelter and avoid hiking on
          exposed ridges.
       f. If the daily forecast calls for sun, tell the user to pack sunblock.
       g. If the temperature is going to exceed 75 degrees, tell the user to bring an extra gallon of water.
       h. If the difference between the high and low temperature exceeds 20 degrees, tell the user to wear breathable layers.
       i. If the temperature is going to be below 20 degrees, make sure to warn the user of the dangers of exposure to frigid temperatures.
4. As a user of the system, I need the ability to change my temperature preference to Celsius or Fahrenheit. My choice should be remembered while browsing the rest of the website.
5. As a user of the system, I need the ability to participate in the daily survey.
    a.  Today’s survey will ask the user to vote on their favorite national park. In additional to selecting a park, they must enter values for a few required fields.
    b. E-mail address, state of residence, and physical activity level (inactive, sedentary, active, extremely active).
    c. Once the survey has been submitted and permanently saved for record, the user is redirected to the survey results page where they see which park leads amongst all survey takers.

## Data Sources

Your application will have access to the following sources of data:

### Daily Weather File

A daily weather table is provided to the system that provides weather forecast data for the next 5 days. 

### Park Data File

A park data table contains information about each park. 

### Park Codes

Each park has been assigned a unique park code.

