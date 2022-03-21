import { Component, OnInit } from '@angular/core';
import { YourProjectNameService } from '../services/your-project-name.service';

@Component({
  selector: 'lib-your-project-name',
  template: ` <p>your-project-name works!</p> `,
  styles: [],
})
export class YourProjectNameComponent implements OnInit {
  constructor(private service: YourProjectNameService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
