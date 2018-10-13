import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { PixelSpinnerModule } from 'angular-epic-spinners'
import { AppComponent } from './app.component';
import { IMovieServiceToken } from '../services/IMovieService-Token';
import { MovieService } from '../services/MovieService';
import { MovieComponent } from '../components/movie.component';
import { ProgressBar } from "../components/progress-bar.component";
import { MovieModal } from "../components/movie-modal.component"

@NgModule({
  declarations: [
    MovieComponent,
    MovieModal,
    ProgressBar,
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    PixelSpinnerModule,
    NgbModule.forRoot()
  ],
  providers: [
    {
      provide: IMovieServiceToken,
      useClass: MovieService
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
