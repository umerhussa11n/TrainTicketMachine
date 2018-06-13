This application is to allow the searching the train stations.
It is created as a winform project as this would have to be installed on a machine.
As it was not required at this stage to implement the User interface hence the controls in Form are not all functional.
There is only LoadStation Button on the form which loads the stations from a xml file.
Most of the functionality is tested using the tests cases writen for the funcationality.
Strategy design pattern is used to have multiple algorithms doing the search, this could be used to analyse algorithms for runtime performance.
(this makes the application scaleable and flexible for further approaches if in future perforamnce is to be enhanced even further.)

Application reads the list of stations before the search so search is from list in memory and not from external file which will make the search quicker.

As there is no user interface implemented at this stage hence a setup project has not been added for installation.