import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent implements OnInit {

  @Input() type: string;
  @Input() message: string;
  @Input() time: number;

  constructor() { }

  ngOnInit() {
    
    // setTimeout(() => {
    //   this.type = null;
    // }, this.time || 9000);
  }
}
