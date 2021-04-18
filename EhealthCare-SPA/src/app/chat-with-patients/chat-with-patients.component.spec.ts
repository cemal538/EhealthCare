/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ChatWithPatientsComponent } from './chat-with-patients.component';

describe('ChatWithPatientsComponent', () => {
  let component: ChatWithPatientsComponent;
  let fixture: ComponentFixture<ChatWithPatientsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChatWithPatientsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChatWithPatientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
