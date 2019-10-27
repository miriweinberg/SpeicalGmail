import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SymbolsPageComponent } from './symbols-page.component';

describe('SymbolsPageComponent', () => {
  let component: SymbolsPageComponent;
  let fixture: ComponentFixture<SymbolsPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SymbolsPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SymbolsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
