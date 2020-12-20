import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskHistoryCardComponent } from './task-history-card.component';

describe('TaskHistoryCardComponent', () => {
  let component: TaskHistoryCardComponent;
  let fixture: ComponentFixture<TaskHistoryCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaskHistoryCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskHistoryCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
