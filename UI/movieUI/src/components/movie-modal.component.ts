import { Component, Input } from '@angular/core';

import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { MovieModel } from '../models/MovieModel';


@Component({
    selector: 'movie-modal',
    templateUrl: './movie-modal.component.html'
})
export class MovieModal {
    closeResult: string;
    @Input() movie: MovieModel

    constructor(private modalService: NgbModal) { }

    open(content) {
        this.modalService.open(content, {
            size: 'lg',
            ariaLabelledBy: 'modal-basic-title'
        }).result.then((result) => {
            this.closeResult = `Closed with: ${result}`;
        }, (reason) => {
            this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        });
    }

    private getDismissReason(reason: any): string {
        if (reason === ModalDismissReasons.ESC) {
            return 'by pressing ESC';
        } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
            return 'by clicking on a backdrop';
        } else {
            return `with: ${reason}`;
        }
    }
}