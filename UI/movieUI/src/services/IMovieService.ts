import { MovieAPIModel } from "../models/MovieAPIModel";
import { Observable } from "rxjs";
import { MovieModel } from "../models/MovieModel";

export interface IMovieService
{
    getMovies(source: string):Observable<MovieAPIModel>
    getMovie(source: string, id: string): Observable<MovieModel>
    get(url:string):Observable<MovieModel>
}