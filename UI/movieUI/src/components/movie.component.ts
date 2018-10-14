import { Component, OnInit, Input, Inject } from "@angular/core";
import { IMovieService } from '../services/IMovieService';
import { IMovieServiceToken } from '../services/IMovieService-Token';
import { MovieModel } from "../models/MovieModel";

@Component({
    selector: 'movie',
    templateUrl: './movie.component.html',
})
export class MovieComponent implements OnInit {
    @Input() movie: MovieModel;
    isMovieModelReady: boolean = false;
    movieDetail: MovieModel;
    filmWorldPrice: number = -1;
    cinemaWorldPrice: number = -1;
    private _movieService: IMovieService;

    constructor(
        @Inject(IMovieServiceToken) movieService: IMovieService
    ) {
        this._movieService = movieService;
    }

    setCinemaWorldPrice(price: number) {
        this.cinemaWorldPrice = price;
    }

    setFilmWorldPrice(price: number) {
        this.filmWorldPrice = price;
    }

    ngOnInit(): void {
        this.isMovieModelReady = false;
        this.movie.DetailsLink.forEach((item) => {
            var get = this._movieService.get(item)
            if (item.indexOf('cinemaworld') !== -1) {
                get.subscribe(data => {
                    if (data !== null && data !== undefined && data.Price !== null && data.Price !== undefined) {
                        var price = parseFloat(data.Price);
                        this.setCinemaWorldPrice(price);
                        if (this.movieDetail === null || this.movieDetail === undefined)
                            this.movieDetail = data;
                    }
                });
            }
            else {
                get.subscribe(data => {
                    if (data !== null && data !== undefined && data.Price !== null && data.Price !== undefined) {
                        var price = parseFloat(data.Price);
                        this.setFilmWorldPrice(price);
                        if (this.movieDetail === null || this.movieDetail === undefined)
                            this.movieDetail = data;
                    }
                });
            }
            this.isMovieModelReady = true;
        })
    }
}