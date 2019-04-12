import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RedeemTokensComponent } from './redeem-tokens.component';

describe('RedeemTokensComponent', () => {
  let component: RedeemTokensComponent;
  let fixture: ComponentFixture<RedeemTokensComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RedeemTokensComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RedeemTokensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
