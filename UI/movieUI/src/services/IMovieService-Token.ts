import { InjectionToken } from "@angular/core";
import { IMovieService } from "./IMovieService";

export let IMovieServiceToken = new InjectionToken<IMovieService>("IMovieService");