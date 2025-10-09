# Aoc2ModdingHelper
is a C# console app developing in Visual Studio and existing to help some modding needs for game Age of Civilizations 2 written on Java.

# features
1. you can scan in-game editor made cities (custom cities in map\\%map_name%\data\cities) on information as coordinates, name, city level and width (idk what it is). after scan app can create json file with all scanned cities so you can put this json to map\\%map_name%\cities directory to make cities edit-proof by aoc player. **command: getcitiesinfo/gci**
2. you can create Age_of_Civilizations file for directory. the file has list of all file names in directory (including extensions) separated by ; char. **command: createaoc2file/caf**
3. you can get continents' and continent package's deserialized from java files information. command: **managepackge/mp**
