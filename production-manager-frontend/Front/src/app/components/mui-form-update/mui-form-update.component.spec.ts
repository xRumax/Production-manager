import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MuiFormUpdateComponent } from './mui-form-update.component';

describe('MuiFormUpdateComponent', () => {
  let component: MuiFormUpdateComponent;
  let fixture: ComponentFixture<MuiFormUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MuiFormUpdateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MuiFormUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
