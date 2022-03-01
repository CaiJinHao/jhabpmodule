import { Component, OnInit } from '@angular/core';
import { JhMenuService } from '../services/jh-menu.service';

@Component({
  selector: 'lib-jh-menu',
  template: ` <p>jh-menu works!</p> `,
  styles: [],
})
export class JhMenuComponent implements OnInit {
  constructor(private service: JhMenuService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
