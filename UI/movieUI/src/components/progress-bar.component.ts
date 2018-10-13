import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'progressbar',
  templateUrl: './progress-bar.component.html',
  styles: [`
    ngb-progressbar {
      margin-top: 5rem;
    }
  `]
})
export class ProgressBar implements OnInit {
  ngOnInit(): void {
    this.text = this.value;
    this.value = this.value * 100 / this.maxValue;
  }
  @Input() value: number
  @Input() maxValue: number
  text: number;
}
