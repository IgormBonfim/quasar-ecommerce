import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FinalizacaoOutrosComponent } from './finalizacao-outros.component';

describe('FinalizacaoOutrosComponent', () => {
  let component: FinalizacaoOutrosComponent;
  let fixture: ComponentFixture<FinalizacaoOutrosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FinalizacaoOutrosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FinalizacaoOutrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
