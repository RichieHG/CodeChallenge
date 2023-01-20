# CodeChallenge
In this repo I will publish my code to my Unosquare CodeChallenge

## Repository Pettern
This pattern allow us reuse a single file to Connect to our DB, it means, this pattern use define a unique Process using Generics

## Unit of Work
This pattern group some Repositories to manage them as an Unit of Work, it means, ``` If we have some DataBase requests, we are able to group and senf them at same time```.

In our IUnitOfWork interface we will have an property per each Repository to use.