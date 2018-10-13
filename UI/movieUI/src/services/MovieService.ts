import { IMovieService } from "./IMovieService";
import { MovieAPIModel } from "../models/MovieAPIModel";
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { MovieModel } from "../models/MovieModel";


@Injectable()
export class MovieService implements IMovieService {
    constructor(private http: HttpClient) {

    }
    getMovies(source: string): Observable<MovieAPIModel> {
        var url = "http://markandmovieapi.azurewebsites.net/api/Movie?source=" + source;
        return this.http.get<MovieAPIModel>(url);
    }

    getMovie(source: string, id: string): Observable<MovieModel> {
        var url = "http://markandmovieapi.azurewebsites.net/api/Movie/" + id + "?source=" + source;
        return this.http.get<MovieModel>(url);
    }

    get(url:string):Observable<MovieModel>
    {
        return this.http.get<MovieModel>(url);
    }
}