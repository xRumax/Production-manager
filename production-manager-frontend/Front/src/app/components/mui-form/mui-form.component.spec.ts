import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MuiFormComponent } from './mui-form.component';

describe('MuiFormComponent', () => {
  let component: MuiFormComponent;
  let fixture: ComponentFixture<MuiFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MuiFormComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(MuiFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
