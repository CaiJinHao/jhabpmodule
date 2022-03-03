import { Component, OnInit } from '@angular/core';
import { JhPermissionService } from '../services/jh-permission.service';

@Component({
  selector: 'lib-jh-permission',
  template: ` <p>jh-permission works!</p> `,
  styles: [],
})
export class JhPermissionComponent implements OnInit {
  constructor(private service: JhPermissionService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
