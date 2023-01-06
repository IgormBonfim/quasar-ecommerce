import { ActivatedRoute } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  constructor(private readonly activatedRoute: ActivatedRoute) {}

  public visibilidade: boolean = false;
  public nome?: string; //Nome do produto

  onKeydown(event: any) {
    if (event.key === 'Enter') {
      console.log(event);
    }
  }

  ngOnInit(): void {
    this.nome = this.activatedRoute.snapshot.queryParams['nome'];
  }
}
