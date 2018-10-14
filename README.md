# Web Jet - Movie Exercise

This repository has 2 projects. 1. WEB API and 2. Movie UI.

## Web API

ASP.NET MVC 5 WEB API 2

API hosted at https://markandmovieapi.azurewebsites.net/swagger

### Libs Used

1. Automapper
2. Newtonsoft.JSON
3. Ninject - DI container
4. RestSharp
5. Swagger


Kept separate models for separate vendor API responses. Makes easy to maintain. If any of these movie vendors updates API response, we only have to make change for that vendor. Rest should work as it is.

## Movie UI

Angular 6

App hosted at https://markandmovies.azurewebsites.net/

### Libs Used

1. Bootstrap
2. app-pixel-spinner

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Run

Run `ng serve` to start the project.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
