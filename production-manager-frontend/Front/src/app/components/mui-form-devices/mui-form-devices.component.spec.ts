import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MuiFormDevicesComponent } from './mui-form-devices.component';

describe('MuiFormDevicesComponent', () => {
  let component: MuiFormDevicesComponent;
  let fixture: ComponentFixture<MuiFormDevicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MuiFormDevicesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MuiFormDevicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
