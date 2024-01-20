import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'ngx-chartjs',
  styleUrls: ['./chartjs.component.scss'],
  templateUrl: './chartjs.component.html',
})
export class ChartjsComponent {
  @Output() periodChange = new EventEmitter<string>();

  @Input() type: string = 'week';

  types: string[] = ['week', 'month', 'year'];
  
  changePeriod(period: string): void {
    this.type = period;
    this.periodChange.emit(period);
    console.log(period);
  }
}

