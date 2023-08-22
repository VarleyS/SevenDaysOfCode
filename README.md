# 7Days Of Code - C#
<div align="center">
  
![Screenshot of a comment on a GitHub issue showing an image, added in the Markdown, of an Octocat smiling and raising a tentacle.](https://7daysofcode.io/assets/img/background-7days.1691614118.svg)

</div>

## Project Summary:

Consume the PokéAPI (Pokémon API) utilizing just C# language, list the Pokémons and allows the user to chooes a Pokémon for adoption.

## Stack:

* **C# Language** 

* **.Net Framework**

* **PokéAPI**

* **Json**

## Day 1:

* **Create C# code to execte the HTTP GET request.**

* **Catch the Json from the request.**

* **Print the Json on the console.**

Using just the library Rest Sharp was made a request to the PokéAPI and cached the list of Pokémons Json:

![Screenshot of a comment on a GitHub issue showing an image, added in the Markdown, of an Octocat smiling and raising a tentacle.](https://github.com/VarleyS/SevenDaysOfCode/blob/master/SevenDaysOfCode/img/Captura%20de%20tela%202023-08-16%20165332.png?raw=true)

## Day 2:

* **Parse the Json response and extract each Pokémon info.**

* **Show the organized information on the console.**

The Json was parsed with the System.Text.Json and the class Mascote and class Ability was created to represent a Pokémon entity.

![Screenshot of a comment on a GitHub issue showing an image, added in the Markdown, of an Octocat smiling and raising a tentacle.](https://github.com/VarleyS/SevenDaysOfCode/blob/master/SevenDaysOfCode/img/day2.png?raw=true)

## Day 3:

* **Create an interactive menu and allow user to view your current mascots, choose an mascot to adopt and exit the app.**

Created Menu class providing user interaction and options to adopt a mascot, view its information and exit the menu.

![Screenshot of a comment on a GitHub issue showing an image, added in the Markdown, of an Octocat smiling and raising a tentacle.](https://github.com/VarleyS/SevenDaysOfCode/blob/master/SevenDaysOfCode/img/Dia%203.png?raw=true)

## Day 4:

* ** Organize the project source files in the MVC (Model view controller) standart.

The application was divided into classes according to Mvc:
Model = Ability, Mascote, Pokemon
View = Menu
Controller = TamagotchiController

## Day 5:

## Day 6:

## Day 7:
