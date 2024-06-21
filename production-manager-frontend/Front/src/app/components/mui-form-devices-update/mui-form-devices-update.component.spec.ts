import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MuiFormDevicesUpdateComponent } from './mui-form-devices-update.component';

describe('MuiFormDevicesUpdateComponent', () => {
  let component: MuiFormDevicesUpdateComponent;
  let fixture: ComponentFixture<MuiFormDevicesUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MuiFormDevicesUpdateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MuiFormDevicesUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
