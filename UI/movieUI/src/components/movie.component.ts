import { Component, OnInit, Input, Inject } from "@angular/core";
import { MovieAPIModel } from "../models/MovieAPIModel";
import { IMovieService } from '../services/IMovieService';
import { IMovieServiceToken } from '../services/IMovieService-Token';
import { MovieModal } from "./movie-modal.component";
import { MovieModel } from "../models/MovieModel";

@Component({
    selector: 'movie',
    templateUrl: './movie.component.html',
})
export class MovieComponent implements OnInit {
    @Input() movie: MovieModel;
    movieDetail: MovieModel;
    filmWorldPrice: string;
    cinemaWorldPrice: string;
    private _movieService: IMovieService;

    constructor(
        @Inject(IMovieServiceToken) movieService: IMovieService
    ) {
        this._movieService = movieService;
    }

    setCinemaWorldPrice(price: string) {
        this.cinemaWorldPrice = price;
    }

    setFilmWorldPrice(price: string) {
        this.filmWorldPrice = price;
    }

    ngOnInit(): void {
        this.movie.DetailsLink.forEach((item) => {
            var get = this._movieService.get(item)
            if (item.indexOf('cinemaworld') !== -1) {
                get.subscribe(data => {
                    if (data.Price !== null || data.Price !== undefined) {
                        this.setCinemaWorldPrice(data.Price);
                        if (this.movieDetail === null || this.movieDetail === undefined)
                            this.movieDetail = data;
                    }
                });
            }
            else {
                get.subscribe(data => {
                    if (data.Price != null || data.Price != undefined) {
                        this.setFilmWorldPrice(data.Price);
                        if (this.movieDetail === null || this.movieDetail === undefined)
                            this.movieDetail = data;
                    }
                });
            }
        })
    }
}