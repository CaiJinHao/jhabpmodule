import { Component, OnInit } from '@angular/core';
import { JhIdentityService } from '../services/jh-identity.service';

@Component({
  selector: 'lib-jh-identity',
  template: ` <p>jh-identity works!</p> `,
  styles: [],
})
export class JhIdentityComponent implements OnInit {
  constructor(private service: JhIdentityService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
