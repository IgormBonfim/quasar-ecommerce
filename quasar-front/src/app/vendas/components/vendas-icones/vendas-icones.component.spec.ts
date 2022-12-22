import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendasIconesComponent } from './vendas-icones.component';

describe('VendasIconesComponent', () => {
  let component: VendasIconesComponent;
  let fixture: ComponentFixture<VendasIconesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendasIconesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendasIconesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
