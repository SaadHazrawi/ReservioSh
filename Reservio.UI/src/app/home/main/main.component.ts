import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'ngx-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  ngOnInit(): void {
    console.log('1');
  }

}
