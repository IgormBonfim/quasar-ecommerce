import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  constructor(private readonly router: Router) {}

  public visibilidade: boolean = false;
  public pesquisa?: string;

  onKeydown(event: any) {
    if (event.key === 'Enter') {
      this.router.navigate(['/produtos'], {
        queryParams: { search: this.pesquisa },
      });
    }
  }

  ngOnInit(): void {}
}
