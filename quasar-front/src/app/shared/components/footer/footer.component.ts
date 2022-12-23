import { Component, OnInit } from '@angular/core';
import { faTwitter, faFacebook, faInstagram } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  iconeTwitter = faTwitter;
  iconeFacebook = faFacebook;
  iconeInstagram = faInstagram;

  constructor() { }

  ngOnInit(): void {
  }

}
