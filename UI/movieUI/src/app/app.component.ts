import { Component, OnInit, Inject } from '@angular/core';
import { MovieAPIModel } from '../models/MovieAPIModel';
import { IMovieService } from '../services/IMovieService';
import { IMovieServiceToken } from '../services/IMovieService-Token';
import { forkJoin } from "rxjs/observable/forkJoin";
import { MovieModel } from '../models/MovieModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  private _movieService: IMovieService;
  movies: MovieModel[];
  isModelReady: boolean = false;
  api: string = "http://markandmovieapi.azurewebsites.net/api/Movie/";

  constructor(
    @Inject(IMovieServiceToken) movieService: IMovieService
  ) {
    this._movieService = movieService;
  }
  ngOnInit(): void {
    this.loadMovies();
  }

  loadMovies() {
    this.isModelReady = false;
    let cinemaWorld = this._movieService.getMovies('cinemaworld');
    let filmworld = this._movieService.getMovies('filmworld');

    forkJoin([cinemaWorld, filmworld])
      .subscribe(results => {
        var cinemaMovies = results[0];
        var filmMovies = results[1];
        this.movies = cinemaMovies.Movies;
        this.addMovies(cinemaMovies.Movies, 'cinemaworld');
        this.addMovies(filmMovies.Movies, 'filmworld');
        this.isModelReady = true;
      });
  }

  addMovies(apiMovies: MovieModel[], source: string) {
    apiMovies.forEach(item => {
      var movie = this.movies.find(x => x.Title == item.Title);
      var detailsLink = this.api + item.ID + "?source=" + source;
      if (movie === null || movie === undefined) {
        if (item.DetailsLink === null || item.DetailsLink === undefined) {
          item.DetailsLink = [];
        }
        item.DetailsLink.push(detailsLink);
        this.movies.push(item);
      }
      else {
        if (movie.DetailsLink === null || movie.DetailsLink === undefined) {
          movie.DetailsLink = [];
        }
        movie.DetailsLink.push(detailsLink);
      }
    });
  }

  title = 'Movies';
}